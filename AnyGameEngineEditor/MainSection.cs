using System.Windows.Forms;
using System.Collections.Generic;
using System.Diagnostics;

namespace AnyGameEngineEditor {
	public abstract class MainSection {
		/*public SectionForm Form = new SectionForm ();
		public Panel Panel = new Panel ();
		public string Title = "";
		
		protected List <Control> SharedControls = new List<Control> ();

		public MainSection () {
			Panel.Dock = DockStyle.Fill;
			Form.Section = this;
		}

		public void MoveToForm () {
			Form.Text = Title;
			SharedControls.ForEach (control => Form.Controls.Add (control));
			Form.Show (MainForm.Instance);
		}

		public void MoveToPanel () {
			Form.Hide ();
			SharedControls.ForEach (control => Panel.Controls.Add (control));
		}

		public abstract void Refresh ();*/
	}
}
