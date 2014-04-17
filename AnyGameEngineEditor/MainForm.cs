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
		private List <MainSection> mainSections = new List<MainSection> ();
		private GeneralSection generalSection;
		private GeneralSection generalSection2;

		private bool docked = false;

		public MainForm () {
			InitializeComponent ();
			Instance = this;
			Error = new ErrorProvider (this);
			Error.BlinkStyle = ErrorBlinkStyle.NeverBlink;
			
			generalSection = new GeneralSection ();
			generalSection.MoveToForm ();
			mainSections.Add (generalSection);

			//generalSection2 = new GeneralSection ();
			//generalSection2.MoveToForm ();
			//mainSections.Add (generalSection2);

			mainSections.ForEach (section => {
				section.Form.FormDragStart += onSectionFormDragStart;
				section.Form.FormDragEnd += onSectionFormDragEnd;
			});

			LoadGame (@"C:\Users\Benjin\Desktop\Bitbucket\AnyGameEngineEditor\AnyGameEngineEditor\bin\Debug\Games\Pokemon test\test.xml");
			//DockMainSection (generalSection);
		}
		
		public void PushUndo (Action action) {
			undos.Push (action);
		}

		public void Undo () {
			if (undos.Count > 0) {
				Action action = undos.Pop ();
				action ();
				RefreshSections ();
			}
		}

		public void RefreshSections () {
			mainSections.ForEach (section => section.Refresh ());
		}

		protected override bool ProcessCmdKey (ref Message msg, Keys keyData) {
			if (keyData == (Keys.Control | Keys.Z)) {
				MainForm.Instance.Undo ();
				return true;
			}

			return base.ProcessCmdKey (ref msg, keyData);
		}

		private void onOpenGameClick (object sender, EventArgs e) {

		}

		private void onSaveGameClick (object sender, EventArgs e) {

		}

		private void onExitClick (object sender, EventArgs e) {
			Application.Exit ();
		}

		private void onSectionFormDragStart (object obj, EventArgs e) {
			
		}

		private void onSectionFormDragEnd (object obj, EventArgs e) {
			
		}

		private bool LoadGame (string path) {
			Game = new Game ();
			
			if (Game.Load (path)) {
				RefreshSections ();
				return true;
			} else {
				return false;
			}
		}

		private void DockMainSection (MainSection section) {
			section.MoveToPanel ();

			if (docked == false) {
				docked = true;
				table.Controls.Add (section.Panel);
			} else {

			}
		}

		public static MainForm Instance;
		public static Game Game;
		public static ErrorProvider Error;
		private static Stack <Action> undos = new Stack <Action> ();
	}

}
