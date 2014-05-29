﻿using AnyGameEngine;
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
			EditNode (tree.SelectedNode);
		}

		private void onTreeKeyDown (object obj, KeyEventArgs e) {
			if (tree.SelectedNode != null && e.KeyCode == Keys.Enter) {
				EditNode (tree.SelectedNode);
			}
		}

		private void EditNode (TreeNode node) {
			LogicBase logic = (LogicBase) node.Tag;

			if (logic is LogicStub) {
				new LogicStubWindow ().ShowDialog (MainWindow.Instance);
			}
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