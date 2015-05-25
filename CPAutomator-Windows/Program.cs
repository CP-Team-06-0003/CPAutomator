using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPAutomator_Windows
{
    static class Program
    {
        /// <summary>
        /// Gets a string array of plugin locations
        /// </summary>
        static string[] getPlugins()
        {
            string path = "plugins/";
            if (!Directory.Exists(path))
                try
                {
                    Directory.CreateDirectory(path);
                }
                catch (Exception)
                {
                    MessageBox.Show("Error, could not create " + path +
                        "! Please create the directory yourself!");
                }
            return Directory.GetFiles(path, "*.dll");
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            MessageBox.Show("Warning! This application is extremely experimental and will probably "
                + "cause permanent damage to the host computer, your cat, and your pet goldfish!\n\n"
                + "PROCEED WITH EXTREME CAUTION!");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow(getPlugins()));
        }
    }
}
