using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CPPlugin;
using CPAutomatorInterface;

namespace CPAutomator_Windows
{
    class PluginRunner
    {
        private ICollection<CPPluginInterface> plugins;
        private MainWindow win_handle;
        private string name = "Script Runner";
   
        public PluginRunner(MainWindow w, ICollection<CPPluginInterface> p)
        {
            this.plugins = p;
            this.win_handle = w;
            w.Log(name, "Initializing runner");
        }

        /// <summary>
        /// Run a list of plugins
        /// </summary>
        public void RunPlugins()
        {
            win_handle.pluginGridView.Enabled = false;
            win_handle.btnRunAll.Enabled = false;
            win_handle.pluginProgress.Maximum = plugins.Count;
            win_handle.pluginProgress.Step = 1;
            win_handle.pluginProgress.Value = 0;
            foreach (var plugin in plugins)
            {
                // Make a new API instance for each plugin
                CPWindowsAPI api = new CPWindowsAPI(win_handle, plugin.Name);
                CPAPI.setAPI(api);
                win_handle.Log(name, "Running plugin " + plugin.Name);
                plugin.Run();
                api = null;
                win_handle.pluginProgress.PerformStep(); // Update progress
            }
            win_handle.Log(name, "Done!");
            win_handle.pluginGridView.Enabled = true;
            win_handle.btnRunAll.Enabled = true;
        }

        /// <summary>
        /// Revert a revertable plugin singleton
        /// </summary>
        /// <param name="rp"></param>
        public void Revert(CPRevertablePluginInterface rp)
        {
            win_handle.pluginGridView.Enabled = false;
            win_handle.btnRunAll.Enabled = false;
            win_handle.pluginProgress.Maximum = 1;
            win_handle.pluginProgress.Step = 1;
            win_handle.pluginProgress.Value = 0;
            CPWindowsAPI api = new CPWindowsAPI(win_handle, rp.Name);
            CPAPI.setAPI(api);
            win_handle.Log(name, "Reverting plugin " + rp.Name);
            rp.Revert();
            api = null;
            win_handle.pluginProgress.PerformStep(); // Update progress
            win_handle.Log(name, "Done!");
            win_handle.pluginGridView.Enabled = true;
            win_handle.btnRunAll.Enabled = true;
        }
    }
}
