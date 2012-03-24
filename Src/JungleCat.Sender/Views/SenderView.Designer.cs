namespace JungleCat.Sender
{
    partial class SenderView
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
            this.LogTextBox = new System.Windows.Forms.TextBox();
            this.CommandTextBox = new System.Windows.Forms.TextBox();
            this.lblCommand = new System.Windows.Forms.Label();
            this.SendButton = new System.Windows.Forms.Button();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.CloseButton = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.EndpointTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.PortTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.CloseButton)).BeginInit();
            this.SuspendLayout();
            // 
            // LogTextBox
            // 
            this.LogTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.LogTextBox.Location = new System.Drawing.Point(11, 104);
            this.LogTextBox.Multiline = true;
            this.LogTextBox.Name = "LogTextBox";
            this.LogTextBox.ReadOnly = true;
            this.LogTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.LogTextBox.Size = new System.Drawing.Size(449, 185);
            this.LogTextBox.TabIndex = 0;
            // 
            // CommandTextBox
            // 
            this.CommandTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.CommandTextBox.Location = new System.Drawing.Point(82, 78);
            this.CommandTextBox.Name = "CommandTextBox";
            this.CommandTextBox.Size = new System.Drawing.Size(314, 20);
            this.CommandTextBox.TabIndex = 1;
            // 
            // lblCommand
            // 
            this.lblCommand.AutoSize = true;
            this.lblCommand.ForeColor = System.Drawing.Color.White;
            this.lblCommand.Location = new System.Drawing.Point(11, 81);
            this.lblCommand.Name = "lblCommand";
            this.lblCommand.Size = new System.Drawing.Size(57, 13);
            this.lblCommand.TabIndex = 2;
            this.lblCommand.Text = "Command:";
            // 
            // SendButton
            // 
            this.SendButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.SendButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(200)))), ((int)(((byte)(0)))));
            this.SendButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SendButton.Location = new System.Drawing.Point(402, 76);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(57, 23);
            this.SendButton.TabIndex = 3;
            this.SendButton.Text = "Send";
            this.SendButton.UseVisualStyleBackColor = false;
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.TitleLabel.Location = new System.Drawing.Point(9, 15);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(177, 23);
            this.TitleLabel.TabIndex = 4;
            this.TitleLabel.Text = "JungleCat Sender";
            // 
            // CloseButton
            // 
            this.CloseButton.BackgroundImage = global::JungleCat.Sender.Properties.Resources.Close;
            this.CloseButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.CloseButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CloseButton.Location = new System.Drawing.Point(432, 9);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(28, 29);
            this.CloseButton.TabIndex = 5;
            this.CloseButton.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(11, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Endpoint IP:";
            // 
            // EndpointTextBox
            // 
            this.EndpointTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.EndpointTextBox.Location = new System.Drawing.Point(82, 50);
            this.EndpointTextBox.Name = "EndpointTextBox";
            this.EndpointTextBox.Size = new System.Drawing.Size(125, 20);
            this.EndpointTextBox.TabIndex = 6;
            this.EndpointTextBox.Text = "127.0.0.1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(229, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Port:";
            // 
            // PortTextBox
            // 
            this.PortTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.PortTextBox.Location = new System.Drawing.Point(264, 50);
            this.PortTextBox.Name = "PortTextBox";
            this.PortTextBox.Size = new System.Drawing.Size(132, 20);
            this.PortTextBox.TabIndex = 8;
            this.PortTextBox.Text = "3000";
            // 
            // SenderView
            // 
            this.AcceptButton = this.SendButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.ClientSize = new System.Drawing.Size(472, 301);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PortTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.EndpointTextBox);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.TitleLabel);
            this.Controls.Add(this.SendButton);
            this.Controls.Add(this.lblCommand);
            this.Controls.Add(this.CommandTextBox);
            this.Controls.Add(this.LogTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SenderView";
            this.Text = "JungleCat Sender";
            ((System.ComponentModel.ISupportInitialize)(this.CloseButton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox LogTextBox;
        private System.Windows.Forms.TextBox CommandTextBox;
        private System.Windows.Forms.Label lblCommand;
        private System.Windows.Forms.Button SendButton;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.PictureBox CloseButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox EndpointTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox PortTextBox;
    }
}

