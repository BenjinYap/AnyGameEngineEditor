using AnyGameEngine;
using AnyGameEngine.LogicItems;
using AnyGameEngineEditor.EditPropertyWindows;

namespace AnyGameEngineEditor.LogicEditorGridHandlers {
	public sealed class LogicTextGridHandler:LogicEditorGridHandler {

		public override void PopulateGrid (LogicBase logic) {
			base.PopulateGrid (logic);
			LogicText foo = (LogicText) logic;

			if (foo.ID.Length > 0) {
				this.Grid.AddRow (Constants.ID, Constants.IDLogicDescription, EditID);
				this.Grid.SetValue (Constants.ID, foo.ID);
			}

			this.Grid.AddRow (Constants.Text, Constants.TextLogicTextDescription, EditText);
			this.Grid.SetValue (Constants.Text, foo.Text);
		}

		private void EditID () {
			LogicText foo = (LogicText) this.Logic;
			EditPropertyWindow window = new EditPropertyTextBoxWindow (Constants.ID, foo.ID, null);
			
			if (window.ShowDialog (MainWindow.Instance) == System.Windows.Forms.DialogResult.OK) {
				string before = foo.ID;
				SetID ((string) window.Value);
				//MainWindow.Instance.PushUndo (() => SetName (before));
				//SetName ((string) window.Value);
			}
		}

		private void SetID (string value) {
			((LogicText) this.Logic).ID = value;
			this.Grid.SetValue (Constants.ID, value);
			MainWindow.SavedLogicWindow.UpdatedLogic (this.Logic);
			MainWindow.ZonesWindow.UpdatedLogic (this.Logic);
		}

		private void EditText () {
			LogicText foo = (LogicText) this.Logic;
			EditPropertyWindow window = new EditPropertyTextBoxWindow (Constants.Text, foo.Text, null);
			
			if (window.ShowDialog (MainWindow.Instance) == System.Windows.Forms.DialogResult.OK) {
				string before = foo.Text;
				//MainWindow.Instance.PushUndo (() => SetName (before));
				//SetName ((string) window.Value);
			}
		}
	}
}
