using System.Diagnostics;
using System.Windows.Forms;
using System.Collections.Generic;
using AnyGameEngine;

namespace AnyGameEngineEditor.SectionWindows.General {
	public sealed class GeneralWindow:SectionWindow {
		private DataTable table = new DataTable ();
		private TextBox name = new TextBox ();
		private TextBox author = new TextBox ();
		private TextBox description = new TextBox ();
		private ComboBox startingZoneID = new ComboBox ();

		public GeneralWindow () {
			this.Text = "General";
			this.Controls.Add (table);
			this.Width = 500;
			table.AddTextBoxRow ("Name", "The name of the game.", name, () => MainWindow.Game.Name = name.Text);
			table.AddTextBoxRow ("Author", "The creator of the game.", author, () => MainWindow.Game.Author = author.Text);
			table.AddTextBoxRow ("Description", "A short summary of the game.", description, () => MainWindow.Game.Description = description.Text);
			startingZoneID.AutoCompleteSource = AutoCompleteSource.ListItems;
			startingZoneID.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			startingZoneID.DisplayMember = "Name";
			startingZoneID.ValueMember = "ID";
			table.AddComboBoxRow ("Starting Zone ID", "The ID of the starting zone.", startingZoneID, () => {});
		}

		public override void RefreshContent () {
			table.SetAllChangeTracking (false);
			name.Text = MainWindow.Game.Name;
			author.Text = MainWindow.Game.Author;
			description.Text = MainWindow.Game.Description;
			startingZoneID.DataSource = MainWindow.Game.Zones;
			
			table.SetAllChangeTracking (true);
		}
	}
}
