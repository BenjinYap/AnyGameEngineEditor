using AnyGameEngine;
using AnyGameEngine.LogicItems;
using AnyGameEngineEditor.EditPropertyWindows;

namespace AnyGameEngineEditor.LogicEditorGridHandlers {
	public sealed class LogicReferenceGridHandler:LogicEditorGridHandler {

		public override void PopulateGrid (LogicBase logic) {
			base.PopulateGrid (logic);
			LogicReference foo = (LogicReference) logic;
			this.Grid.AddRow (Constants.Logic, Constants.LogicDescription, EditLogic);
			SetLogic (foo.Logic);
		}

		private void EditLogic () {
			LogicReference foo = (LogicReference) this.Logic;
			EditPropertyWindow window = new EditPropertyComboBoxWindow (foo.Logic.ToString (), MainWindow.Game.SavedLogic.ToArray (), foo.Logic, false);
			
			if (window.ShowDialog (MainWindow.Instance) == System.Windows.Forms.DialogResult.OK) {
				LogicItem before = foo.Logic;
				MainWindow.Instance.PushUndo (() => SetLogic (before));
				SetLogic ((LogicItem) window.Value);
			}
		}

		private void SetLogic (LogicItem value) {
			((LogicReference) this.Logic).Logic = value;
			this.Grid.SetValue (Constants.Logic, value.ToString ());
			MainWindow.SavedLogicWindow.UpdatedLogic (this.Logic);
			MainWindow.ZonesWindow.UpdatedLogic (this.Logic);
		}
	}
}
