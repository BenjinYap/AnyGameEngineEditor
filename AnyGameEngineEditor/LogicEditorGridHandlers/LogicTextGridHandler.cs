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
				SetID (foo.ID);
			}

			this.Grid.AddRow (Constants.Text, Constants.TextLogicTextDescription, EditText);
			SetText (foo.Text);
		}

		private void EditID () {
			LogicItem foo = (LogicItem) this.Logic;
			EditPropertyWindow window = new EditPropertyTextBoxWindow (Constants.ID, foo.ID, null);
			
			if (window.ShowDialog (MainWindow.Instance) == System.Windows.Forms.DialogResult.OK) {
				string before = foo.ID;
				MainWindow.Instance.PushUndo (() => SetID (before));
				SetID ((string) window.Value);
			}
		}

		private void SetID (string value) {
			((LogicItem) this.Logic).ID = value;
			this.Grid.SetValue (Constants.ID, value);
			MainWindow.SavedLogicWindow.UpdatedLogic (this.Logic);
			MainWindow.ZonesWindow.UpdatedLogic (this.Logic);
		}

		private void EditText () {
			LogicText foo = (LogicText) this.Logic;
			EditPropertyWindow window = new EditPropertyTextBoxWindow (Constants.Text, foo.Text, null);
			
			if (window.ShowDialog (MainWindow.Instance) == System.Windows.Forms.DialogResult.OK) {
				string before = foo.Text;
				MainWindow.Instance.PushUndo (() => SetText (before));
				SetText ((string) window.Value);
			}
		}

		private void SetText (string value) {
			((LogicText) this.Logic).Text = value;
			this.Grid.SetValue (Constants.Text, value);
			MainWindow.SavedLogicWindow.UpdatedLogic (this.Logic);
			MainWindow.ZonesWindow.UpdatedLogic (this.Logic);
		}
	}
}
