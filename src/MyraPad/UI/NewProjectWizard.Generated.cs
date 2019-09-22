/* Generated by MyraPad at 30.07.2019 10:18:14 */
using Myra.Graphics2D.UI;

#if !XENKO
using Microsoft.Xna.Framework;
#else
using Xenko.Core.Mathematics;
#endif

namespace MyraPad.UI
{
	partial class NewProjectWizard
	{
		private void BuildUI()
		{
			_radioButtonGrid = new RadioButton();
			_radioButtonGrid.Text = "Grid";
			_radioButtonGrid.Id = "_radioButtonGrid";

			_radioButtonPanel = new RadioButton();
			_radioButtonPanel.Text = "Panel";
			_radioButtonPanel.Id = "_radioButtonPanel";
			_radioButtonPanel.GridRow = 1;

			_radioButtonScrollPane = new RadioButton();
			_radioButtonScrollPane.Text = "ScrollPane";
			_radioButtonScrollPane.Id = "_radioButtonScrollPane";
			_radioButtonScrollPane.GridRow = 2;

			_radioButtonHorizontalSplitPane = new RadioButton();
			_radioButtonHorizontalSplitPane.Text = "HorizontalSplitPane";
			_radioButtonHorizontalSplitPane.Id = "_radioButtonHorizontalSplitPane";
			_radioButtonHorizontalSplitPane.GridRow = 3;

			_radioButtonVerticalSplitPane = new RadioButton();
			_radioButtonVerticalSplitPane.Text = "VerticalSplitPane";
			_radioButtonVerticalSplitPane.Id = "_radioButtonVerticalSplitPane";
			_radioButtonVerticalSplitPane.GridRow = 4;

			_radioButtonWindow = new RadioButton();
			_radioButtonWindow.Text = "Window";
			_radioButtonWindow.Id = "_radioButtonWindow";
			_radioButtonWindow.GridRow = 5;

			_radioButtonDialog = new RadioButton();
			_radioButtonDialog.Text = "Dialog";
			_radioButtonDialog.Id = "_radioButtonDialog";
			_radioButtonDialog.GridRow = 6;

			var grid1 = new Grid();
			grid1.RowsProportions.Add(new Proportion());
			grid1.RowsProportions.Add(new Proportion());
			grid1.RowsProportions.Add(new Proportion());
			grid1.RowsProportions.Add(new Proportion());
			grid1.RowsProportions.Add(new Proportion());
			grid1.RowsProportions.Add(new Proportion());
			grid1.RowsProportions.Add(new Proportion());
			grid1.GridRow = 1;
			grid1.Widgets.Add(_radioButtonGrid);
			grid1.Widgets.Add(_radioButtonPanel);
			grid1.Widgets.Add(_radioButtonScrollPane);
			grid1.Widgets.Add(_radioButtonHorizontalSplitPane);
			grid1.Widgets.Add(_radioButtonVerticalSplitPane);
			grid1.Widgets.Add(_radioButtonWindow);
			grid1.Widgets.Add(_radioButtonDialog);

			
			Title = "Choose Root Container";
			Left = 381;
			Top = 78;
			Content = grid1;
		}

		
		public RadioButton _radioButtonGrid;
		public RadioButton _radioButtonPanel;
		public RadioButton _radioButtonScrollPane;
		public RadioButton _radioButtonHorizontalSplitPane;
		public RadioButton _radioButtonVerticalSplitPane;
		public RadioButton _radioButtonWindow;
		public RadioButton _radioButtonDialog;
	}
}