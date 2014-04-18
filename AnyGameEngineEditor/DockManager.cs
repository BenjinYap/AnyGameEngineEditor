using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using System;


namespace AnyGameEngineEditor {
	public class DockManager:Panel {
		private TableLayoutPanel flapTable = new TableLayoutPanel ();
		private Panel [] flaps;
		private Panel leftFlap = new Panel ();
		private Panel rightFlap = new Panel ();
		private Panel topFlap = new Panel ();
		private Panel bottomFlap = new Panel ();
		private Panel centerFlap = new Panel ();

		private List <Form> dockableForms = new List<Form> ();
		private Dictionary <Form, Size> formSizes = new Dictionary<Form,Size> ();

		public DockManager () {
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
		}

		public void RegisterDockableForm (Form form) {
			dockableForms.Add (form);
			formSizes.Add (form, new Size ());
			form.ResizeBegin += onResizeBegin;
			form.ResizeEnd += onResizeEnd;
		}

		public void UnregisterDockableForm (Form form) {
			dockableForms.Remove (form);
			formSizes.Remove (form);
		}

		private void onResizeBegin (object obj, EventArgs e) {
			formSize = this.Size;
			this.LocationChanged += onLocationChanged;
		}

		private void onResizeEnd (object obj, EventArgs e) {
			this.LocationChanged -= onLocationChanged;

			if (dragEnded == false && FormDragEnd!= null) {
				dragStarted = false;
				dragEnded = true;
				FormDragEnd (this, EventArgs.Empty);
				MainForm.DraggingSection = null;
			}
		}

		private void onLocationChanged (object obj, EventArgs e) {
			if (formSize == this.Size) {
				if (dragStarted == false && FormDragStart != null) {
					MainForm.DraggingSection = this.Section;
					dragStarted = true;
					dragEnded = false;
					FormDragStart (this, EventArgs.Empty);
				}
			}
		}
	}
}
