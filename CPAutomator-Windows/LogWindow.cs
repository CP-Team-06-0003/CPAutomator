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
    public partial class LogWindow : MetroFramework.Forms.MetroForm
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
            this.logTextBox.Text += text.Replace(System.Environment.NewLine, "")
                + "\r\n";
        }

        /// <summary>
        /// Adds raw text to the log (without a newline at the end)
        /// </summary>
        /// <param name="text"></param>
        public void addText(string text)
        {
            this.logTextBox.Text += text;
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
    }
}
