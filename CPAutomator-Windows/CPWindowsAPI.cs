using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;
using CPAutomator_Windows;

namespace CPAutomatorInterface
{
    public class CPWindowsAPI : CPUniversalInterface
    {
        private MainWindow main_window;
        private string plug_name;

        public CPWindowsAPI(MainWindow w, string plugin_name)
        {
            this.main_window = w;
            this.plug_name = plugin_name;
            w.Log("CP Windows API", "Initializing API");
        }

        public Assembly getPluginByName(string name)
        {
            // TODO
            return null;
        }

        public void Log(string text)
        {
            main_window.Log(plug_name, text);
        }
    }
}
