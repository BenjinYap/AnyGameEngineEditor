using CSharpControls.DockManager;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;

namespace AnyGameEngineEditor {
	public delegate void FormDragEventHandler (object obj, EventArgs e);

	public abstract class SectionWindow:CSSDockableForm {
		
		public abstract void ForceUpdate ();
		public abstract void EngageLayoutTracking ();
		public abstract void DisengageLayoutTracking ();
		public abstract void LoadIDE (Dictionary <string, string> pairs);
		public abstract void SaveIDE (StringBuilder sb);

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
