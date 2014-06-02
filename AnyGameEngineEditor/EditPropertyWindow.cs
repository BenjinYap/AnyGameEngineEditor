using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnyGameEngineEditor {
	public class EditPropertyWindow:EditWindow {
		public string Value;

		private Action validateAction;

		public EditPropertyWindow (EditPropertyType type, string name, string value, Action validateAction) {
			this.validateAction = validateAction;

			this.Text = "Edit " + name;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;

			Label label = new Label ();
			label.Text = name;
			label.Width = 100;
			label.BackColor = Color.Red;
			
			this.Panel.Controls.Add (label);
			
			if (type == EditPropertyType.Text) {
				TextBox box = new TextBox ();
				box.Text = value;
				box.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
				box.Left = label.Width;
				box.Width = this.ClientSize.Width - label.Width - 19;
				this.Panel.Controls.Add (box);
				box.Multiline = true;
				box.WordWrap = true;
			}
		}

		public EditPropertyWindow (EditPropertyType type, string name, string value):this (type, name, value, null) {

		}
	}

	public enum EditPropertyType {Text, ComboBox};
}
