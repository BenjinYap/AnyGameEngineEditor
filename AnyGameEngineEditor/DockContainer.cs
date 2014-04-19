using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;


namespace AnyGameEngineEditor {
	public sealed class DockContainer:Panel {
		private TableLayoutPanel flapTable = new TableLayoutPanel ();
		private Panel [] flaps;
		private Panel leftFlap = new Panel ();
		private Panel rightFlap = new Panel ();
		private Panel topFlap = new Panel ();
		private Panel bottomFlap = new Panel ();
		private Panel centerFlap = new Panel ();

		private SplitContainer split = new SplitContainer ();
		private TabControl tabs = new TabControl ();

		public DockContainer () {
			this.Dock = DockStyle.Fill;
			
			flapTable.Width = 150;
			flapTable.Height = 150;
			flapTable.ColumnCount = 3;
			flapTable.RowCount = 3;
			this.Controls.Add (flapTable);

			for (int i = 0; i < 3; i++) {
				flapTable.RowStyles.Add (new RowStyle (SizeType.Percent, 33));
				flapTable.ColumnStyles.Add (new ColumnStyle (SizeType.Percent, 33));
			}

			flaps = new Panel [] {leftFlap, rightFlap, topFlap, bottomFlap, centerFlap};
			
			foreach (Panel flap in flaps) {
				flap.BackColor = Color.FromArgb (128, Color.Red);
			}

			flapTable.Controls.Add (topFlap, 1, 0);
			flapTable.Controls.Add (bottomFlap, 1, 2);
			flapTable.Controls.Add (leftFlap, 0, 1);
			flapTable.Controls.Add (rightFlap, 2, 1);
			flapTable.Controls.Add (centerFlap, 1, 1);

			flapTable.Hide ();

			split.Dock = DockStyle.Fill;
			split.BackColor = Color.Yellow;
			split.Panel2Collapsed = true;
			this.Controls.Add (split);

			tabs.Dock = DockStyle.Fill;
			split.Panel1.Controls.Add (tabs);
		}
		
		

		public void CheckDragPosition () {
			Point pos = this.PointToClient (Cursor.Position);
			
			if (this.ClientRectangle.Contains (pos)) {
				flapTable.Location = new Point ((this.Width - flapTable.Width) / 2, (this.Height - flapTable.Height) / 2);
				flapTable.Show ();

				CheckFlaps ();
			} else {
				flapTable.Hide ();
			}
		}

		public void CheckDragEnd () {
			flapTable.Hide ();
			
			foreach (Panel flap in flaps) {
				if (CursorOverFlap (flap)) {
					ProcessFlapDrop (flap);
				}
			}
		}

		private void CheckFlaps () {
			foreach (Panel flap in flaps) {
				if (CursorOverFlap (flap)) {
					flap.BackColor = Color.FromArgb (255, Color.Red);
				} else {
					flap.BackColor = Color.FromArgb (128, Color.Red);
				}
			}
		}

		private bool CursorOverFlap (Panel flap) {
			Point pos = flap.PointToClient (Cursor.Position);
			return flap.ClientRectangle.Contains (pos);
		}

		private void ProcessFlapDrop (Panel flap) {
			if (flap == centerFlap) {
				/*MainSection section = MainForm.DraggingSection;
				section.MoveToPanel ();
				section.Form.Hide ();
				TabPage tabPage = new TabPage (section.Title);
				tabPage.Controls.Add (section.Panel);
				tabs.TabPages.Add (tabPage);*/
			}
		}
	}
}
