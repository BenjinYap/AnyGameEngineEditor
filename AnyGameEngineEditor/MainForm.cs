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

		private SectionForm draggingSectionForm;
		private bool docked = false;
		private DockContainer mainDockContainer = new DockContainer ();

		private Panel [] dockPanels;
		private Panel dockPanelTop = new Panel ();
		private Panel dockPanelBottom = new Panel ();
		private Panel dockPanelLeft = new Panel ();
		private Panel dockPanelRight = new Panel ();
		
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
			table.Controls.Add (mainDockContainer);
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
			draggingSectionForm = (SectionForm) obj;
			draggingSectionForm.Opacity = 0.5;
			draggingSectionForm.LocationChanged += onDraggingSectionFormLocationChanged;
		}

		private void onSectionFormDragEnd (object obj, EventArgs e) {
			draggingSectionForm.Opacity = 1;
			draggingSectionForm.LocationChanged -= onDraggingSectionFormLocationChanged;

			/*if (docked == false) {
				if (this.ClientRectangle.Contains (this.PointToClient (Cursor.Position))) {
					DockMainSection (mainSections.Find (section => section.Form == draggingSectionForm));
				}
			}*/
			mainDockContainer.CheckDragEnd ();
		}

		private void onDraggingSectionFormLocationChanged (object obj, EventArgs e) {
			/*if (docked == false) {
				if (this.ClientRectangle.Contains (this.PointToClient (Cursor.Position))) {
					dockPanelTop.Location = new Point (table.Location.X, mainMenuStrip.Height);
					dockPanelTop.Size = new Size (table.Width, table.Height - mainMenuStrip.Height);
					dockPanelTop.Show ();
				} else {
					dockPanelTop.Hide ();
				}
			}*/
			mainDockContainer.CheckDragPosition ();
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
			foreach (Panel panel in dockPanels) {
				panel.Hide ();
			}

			section.MoveToPanel ();

			if (docked == false) {
				docked = true;
				table.Controls.Add (section.Panel);
			} else {

			}
		}

		public static Action awd = () => new Panel ().DoDragDrop (123, DragDropEffects.All);
		public static MainForm Instance;
		public static Game Game;
		public static ErrorProvider Error;
		public static MainSection DraggingSection;
		private static Stack <Action> undos = new Stack <Action> ();
	}

}
