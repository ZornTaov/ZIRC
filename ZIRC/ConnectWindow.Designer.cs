namespace ZIRC
{
    partial class ConnectWindow
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
            this.serverInfo = new System.Windows.Forms.GroupBox();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.portBox = new System.Windows.Forms.TextBox();
            this.serverBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.connectButton = new System.Windows.Forms.Button();
            this.userInfo = new System.Windows.Forms.GroupBox();
            this.altNickBox2 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.altNickBox1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.realnameBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.usernameBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.nicknameBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.serverInfo.SuspendLayout();
            this.userInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // serverInfo
            // 
            this.serverInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.serverInfo.Controls.Add(this.passwordBox);
            this.serverInfo.Controls.Add(this.label3);
            this.serverInfo.Controls.Add(this.label2);
            this.serverInfo.Controls.Add(this.portBox);
            this.serverInfo.Controls.Add(this.serverBox);
            this.serverInfo.Controls.Add(this.label1);
            this.serverInfo.Location = new System.Drawing.Point(13, 13);
            this.serverInfo.Name = "serverInfo";
            this.serverInfo.Size = new System.Drawing.Size(397, 80);
            this.serverInfo.TabIndex = 0;
            this.serverInfo.TabStop = false;
            this.serverInfo.Text = "Server Info";
            // 
            // passwordBox
            // 
            this.passwordBox.Location = new System.Drawing.Point(252, 47);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.Size = new System.Drawing.Size(139, 20);
            this.passwordBox.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(193, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Port";
            // 
            // portBox
            // 
            this.portBox.Location = new System.Drawing.Point(87, 47);
            this.portBox.Name = "portBox";
            this.portBox.Size = new System.Drawing.Size(100, 20);
            this.portBox.TabIndex = 2;
            // 
            // serverBox
            // 
            this.serverBox.Location = new System.Drawing.Point(87, 20);
            this.serverBox.Name = "serverBox";
            this.serverBox.Size = new System.Drawing.Size(304, 20);
            this.serverBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server: ";
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(335, 219);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // connectButton
            // 
            this.connectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.connectButton.Location = new System.Drawing.Point(254, 219);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(75, 23);
            this.connectButton.TabIndex = 2;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // userInfo
            // 
            this.userInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userInfo.Controls.Add(this.altNickBox2);
            this.userInfo.Controls.Add(this.label8);
            this.userInfo.Controls.Add(this.altNickBox1);
            this.userInfo.Controls.Add(this.label7);
            this.userInfo.Controls.Add(this.realnameBox);
            this.userInfo.Controls.Add(this.label6);
            this.userInfo.Controls.Add(this.usernameBox);
            this.userInfo.Controls.Add(this.label5);
            this.userInfo.Controls.Add(this.nicknameBox);
            this.userInfo.Controls.Add(this.label4);
            this.userInfo.Location = new System.Drawing.Point(13, 99);
            this.userInfo.Name = "userInfo";
            this.userInfo.Size = new System.Drawing.Size(397, 107);
            this.userInfo.TabIndex = 3;
            this.userInfo.TabStop = false;
            this.userInfo.Text = "User Info";
            // 
            // altNickBox2
            // 
            this.altNickBox2.Location = new System.Drawing.Point(265, 72);
            this.altNickBox2.Name = "altNickBox2";
            this.altNickBox2.Size = new System.Drawing.Size(126, 20);
            this.altNickBox2.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(193, 75);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Alt Nick 2: ";
            // 
            // altNickBox1
            // 
            this.altNickBox1.Location = new System.Drawing.Point(87, 72);
            this.altNickBox1.Name = "altNickBox1";
            this.altNickBox1.Size = new System.Drawing.Size(100, 20);
            this.altNickBox1.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Alt Nick 1: ";
            // 
            // realnameBox
            // 
            this.realnameBox.Location = new System.Drawing.Point(87, 46);
            this.realnameBox.Name = "realnameBox";
            this.realnameBox.Size = new System.Drawing.Size(304, 20);
            this.realnameBox.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Real Name: ";
            // 
            // usernameBox
            // 
            this.usernameBox.Location = new System.Drawing.Point(265, 20);
            this.usernameBox.Name = "usernameBox";
            this.usernameBox.Size = new System.Drawing.Size(126, 20);
            this.usernameBox.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(193, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Username: ";
            // 
            // nicknameBox
            // 
            this.nicknameBox.Location = new System.Drawing.Point(87, 20);
            this.nicknameBox.Name = "nicknameBox";
            this.nicknameBox.Size = new System.Drawing.Size(100, 20);
            this.nicknameBox.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "NickName: ";
            // 
            // ConnectWindow
            // 
            this.AcceptButton = this.connectButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(422, 254);
            this.Controls.Add(this.userInfo);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.serverInfo);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConnectWindow";
            this.Text = "ConnectWindow";
            this.Load += new System.EventHandler(this.ConnectWindow_Load);
            this.serverInfo.ResumeLayout(false);
            this.serverInfo.PerformLayout();
            this.userInfo.ResumeLayout(false);
            this.userInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox serverInfo;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.GroupBox userInfo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox passwordBox;
        public System.Windows.Forms.TextBox portBox;
        public System.Windows.Forms.TextBox serverBox;
        public System.Windows.Forms.TextBox altNickBox2;
        public System.Windows.Forms.TextBox altNickBox1;
        public System.Windows.Forms.TextBox realnameBox;
        public System.Windows.Forms.TextBox usernameBox;
        public System.Windows.Forms.TextBox nicknameBox;

    }
}