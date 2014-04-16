using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnyGameEngineEditor {
	public partial class Form1 : Form {
		public Form1 () {
			InitializeComponent ();
			textBox1.Dock = DockStyle.Fill;
			errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
			errorProvider1.SetError (textBox1, "A");
			
		}
	}
}
