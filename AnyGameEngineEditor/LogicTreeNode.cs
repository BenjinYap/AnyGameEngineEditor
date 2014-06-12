using AnyGameEngine;
using AnyGameEngine.LogicItems;
using System.Drawing;
using System.Windows.Forms;

namespace AnyGameEngineEditor {
	public class LogicTreeNode:TreeNode {
		public LogicBase Logic;

		public bool Edited {
			get {
				return edited;
			}
			set {
				edited = value;
				this.ForeColor = (edited) ? Color.Purple : Color.Black;
			}
		}
		private bool edited = false;

		public LogicTreeNode (LogicBase logic) {
			Edited = false;
			Logic = logic;

			if (logic is LogicReference) {
				LogicReference reference = (LogicReference) logic;
				this.Text = string.Format ("{0}{1}({2})", reference.Logic.ID, ((reference.Logic.ID.Length > 0) ? " " : ""), logic.GetType ().Name);
				logic = reference.Logic;
			} else {
				LogicItem item = (LogicItem) logic;
				this.Text = string.Format ("{0}{1}({2})", item.ID, ((item.ID.Length > 0) ? " " : ""), logic.GetType ().Name);

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
}
