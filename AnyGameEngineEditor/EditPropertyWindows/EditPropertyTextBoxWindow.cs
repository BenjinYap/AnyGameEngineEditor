using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace AnyGameEngineEditor.EditPropertyWindows {
	public class EditPropertyTextBoxWindow:EditPropertyWindow {
		private TextBox box = new TextBox ();

		public EditPropertyTextBoxWindow (string name, string value, ValueValidator validator):base (name, validator) {
			this.Value = value;
			box.Text = value;
			box.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
			box.Left = EditPropertyWindow.LabelWidth;
			box.Width = this.ClientSize.Width - EditPropertyWindow.LabelWidth - 19;
			box.TextChanged += onTextChanged;
			
			this.Panel.Controls.Add (box);
			
			this.Shown += onShown;
			this.FormClosed += onFormClosed;
		}

		private void onShown (object obj, EventArgs e) {
			box.Focus ();
		}

		private void onFormClosed (object obj, EventArgs e) {
			this.Shown -= onShown;
			this.FormClosed -= onFormClosed;
			box.TextChanged -= onTextChanged;
		}

		private void onTextChanged (object obj, EventArgs e) {
			this.Value = box.Text;

			if (this.validator != null) {
				string error;

				if (this.validator (box.Text, out error)) {
					MainWindow.Error.SetError (box, "");
					this.EnableConfirm ();
				} else {
					MainWindow.Error.SetError (box, error);
					this.DisableConfirm ();
				}
			}
		}
	}
}
