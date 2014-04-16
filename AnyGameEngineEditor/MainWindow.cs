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

namespace AnyGameEngineEditor {
	public partial class MainWindow : Form {
		public Game Game;

		public MainWindow () {
			InitializeComponent ();
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

				return true;
			} else {
				return false;
			}
		}
	}

}
