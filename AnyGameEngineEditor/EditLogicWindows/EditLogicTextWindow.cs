using AnyGameEngine.LogicItems;
using AnyGameEngineEditor.EditPropertyWindows;
using System;
namespace AnyGameEngineEditor.EditLogicWindows {
	public sealed class EditLogicTextWindow:EditLogicWindow {
		public string TextValue;

		public EditLogicTextWindow (LogicText logic) {
			this.Text = "Edit Logic Text";
			TextValue = logic.Text;
			this.Label.AddTextChunk ("Display the following text: ");
			this.Label.AddLinkChunk ("a", TextValue, onTextClick);
			
			this.Shown += onShown;
			this.FormClosed += onFormClosed;
		}

		private void onShown (object obj, EventArgs e) {
			this.Label.Focus ();
		}

		private void onFormClosed (object obj, EventArgs e) {
			this.Shown -= onShown;
			this.FormClosed -= onFormClosed;
		}

		private void onTextClick () {
			EditPropertyWindow window = new EditPropertyTextBoxWindow ("Text", TextValue, null);
			
			if (window.ShowDialog (MainWindow.Instance) == System.Windows.Forms.DialogResult.OK) {
				TextValue = (string) window.Value;
				this.Label.SetLinkChunkText ("a", TextValue);
			}

			//this.Confirm.Focus ();
		}
	}
}
