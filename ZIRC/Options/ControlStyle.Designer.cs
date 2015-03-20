namespace ZIRC.Options
{
	partial class ControlStyle
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.selFont = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.ResetAll = new System.Windows.Forms.Button();
			this.Reset = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.fontDialog1 = new System.Windows.Forms.FontDialog();
			this.label4 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.panel1);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.groupBox1.Location = new System.Drawing.Point(10, 178);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(10);
			this.groupBox1.Size = new System.Drawing.Size(480, 166);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Font";
			// 
			// label1
			// 
			this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label1.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::ZIRC.Properties.Settings.Default, "mainFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label1.Font = global::ZIRC.Properties.Settings.Default.mainFont;
			this.label1.Location = new System.Drawing.Point(10, 52);
			this.label1.Margin = new System.Windows.Forms.Padding(10);
			this.label1.Name = "label1";
			this.label1.Padding = new System.Windows.Forms.Padding(10);
			this.label1.Size = new System.Drawing.Size(460, 104);
			this.label1.TabIndex = 1;
			this.label1.Text = "The quick brown fox jumped over the lazy dog";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.selFont);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(10, 23);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(460, 29);
			this.panel1.TabIndex = 2;
			// 
			// selFont
			// 
			this.selFont.Location = new System.Drawing.Point(3, 3);
			this.selFont.Name = "selFont";
			this.selFont.Size = new System.Drawing.Size(75, 23);
			this.selFont.TabIndex = 1;
			this.selFont.Text = "Select Font";
			this.selFont.UseVisualStyleBackColor = true;
			this.selFont.Click += new System.EventHandler(this.selFont_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.ResetAll);
			this.groupBox2.Controls.Add(this.Reset);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.panel2);
			this.groupBox2.Controls.Add(this.listBox1);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox2.Location = new System.Drawing.Point(10, 10);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(480, 168);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Colors";
			// 
			// ResetAll
			// 
			this.ResetAll.Location = new System.Drawing.Point(395, 54);
			this.ResetAll.Name = "ResetAll";
			this.ResetAll.Size = new System.Drawing.Size(75, 23);
			this.ResetAll.TabIndex = 4;
			this.ResetAll.Text = "Reset All";
			this.ResetAll.UseVisualStyleBackColor = true;
			// 
			// Reset
			// 
			this.Reset.Location = new System.Drawing.Point(395, 25);
			this.Reset.Name = "Reset";
			this.Reset.Size = new System.Drawing.Size(75, 23);
			this.Reset.TabIndex = 3;
			this.Reset.Text = "Reset";
			this.Reset.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			this.label2.BackColor = System.Drawing.SystemColors.Window;
			this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label2.Location = new System.Drawing.Point(150, 128);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(320, 29);
			this.label2.TabIndex = 2;
			this.label2.Text = "label2";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panel2
			// 
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel2.Location = new System.Drawing.Point(150, 25);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(100, 100);
			this.panel2.TabIndex = 1;
			// 
			// listBox1
			// 
			this.listBox1.Dock = System.Windows.Forms.DockStyle.Left;
			this.listBox1.FormattingEnabled = true;
			this.listBox1.IntegralHeight = false;
			this.listBox1.Items.AddRange(new object[] {
            "Your Text",
            "NormalText",
            "Background",
            "Actions",
            "CTCP",
            "Joins",
            "Kicks",
            "Modes",
            "Nick Changes",
            "Notices",
            "Other",
            "Parts",
            "Quits",
            "Topics",
            "TreeView Background"});
			this.listBox1.Location = new System.Drawing.Point(3, 16);
			this.listBox1.Name = "listBox1";
			this.listBox1.ScrollAlwaysVisible = true;
			this.listBox1.Size = new System.Drawing.Size(132, 149);
			this.listBox1.TabIndex = 0;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(300, 59);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(34, 13);
			this.label4.TabIndex = 7;
			this.label4.Text = "(WIP)";
			// 
			// ControlStyle
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Name = "ControlStyle";
			this.Padding = new System.Windows.Forms.Padding(10);
			this.Size = new System.Drawing.Size(500, 354);
			this.groupBox1.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button selFont;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button ResetAll;
		private System.Windows.Forms.Button Reset;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.FontDialog fontDialog1;
		private System.Windows.Forms.Label label4;
	}
}
