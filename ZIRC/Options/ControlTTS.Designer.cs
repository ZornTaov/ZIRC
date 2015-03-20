namespace ZIRC.Options
{
	partial class ControlTTS
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
			this.voiceBox = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.trackBar1 = new System.Windows.Forms.TrackBar();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.trackBar2 = new System.Windows.Forms.TrackBar();
			this.label4 = new System.Windows.Forms.Label();
			this.TTSEnabler = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
			this.SuspendLayout();
			// 
			// voiceBox
			// 
			this.voiceBox.FormattingEnabled = true;
			this.voiceBox.Location = new System.Drawing.Point(163, 107);
			this.voiceBox.Name = "voiceBox";
			this.voiceBox.Size = new System.Drawing.Size(121, 21);
			this.voiceBox.TabIndex = 0;
			this.voiceBox.SelectedIndexChanged += new System.EventHandler(this.voiceBox_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(71, 110);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(86, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "TTS Voice Used";
			// 
			// trackBar1
			// 
			this.trackBar1.LargeChange = 10;
			this.trackBar1.Location = new System.Drawing.Point(163, 134);
			this.trackBar1.Maximum = 100;
			this.trackBar1.Name = "trackBar1";
			this.trackBar1.Size = new System.Drawing.Size(267, 45);
			this.trackBar1.TabIndex = 2;
			this.trackBar1.TickFrequency = 10;
			this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(71, 147);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(66, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "TTS Volume";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(71, 198);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(94, 13);
			this.label3.TabIndex = 5;
			this.label3.Text = "TTS Speech Rate";
			// 
			// trackBar2
			// 
			this.trackBar2.LargeChange = 10;
			this.trackBar2.Location = new System.Drawing.Point(163, 185);
			this.trackBar2.Maximum = 100;
			this.trackBar2.Minimum = -100;
			this.trackBar2.Name = "trackBar2";
			this.trackBar2.Size = new System.Drawing.Size(267, 45);
			this.trackBar2.TabIndex = 4;
			this.trackBar2.TickFrequency = 10;
			this.trackBar2.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(293, 54);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(34, 13);
			this.label4.TabIndex = 6;
			this.label4.Text = "(WIP)";
			// 
			// TTSEnabler
			// 
			this.TTSEnabler.AutoSize = true;
			this.TTSEnabler.Location = new System.Drawing.Point(74, 75);
			this.TTSEnabler.Name = "TTSEnabler";
			this.TTSEnabler.Size = new System.Drawing.Size(89, 17);
			this.TTSEnabler.TabIndex = 7;
			this.TTSEnabler.Text = "TTS Enabled";
			this.TTSEnabler.UseVisualStyleBackColor = true;
			this.TTSEnabler.CheckedChanged += new System.EventHandler(this.TTSEnabler_CheckedChanged);
			// 
			// ControlTTS
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.TTSEnabler);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.trackBar2);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.trackBar1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.voiceBox);
			this.Name = "ControlTTS";
			this.Size = new System.Drawing.Size(500, 354);
			((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox voiceBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TrackBar trackBar1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TrackBar trackBar2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.CheckBox TTSEnabler;
	}
}
