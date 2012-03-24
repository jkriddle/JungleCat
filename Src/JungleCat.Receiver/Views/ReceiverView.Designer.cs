namespace JungleCat.Receiver
{
    partial class ReceiverView
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
            this.SuspendLayout();
            // 
            // LogTextBox
            // 
            this.LogTextBox.Location = new System.Drawing.Point(12, 12);
            this.LogTextBox.Multiline = true;
            this.LogTextBox.Name = "LogTextBox";
            this.LogTextBox.Size = new System.Drawing.Size(390, 369);
            this.LogTextBox.TabIndex = 0;
            // 
            // ReceiverView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.ClientSize = new System.Drawing.Size(414, 393);
            this.Controls.Add(this.LogTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ReceiverView";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "JungleCat Receiver";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox LogTextBox;
    }
}

