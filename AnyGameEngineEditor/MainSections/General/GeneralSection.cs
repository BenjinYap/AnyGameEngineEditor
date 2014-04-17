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
			this.Form.Width = 500;
			table.AddTextBoxRow ("Name", "The name of the game.", name, () => MainForm.Game.Name = name.Text);
			table.AddTextBoxRow ("Author", "The creator of the game.", author, () => MainForm.Game.Author = author.Text);
			table.AddTextBoxRow ("Description", "A short summary of the game.", description, () => MainForm.Game.Description = description.Text);
		}

		public override void Refresh () {
			table.SetAllChangeTracking (false);
			name.Text = MainForm.Game.Name;
			author.Text = MainForm.Game.Author;
			description.Text = MainForm.Game.Description;
			table.SetAllChangeTracking (true);
		}
	}
}
