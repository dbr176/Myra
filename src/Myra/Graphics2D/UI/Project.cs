﻿using System.Collections;
using System.Reflection;
using System.ComponentModel;
using Myra.Graphics2D.UI.Styles;
using Myra.Utility;
using System.Xml.Linq;
using System.Xml.Serialization;
using System;
using Myra.MML;
using System.Collections.Generic;
using Myra.Attributes;

#if !XENKO
using Microsoft.Xna.Framework;
#else
using Xenko.Core.Mathematics;
#endif

namespace Myra.Graphics2D.UI
{
	public class ExportOptions
	{
		public string Namespace { get; set; }
		public string Class { get; set; }
		public string OutputPath { get; set; }
	}

	public class Project
	{
		public const string ProportionName = "Proportion";
		public const string DefaultProportionName = "DefaultProportion";
		public const string DefaultColumnProportionName = "DefaultColumnProportion";
		public const string DefaultRowProportionName = "DefaultRowProportion";

		private static readonly Dictionary<string, string> LegacyClassNames = new Dictionary<string, string>();

		private readonly ExportOptions _exportOptions = new ExportOptions();

		[Browsable(false)]
		public ExportOptions ExportOptions
		{
			get { return _exportOptions; }
		}

		[Browsable(false)]
		[Content]
		public Control Root { get; set; }

		[Browsable(false)]
		public string StylesheetPath
		{
			get; set;
		}

		[Browsable(false)]
		[XmlIgnore]
		public Stylesheet Stylesheet { get; set; }

		static Project()
		{
			LegacyClassNames["Button"] = "ImageTextButton";
			LegacyClassNames["VerticalBox"] = "VerticalStackPanel";
			LegacyClassNames["HorizontalBox"] = "HorizontalStackPanel";
			LegacyClassNames["TextField"] = "TextBox";
			LegacyClassNames["TextBlock"] = "Label";
			LegacyClassNames["ScrollPane"] = "ScrollViewer";
		}

		public Project()
		{
			Stylesheet = Stylesheet.Current;
		}

		public static bool IsProportionName(string s)
		{
			return s.EndsWith(ProportionName) ||
				s.EndsWith(DefaultProportionName) ||
				s.EndsWith(DefaultColumnProportionName) ||
				s.EndsWith(DefaultRowProportionName);
		}

		public static bool ShouldSerializeProperty(Stylesheet stylesheet, object o, PropertyInfo p)
		{
			var asWidget = o as Control;
			if (asWidget != null && asWidget.Parent != null && asWidget.Parent is Grid)
			{
				var container = asWidget.Parent.Parent;
				if (container != null &&
				   (container is Box || container is SplitPane) &&
				   (p.Name == "GridRow" || p.Name == "GridColumn"))
				{
					// Skip serializing auto-assigned GridRow/GridColumn for SplitPane and Box containers
					return false;
				}
			}

			var asGrid = o as Grid;
			if (asGrid != null)
			{
				var value = p.GetValue(o);
				if ((p.Name == DefaultColumnProportionName || p.Name == DefaultRowProportionName) &&
					value == Proportion.GridDefault)
				{
					return false;
				}
			}

			var asBox = o as Box;
			if (asBox != null)
			{
				var value = p.GetValue(o);
				if (p.Name == DefaultProportionName && value == Proportion.BoxDefault)
				{
					return false;
				}
			}

			if (SaveContext.HasDefaultValue(o, p))
			{
				return false;
			}

			if(asWidget != null && HasStylesheetValue(asWidget, p, stylesheet))
			{
				return false;
			}

			return true;
		}

		public bool ShouldSerializeProperty(object o, PropertyInfo p)
		{
			return ShouldSerializeProperty(Stylesheet, o, p);
		}

		internal static SaveContext CreateSaveContext(Stylesheet stylesheet)
		{
			return new SaveContext
			{
				ShouldSerializeProperty = (o, p) => ShouldSerializeProperty(stylesheet, o, p)
			};
		}

		internal SaveContext CreateSaveContext()
		{
			return CreateSaveContext(Stylesheet);
		}

		internal static LoadContext CreateLoadContext(Stylesheet stylesheet)
		{
			return new LoadContext
			{
				LegacyClassNames = LegacyClassNames,
				ObjectCreator = t => CreateItem(t, stylesheet),
				Namespace = typeof(Control).Namespace
			};
		}

		internal LoadContext CreateLoadContext()
		{
			return CreateLoadContext(Stylesheet);
		}

