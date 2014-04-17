using System.Windows.Forms;
using System.Collections.Generic;
using System.Diagnostics;

namespace AnyGameEngineEditor {
	public abstract class MainSection {
		protected SectionForm Form = new SectionForm ();
		protected Panel Panel;
		protected List <Control> SharedControls = new List<Control> ();

		protected string Title = "";

		public void MoveToForm () {
			Form.Text = Title;
			SharedControls.ForEach (control => Form.Controls.Add (control));
			Form.Show (MainForm.Instance);
			Form.KeyDown += (a, b)  => {Debug.WriteLine ("A");};
		}

		public void MoveToPanel () {

		}

		public abstract void Refresh ();
	}
}
