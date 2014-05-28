using CSharpControls;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace AnyGameEngineEditor.SectionWindows.Zones {
	public sealed class ZonesWindow:SectionWindow {
		private SplitContainer mainSplit = new SplitContainer ();
		private CSSTreeView tree = new CSSTreeView ();

		private SplitContainer zoneSplit = new SplitContainer ();
		private DataTable zoneTable = new DataTable ();
		private TextBox zoneID = new TextBox ();
		private TextBox zoneName = new TextBox ();

		public ZonesWindow () {
			this.Text = "Zones";

			mainSplit.Dock = DockStyle.Fill;
			mainSplit.TabStop = false;
			this.Controls.Add (mainSplit);

			tree.Dock = DockStyle.Fill;
			mainSplit.Panel1.Controls.Add (tree);

			zoneSplit.Dock = DockStyle.Fill;
			zoneSplit.Orientation = Orientation.Horizontal;
			mainSplit.Panel2.Controls.Add (zoneSplit);
			
			zoneTable.AddTextBoxRow ("ID", "A unique string to identify this zone.", zoneID, () => {});
			zoneTable.AddTextBoxRow ("Name", "The name of this zone.", zoneName, () => {});
			zoneSplit.Panel1.Controls.Add (zoneTable);
		}

		public override void RefreshContent () {
			
		}
	}
}
