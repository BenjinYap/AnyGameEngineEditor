using System.Diagnostics;
using System.Windows.Forms;

namespace AnyGameEngineEditor.MainSections.General {
	public sealed class GeneralSection:MainSection {
		private DataTable table = new DataTable ();
		private TextBox name = new TextBox ();
		private TextBox author = new TextBox ();

		public GeneralSection (MainForm mainForm):base (mainForm) {
			this.Title = "General";
			this.SharedControls.Add (table);

			table.AddRow ("Name", "The name of the game.", name);
			table.AddRow ("Author", "The creator of the game.", author);
		}

		public override void Refresh () {
			name.Text = this.MainForm.Game.Name;
			author.Text = this.MainForm.Game.Author;
		}
	}
}
