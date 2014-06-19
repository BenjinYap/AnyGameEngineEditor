using AnyGameEngine;
using AnyGameEngine.LogicItems;
using AnyGameEngineEditor.EditPropertyWindows;

namespace AnyGameEngineEditor.LogicEditorGridHandlers {
	public sealed class LogicListGridHandler:LogicEditorGridHandler {

		public override void PopulateGrid (LogicBase logic) {
			base.PopulateGrid (logic);
			LogicList foo = (LogicList) logic;

			if (foo.ID.Length > 0) {
				this.Grid.AddRow (Constants.ID, Constants.IDLogicDescription, EditID);
				this.Grid.SetValue (Constants.ID, foo.ID);
			}
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
	}
}
