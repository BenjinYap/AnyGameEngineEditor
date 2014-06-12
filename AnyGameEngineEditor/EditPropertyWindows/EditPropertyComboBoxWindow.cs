using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace AnyGameEngineEditor.EditPropertyWindows {
	public class EditPropertyComboBoxWindow:EditPropertyWindow {
		private ComboBox box = new ComboBox ();

		public EditPropertyComboBoxWindow (string name, object [] items, object value, bool autoComplete):base (name, null) {
			this.SetMinimumClientSize (0, box.Height);
			this.MaximumSize = new Size (1000, this.MinimumSize.Height);

			box.Items.AddRange (items);
			box.SelectedItem = value;
			this.Value = value;
			box.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
			box.Width = this.ClientSize.Width - 19;
			
			if (autoComplete) {
				box.AutoCompleteMode = AutoCompleteMode.Suggest;
				box.AutoCompleteSource = AutoCompleteSource.ListItems;
				box.TextChanged += onTextChanged;
			} else {
				box.DropDownStyle = ComboBoxStyle.DropDownList;
				box.SelectedIndexChanged += onSelectedIndexChanged;
			}

			this.Controls.Add (box);
			
			this.Shown += onShown;
			this.FormClosed += onFormClosed;
		}

		private void onShown (object obj, EventArgs e) {
			box.Focus ();
		}

		private void onFormClosed (object obj, EventArgs e) {
			this.Shown -= onShown;
			this.FormClosed -= onFormClosed;
			box.TextChanged -= onTextChanged;
			box.SelectedIndexChanged -= onSelectedIndexChanged;
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
