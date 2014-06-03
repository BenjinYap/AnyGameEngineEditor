using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace AnyGameEngineEditor.EditPropertyWindows {
	public class EditPropertyComboBoxWindow:EditPropertyWindow {
		private ComboBox box = new ComboBox ();

		public EditPropertyComboBoxWindow (string name, object [] items, object value, bool autoComplete):base (name, null) {
			box.Items.AddRange (items);
			box.SelectedItem = value;
			this.Value = value;
			box.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
			box.Left = EditPropertyWindow.LabelWidth;
			box.Width = this.ClientSize.Width - EditPropertyWindow.LabelWidth - 19;
			
			if (autoComplete) {
				box.AutoCompleteMode = AutoCompleteMode.Suggest;
				box.AutoCompleteSource = AutoCompleteSource.ListItems;
				box.TextChanged += onTextChanged;
			} else {
				box.DropDownStyle = ComboBoxStyle.DropDownList;
				box.SelectedIndexChanged += onSelectedIndexChanged;
			}

			this.Panel.Controls.Add (box);
			
			this.Shown += (a, b) => box.Focus ();
		}

		private void onSelectedIndexChanged (object obj, EventArgs e) {
			this.Value = box.SelectedItem;
		}

		private void onTextChanged (object obj, EventArgs e) {
			bool valid = false;
			
			foreach (object item in box.Items) {
				if (box.Text == item.ToString ()) {
					box.SelectedItem = item;
					valid = true;
					break;
				}
			}
			
			if (valid) {
				this.Value = box.SelectedItem;
				MainWindow.Error.SetError (box, "");
				this.EnableConfirm ();
			} else {
				MainWindow.Error.SetError (box, "Not a valid item.");
				this.DisableConfirm ();
			}
		}
	}
}
