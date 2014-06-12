using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace AnyGameEngineEditor {
	public abstract class EditPropertyWindow:EditWindow {
		public object Value;

		protected ValueValidator validator;

		public EditPropertyWindow (string title, ValueValidator validator) {
			this.validator = validator;
			
			this.Text = "Edit " + title;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
		}

		public delegate bool ValueValidator (string value, out string error);
	}
}
