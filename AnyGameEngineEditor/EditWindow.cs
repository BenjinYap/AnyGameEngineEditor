using System.Windows.Forms;

namespace AnyGameEngineEditor {
	public abstract class EditWindow:Form {
		public Panel Panel = new Panel ();
		protected Button confirm = new Button ();
		private Button cancel = new Button ();

		public EditWindow () {
			//this.AutoSize = true;
			//this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;

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

			this.AcceptButton = confirm;
			this.CancelButton = cancel;

			Panel.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
			Panel.Width = this.ClientSize.Width;
			Panel.Height = confirm.Top;
			this.Controls.Add (Panel);
		}
	}
}
