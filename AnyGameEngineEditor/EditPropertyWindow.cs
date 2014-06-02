using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace AnyGameEngineEditor {
	public class EditPropertyWindow:EditWindow {
		public string Value;

		protected Func <string, bool> validator;

		public EditPropertyWindow (string name, Func <string, bool> validator) {
			this.validator = validator;
			
			this.Text = "Edit " + name;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;

			Label label = new Label ();
			label.Text = name;
			label.Width = LabelWidth;
			this.Panel.Controls.Add (label);
		}

		protected const int LabelWidth = 100;
	}
}
