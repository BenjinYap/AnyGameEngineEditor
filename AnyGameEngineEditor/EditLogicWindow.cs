using CSharpControls;
using System.Diagnostics;
using System.Windows.Forms;

namespace AnyGameEngineEditor.EditLogicWindows {
	public class EditLogicWindow:EditWindow {
		protected CSSLinkLabel Label = new CSSLinkLabel ();

		public EditLogicWindow () {
			Label.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom;
			Label.Width = this.ClientSize.Width;
			Label.Height = this.Confirm.Location.Y;
			this.Controls.Add (Label);
		}
	}
}
