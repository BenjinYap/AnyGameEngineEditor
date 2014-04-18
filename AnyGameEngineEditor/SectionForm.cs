using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;


namespace AnyGameEngineEditor {
	public delegate void FormDragEventHandler (object obj, EventArgs e);

	public class SectionForm:Form {
		public event FormDragEventHandler FormDragStart;
		public event FormDragEventHandler FormDragEnd;
		public MainSection Section;

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
