using CSharpControls.DockManager;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;


namespace AnyGameEngineEditor {
	public delegate void FormDragEventHandler (object obj, EventArgs e);

	public abstract class SectionWindow:CSSDockableForm {
		
		public abstract void ForceUpdate ();

		protected override bool ProcessCmdKey (ref Message msg, Keys keyData) {
			if (keyData == (Keys.Control | Keys.Z)) {
				MainWindow.Instance.Undo ();
				return true;
			} else if (keyData == (Keys.Control | Keys.S)) {

			}
			
			return base.ProcessCmdKey (ref msg, keyData);
		}
	}
}
