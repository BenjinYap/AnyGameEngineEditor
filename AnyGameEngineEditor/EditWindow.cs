using System;
using System.Drawing;
using System.Windows.Forms;

namespace AnyGameEngineEditor {
	public abstract class EditWindow:Form {
		protected Button Confirm = new Button ();
		protected Button Cancel = new Button ();

		public EditWindow () {
			Confirm.Text = "Confirm";
			Confirm.DialogResult = System.Windows.Forms.DialogResult.OK;
			Confirm.Anchor = AnchorStyles.Bottom;
			Confirm.Top = this.ClientSize.Height - Confirm.Height;
			Confirm.Left = this.ClientSize.Width / 2 - Confirm.Width;
			this.Controls.Add (Confirm);
			
			Cancel.Text = "Cancel";
			Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			Cancel.Anchor = AnchorStyles.Bottom;
			Cancel.Top = Confirm.Top;
			Cancel.Left = Confirm.Left + Confirm.Width;
			this.Controls.Add (Cancel);

			this.AcceptButton = Confirm;
			this.CancelButton = Cancel;

			SetMinimumClientSize (0, 0);
		}

		public void SetMinimumClientSize (int width, int height) {
			this.MinimumSize = new Size (width + Confirm.Width + Cancel.Width + this.Width - this.ClientSize.Width, height + Confirm.Height + this.Height - this.ClientSize.Height);
		}

		public void SetSize (int width, int height) {
			this.Size = new Size (width + Confirm.Width + Cancel.Width + this.Width - this.ClientSize.Width, height + Confirm.Height + this.Height - this.ClientSize.Height);
		}

		protected void EnableConfirm () {
			Confirm.Enabled = true;
		}

		protected void DisableConfirm () {
			Confirm.Enabled = false;
		}

		
	}
}
