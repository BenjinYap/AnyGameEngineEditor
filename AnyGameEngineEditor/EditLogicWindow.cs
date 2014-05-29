using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace AnyGameEngineEditor {
	public abstract class EditLogicWindow:Form {
		protected DataTable table = new DataTable ();

		private Button confirm = new Button ();
		private Button cancel = new Button ();

		public EditLogicWindow () {
			confirm.Text = "Confirm";
			confirm.DialogResult = System.Windows.Forms.DialogResult.OK;
			confirm.Anchor = AnchorStyles.Bottom;
			confirm.Top = this.ClientSize.Height - confirm.Height;
			confirm.Left = this.ClientSize.Width / 2 - confirm.Width;
			this.Controls.Add (confirm);

			cancel.Text = "Cancel";
			cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			cancel.Anchor = AnchorStyles.Bottom;
			cancel.Top = confirm.Top;
			cancel.Left = confirm.Left + confirm.Width;
			this.Controls.Add (cancel);

			table.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
			table.Width = this.ClientSize.Width;
			table.Height = confirm.Top;
			this.Controls.Add (table);

			this.AcceptButton = confirm;
			this.CancelButton = cancel;
		}
	}
}
