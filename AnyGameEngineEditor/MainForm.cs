using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AnyGameEngine;
using AnyGameEngine.LogicItems;
using AnyGameEngineEditor.MainSections.General;

namespace AnyGameEngineEditor {
	public partial class MainForm : Form {
		public Game Game;

		private List <MainSection> mainSections = new List<MainSection> ();
		private GeneralSection generalSection;

		public MainForm () {
			InitializeComponent ();
			Instance = this;
			
			generalSection = new GeneralSection (this);
			generalSection.MoveToForm ();
			mainSections.Add (generalSection);

			LoadGame (@"C:\Users\Benjin\Desktop\Bitbucket\AnyGameEngineEditor\AnyGameEngineEditor\bin\Debug\Games\Pokemon test\test.xml");
		}

		private void onOpenGameClick (object sender, EventArgs e) {

		}

		private void onSaveGameClick (object sender, EventArgs e) {

		}

		private void onExitClick (object sender, EventArgs e) {
			Application.Exit ();
		}

		private bool LoadGame (string path) {
			Game = new Game ();
			
			if (Game.Load (path)) {
				/*foreach (TabPage page in this.mainTabControl.TabPages) {
					if (page.Controls.Count > 0) {
						((MainTabPanel) page.Controls [0]).UpdatePanel ();
					}
				}*/

				mainSections.ForEach (section => section.Refresh ());
				return true;
			} else {
				return false;
			}
		}

		public static Form Instance;
	}

}
