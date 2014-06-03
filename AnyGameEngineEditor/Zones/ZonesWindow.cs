using AnyGameEngine;
using CSharpControls;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace AnyGameEngineEditor.Zones {
	public sealed class ZonesWindow:SectionWindow {
		private SplitContainer mainSplit = new SplitContainer ();
		private CSSTreeView tree = new CSSTreeView ();

		private SplitContainer zoneSplit = new SplitContainer ();
		private DataTable zoneTable = new DataTable ();
		private TextBox zoneID = new TextBox ();
		private TextBox zoneName = new TextBox ();
		private TreeView zoneLogicTree = new TreeView ();

		private LogicEditor logicEditor;

		private Zone currentZone;

		public ZonesWindow () {
			this.Text = "Zones";

			mainSplit.Dock = DockStyle.Fill;
			mainSplit.TabStop = false;
			this.Controls.Add (mainSplit);

			tree.Dock = DockStyle.Fill;
			tree.AfterSelect += onZoneSelect;
			mainSplit.Panel1.Controls.Add (tree);

			zoneSplit.Dock = DockStyle.Fill;
			zoneSplit.Orientation = Orientation.Horizontal;
			mainSplit.Panel2.Controls.Add (zoneSplit);
			
			zoneTable.AddTextBoxRow ("ID", "A unique string to identify this zone.", zoneID, IDChanged);
			zoneTable.AddTextBoxRow ("Name", "The name of this zone.", zoneName, NameChanged);
			zoneSplit.Panel1.Controls.Add (zoneTable);

			zoneLogicTree.Dock = DockStyle.Fill;
			zoneSplit.Panel2.Controls.Add (zoneLogicTree);

			logicEditor = new LogicEditor (zoneLogicTree);
		}

		public override void ForceUpdate () {
			tree.Nodes.Clear ();
			
			foreach (Zone zone in MainWindow.Game.Zones) {
				TreeNode node = new TreeNode ();
				node.Tag = zone;
				node.Text = GetZoneNodeText (zone);
				tree.Nodes.Add (node);
			}

			tree.SelectedNode = tree.Nodes [0];
		}

		private void onZoneSelect (object obj, TreeViewEventArgs e) {
			currentZone = (Zone) e.Node.Tag;

			zoneTable.SetAllChangeTracking (false);
			zoneID.Text = currentZone.ID;
			zoneName.Text = currentZone.Name;
			zoneTable.SetAllChangeTracking (true);

			zoneLogicTree.Nodes.Clear ();
			logicEditor.AddLogicToTree (currentZone.Logic);
		}

		private void IDChanged () {
			currentZone.ID = zoneID.Text;
			
		}

		private void NameChanged () {
			currentZone.Name = zoneName.Text;
			//MainWindow.Game.Zones.ResetBindings ();
			MainWindow.GeneralWindow.UpdateStartingZone ();
		}

		private string GetZoneNodeText (Zone zone) {
			return string.Format ("{0} ({1})", zone.ID, zone.Name);
		}
	}
}