		public string Save()
		{
			var saveContext = CreateSaveContext();
			var root = saveContext.Save(this);

			var xDoc = new XDocument(root);

			return xDoc.ToString();
		}

		public static Project LoadFromXml(XDocument xDoc, Stylesheet stylesheet)
		{
			var result = new Project
			{
				Stylesheet = stylesheet
			};

			var loadContext = result.CreateLoadContext();
			loadContext.Load(result, xDoc.Root);

			return result;
		}

		public static Project LoadFromXml(string data, Stylesheet stylesheet)
		{
			return LoadFromXml(XDocument.Parse(data), stylesheet);
		}

		public static Project LoadFromXml(string data)
		{
			return LoadFromXml(data, Stylesheet.Current);
		}

		public static object LoadObjectFromXml(string data, Stylesheet stylesheet)
		{
			XDocument xDoc = XDocument.Parse(data);

			Type itemType;
			if (!IsProportionName(xDoc.Root.Name.ToString()))
			{
				var itemNamespace = typeof(Control).Namespace;

				var widgetName = xDoc.Root.Name.ToString();
				string newName;
				if (LegacyClassNames.TryGetValue(widgetName, out newName))
				{
					widgetName = newName;
				}

				itemType = typeof(Control).Assembly.GetType(itemNamespace + "." + widgetName);
			}
			else
			{
				itemType = typeof(Proportion);
			}

			if (itemType == null)
			{
				return null;
			}

			var item = CreateItem(itemType, stylesheet);
			var loadContext = CreateLoadContext(stylesheet);
			loadContext.Load(item, xDoc.Root);

			return item;
		}

		public static object LoadObjectFromXml(string data)
		{
			return LoadObjectFromXml(data, Stylesheet.Current);
		}

		public string SaveObjectToXml(object obj, string tagName)
		{
			var saveContext = CreateSaveContext(Stylesheet);
			return saveContext.Save(obj, true, tagName).ToString();
		}

		private static object CreateItem(Type type, Stylesheet stylesheet)
		{
			// Check whether item has constructor with stylesheet param
			var acceptsStylesheet = false;
			foreach (var c in type.GetConstructors())
			{
				var p = c.GetParameters();
				if (p != null && p.Length == 1)
				{
					if (p[0].ParameterType == typeof(Stylesheet))
					{
						acceptsStylesheet = true;
						break;
					}
				}
			}

			if (acceptsStylesheet)
			{
				return Activator.CreateInstance(type, stylesheet);
			}

			return Activator.CreateInstance(type);
		}

		private static bool HasStylesheetValue(Control w, PropertyInfo property, Stylesheet stylesheet)
		{
			if (stylesheet == null)
			{
				return false;
			}

			var styleName = w.StyleName;
			if (string.IsNullOrEmpty(styleName))
			{
				styleName = Stylesheet.DefaultStyleName;
			}

			// Find styles dict of that widget
			var typeName = w.GetType().Name;
			if (typeName == "ImageTextButton" || typeName == "ImageButton" || typeName == "TextButton")
			{
				// Small hack
				// ImageTextButton styles are stored in Stylesheet.ButtonStyles
				typeName = "Button";
			}

			var stylesDictPropertyName = typeName + "Styles";
			var stylesDictProperty = stylesheet.GetType().GetRuntimeProperty(stylesDictPropertyName);
			if (stylesDictProperty == null)
			{
				return false;
			}

			var stylesDict = (IDictionary)stylesDictProperty.GetValue(stylesheet);
			if (stylesDict == null)
			{
				return false;
			}

			// Fetch style from the dict
			object obj = stylesDict[styleName];

			// Now find corresponding property
			PropertyInfo styleProperty = null;

			var stylePropertyPathAttribute = property.FindAttribute<StylePropertyPathAttribute>();
			if (stylePropertyPathAttribute != null)
			{
				var path = stylePropertyPathAttribute.Name;
				if (path.StartsWith("/"))
				{
					obj = stylesheet;
					path = path.Substring(1);
				}

				var parts = path.Split('/');
				for (var i = 0; i < parts.Length; ++i)
				{
					styleProperty = obj.GetType().GetRuntimeProperty(parts[i]);

					if (i < parts.Length - 1)
					{
						obj = styleProperty.GetValue(obj);
					}
				}
			}
			else
			{
				styleProperty = obj.GetType().GetRuntimeProperty(property.Name);
			}

			if (styleProperty == null)
			{
				return false;
			}

			// Compare values
			var styleValue = styleProperty.GetValue(obj);
			var value = property.GetValue(w);
			if (!Equals(styleValue, value))
			{
				return false;
			}

			return true;
		}
	}
}