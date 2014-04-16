using System.Windows.Forms;
using System.Collections.Generic;

namespace AnyGameEngineEditor {
	public abstract class MainSection {
		protected MainForm MainForm;

		protected Form Form = new Form ();
		protected Panel Panel;
		protected List <Control> SharedControls = new List<Control> ();

		protected string Title = "";

		public MainSection (MainForm mainForm) {
			MainForm = mainForm;
		}

		public void MoveToForm () {
			Form.Text = Title;
			SharedControls.ForEach (control => Form.Controls.Add (control));
			Form.Show (MainForm);
		}

		public void MoveToPanel () {

		}

		public abstract void Refresh ();
	}
}
