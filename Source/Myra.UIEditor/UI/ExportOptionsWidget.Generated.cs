/* Generated by Myra UI Editor at 12/16/2017 7:59:02 PM */
using Microsoft.Xna.Framework;
using Myra.Graphics2D.UI;

namespace Myra.UIEditor.UI
{
	partial class ExportOptionsWidget
	{
		private void BuildUI()
		{
			var textBlock1 = new TextBlock();
			textBlock1.Text = "Class Name:";
			textBlock1.TextColor = Color.White;
			textBlock1.DisabledTextColor = new Color
			{
				B = 170,
				G = 170,
				R = 170,
				A = 255,
				PackedValue = 4289374890,
			};
			textBlock1.Id = "";
			textBlock1.GridPositionY = 1;

			_textClassName = new TextField();
			_textClassName.Text = "";
			_textClassName.TextColor = Color.White;
			_textClassName.DisabledTextColor = new Color
			{
				B = 170,
				G = 170,
				R = 170,
				A = 255,
				PackedValue = 4289374890,
			};
			_textClassName.MessageTextColor = new Color
			{
				B = 170,
				G = 170,
				R = 170,
				A = 255,
				PackedValue = 4289374890,
			};
			_textClassName.Id = "_textClassName";
			_textClassName.HorizontalAlignment = Myra.Graphics2D.UI.HorizontalAlignment.Stretch;
			_textClassName.GridPositionX = 1;
			_textClassName.GridPositionY = 1;
			_textClassName.CanFocus = true;

			var textBlock2 = new TextBlock();
			textBlock2.Text = "Output Path:";
			textBlock2.TextColor = Color.White;
			textBlock2.DisabledTextColor = new Color
			{
				B = 170,
				G = 170,
				R = 170,
				A = 255,
				PackedValue = 4289374890,
			};
			textBlock2.GridPositionY = 2;

			_textOutputPath = new TextField();
			_textOutputPath.Text = "";
			_textOutputPath.TextColor = Color.White;
			_textOutputPath.DisabledTextColor = new Color
			{
				B = 170,
				G = 170,
				R = 170,
				A = 255,
				PackedValue = 4289374890,
			};
			_textOutputPath.MessageTextColor = new Color
			{
				B = 170,
				G = 170,
				R = 170,
				A = 255,
				PackedValue = 4289374890,
			};
			_textOutputPath.Id = "_textOutputPath";
			_textOutputPath.HorizontalAlignment = Myra.Graphics2D.UI.HorizontalAlignment.Stretch;
			_textOutputPath.GridPositionX = 1;
			_textOutputPath.GridPositionY = 2;
			_textOutputPath.CanFocus = true;

			_buttonChangeOutputPath = new Button();
			_buttonChangeOutputPath.Text = "Change...";
			_buttonChangeOutputPath.TextColor = Color.White;
			_buttonChangeOutputPath.ContentHorizontalAlignment = Myra.Graphics2D.UI.HorizontalAlignment.Stretch;
			_buttonChangeOutputPath.ContentVerticalAlignment = Myra.Graphics2D.UI.VerticalAlignment.Stretch;
			_buttonChangeOutputPath.Id = "_buttonChangeOutputPath";
			_buttonChangeOutputPath.GridPositionX = 2;
			_buttonChangeOutputPath.GridPositionY = 2;

			var textBlock3 = new TextBlock();
			textBlock3.Text = "Namespace:";
			textBlock3.TextColor = Color.White;
			textBlock3.DisabledTextColor = new Color
			{
				B = 170,
				G = 170,
				R = 170,
				A = 255,
				PackedValue = 4289374890,
			};

			_textNamespace = new TextField();
			_textNamespace.Text = "";
			_textNamespace.TextColor = Color.White;
			_textNamespace.DisabledTextColor = new Color
			{
				B = 170,
				G = 170,
				R = 170,
				A = 255,
				PackedValue = 4289374890,
			};
			_textNamespace.MessageTextColor = new Color
			{
				B = 170,
				G = 170,
				R = 170,
				A = 255,
				PackedValue = 4289374890,
			};
			_textNamespace.Id = "_textNamespace";
			_textNamespace.HorizontalAlignment = Myra.Graphics2D.UI.HorizontalAlignment.Stretch;
			_textNamespace.GridPositionX = 1;
			_textNamespace.CanFocus = true;

			
			DrawLinesColor = Color.White;
			ColumnSpacing = 8;
			RowSpacing = 8;
			ColumnsProportions.Add(new Proportion());
			ColumnsProportions.Add(new Proportion
			{
				Type = Myra.Graphics2D.UI.Grid.ProportionType.Fill,
			});
			ColumnsProportions.Add(new Proportion());
			RowsProportions.Add(new Proportion());
			RowsProportions.Add(new Proportion());
			RowsProportions.Add(new Proportion());
			Id = "Root";
			WidthHint = 800;
			HorizontalAlignment = Myra.Graphics2D.UI.HorizontalAlignment.Stretch;
			VerticalAlignment = Myra.Graphics2D.UI.VerticalAlignment.Stretch;
			Widgets.Add(textBlock1);
			Widgets.Add(_textClassName);
			Widgets.Add(textBlock2);
			Widgets.Add(_textOutputPath);
			Widgets.Add(_buttonChangeOutputPath);
			Widgets.Add(textBlock3);
			Widgets.Add(_textNamespace);
		}

		
		public TextField _textClassName;
		public TextField _textOutputPath;
		public Button _buttonChangeOutputPath;
		public TextField _textNamespace;
	}
}