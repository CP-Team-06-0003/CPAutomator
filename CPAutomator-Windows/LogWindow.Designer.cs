namespace CPAutomator_Windows
{
    partial class LogWindow
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
            this.logTextBox = new System.Windows.Forms.TextBox();
            this.exportLogButton = new MetroFramework.Controls.MetroButton();
            this.clearLogButton = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // logTextBox
            // 
            this.logTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logTextBox.Location = new System.Drawing.Point(23, 63);
            this.logTextBox.Multiline = true;
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.ReadOnly = true;
            this.logTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logTextBox.Size = new System.Drawing.Size(356, 306);
            this.logTextBox.TabIndex = 0;
            this.logTextBox.TextChanged += new System.EventHandler(this.logTextBox_TextChanged);
            // 
            // exportLogButton
            // 
            this.exportLogButton.Location = new System.Drawing.Point(23, 375);
            this.exportLogButton.Name = "exportLogButton";
            this.exportLogButton.Size = new System.Drawing.Size(250, 30);
            this.exportLogButton.TabIndex = 1;
            this.exportLogButton.Text = "Export Log";
            this.exportLogButton.UseSelectable = true;
            this.exportLogButton.Click += new System.EventHandler(this.exportLogButton_Click);
            // 
            // clearLogButton
            // 
            this.clearLogButton.Location = new System.Drawing.Point(279, 375);
            this.clearLogButton.Name = "clearLogButton";
            this.clearLogButton.Size = new System.Drawing.Size(100, 30);
            this.clearLogButton.TabIndex = 2;
            this.clearLogButton.Text = "Clear";
            this.clearLogButton.Click += new System.EventHandler(this.clearLogButton_Click);
            // 
            // LogWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 428);
            this.Controls.Add(this.clearLogButton);
            this.Controls.Add(this.exportLogButton);
            this.Controls.Add(this.logTextBox);
            this.MinimumSize = new System.Drawing.Size(402, 428);
            this.Name = "LogWindow";
            this.Text = "Log";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LogWindow_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox logTextBox;
        private MetroFramework.Controls.MetroButton exportLogButton;
        private MetroFramework.Controls.MetroButton clearLogButton;
    }
}