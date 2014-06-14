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

			
		}
	}
}
