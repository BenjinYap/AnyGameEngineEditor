using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;

namespace AnyGameEngineEditor {
	public class PropertyGrid:DataGridView {
		private List <Row> rows = new List<Row> ();

		public PropertyGrid () {
			this.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.Dock = DockStyle.Fill;
			this.RowHeadersVisible = false;
			this.ColumnCount = 2;
			this.Columns [0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.Columns [1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.Columns [0].HeaderText = "Property";
			this.Columns [1].HeaderText = "Value";
			this.ReadOnly = true;
			this.AllowUserToAddRows = false;
			this.AllowUserToDeleteRows = false;
			this.CellDoubleClick += onCellDoubleClick;
			this.KeyDown += onKeyDown;
			this.Disposed += onDisposed;
			this.CurrentCellChanged += onCurrentCellChanged;
		}

		public void AddRow (string name, string description, Action editCallback) {
			this.Rows.Add (new object [] {name + " - " + description, ""});
			rows.Add (new Row (name, description, this.Rows [this.Rows.Count - 1], editCallback));
			//this.Rows [this.Rows.Count - 1].Cells [0].ToolTipText = name + " - " + description;
			//this.Rows [this.Rows.Count - 1].Cells [0].Style.WrapMode = DataGridViewTriState.True;
			//this.Rows [this.Rows.Count - 1].Cells [1].ToolTipText = description;
			//this.Rows [this.Rows.Count - 1].Cells [1].Style.WrapMode = DataGridViewTriState.True;
		}

		public void ClearRows () {
			rows.Clear ();
			this.Rows.Clear ();
		}

		public void SetValue (string name, string value) {
			rows.Find (r => r.Name == name).RowReference.Cells [1].Value = value;
			//rows.Find (r => r.Name == name).RowReference.Cells [1].ToolTipText = value;
		}

		private void onDisposed (object obj, EventArgs e) {
			this.Disposed -= onDisposed;
			this.CellDoubleClick -= onCellDoubleClick;
			this.KeyDown -= onKeyDown;
			this.CurrentCellChanged -= onCurrentCellChanged;
		}

		private void onCurrentCellChanged (object obj, EventArgs e) {
			//using (Graphics g = CreateGraphics ()) {
			//	Debug.WriteLine (this.CurrentCell.Value);
			//	SizeF size = g.MeasureString (this.CurrentCell.Value as string, this.Font, this.Columns [0].Width - this.DefaultCellStyle.Padding.All * 2);
			//	this.CurrentRow.MinimumHeight = (int) size.Height + this.DefaultCellStyle.Padding.All * 20;
			//}
		}

		private void onCellDoubleClick (object obj, DataGridViewCellEventArgs e) {
			if (e.RowIndex < 0) {
				return;
			}
			
			rows.Find (r => r.RowReference == this.CurrentCell.OwningRow).EditCallback ();
		}

		private void onKeyDown (object obj, KeyEventArgs e) {
			if (e.KeyCode == Keys.Enter) {
				rows.Find (r => r.RowReference == this.CurrentCell.OwningRow).EditCallback ();
				this.Focus ();
				e.Handled = true;
			}
		}

		//private DataGridViewRow GetRow (string name) {
		//	for (int i = 0; i < this.Rows.Count; i++) {
		//		if ((string) this.Rows [i].Cells [0].Value == name) {
		//			return this.Rows [i];
		//		}
		//	}

		//	return null;
		//}

		public class Row {
			public string Name;
			public string Description;
			public DataGridViewRow RowReference;
			public Action EditCallback;

			public Row (string name, string description, DataGridViewRow row, Action editCallback) {
				Name = name;
				Description = description;
				RowReference = row;
				EditCallback = editCallback;
			}
		}
	}
}
