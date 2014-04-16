using System.Diagnostics;
using System.Windows.Forms;

namespace AnyGameEngineEditor.MainSections.General {
	public sealed class GeneralSection:MainSection {
		private DataTable table = new DataTable ();
		private TextBox name = new TextBox ();
		private TextBox author = new TextBox ();
		private TextBox description = new TextBox ();
		
		public GeneralSection () {
			this.Title = "General";
			this.SharedControls.Add (table);

			table.AddRow ("Name", "The name of the game.", name);
			table.AddRow ("Author", "The creator of the game.", author);
			table.AddRow ("Description", "A short summary of the game.", description);
		}

		public override void Refresh () {
			name.Text = MainForm.Game.Name;
			author.Text = MainForm.Game.Author;
			description.Text = MainForm.Game.Description;
		}
	}
}
