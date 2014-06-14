using AnyGameEngine;
using AnyGameEngine.LogicItems;

namespace AnyGameEngineEditor.LogicEditorGridHandlers {
	public sealed class LogicReferenceGridHandler:LogicEditorGridHandler {

		public override void PopulateGrid (LogicBase logic) {
			base.PopulateGrid (logic);
			LogicReference foo = (LogicReference) logic;

			//if (foo.ID.Length > 0) {
			//	this.Grid.AddRow (Constants.ID, Constants.IDLogicDescription, null);
			//	this.Grid.SetValue (Constants.ID, foo.ID);
			//}

			//this.Grid.AddRow (Constants.Text, Constants.TextLogicTextDescription, null);
			//this.Grid.SetValue (Constants.Text, foo.Text);
		}

		//private void EditText () {
		//	LogicText logic = (LogicText) ((LogicTreeNode) tree.SelectedNode).Logic;
		//	EditPropertyWindow window = new EditPropertyTextBoxWindow (Constants.Text, logic.Text, null);
			
		//	if (window.ShowDialog (MainWindow.Instance) == System.Windows.Forms.DialogResult.OK) {
		//		string before = logic.Text;
		//		//MainWindow.Instance.PushUndo (() => SetName (before));
		//		//SetName ((string) window.Value);
		//	}
		//}
	}
}
