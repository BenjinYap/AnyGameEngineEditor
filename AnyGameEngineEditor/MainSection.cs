using System.Windows.Forms;
using System.Collections.Generic;

namespace AnyGameEngineEditor {
	public abstract class MainSection {
		protected Form Form = new Form ();
		protected Panel Panel;
		protected List <Control> SharedControls = new List<Control> ();

		protected string Title = "";

		public void MoveToForm () {
			Form.Text = Title;
			SharedControls.ForEach (control => Form.Controls.Add (control));
			Form.Show (MainForm.Instance);
		}

		public void MoveToPanel () {

		}

		public abstract void Refresh ();
	}
}
