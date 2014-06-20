namespace AnyGameEngineEditor {
	partial class MainWindow {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose (bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose ();
			}
			base.Dispose (disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent () {
			this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openGameItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveGameItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitItem = new System.Windows.Forms.ToolStripMenuItem();
			this.viewMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.viewMenuGeneral = new System.Windows.Forms.ToolStripMenuItem();
			this.table = new System.Windows.Forms.TableLayoutPanel();
			this.zonesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.savedLogicToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.mainMenuStrip.SuspendLayout();
			this.table.SuspendLayout();
			this.SuspendLayout();
			// 
			// mainMenuStrip
			// 
			this.mainMenuStrip.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewMenu});
			this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
			this.mainMenuStrip.Name = "mainMenuStrip";
			this.mainMenuStrip.Size = new System.Drawing.Size(1133, 30);
			this.mainMenuStrip.TabIndex = 1;
			this.mainMenuStrip.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openGameItem,
            this.saveGameItem,
            this.saveAsToolStripMenuItem,
            this.exitItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 26);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// newToolStripMenuItem
			// 
			this.newToolStripMenuItem.Name = "newToolStripMenuItem";
			this.newToolStripMenuItem.Size = new System.Drawing.Size(167, 24);
			this.newToolStripMenuItem.Text = "New";
			// 
			// openGameItem
			// 
			this.openGameItem.Name = "openGameItem";
			this.openGameItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
			this.openGameItem.Size = new System.Drawing.Size(167, 24);
			this.openGameItem.Text = "Open";
			this.openGameItem.Click += new System.EventHandler(this.onOpenGameClick);
			// 
			// saveGameItem
			// 
			this.saveGameItem.Name = "saveGameItem";
			this.saveGameItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.saveGameItem.Size = new System.Drawing.Size(167, 24);
			this.saveGameItem.Text = "Save";
			this.saveGameItem.Click += new System.EventHandler(this.onSaveGameClick);
			// 
			// saveAsToolStripMenuItem
			// 
			this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
			this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(167, 24);
			this.saveAsToolStripMenuItem.Text = "Save As";
			// 
			// exitItem
			// 
			this.exitItem.Name = "exitItem";
			this.exitItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
			this.exitItem.Size = new System.Drawing.Size(167, 24);
			this.exitItem.Text = "Exit";
			this.exitItem.Click += new System.EventHandler(this.onExitClick);
			// 
			// viewMenu
			// 
			this.viewMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewMenuGeneral,
            this.zonesToolStripMenuItem,
            this.savedLogicToolStripMenuItem});
			this.viewMenu.Name = "viewMenu";
			this.viewMenu.Size = new System.Drawing.Size(53, 26);
			this.viewMenu.Text = "View";
			// 
			// viewMenuGeneral
			// 
			this.viewMenuGeneral.Name = "viewMenuGeneral";
			this.viewMenuGeneral.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D1)));
			this.viewMenuGeneral.Size = new System.Drawing.Size(208, 24);
			this.viewMenuGeneral.Text = "General";
			// 
			// table
			// 
			this.table.ColumnCount = 1;
			this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.table.Controls.Add(this.mainMenuStrip, 0, 0);
			this.table.Dock = System.Windows.Forms.DockStyle.Fill;
			this.table.Location = new System.Drawing.Point(0, 0);
			this.table.Margin = new System.Windows.Forms.Padding(0);
			this.table.Name = "table";
			this.table.RowCount = 2;
			this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.table.Size = new System.Drawing.Size(1133, 653);
			this.table.TabIndex = 2;
			// 
			// zonesToolStripMenuItem
			// 
			this.zonesToolStripMenuItem.Name = "zonesToolStripMenuItem";
			this.zonesToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D2)));
			this.zonesToolStripMenuItem.Size = new System.Drawing.Size(208, 24);
			this.zonesToolStripMenuItem.Text = "Zones";
			// 
			// savedLogicToolStripMenuItem
			// 
			this.savedLogicToolStripMenuItem.Name = "savedLogicToolStripMenuItem";
			this.savedLogicToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D3)));
			this.savedLogicToolStripMenuItem.Size = new System.Drawing.Size(208, 24);
			this.savedLogicToolStripMenuItem.Text = "Saved Logic";
			// 
			// MainWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1133, 653);
			this.Controls.Add(this.table);
			this.Name = "MainWindow";
			this.Text = "Form1";
			this.mainMenuStrip.ResumeLayout(false);
			this.mainMenuStrip.PerformLayout();
			this.table.ResumeLayout(false);
			this.table.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.MenuStrip mainMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openGameItem;
		private System.Windows.Forms.ToolStripMenuItem saveGameItem;
		private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitItem;
		private System.Windows.Forms.TableLayoutPanel table;
		private System.Windows.Forms.ToolStripMenuItem viewMenu;
		private System.Windows.Forms.ToolStripMenuItem viewMenuGeneral;
		private System.Windows.Forms.ToolStripMenuItem zonesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem savedLogicToolStripMenuItem;
	}
}

