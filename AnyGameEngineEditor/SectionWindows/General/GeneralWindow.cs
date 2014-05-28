using System.Diagnostics;
using System.Windows.Forms;

namespace AnyGameEngineEditor.SectionWindows.General {
	public sealed class GeneralWindow:SectionWindow {
		private DataTable table = new DataTable ();
		private TextBox name = new TextBox ();
		private TextBox author = new TextBox ();
		private TextBox description = new TextBox ();

		public GeneralWindow () {
			this.Text = "General";
			this.Controls.Add (table);
			this.Width = 500;
			table.AddTextBoxRow ("Name", "The name of the game.", name, () => MainWindow.Game.Name = name.Text);
			table.AddTextBoxRow ("Author", "The creator of the game.", author, () => MainWindow.Game.Author = author.Text);
			table.AddTextBoxRow ("Description", "A short summary of the game.", description, () => MainWindow.Game.Description = description.Text);
		}

		public override void RefreshContent () {
			table.SetAllChangeTracking (false);
			name.Text = MainWindow.Game.Name;
			author.Text = MainWindow.Game.Author;
			description.Text = MainWindow.Game.Description;
			table.SetAllChangeTracking (true);
		}
	}
}
