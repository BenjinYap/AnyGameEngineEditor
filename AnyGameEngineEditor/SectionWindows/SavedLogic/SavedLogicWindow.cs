using System.Windows.Forms;
using System.Diagnostics;
using AnyGameEngine;
using AnyGameEngine.LogicItems;

namespace AnyGameEngineEditor.SectionWindows.SavedLogic {
	public sealed class SavedLogicWindow:SectionWindow {
		private TreeView tree = new TreeView ();

		public SavedLogicWindow () {
			this.Text = "Saved Logic";

			tree.Dock = DockStyle.Fill;
			this.Controls.Add (tree);
		}

		public override void RefreshContent () {
			tree.Nodes.Clear ();

			MainWindow.Game.SavedLogic.ForEach (logic => {
				CreateNode (null, logic);
			});
		}

		private void CreateNode (TreeNode parentNode, LogicBase logic) {
			TreeNode node = new TreeNode ();
			string text = "";

			if (logic is LogicStub) {
				LogicStub stub = (LogicStub) logic;
				text = string.Format ("{0}{1}({2})", stub.ID, ((stub.ID.Length > 0) ? " " : ""), logic.GetType ().Name);
			} else if (logic is LogicItem) {
				LogicItem item = (LogicItem) logic;
				text = string.Format ("{0}{1}({2})", item.ID, ((item.ID.Length > 0) ? " " : ""), logic.GetType ().Name);
			}

			node.Text = text;
			node.Tag = logic;
			
			if (logic is LogicList) {
				LogicList list = (LogicList) logic;

				list.Logics.ForEach (foo => CreateNode (node, foo));
			}

			node.ExpandAll ();

			if (parentNode == null) {
				tree.Nodes.Add (node);
			} else {
				parentNode.Nodes.Add (node);
			}
		}
	}
}
