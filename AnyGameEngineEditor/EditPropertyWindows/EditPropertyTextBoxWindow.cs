using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace AnyGameEngineEditor.EditPropertyWindows {
	public class EditPropertyTextBoxWindow:EditPropertyWindow {
		private TextBox box = new TextBox ();

		public EditPropertyTextBoxWindow (string name, string value, Func <string, bool> validator):base (name, validator) {
			box.Text = value;
			box.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
			box.Left = EditPropertyWindow.LabelWidth;
			box.Width = this.ClientSize.Width - EditPropertyWindow.LabelWidth - 19;
			box.TextChanged += onTextChanged;
			this.Panel.Controls.Add (box);
			
			//box.Multiline = true;
			//box.WordWrap = true;
			
		}

		private void onTextChanged (object obj, EventArgs e) {
			this.Value = box.Text;

			if (this.validator != null) {
				if (this.validator (box.Text)) {
					this.EnableConfirm ();
				} else {
					this.DisableConfirm ();
				}
			}
		}
	}
}
