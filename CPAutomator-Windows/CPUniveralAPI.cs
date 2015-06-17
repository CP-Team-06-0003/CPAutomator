using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;
using CPAutomator_Windows;

namespace CPAutomatorInterface
{
    /* Universal API -- Should work across all OSes */
    public class CPUniversalAPI : CPUniversalInterface
    {
        protected MainWindow main_window;
        protected string plug_name;

        public CPUniversalAPI(MainWindow w, string plugin_name)
        {
            this.main_window = w;
            this.plug_name = plugin_name;
            w.Log("CP Universal API", "Initializing API");
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

        public bool runCommandQueue(CPPlugin.CPCommandQueue q)
        {
            // TODO
            return false;
        }
    }
}
