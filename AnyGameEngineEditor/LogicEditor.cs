using AnyGameEngine;
using AnyGameEngine.LogicItems;
using AnyGameEngineEditor.EditLogicWindows;
using CSharpControls;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using AnyGameEngineEditor.LogicEditorGridHandlers;

namespace AnyGameEngineEditor {
	public sealed partial class LogicEditor:SplitContainer {
		private CSSTreeView tree = new CSSTreeView ();
		private PropertyGrid grid = new PropertyGrid ();

		private Dictionary <LogicBase, List <LogicTreeNode>> logicNodeReferences = new Dictionary<LogicBase,List<LogicTreeNode>> ();
		private Dictionary <Type, LogicEditorGridHandler> gridHandlers = new Dictionary<Type,LogicEditorGridHandler> ();
		
		public LogicEditor () {
			gridHandlers.Add (typeof (LogicText), new LogicTextGridHandler ().SetGrid (grid));
			gridHandlers.Add (typeof (LogicList), new LogicListGridHandler ().SetGrid (grid));
			gridHandlers.Add (typeof (LogicReference), new LogicReferenceGridHandler ().SetGrid (grid));

			this.Dock = DockStyle.Fill;
			this.Orientation = System.Windows.Forms.Orientation.Horizontal;
			this.Panel1.Controls.Add (tree);
			this.Panel2.Controls.Add (grid);

			tree.Dock = DockStyle.Fill;
			tree.AfterSelect += onTreeAfterSelect;
		}

		public void AddLogicToTree (LogicBase logic) {
			CreateNode (null, logic);

			if (tree.Nodes.Count == 1) {
				tree.SelectedNode = tree.Nodes [0];
			}
		}

		public void Clear () {
			tree.Nodes.Clear ();
			grid.ClearRows ();
			logicNodeReferences.Clear ();
		}

		public void UpdatedLogic (LogicBase logic) {
			Stack <LogicTreeNode> nodes = new Stack<LogicTreeNode> ();

			foreach (LogicTreeNode node in tree.Nodes) {
				nodes.Push (node);
			}
			
			while (nodes.Count > 0) {
				LogicTreeNode node = nodes.Pop ();
				node.Text = GetNodeName (node.Logic);

				if (node.Logic is LogicList) {
					foreach (LogicTreeNode n in node.Nodes) {
						nodes.Push (n);
					}
				}
			}
		}

		private void onTreeAfterSelect (object obj, EventArgs e) {
			grid.ClearRows ();
			gridHandlers [((LogicTreeNode) tree.SelectedNode).Logic.GetType ()].PopulateGrid (((LogicTreeNode) tree.SelectedNode).Logic);
		}

		private string GetNodeName (LogicBase logic) {
			string name = "";

			if (logic is LogicReference) {
				name = ((LogicReference) logic).Logic.ID + " ";
			} else {
				name = ((LogicItem) logic).ID + " ";
				name = (name.Length <= 1) ? "" : name;
			}

			name += "(" + logic.GetType ().Name + ")";
			return name;
		}

		private void CreateNode (TreeNode parentNode, LogicBase logic) {
			LogicTreeNode node = new LogicTreeNode (logic);
			
			if (logicNodeReferences.ContainsKey (logic) == false) {
				logicNodeReferences [logic] = new List<LogicTreeNode> ();
			}

			logicNodeReferences [logic].Add (node);

			if (logic is LogicReference) {
				LogicReference reference = (LogicReference) logic;
				node.Text = string.Format ("{0}{1}({2})", reference.Logic.ID, ((reference.Logic.ID.Length > 0) ? " " : ""), logic.GetType ().Name);
			} else {
				LogicItem item = (LogicItem) logic;
				node.Text = string.Format ("{0}{1}({2})", item.ID, ((item.ID.Length > 0) ? " " : ""), logic.GetType ().Name);

				if (logic is LogicList) {
					LogicList list = (LogicList) logic;

					foreach (LogicBase l in list.Logics) {
						CreateNode (node, l);
					}
				}

				node.ExpandAll ();
			}

			if (parentNode == null) {
				tree.Nodes.Add (node);
			} else {
				parentNode.Nodes.Add (node);
			}

			
		}
	}
}
