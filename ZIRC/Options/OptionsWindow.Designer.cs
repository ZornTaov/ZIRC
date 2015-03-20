namespace ZIRC.Options
{
	partial class OptionsWindow
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose( bool disposing )
		{
			if ( disposing && ( components != null ) )
			{
				components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("General");
			System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("IRC");
			System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Style");
			System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Text To Speach");
			System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("User Info");
			System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("Logging");
			this.Options = new System.Windows.Forms.TreeView();
			this.panel1 = new System.Windows.Forms.Panel();
			this.Apply = new System.Windows.Forms.Button();
			this.Cancel = new System.Windows.Forms.Button();
			this.Ok = new System.Windows.Forms.Button();
			this.OptionsPanal = new System.Windows.Forms.Panel();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// Options
			// 
			this.Options.Dock = System.Windows.Forms.DockStyle.Left;
			this.Options.Location = new System.Drawing.Point(0, 0);
			this.Options.Name = "Options";
			treeNode13.Name = "General";
			treeNode13.Text = "General";
			treeNode14.Name = "IRC";
			treeNode14.Text = "IRC";
			treeNode15.Name = "Style";
			treeNode15.Text = "Style";
			treeNode16.Name = "TTS";
			treeNode16.Text = "Text To Speach";
			treeNode17.Name = "UserInfo";
			treeNode17.Text = "User Info";
			treeNode18.Name = "Logging";
			treeNode18.Text = "Logging";
			this.Options.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode13,
            treeNode14,
            treeNode15,
            treeNode16,
            treeNode17,
            treeNode18});
			this.Options.Size = new System.Drawing.Size(120, 400);
			this.Options.TabIndex = 2;
			this.Options.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.Options_AfterSelect);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.Apply);
			this.panel1.Controls.Add(this.Cancel);
			this.panel1.Controls.Add(this.Ok);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(120, 354);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(500, 46);
			this.panel1.TabIndex = 3;
			// 
			// Apply
			// 
			this.Apply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.Apply.Location = new System.Drawing.Point(413, 11);
			this.Apply.Name = "Apply";
			this.Apply.Size = new System.Drawing.Size(75, 23);
			this.Apply.TabIndex = 2;
			this.Apply.Text = "Apply";
			this.Apply.UseVisualStyleBackColor = true;
			this.Apply.Click += new System.EventHandler(this.Apply_Click);
			// 
			// Cancel
			// 
			this.Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.Cancel.Location = new System.Drawing.Point(332, 11);
			this.Cancel.Name = "Cancel";
			this.Cancel.Size = new System.Drawing.Size(75, 23);
			this.Cancel.TabIndex = 1;
			this.Cancel.Text = "Cancel";
			this.Cancel.UseVisualStyleBackColor = true;
			this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
			// 
			// Ok
			// 
			this.Ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.Ok.Location = new System.Drawing.Point(251, 11);
			this.Ok.Name = "Ok";
			this.Ok.Size = new System.Drawing.Size(75, 23);
			this.Ok.TabIndex = 0;
			this.Ok.Text = "Ok";
			this.Ok.UseVisualStyleBackColor = true;
			this.Ok.Click += new System.EventHandler(this.Ok_Click);
			// 
			// OptionsPanal
			// 
			this.OptionsPanal.Dock = System.Windows.Forms.DockStyle.Fill;
			this.OptionsPanal.Location = new System.Drawing.Point(120, 0);
			this.OptionsPanal.Name = "OptionsPanal";
			this.OptionsPanal.Size = new System.Drawing.Size(500, 354);
			this.OptionsPanal.TabIndex = 4;
			// 
			// OptionsWindow
			// 
			this.AcceptButton = this.Ok;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.Cancel;
			this.ClientSize = new System.Drawing.Size(620, 400);
			this.Controls.Add(this.OptionsPanal);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.Options);
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(636, 438);
			this.MinimumSize = new System.Drawing.Size(636, 438);
			this.Name = "OptionsWindow";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "OptionsWindow";
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		internal System.Windows.Forms.TreeView Options;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button Apply;
		private System.Windows.Forms.Button Cancel;
		private System.Windows.Forms.Button Ok;
		private System.Windows.Forms.Panel OptionsPanal;

	}
}