using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Diagnostics;

namespace AnyGameEngineEditor {
	public class PropertyGrid:SplitContainer {
		private Dictionary <string, Action> keys = new Dictionary<string,Action> ();
		private DataGridView grid = new DataGridView ();
		private Label description = new Label ();

		public PropertyGrid () {
			this.Orientation = System.Windows.Forms.Orientation.Horizontal;

			grid.Dock = DockStyle.Fill;
			grid.RowHeadersVisible = false;
			grid.ColumnCount = 2;
			grid.Columns [0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			grid.Columns [1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			grid.Columns [0].HeaderText = "Property";
			grid.Columns [1].HeaderText = "Value";
			grid.ReadOnly = true;
			grid.AllowUserToAddRows = false;
			grid.AllowUserToDeleteRows = false;
			grid.CellDoubleClick += onCellDoubleClick;
			grid.CurrentCellChanged += onCurrentCellChanged;
			this.Panel1.Controls.Add (grid);

			description.Dock = DockStyle.Fill;
			this.Panel2.Controls.Add (description);
		}

		public void AddRow (string name, string description, Action editCallback) {
			grid.Rows.Add (new object [] {name, ""});
			grid.Rows [grid.Rows.Count - 1].Cells [0].ToolTipText = description;
			grid.Rows [grid.Rows.Count - 1].Cells [0].Style.WrapMode = DataGridViewTriState.True;
			grid.Rows [grid.Rows.Count - 1].Cells [1].ToolTipText = description;
			grid.Rows [grid.Rows.Count - 1].Cells [1].Style.WrapMode = DataGridViewTriState.True;
			keys.Add (name, editCallback);
		}

		public void SetValue (string name, string value) {
			GetRow (name).Cells [1].Value = value;
		}

		private void onCellDoubleClick (object obj, DataGridViewCellEventArgs e) {
			if (e.RowIndex < 0) {
				return;
			}
			
			foreach (KeyValuePair <string, Action> pair in keys) {
				if ((string) grid.Rows [e.RowIndex].Cells [0].Value == pair.Key) {
					pair.Value ();
				}
			}
		}

		private void onCurrentCellChanged (object obj, EventArgs e) {
			description.Text = grid.CurrentCell.ToolTipText;
		}

		private DataGridViewRow GetRow (string name) {
			for (int i = 0; i < grid.Rows.Count; i++) {
				if ((string) grid.Rows [i].Cells [0].Value == name) {
					return grid.Rows [i];
				}
			}

			return null;
		}
	}
}
