using AnyGameEngine;
using AnyGameEngineEditor.EditPropertyWindows;
using CSharpControls;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AnyGameEngineEditor.Zones {
	public sealed class ZonesWindow:SectionWindow {
		private SplitContainer mainSplit = new SplitContainer ();
		private CSSTreeView tree = new CSSTreeView ();

		private SplitContainer zoneSplit = new SplitContainer ();
		private PropertyGrid zoneGrid = new PropertyGrid ();
		private DataTable zoneTable = new DataTable ();
		private TextBox zoneID = new TextBox ();
		private TextBox zoneName = new TextBox ();

		private LogicEditor logicEditor = new LogicEditor ();

		private Zone currentZone;

		public ZonesWindow () {
			this.Text = "Zones";

			mainSplit.Dock = DockStyle.Fill;
			mainSplit.TabStop = false;
			this.Controls.Add (mainSplit);

			zoneSplit.Dock = DockStyle.Fill;
			zoneSplit.Orientation = Orientation.Horizontal;
			mainSplit.Panel1.Controls.Add (zoneSplit);

			tree.Dock = DockStyle.Fill;
			tree.AfterSelect += onZoneSelect;
			zoneSplit.Panel1.Controls.Add (tree);
			
			zoneGrid.Dock = DockStyle.Fill;
			zoneGrid.AddRow (id, "A unique behind-the-scenes name for this zone.", EditID);
			zoneGrid.AddRow (name, "The actual name for this zone.", EditName);
			zoneSplit.Panel2.Controls.Add (zoneGrid);

			mainSplit.Panel2.Controls.Add (logicEditor);
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

		public void UpdatedLogic (LogicBase logic) {
			logicEditor.UpdatedLogic (logic);
		}

		public override void SaveIDE (StringBuilder sb) {
			throw new System.NotImplementedException ();
		}

		private void onZoneSelect (object obj, TreeViewEventArgs e) {
			currentZone = (Zone) e.Node.Tag;

			SetID (currentZone.ID);
			SetName (currentZone.Name);

			logicEditor.Clear ();
			logicEditor.AddLogicToTree (currentZone.Logic);
		}

		private void IDChanged () {
			currentZone.ID = zoneID.Text;
			
		}

		private void NameChanged () {
			currentZone.Name = zoneName.Text;
			//MainWindow.Game.Zones.ResetBindings ();
			MainWindow.GeneralWindow.UpdatedStartingZone ();
		}

		private string GetZoneNodeText (Zone zone) {
			return string.Format ("{0} ({1})", zone.ID, zone.Name);
		}

		private void EditID () {
			EditPropertyWindow window = new EditPropertyTextBoxWindow (name, currentZone.ID, null);
			
			if (window.ShowDialog (MainWindow.Instance) == System.Windows.Forms.DialogResult.OK) {
				string before = currentZone.ID;
				MainWindow.Instance.PushUndo (() => SetID (before));
				SetID ((string) window.Value);
			}
		}

		private void SetID (string value) {
			currentZone.ID = value;
			zoneGrid.SetValue (id, value);
			MainWindow.GeneralWindow.UpdatedStartingZone ();
		}

		private void EditName () {
			EditPropertyWindow window = new EditPropertyTextBoxWindow (name, currentZone.Name, null);
			
			if (window.ShowDialog (MainWindow.Instance) == System.Windows.Forms.DialogResult.OK) {
				string before = currentZone.Name;
				MainWindow.Instance.PushUndo (() => SetName (before));
				SetName ((string) window.Value);
			}
		}

		private void SetName (string value) {
			currentZone.Name = value;
			zoneGrid.SetValue (name, value);
			MainWindow.GeneralWindow.UpdatedStartingZone ();
		}

		private const string id = "ID";
		private const string name = "Name";
	}
}
