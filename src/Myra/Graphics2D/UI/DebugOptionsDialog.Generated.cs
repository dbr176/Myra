/* Generated by MyraPad at 26.07.2019 21:13:36 */
using Microsoft.Xna.Framework;
using Myra.Graphics2D.UI;

namespace Myra.Graphics2D.UI
{
	partial class DebugOptionsDialog
	{
		private void BuildUI()
		{
			_checkBoxWidgetFrames = new CheckBox();
			_checkBoxWidgetFrames.Text = "Draw green frame around every widget";
			_checkBoxWidgetFrames.Id = "_checkBoxWidgetFrames";

			_checkBoxKeyboardFocusedWidgetFrame = new CheckBox();
			_checkBoxKeyboardFocusedWidgetFrame.Text = "Draw red frame around the keyboard focused widget";
			_checkBoxKeyboardFocusedWidgetFrame.Id = "_checkBoxKeyboardFocusedWidgetFrame";
			_checkBoxKeyboardFocusedWidgetFrame.GridRow = 1;

			_checkBoxMouseWheelFocusedWidgetFrame = new CheckBox();
			_checkBoxMouseWheelFocusedWidgetFrame.Text = "Draw yellow frame around the mouse wheel focused widget";
			_checkBoxMouseWheelFocusedWidgetFrame.Id = "_checkBoxMouseWheelFocusedWidgetFrame";
			_checkBoxMouseWheelFocusedWidgetFrame.GridRow = 2;

			_checkBoxGlyphFrames = new CheckBox();
			_checkBoxGlyphFrames.Text = "Draw white frame around every letter glyph";
			_checkBoxGlyphFrames.Id = "_checkBoxGlyphFrames";
			_checkBoxGlyphFrames.GridRow = 3;

			_checkBoxDisableClipping = new CheckBox();
			_checkBoxDisableClipping.Text = "Disable clipping";
			_checkBoxDisableClipping.Id = "_checkBoxDisableClipping";
			_checkBoxDisableClipping.GridRow = 4;

			Root = new Grid();
			Root.RowsProportions.Add(new Grid.Proportion());
			Root.RowsProportions.Add(new Grid.Proportion());
			Root.RowsProportions.Add(new Grid.Proportion());
			Root.RowsProportions.Add(new Grid.Proportion());
			Root.RowsProportions.Add(new Grid.Proportion());
			Root.Id = "Root";
			Root.GridRow = 1;
			Root.Widgets.Add(_checkBoxWidgetFrames);
			Root.Widgets.Add(_checkBoxKeyboardFocusedWidgetFrame);
			Root.Widgets.Add(_checkBoxMouseWheelFocusedWidgetFrame);
			Root.Widgets.Add(_checkBoxGlyphFrames);
			Root.Widgets.Add(_checkBoxDisableClipping);

			
			Title = "Debug Options";
			Left = 260;
			Top = 100;
			Content = Root;
		}

		
		public CheckBox _checkBoxWidgetFrames;
		public CheckBox _checkBoxKeyboardFocusedWidgetFrame;
		public CheckBox _checkBoxMouseWheelFocusedWidgetFrame;
		public CheckBox _checkBoxGlyphFrames;
		public CheckBox _checkBoxDisableClipping;
		public Grid Root;
	}
}