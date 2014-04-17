using System.Diagnostics;
using System.Windows.Forms;


namespace AnyGameEngineEditor {
	public class SectionForm:Form {
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
