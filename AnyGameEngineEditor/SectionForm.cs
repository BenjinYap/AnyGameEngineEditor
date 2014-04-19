using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;


namespace AnyGameEngineEditor {
	public delegate void FormDragEventHandler (object obj, EventArgs e);

	public abstract class SectionForm:Form {
		
		public abstract void RefreshContent ();

		protected override bool ProcessCmdKey (ref Message msg, Keys keyData) {
			if (keyData == (Keys.Control | Keys.Z)) {
				MainForm.Instance.Undo ();
				return true;
			} else if (keyData == (Keys.Control | Keys.S)) {

			}
			
			return base.ProcessCmdKey (ref msg, keyData);
		}
	}
}
