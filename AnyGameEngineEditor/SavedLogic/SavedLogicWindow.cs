using System.Windows.Forms;
using System.Diagnostics;
using AnyGameEngine;
using AnyGameEngine.LogicItems;
using System.Text;
using System.Collections.Generic;
using System;

namespace AnyGameEngineEditor.SavedLogic {
	public sealed class SavedLogicWindow:SectionWindow {
		private LogicEditor logicEditor = new LogicEditor ();

		public SavedLogicWindow () {
			this.Text = "Saved Logic";

			this.Controls.Add (logicEditor);
		}

		public override void ForceUpdate () {
			MainWindow.Game.SavedLogic.ForEach (logic => {
				logicEditor.AddLogicToTree (logic);
			});
		}

		public void UpdatedLogic (LogicBase logic) {
			logicEditor.UpdatedLogic (logic);
		}

		public override void EngageLayoutTracking () {
			logicEditor.SplitterMoved += onSplitterMoved;
		}

		public override void DisengageLayoutTracking () {
			logicEditor.SplitterMoved -= onSplitterMoved;
		}

		public override void LoadIDE (Dictionary<string, string> pairs) {
			if (pairs.ContainsKey ("savedLogicLogicEditorSplit")) {
				logicEditor.SplitterDistance = int.Parse (pairs ["savedLogicLogicEditorSplit"]);
			}
		}

		public override void SaveIDE (StringBuilder sb) {
			sb.AppendLine ("savedLogicLogicEditorSplit=" + logicEditor.SplitterDistance);
		}

		private void onSplitterMoved (object obj, EventArgs e) {
			MainWindow.Instance.SaveIDE ();
		}
	}
}
