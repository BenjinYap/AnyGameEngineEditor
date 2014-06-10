using AnyGameEngine;
using AnyGameEngine.LogicItems;
using AnyGameEngineEditor.EditLogicWindows;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace AnyGameEngineEditor {
	public sealed class LogicEditor {
		private TreeView tree;

		public LogicEditor (TreeView tree) {
			this.tree = tree;
			tree.NodeMouseDoubleClick += onNodeDoubleClick;
			tree.KeyDown += onTreeKeyDown;
		}

		public void AddLogicToTree (LogicBase logic) {
			CreateNode (null, logic);
		}

		private void onNodeDoubleClick (object obj, EventArgs e) {
			EditNode ((LogicTreeNode) tree.SelectedNode);
		}

		private void onTreeKeyDown (object obj, KeyEventArgs e) {
			if (tree.SelectedNode != null && e.KeyCode == Keys.Enter) {
				EditNode ((LogicTreeNode) tree.SelectedNode);
			}
		}

		private void EditNode (LogicTreeNode node) {
			LogicBase logic = (LogicBase) node.Logic;

			if (logic is LogicReference) {
				new LogicReferenceWindow ().ShowDialog (MainWindow.Instance);
			}
		}

		private void CreateNode (TreeNode parentNode, LogicBase logic) {
			LogicTreeNode node = new LogicTreeNode (logic);
			
			//if (logic is LogicList) {
			//	LogicList list = (LogicList) logic;

			//	list.Logics.ForEach (foo => CreateNode (node, foo));
			//}

			node.ExpandAll ();

			if (parentNode == null) {
				tree.Nodes.Add (node);
			} else {
				parentNode.Nodes.Add (node);
			}
		}
	}
}
