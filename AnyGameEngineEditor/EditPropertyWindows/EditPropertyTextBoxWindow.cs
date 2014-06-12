using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace AnyGameEngineEditor.EditPropertyWindows {
	public class EditPropertyTextBoxWindow:EditPropertyWindow {
		private TextBox box = new TextBox ();

		public EditPropertyTextBoxWindow (string name, string value, ValueValidator validator):base (name, validator) {
			this.SetMinimumClientSize (0, box.Height);

			this.Value = value;
			box.Text = value;
			box.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom;
			box.Width = this.ClientSize.Width - 19;
			box.Height = this.Confirm.Location.Y;
			box.Multiline = true;
			box.ScrollBars = ScrollBars.Vertical;
			box.KeyDown += onKeyDown;
			box.TextChanged += onTextChanged;
			this.Controls.Add (box);
			
			this.Shown += onShown;
			this.FormClosed += onFormClosed;
		}

		private void onShown (object obj, EventArgs e) {
			box.Focus ();
		}

		private void onFormClosed (object obj, EventArgs e) {
			this.Shown -= onShown;
			this.FormClosed -= onFormClosed;
			box.KeyDown -= onKeyDown;
			box.TextChanged -= onTextChanged;
		}
		
		private void onKeyDown (object obj, KeyEventArgs e) {
			if (e.KeyCode == Keys.Enter) {
				e.SuppressKeyPress = true;
			}
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
