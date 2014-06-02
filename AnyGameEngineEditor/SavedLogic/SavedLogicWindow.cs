using System.Windows.Forms;
using System.Diagnostics;
using AnyGameEngine;
using AnyGameEngine.LogicItems;

namespace AnyGameEngineEditor.SavedLogic {
	public sealed class SavedLogicWindow:SectionWindow {
		private TreeView tree = new TreeView ();

		private LogicEditor logicEditor;

		public SavedLogicWindow () {
			this.Text = "Saved Logic";

			tree.Dock = DockStyle.Fill;
			this.Controls.Add (tree);

			logicEditor = new LogicEditor (tree);
		}

		public override void ForceUpdate () {
			tree.Nodes.Clear ();

			MainWindow.Game.SavedLogic.ForEach (logic => {
				logicEditor.AddLogicToTree (logic);
			});
		}

		
	}
}
