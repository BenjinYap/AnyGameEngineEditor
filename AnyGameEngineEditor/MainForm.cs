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
using AnyGameEngineEditor.SectionForms.General;
using CSharpControls;

namespace AnyGameEngineEditor {

	public partial class MainForm : Form {
		private List <SectionForm> sectionForms = new List<SectionForm> ();
		private GeneralForm generalForm;
		private GeneralForm generalForm2;

		private CSSDockManager dockManager = new CSSDockManager ();
		
		public MainForm () {
			InitializeComponent ();
			Instance = this;
			Error = new ErrorProvider (this);
			Error.BlinkStyle = ErrorBlinkStyle.NeverBlink;
			
			dockManager.Dock = DockStyle.Fill;
			table.Controls.Add (dockManager);
			
			generalForm = new GeneralForm ();
			generalForm2 = new GeneralForm ();
			generalForm.Show (this);
			generalForm2.Show (this);
			sectionForms.AddRange (new SectionForm [] {generalForm, generalForm2});
			dockManager.RegisterDockableForm (generalForm);
			dockManager.RegisterDockableForm (generalForm2);
			
			LoadGame (@"C:\Users\Benjin\Desktop\Bitbucket\AnyGameEngineEditor\AnyGameEngineEditor\bin\Debug\Games\Pokemon test\test.xml");
			dockManager.DockForm (null, generalForm, "AWD", CSSDockManager.DockDirection.Bottom);
			dockManager.DockForm ("AWD", generalForm2, "DWA", CSSDockManager.DockDirection.Bottom);
			//generalForm.Hide ();
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
			sectionForms.ForEach (form => form.RefreshContent ());
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

		private bool LoadGame (string path) {
			Game = new Game ();
			
			if (Game.Load (path)) {
				RefreshSections ();
				return true;
			} else {
				return false;
			}
		}

		public static MainForm Instance;
		public static Game Game;
		public static ErrorProvider Error;
		private static Stack <Action> undos = new Stack <Action> ();
	}

}
