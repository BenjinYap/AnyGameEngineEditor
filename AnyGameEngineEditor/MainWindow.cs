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
using AnyGameEngineEditor.General;
using CSharpControls.DockManager;
using AnyGameEngineEditor.Zones;
using AnyGameEngineEditor.SavedLogic;
using System.IO;

namespace AnyGameEngineEditor {

	public partial class MainWindow : Form {
		private List <SectionWindow> sectionForms = new List<SectionWindow> ();
		private GeneralWindow generalWindow;
		private ZonesWindow zonesWindow;
		private SavedLogicWindow savedLogicWindow;
		
		private CSSDockManager dockManager = new CSSDockManager ();
		
		public MainWindow () {
			InitializeComponent ();
			Instance = this;
			Error = new ErrorProvider (this);
			Error.BlinkStyle = ErrorBlinkStyle.NeverBlink;
			
			dockManager.Dock = DockStyle.Fill;
			table.Controls.Add (dockManager);
			
			generalWindow = new GeneralWindow ();
			GeneralWindow = generalWindow;
			zonesWindow = new ZonesWindow ();
			ZonesWindow = zonesWindow;
			savedLogicWindow = new SavedLogicWindow ();
			SavedLogicWindow = savedLogicWindow;
			sectionForms.AddRange (new SectionWindow [] {generalWindow, zonesWindow, savedLogicWindow});

			for (int i = 0; i < sectionForms.Count; i++) {
				dockManager.RegisterDockableForm ((i + 1).ToString (), sectionForms [i]);
				sectionForms [i].Owner = this;
				sectionForms [i].Show ();
			}
			
			LoadGame (@"C:\Users\Benjin\Desktop\Bitbucket\AnyGameEngineEditor\AnyGameEngineEditor\bin\Debug\Games\Pokemon test\test.xml");
			
			this.ResizeBegin += (s, e) => { this.SuspendLayout(); };
			this.ResizeEnd += (s, e) => { this.ResumeLayout(true); };

			dockManager.LoadLayout ();
			
			foreach (ToolStripItem item in viewMenu.DropDownItems) {
				item.Click += onViewItemClick;
			}

			this.Paint += onWindowReady;
		}

		public void LoadIDE () {
			if (File.Exists ("ide.txt") == false) {
				return;
			}
			
			string [] lines = File.ReadAllLines ("ide.txt");
			Dictionary <string, string> pairs = new Dictionary<string,string> ();

			for (int i = 0; i < lines.Length; i++) {
				string [] pair = lines [i].Split ('=');
				pairs.Add (pair [0], pair [1]);
			}

			sectionForms.ForEach (form => form.LoadIDE (pairs));
		}

		public void SaveIDE () {
			StringBuilder sb = new StringBuilder ();
			sectionForms.ForEach (form => form.SaveIDE (sb));
			File.WriteAllText ("ide.txt", sb.ToString ());
		}
		
		public void PushUndo (Action action) {
			undos.Push (action);
		}

		public void Undo () {
			
			if (undos.Count > 0) {
				Action action = undos.Pop ();
				action ();
				//RefreshSections ();
			}
		}

		public void RefreshSections () {
			sectionForms.ForEach (form => form.ForceUpdate ());
		}

		protected override bool ProcessCmdKey (ref Message msg, Keys keyData) {
			if (keyData == (Keys.Control | Keys.Z)) {
				MainWindow.Instance.Undo ();
				return true;
			}

			return base.ProcessCmdKey (ref msg, keyData);
		}

		private void onWindowReady (object obj, EventArgs e) {
			this.Paint -= onWindowReady;
			LoadIDE ();
			sectionForms.ForEach (form => form.EngageLayoutTracking ());
		}

		private void onOpenGameClick (object sender, EventArgs e) {

		}

		private void onSaveGameClick (object sender, EventArgs e) {
			
		}

		private void onViewItemClick (object sender, EventArgs e) {
			SectionWindow form = sectionForms [viewMenu.DropDownItems.IndexOf ((ToolStripItem) sender)];
			form.Visible = !form.Visible;
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

		public static MainWindow Instance;
		public static GeneralWindow GeneralWindow;
		public static ZonesWindow ZonesWindow;
		public static SavedLogicWindow SavedLogicWindow;

		public static Game Game;

		public static ErrorProvider Error;

		private static Stack <Action> undos = new Stack <Action> ();
	}

}
