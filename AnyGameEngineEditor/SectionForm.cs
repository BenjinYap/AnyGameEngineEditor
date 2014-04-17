using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;


namespace AnyGameEngineEditor {
	public delegate void FormDragEventHandler (object obj, EventArgs e);

	public class SectionForm:Form {
		public event FormDragEventHandler FormDragStart;
		public event FormDragEventHandler FormDragEnd;

		private bool dragStarted = false;
		private bool dragEnded = true;
		private Size formSize;

		public SectionForm () {
			this.ResizeBegin += onResizeBegin;
			this.ResizeEnd += onResizeEnd;
		}

		protected override bool ProcessCmdKey (ref Message msg, Keys keyData) {
			if (keyData == (Keys.Control | Keys.Z)) {
				MainForm.Instance.Undo ();
				return true;
			} else if (keyData == (Keys.Control | Keys.S)) {

			}
			
			return base.ProcessCmdKey (ref msg, keyData);
		}
		/*
		protected override void WndProc (ref Message m) {
			/*if (m.Msg == 0x0231) {
				Debug.WriteLine ("START");
				Debug.WriteLine (Cursor.Position);
				Debug.WriteLine (this.Location);
			} else if (m.Msg == 0x0232) {
				Debug.WriteLine ("END");
			}
			

			base.WndProc (ref m);
		}
	*/
		private void onResizeBegin (object obj, EventArgs e) {
			formSize = this.Size;
			this.LocationChanged += onLocationChanged;
		}

		private void onResizeEnd (object obj, EventArgs e) {
			this.LocationChanged -= onLocationChanged;

			if (dragEnded == false && FormDragEnd!= null) {
				dragEnded = true;
				FormDragEnd (this, EventArgs.Empty);
			}
		}

		private void onLocationChanged (object obj, EventArgs e) {
			if (formSize == this.Size) {
				if (dragStarted == false && FormDragStart != null) {
					dragStarted = true;
					dragEnded = false;
					FormDragStart (this, EventArgs.Empty);
				}
			}
		}
	}
}
