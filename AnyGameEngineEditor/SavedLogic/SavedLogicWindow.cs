﻿using System.Windows.Forms;
using System.Diagnostics;
using AnyGameEngine;
using AnyGameEngine.LogicItems;
using System.Text;

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

		public override void SaveIDE (StringBuilder sb) {
			throw new System.NotImplementedException ();
		}
	}
}
