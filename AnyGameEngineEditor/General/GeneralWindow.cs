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
			grid.AddRow (startingZone, "The starting zone of the game.", EditStartingZone);

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
			//grid.SetValue (name, MainWindow.Game.Name);
			//grid.SetValue (author, MainWindow.Game.Author);
			//grid.SetValue (description, MainWindow.Game.Description);
			//grid.SetValue (startingZone, Helper.GetZoneText (MainWindow.Game.StartingZone));
			SetName (MainWindow.Game.Name);
			SetAuthor (MainWindow.Game.Author);
			SetDescription (MainWindow.Game.Description);
			SetStartingZone (MainWindow.Game.StartingZone);
			//startingZoneID.DataSource = MainWindow.Game.Zones;
		}

		public void UpdateStartingZone () {
			//startingZoneID.SelectedIndex = 1;
		}

		private void EditName () {
			EditPropertyWindow window = new EditPropertyTextBoxWindow (name, MainWindow.Game.Name, null);
			
			if (window.ShowDialog (MainWindow.Instance) == System.Windows.Forms.DialogResult.OK) {
				string before = MainWindow.Game.Name;
				MainWindow.Instance.PushUndo (() => SetName (before));
				SetName ((string) window.Value);
			}
		}

		private void SetName (string value) {
			MainWindow.Game.Name = value;
			grid.SetValue (name, value);
		}

		private void EditAuthor () {
			EditPropertyWindow window = new EditPropertyTextBoxWindow (author, MainWindow.Game.Author, null);
			
			if (window.ShowDialog (MainWindow.Instance) == System.Windows.Forms.DialogResult.OK) {
				string before = MainWindow.Game.Author;
				MainWindow.Instance.PushUndo (() => SetAuthor (before));
				SetAuthor ((string) window.Value);
			}
		}

		private void SetAuthor (string value) {
			MainWindow.Game.Author = value;
			grid.SetValue (author, value);
		}

		private void EditDescription () {
			EditPropertyWindow window = new EditPropertyTextBoxWindow (name, MainWindow.Game.Description, null);
			
			if (window.ShowDialog (MainWindow.Instance) == System.Windows.Forms.DialogResult.OK) {
				string before = MainWindow.Game.Description;
				MainWindow.Instance.PushUndo (() => SetDescription (before));
				SetDescription ((string) window.Value);
			}
		}

		private void SetDescription (string value) {
			MainWindow.Game.Description = value;
			grid.SetValue (description, value);
		}

		private void EditStartingZone () {
			EditPropertyWindow window = new EditPropertyComboBoxWindow (startingZone, MainWindow.Game.Zones.ToArray (), MainWindow.Game.StartingZone, false);
			
			if (window.ShowDialog (MainWindow.Instance) == System.Windows.Forms.DialogResult.OK) {
				Zone before = MainWindow.Game.StartingZone;
				MainWindow.Instance.PushUndo (() => SetStartingZone (before));
				SetStartingZone ((Zone) window.Value);
			}
		}

		private void SetStartingZone (Zone value) {
			MainWindow.Game.StartingZone = value;
			grid.SetValue (startingZone, value.ToString ());
		}

		private const string name = "Name";
		private const string author = "Author";
		private const string description = "Description";
		private const string startingZone = "Starting Zone";
	}
}
