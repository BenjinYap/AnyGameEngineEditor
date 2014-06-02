using System.Diagnostics;
using System.Windows.Forms;
using System.Collections.Generic;
using AnyGameEngine;
using AnyGameEngineEditor.EditPropertyWindows;

namespace AnyGameEngineEditor.General {
	public sealed class GeneralWindow:SectionWindow {
		private ComboBox startingZoneID = new ComboBox ();
		private PropertyGrid grid = new PropertyGrid ();

		public GeneralWindow () {
			this.Text = "General";
			this.Width = 500;

			grid.Dock = DockStyle.Fill;
			this.Controls.Add (grid);
			grid.AddRow (name, "The name of the game.", EditName);
			grid.AddRow (author, "The name of the author.", EditAuthor);
			grid.AddRow (description, "A summary of the game.", EditDescription);

			//this.Controls.Add (table);
			//table.AddTextBoxRow ("Name", "The name of the game.", name, () => MainWindow.Game.Name = name.Text);
			//table.AddTextBoxRow ("Author", "The creator of the game.", author, () => MainWindow.Game.Author = author.Text);
			//table.AddTextBoxRow ("Description", "A short summary of the game.", description, () => MainWindow.Game.Description = description.Text);
			//startingZoneID.AutoCompleteSource = AutoCompleteSource.ListItems;
			//startingZoneID.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			//startingZoneID.DisplayMember = "Name";
			//startingZoneID.ValueMember = "ID";
			//table.AddComboBoxRow ("Starting Zone ID", "The ID of the starting zone.", startingZoneID, () => {});
		}

		public override void ForceUpdate () {
			grid.SetValue (name, MainWindow.Game.Name);
			grid.SetValue (author, MainWindow.Game.Author);
			grid.SetValue (description, MainWindow.Game.Description);
			//startingZoneID.DataSource = MainWindow.Game.Zones;
		}

		public void UpdateStartingZone () {
			//startingZoneID.SelectedIndex = 1;
		}

		private void EditName () {
			EditPropertyWindow window = new EditPropertyTextBoxWindow (name, MainWindow.Game.Name, null);
			
			if (window.ShowDialog (MainWindow.Instance) == System.Windows.Forms.DialogResult.OK) {
				MainWindow.Game.Name = window.Value;
				grid.SetValue (name, MainWindow.Game.Name);
			}
		}

		private void EditAuthor () {

		}

		private void EditDescription () {

		}

		private const string name = "Name";
		private const string author = "Author";
		private const string description = "Description";
	}
}
