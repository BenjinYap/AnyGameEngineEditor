using AnyGameEngine;
using AnyGameEngine.LogicItems;
using System.Windows.Forms;

namespace AnyGameEngineEditor {
	public class LogicTreeNode:TreeNode {
		public LogicBase Logic;

		public LogicTreeNode (LogicBase logic) {
			Logic = logic;

			if (logic is LogicReference) {
				LogicReference reference = (LogicReference) logic;
				//this.Text = string.Format ("{0}{1}({2})", reference.Logic.ID, ((reference.Logic.ID.Length > 0) ? " " : ""), logic.GetType ().Name);

				logic = reference.Logic;
			}

			LogicItem item = (LogicItem) logic;
			this.Text = string.Format ("{0}{1}({2})", item.ID, ((item.ID.Length > 0) ? " " : ""), logic.GetType ().Name);

			if (Logic is LogicReference) {
				this.Text += " (LogicReference)";
			}

			if (logic is LogicList) {
				LogicList list = (LogicList) logic;

				foreach (LogicBase l in list.Logics) {
					this.Nodes.Add (new LogicTreeNode (l));
				}
			}

			this.ExpandAll ();
		}
	}
}
