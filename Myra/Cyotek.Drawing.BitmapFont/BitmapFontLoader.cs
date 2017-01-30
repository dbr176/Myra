﻿/* AngelCode bitmap font parsing using C#
 * http://www.cyotek.com/blog/angelcode-bitmap-font-parsing-using-csharp
 *
 * Copyright © 2012-2015 Cyotek Ltd.
 *
 * Licensed under the MIT License. See license.txt for the full text.
 */

using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;

namespace Cyotek.Drawing.BitmapFont
{
	/// <summary>
	/// Parsing class for bitmap fonts generated by AngelCode BMFont
	/// </summary>
	internal static class BitmapFontLoader
	{
		#region Static Methods

		/// <summary>
		/// Returns a boolean from an array of name/value pairs.
		/// </summary>
		/// <param name="parts">The array of parts.</param>
		/// <param name="name">The name of the value to return.</param>
		/// <param name="defaultValue">Default value(if the key doesnt exist or can't be parsed)</param>
		/// <returns></returns>
		internal static bool GetNamedBool(string[] parts, string name, bool defaultValue = false)
		{
			var s = GetNamedString(parts, name);

			bool result;
			int v;
			if (int.TryParse(s, out v))
			{
				result = v > 0;
			}
			else
			{
				result = defaultValue;
			}

			return result;
		}

		/// <summary>
		/// Returns an integer from an array of name/value pairs.
		/// </summary>
		/// <param name="parts">The array of parts.</param>
		/// <param name="name">The name of the value to return.</param>
		/// <param name="defaultValue">Default value(if the key doesnt exist or can't be parsed)</param>
		/// <returns></returns>
		internal static int GetNamedInt(string[] parts, string name, int defaultValue = 0)
		{
			var s = GetNamedString(parts, name);

			int result;
			if (!int.TryParse(s, out result))
			{
				result = defaultValue;
			}

			return result;
		}

		/// <summary>
		/// Returns a string from an array of name/value pairs.
		/// </summary>
		/// <param name="parts">The array of parts.</param>
		/// <param name="name">The name of the value to return.</param>
		/// <returns></returns>
		internal static string GetNamedString(string[] parts, string name)
		{
			string result;

			result = string.Empty;

			foreach (string part in parts)
			{
				int nameEndIndex;

				nameEndIndex = part.IndexOf('=');
				if (nameEndIndex != -1)
				{
					string namePart;
					string valuePart;

					namePart = part.Substring(0, nameEndIndex);
					valuePart = part.Substring(nameEndIndex + 1);

					if (string.Equals(name, namePart, StringComparison.OrdinalIgnoreCase))
					{
						int length;

						length = valuePart.Length;

						if (length > 1 && valuePart[0] == '"' && valuePart[length - 1] == '"')
						{
							valuePart = valuePart.Substring(1, length - 2);
						}

						result = valuePart;
						break;
					}
				}
			}

			return result;
		}

		/// <summary>
		/// Creates a Padding object from a string representation
		/// </summary>
		/// <param name="s">The string.</param>
		/// <returns></returns>
		internal static Padding ParsePadding(string s)
		{
			string[] parts;

			parts = s.Split(',');

			return new Padding()
			{
				Left = Convert.ToInt32(parts[3].Trim()),
				Top = Convert.ToInt32(parts[0].Trim()),
				Right = Convert.ToInt32(parts[1].Trim()),
				Bottom = Convert.ToInt32(parts[2].Trim())
			};
		}

		/// <summary>
		/// Creates a Point object from a string representation
		/// </summary>
		/// <param name="s">The string.</param>
		/// <returns></returns>
		internal static Point ParsePoint(string s)
		{
			string[] parts;

			parts = s.Split(',');

			return new Point()
			{
				X = Convert.ToInt32(parts[0].Trim()),
				Y = Convert.ToInt32(parts[1].Trim())
			};
		}

		/// <summary>
		/// Updates <see cref="Page"/> data with a fully qualified path
		/// </summary>
		/// <param name="font">The <see cref="BitmapFont"/> to update.</param>
		/// <param name="resourcePath">The path where texture resources are located.</param>
		internal static void QualifyResourcePaths(BitmapFont font, string resourcePath)
		{
			Page[] pages;

			pages = font.Pages;

			for (int i = 0; i < pages.Length; i++)
			{
				Page page;

				page = pages[i];
				page.FileName = Path.Combine(resourcePath, page.FileName);
				pages[i] = page;
			}

			font.Pages = pages;
		}

		/// <summary>
		/// Splits the specified string using a given delimiter, ignoring any instances of the delimiter as part of a quoted string.
		/// </summary>
		/// <param name="s">The string to split.</param>
		/// <param name="delimiter">The delimiter.</param>
		/// <returns></returns>
		internal static string[] Split(string s, char delimiter)
		{
			string[] results;

			if (s.IndexOf('"') != -1)
			{
				List<string> parts;
				int partStart;

				partStart = -1;
				parts = new List<string>();

				do
				{
					int partEnd;
					int quoteStart;
					int quoteEnd;
					bool hasQuotes;

					quoteStart = s.IndexOf('"', partStart + 1);
					quoteEnd = s.IndexOf('"', quoteStart + 1);
					partEnd = s.IndexOf(delimiter, partStart + 1);

					if (partEnd == -1)
					{
						partEnd = s.Length;
					}

					hasQuotes = quoteStart != -1 && partEnd > quoteStart && partEnd < quoteEnd;
					if (hasQuotes)
					{
						partEnd = s.IndexOf(delimiter, quoteEnd + 1);
					}

					parts.Add(s.Substring(partStart + 1, partEnd - partStart - 1));

					if (hasQuotes)
					{
						partStart = partEnd - 1;
					}

					partStart = s.IndexOf(delimiter, partStart + 1);
				} while (partStart != -1);

				results = parts.ToArray();
			}
			else
			{
				results = s.Split(new char[]
				{
					delimiter
				}, StringSplitOptions.RemoveEmptyEntries);
			}

			return results;
		}

		/// <summary>
		/// Converts the given collection into an array
		/// </summary>
		/// <typeparam name="T">Type of the items in the array</typeparam>
		/// <param name="values">The values.</param>
		/// <returns></returns>
		internal static T[] ToArray<T>(ICollection<T> values)
		{
			T[] result;

			// avoid a forced .NET 3 dependency just for one call to Linq

			result = new T[values.Count];
			values.CopyTo(result, 0);

			return result;
		}

		#endregion
	}
}