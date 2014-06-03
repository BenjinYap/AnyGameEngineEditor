using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace AnyGameEngineEditor {
	public class EditPropertyWindow:EditWindow {
		public object Value;

		protected ValueValidator validator;

		public EditPropertyWindow (string name, ValueValidator validator) {
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

		public delegate bool ValueValidator (string value, out string error);
	}
}
