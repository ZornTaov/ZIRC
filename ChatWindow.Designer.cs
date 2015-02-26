namespace ZIRC
{
    partial class ChatWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			this.chatBox = new System.Windows.Forms.TextBox();
			this.splitter2 = new System.Windows.Forms.Splitter();
			this.inputText = new System.Windows.Forms.TextBox();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.userList = new System.Windows.Forms.TreeView();
			this.userListContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.toggleOpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toggleVoiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.kickUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.whoisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.queryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.userListContextMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// chatBox
			// 
			this.chatBox.AcceptsReturn = true;
			this.chatBox.BackColor = System.Drawing.SystemColors.Window;
			this.chatBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.chatBox.Location = new System.Drawing.Point(0, 0);
			this.chatBox.Multiline = true;
			this.chatBox.Name = "chatBox";
			this.chatBox.ReadOnly = true;
			this.chatBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.chatBox.Size = new System.Drawing.Size(207, 242);
			this.chatBox.TabIndex = 14;
			this.chatBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.main_KeyDown);
			// 
			// splitter2
			// 
			this.splitter2.Dock = System.Windows.Forms.DockStyle.Right;
			this.splitter2.Location = new System.Drawing.Point(207, 0);
			this.splitter2.Name = "splitter2";
			this.splitter2.Size = new System.Drawing.Size(3, 242);
			this.splitter2.TabIndex = 15;
			this.splitter2.TabStop = false;
			// 
			// inputText
			// 
			this.inputText.AcceptsReturn = true;
			this.inputText.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.inputText.Location = new System.Drawing.Point(0, 242);
			this.inputText.Multiline = true;
			this.inputText.Name = "inputText";
			this.inputText.Size = new System.Drawing.Size(284, 20);
			this.inputText.TabIndex = 13;
			this.inputText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.main_KeyDown);
			this.inputText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.inputText_KeyPress);
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Interval = 1;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// userList
			// 
			this.userList.ContextMenuStrip = this.userListContextMenu;
			this.userList.Dock = System.Windows.Forms.DockStyle.Right;
			this.userList.Location = new System.Drawing.Point(210, 0);
			this.userList.Name = "userList";
			this.userList.Size = new System.Drawing.Size(74, 242);
			this.userList.TabIndex = 16;
			// 
			// userListContextMenu
			// 
			this.userListContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toggleOpToolStripMenuItem,
            this.toggleVoiceToolStripMenuItem,
            this.kickUserToolStripMenuItem,
            this.toolStripSeparator1,
            this.whoisToolStripMenuItem,
            this.queryToolStripMenuItem});
			this.userListContextMenu.Name = "userListContextMenu";
			this.userListContextMenu.Size = new System.Drawing.Size(153, 142);
			// 
			// toggleOpToolStripMenuItem
			// 
			this.toggleOpToolStripMenuItem.Name = "toggleOpToolStripMenuItem";
			this.toggleOpToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.toggleOpToolStripMenuItem.Text = "Toggle Op";
			this.toggleOpToolStripMenuItem.Click += new System.EventHandler(this.toggleOpToolStripMenuItem_Click);
			// 
			// toggleVoiceToolStripMenuItem
			// 
			this.toggleVoiceToolStripMenuItem.Name = "toggleVoiceToolStripMenuItem";
			this.toggleVoiceToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.toggleVoiceToolStripMenuItem.Text = "Toggle Voice";
			this.toggleVoiceToolStripMenuItem.Click += new System.EventHandler(this.toggleVoiceToolStripMenuItem_Click);
			// 
			// kickUserToolStripMenuItem
			// 
			this.kickUserToolStripMenuItem.Name = "kickUserToolStripMenuItem";
			this.kickUserToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.kickUserToolStripMenuItem.Text = "Kick User";
			this.kickUserToolStripMenuItem.Click += new System.EventHandler(this.kickUserToolStripMenuItem_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
			// 
			// whoisToolStripMenuItem
			// 
			this.whoisToolStripMenuItem.Name = "whoisToolStripMenuItem";
			this.whoisToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.whoisToolStripMenuItem.Text = "Whois";
			this.whoisToolStripMenuItem.Click += new System.EventHandler(this.whoisToolStripMenuItem_Click);
			// 
			// queryToolStripMenuItem
			// 
			this.queryToolStripMenuItem.Name = "queryToolStripMenuItem";
			this.queryToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.queryToolStripMenuItem.Text = "Query";
			this.queryToolStripMenuItem.Click += new System.EventHandler(this.queryToolStripMenuItem_Click);
			// 
			// ChatWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 262);
			this.Controls.Add(this.chatBox);
			this.Controls.Add(this.splitter2);
			this.Controls.Add(this.userList);
			this.Controls.Add(this.inputText);
			this.Name = "ChatWindow";
			this.Text = "ChatWindow";
			this.Activated += new System.EventHandler(this.ChatWindow_Activated);
			this.userListContextMenu.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox chatBox;
		private System.Windows.Forms.Splitter splitter2;
        public System.Windows.Forms.TextBox inputText;
		protected System.Windows.Forms.Timer timer1;
		public System.Windows.Forms.TreeView userList;
		private System.Windows.Forms.ContextMenuStrip userListContextMenu;
		private System.Windows.Forms.ToolStripMenuItem toggleOpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem toggleVoiceToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem kickUserToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem whoisToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem queryToolStripMenuItem;
    }
}