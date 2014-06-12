using AnyGameEngine;
using AnyGameEngine.LogicItems;
using AnyGameEngineEditor.EditLogicWindows;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace AnyGameEngineEditor {
	public sealed class LogicEditor {
		private TreeView tree;
		private bool cancelExpand = false;
		private DateTime lastTime = DateTime.Now;

		public LogicEditor (TreeView tree) {
			this.tree = tree;
			tree.NodeMouseDoubleClick += onNodeDoubleClick;
			tree.KeyDown += onTreeKeyDown;
			tree.MouseDown += onMouseDown;
			tree.BeforeExpand += onBeforeExpandCollapse;
			tree.BeforeCollapse += onBeforeExpandCollapse;
		}

		public void AddLogicToTree (LogicBase logic) {
			CreateNode (null, logic);

			if (tree.Nodes.Count == 1) {
				tree.SelectedNode = tree.Nodes [0];
			}
		}

		private void onNodeDoubleClick (object obj, EventArgs e) {
			EditNode ((LogicTreeNode) tree.SelectedNode);
		}

		private void onTreeKeyDown (object obj, KeyEventArgs e) {
			if (tree.SelectedNode != null && e.KeyCode == Keys.Enter) {
				EditNode ((LogicTreeNode) tree.SelectedNode);
			}
		}

		private void onBeforeExpandCollapse (object obj, TreeViewCancelEventArgs e) {
			e.Cancel = cancelExpand;
			cancelExpand = false;
		}
		
		private void onMouseDown (object obj, MouseEventArgs e) {
			int delta = (int) DateTime.Now.Subtract (lastTime).TotalMilliseconds;
			cancelExpand = delta < SystemInformation.DoubleClickTime;
			lastTime = DateTime.Now;
		}

		private void CreateNode (TreeNode parentNode, LogicBase logic) {
			LogicTreeNode node = new LogicTreeNode (logic);
			
			if (parentNode == null) {
				tree.Nodes.Add (node);
			} else {
				parentNode.Nodes.Add (node);
			}
		}

		private void EditNode (LogicTreeNode node) {
			LogicBase logic = (LogicBase) node.Logic;
			
			if (logic is LogicReference) {
				//new LogicReferenceWindow ().ShowDialog (MainWindow.Instance);
				
			} else if (logic is LogicText) {
				LogicText logicText = (LogicText) logic;
				EditLogicTextWindow window = new EditLogicTextWindow (logicText);

				if (window.ShowDialog (MainWindow.Instance) == DialogResult.OK) {
					string before = logicText.Text;
					MainWindow.Instance.PushUndo (() => {
						node.Edited = false;
						logicText.Text = before;
					});
					node.Edited = true;
					logicText.Text = window.TextValue;
				}
			}
		}

		private void EditedNode (LogicTreeNode node) {
			node.Edited = true;
			node.ForeColor = Color.Purple;
		}
	}
}
