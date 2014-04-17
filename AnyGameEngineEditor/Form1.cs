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

namespace AnyGameEngineEditor {
	public partial class Form1 : Form {
		private object originalValue = null;
		private Timer timer = new Timer ();
		private bool canPushUndo = true;

		public Form1 () {
			InitializeComponent ();
			
			timer.Interval = 500;
			timer.Tick += (a, b) => {
				timer.Stop ();
				canPushUndo = true;
			};

		}

		private void onTextBoxGotFocus (object obj, EventArgs e) {
			originalValue = ((TextBox) obj).Text;
		}

		private void onTextBoxLostFocus (object obj, EventArgs e) {
			/*if (((TextBox) obj).Text != (string) originalValue) {
				Debug.WriteLine ("B");
				string undoValue = (string) originalValue;
				MainForm.Instance.PushUndo (() => ((TextBox) obj).Text = undoValue);
			}*/
		}

		private void onTextBoxTextChanged (object obj, EventArgs e) {
			if (canPushUndo && ((TextBox) obj).Text != (string) originalValue) {
				canPushUndo = false;
				timer.Start ();
				string undoValue = (string) originalValue;
				originalValue = ((TextBox) obj).Text;
				//MainForm.Instance.PushUndo (() => {((TextBox) obj).Text = "AAA";Debug.WriteLine (undoValue);});
				MainForm.Instance.PushUndo (() => {});
				Debug.WriteLine (undoValue);
			}
		}

		private void PushUndo (Action action) {
			undos.Push (action);
			Debug.WriteLine ("push");
		}

		private void Undo () {
			if (undos.Count > 0) {
				Action action = undos.Pop ();
				action ();
				//mainSections.ForEach (section => section.Refresh ());
				Debug.WriteLine ("undo");
			}
		}

		private Stack <Action> undos = new Stack <Action> ();
	}
}
