using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPAutomator_Windows
{
    public partial class LogWindow : CPUniversalForm
    {
        public LogWindow()
        {
            CheckForIllegalCrossThreadCalls = false; // No worries ;)
            InitializeComponent();
        }

        /// <summary>
        /// Adds a line of text to the log
        /// </summary>
        /// <param name="text"></param>
        public void addLine(string text)
        {
            addText(text.Replace(System.Environment.NewLine, "")
                + "\r\n");
        }

        /// <summary>
        /// Adds raw text to the log (without a newline at the end)
        /// </summary>
        /// <param name="text"></param>
        public void addText(string text)
        {
            this.logTextBox.Text += text;
            this.logTextBox.SelectionStart =
                this.logTextBox.TextLength;
            this.logTextBox.ScrollToCaret();
        }

        private void logTextBox_TextChanged(object sender, EventArgs e)
        {
            // TODO
        }

        private void LogWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void exportLogButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveLog = new SaveFileDialog();
            saveLog.Filter = "Log Data|*.log|Text File|*.txt";
            saveLog.Title = "Save CPAutomator Log Data";
            saveLog.ShowDialog();
            if (saveLog.FileName != "")
                System.IO.File.WriteAllText(@saveLog.FileName,
                    this.logTextBox.Text);
        }

        private void clearLogButton_Click(object sender, EventArgs e)
        {
            this.logTextBox.Text = "";
        }
    }
}
