﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace AnyGameEngineEditor {
	public class DataTable:SplitContainer {
		private TableLayoutPanel table = new TableLayoutPanel ();
		private RichTextBox descriptionTextBox = new RichTextBox ();
		private List <TableRow> rows = new List<TableRow> ();
		private int selectedRow = -1;

		public DataTable () {
			this.Dock = DockStyle.Fill;
			this.Orientation = System.Windows.Forms.Orientation.Horizontal;
			this.Panel1.Controls.Add (table);
			this.Panel2.Controls.Add (descriptionTextBox);

			table.Dock = DockStyle.Fill;
			table.ColumnCount = 2;
			table.ColumnStyles.Add (new ColumnStyle (SizeType.Absolute, 100));
			table.CellBorderStyle = TableLayoutPanelCellBorderStyle.InsetDouble;
			table.CellPaint += onCellPaint;

			descriptionTextBox.Dock = DockStyle.Fill;
			descriptionTextBox.Enabled = false;
			descriptionTextBox.ReadOnly = true;
			descriptionTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		}

		public void AddRow (string name, string description, Control control) {
			Label label = new Label ();
			label.Text = name;
			label.Dock = DockStyle.Fill;
			label.MouseEnter += onCellMouseEnter;
			label.MouseLeave += onCellMouseLeave;
			label.BackColor = Color.Transparent;

			control.Dock = DockStyle.Fill;
			control.MouseEnter += onCellMouseEnter;
			control.MouseLeave += onCellMouseLeave;

			table.Controls.Add (label);
			table.Controls.Add (control);

			TableRow row = new TableRow ();
			row.Label = label;
			row.Description = description;
			row.Control = control;
			rows.Add (row);
		}

		private void onCellPaint (object obj, TableLayoutCellPaintEventArgs e) {
			if (e.Row == selectedRow) {
				e.Graphics.FillRectangle (Brushes.Red, e.CellBounds);
			}
		}

		private void onCellMouseEnter (object obj, EventArgs e) {
			selectedRow = rows.FindIndex (row => row.Label == obj || row.Control == obj);
			this.Refresh ();
			ShowDescription ();
		}

		private void onCellMouseLeave (object obj, EventArgs e) {
			selectedRow = -1;
		}

		private void ShowDescription () {
			descriptionTextBox.Text = "";
			Font font = descriptionTextBox.SelectionFont;
			descriptionTextBox.SelectionFont = new Font (font.FontFamily, font.Size, FontStyle.Bold);
			descriptionTextBox.AppendText (rows [selectedRow].Label.Text+ "\n");
			descriptionTextBox.SelectionFont = new Font (font.FontFamily, font.Size, FontStyle.Regular);
			descriptionTextBox.AppendText (rows [selectedRow].Description);
		}
	}

	public struct TableRow {
		public Label Label;
		public Control Control;
		public string Description;
	}
}
