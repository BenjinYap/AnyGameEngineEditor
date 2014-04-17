using System;
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
		private bool stickySelect = false;

		private object originalValue = null;
		
		public DataTable () {
			this.Dock = DockStyle.Fill;
			this.Orientation = System.Windows.Forms.Orientation.Horizontal;
			this.TabStop = false;
			this.Panel1.Controls.Add (table);
			this.Panel2.Controls.Add (descriptionTextBox);

			table.Dock = DockStyle.Fill;
			table.ColumnCount = 2;
			table.ColumnStyles.Add (new ColumnStyle (SizeType.Absolute, 100));
			table.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
			table.CellPaint += onCellPaint;

			descriptionTextBox.Dock = DockStyle.Fill;
			descriptionTextBox.TabStop = false;
			descriptionTextBox.Enabled = false;
			descriptionTextBox.ReadOnly = true;
			descriptionTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
		}

		public void AddTextBoxRow (string name, string description, TextBox textBox, Action valueChangedAction) {
			Label label = new Label ();
			label.Text = name;
			label.Dock = DockStyle.Fill;
			label.MouseEnter += onCellMouseEnter;
			label.MouseLeave += onCellMouseLeave;
			label.BackColor = Color.Transparent;

			PrepareControl (textBox);
			SetChangeTracking (textBox, true);

			table.Controls.Add (label);
			table.Controls.Add (textBox);

			TableRow row = new TableRow ();
			row.Label = label;
			row.Description = description;
			row.Control = textBox;
			row.ValueChangedAction = valueChangedAction;
			rows.Add (row);
		}

		public void SetChangeTracking (Control control, bool enabled) {
			if (enabled) {
				if (control is TextBox) {
					TextBox textBox = (TextBox) control;
					textBox.GotFocus += onTextBoxGotFocus;
					textBox.TextChanged += onTextBoxTextChanged;
				}
			} else {
				if (control is TextBox) {
					TextBox textBox = (TextBox) control;
					textBox.GotFocus -= onTextBoxGotFocus;
					textBox.TextChanged -= onTextBoxTextChanged;
				}
			}
		}

		public void SetAllChangeTracking (bool enabled) {
			rows.ForEach (row => SetChangeTracking (row.Control, enabled));
		}

		private void onCellPaint (object obj, TableLayoutCellPaintEventArgs e) {
			if (e.Row == selectedRow) {
				e.Graphics.FillRectangle (Brushes.Yellow, e.CellBounds);
			}
		}

		private void onCellMouseEnter (object obj, EventArgs e) {
			if (stickySelect == false) {
				selectedRow = rows.FindIndex (row => row.Label == obj || row.Control == obj);
				this.Refresh ();
				ShowDescription ();
			}
		}

		private void onCellMouseLeave (object obj, EventArgs e) {
			selectedRow = -1;
		}

		private void onControlGotFocus (object obj, EventArgs e) {
			stickySelect = true;
			selectedRow = rows.FindIndex (row => row.Control == obj);
			this.Refresh ();
			ShowDescription ();
		}

		private void onControlLostFocus (object obj, EventArgs e) {
			stickySelect = false;
		}

		private void onTextBoxGotFocus (object obj, EventArgs e) {
			originalValue = ((TextBox) obj).Text;
		}

		private void onTextBoxTextChanged (object obj, EventArgs e) {
			TableRow row = rows.Find (a => obj == a.Control);
			string undoValue = (string) originalValue;
			
			MainForm.Instance.PushUndo (() => {
				TextBox textBox = (TextBox) obj;
				SetChangeTracking (textBox, false);
				textBox.Text = undoValue;
				row.ValueChangedAction ();
				SetChangeTracking (textBox, true);
				textBox.Focus ();
				textBox.SelectionStart = undoValue.Length;
			});
			
			row.ValueChangedAction ();
			MainForm.Instance.RefreshSections ();
			originalValue = ((TextBox) obj).Text;
		}

		private void PrepareControl (Control control) {
			control.Dock = DockStyle.Fill;
			Padding margin = control.Margin;
			margin.Right += 19;
			control.Margin = margin;
			control.MouseEnter += onCellMouseEnter;
			control.MouseLeave += onCellMouseLeave;
			control.GotFocus += onControlGotFocus;
			control.LostFocus += onControlLostFocus;
			MainForm.Error.SetIconPadding (control, 3);
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
		public Action ValueChangedAction;
	}
}
