using System;
using System.Reflection;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CPAutomatorInterface;
using CPPlugin;

namespace CPAutomator_Windows
{
    public partial class MainWindow : CPUniversalForm
    {
        private ICollection<Assembly> assemblies = new List<Assembly>();
        private LogWindow logWindow = new LogWindow();
        private cpPlugins plug_struct;

        /// <summary>
        /// Holds a collection of plugins and revertable plugins
        /// </summary>
        private struct cpPlugins
        {
            public ICollection<CPPluginInterface> plugins;
            public ICollection<CPRevertablePluginInterface> rev_plugins;
        }

        /// <summary>
        /// Returns a list of plugin assemblies
        /// </summary>
        public ICollection<Assembly> getAssemblies()
        {
            return assemblies;
        }

        /// <summary>
        /// Constructs the MainWindow object
        /// </summary>
        /// <param name="plugins"></param>
        public MainWindow(string[] plugins)
        {
            CheckForIllegalCrossThreadCalls = false; // No worries ;)
            Log("Loading CPAutomator...");
            this.plug_struct = new cpPlugins();
            plug_struct.plugins = new List<CPPluginInterface>();
            plug_struct.rev_plugins = new List<CPRevertablePluginInterface>();
            foreach (string plugin in plugins)
            {
                AssemblyName an = AssemblyName.GetAssemblyName(plugin);
                Assembly assembly = Assembly.Load(an);
                assemblies.Add(assembly);
            }
            InitializeComponent();
            enumeratePlugins(plug_struct);
            foreach (var item in plug_struct.plugins)
            {
                CPWindowsAPI api = new CPWindowsAPI(this, item.Name);
                CPAPI.setAPI(api);
                this.pluginGridView.Rows.Add(item.PrettyName,
                    "Run", "Settings", "Unload", "0", item.Name);
                item.onPluginLoad();
            }
            foreach (var item in plug_struct.rev_plugins)
            {
                CPWindowsAPI api = new CPWindowsAPI(this, item.Name);
                CPAPI.setAPI(api);
                this.pluginGridView.Rows.Add(item.PrettyName + " (Rev)");
                item.onPluginLoad();
            }
        }

        /// <summary>
        /// Run a list of plugins with the plugin runner
        /// </summary>
        /// <param name="p"></param>
        private void RunPlugins(ICollection<CPPluginInterface> p)
        {
            Log("Running plugins...");
            PluginRunner runner = new PluginRunner(this, p);
            Thread thread = new Thread(new ThreadStart(runner.RunPlugins));
            thread.Start();
            while (!thread.IsAlive) ;
        }

        /// <summary>
        /// Gets a plugin instance by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public CPPluginInterface getPluginInstanceByName(string name)
        {
            foreach (var plgn in plug_struct.plugins)
                if (plgn.Name == name)
                    return plgn;
            foreach (var plgn in plug_struct.rev_plugins)
                if (plgn.Name == name)
                    return plgn;
            return null;
        }

        /// <summary>
        /// Logs text to the log window
        /// </summary>
        /// <param name="name"></param>
        /// <param name="text"></param>
        public void Log(string name, string text)
        {
            logWindow.addLine("[" + name + "] " + text);
        }

        /// <summary>
        /// Internal system application log function
        /// </summary>
        /// <param name="text"></param>
        protected void Log(string text)
        {
            this.Log("System", text);
        }

        /// <summary>
        /// Enumerates plugins from their Assembly
        /// </summary>
        /// <param name="plugins"></param>
        private void enumeratePlugins(cpPlugins plugins)
        {
            foreach (Assembly assembly in assemblies)
            {
                if (assembly != null)
                {
                    Type[] types = assembly.GetTypes();
                    foreach (Type type in types)
                    {
                        if (type.IsInterface || type.IsAbstract)
                            continue;
                        else
                        {
                            if (type.GetInterface(typeof(CPRevertablePluginInterface).FullName)
                                != null)
                                plugins.rev_plugins.Add(
                                    (CPRevertablePluginInterface)Activator.CreateInstance(type));
                            else if (type.GetInterface(typeof(CPPluginInterface).FullName)
                                != null)
                                plugins.plugins.Add(
                                    (CPPluginInterface)Activator.CreateInstance(type));
                        }
                    }
                }
            }
        }

        //////// FORM HANDLERS ////////

        private void btnLog_Click(object sender, EventArgs e)
        {
            logWindow.Show();
        }

        private void pluginGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == pluginGridView.Columns["RunPlugin"].Index && e.RowIndex >= 0)
            {
                Log("Run button clicked on " + e.RowIndex);
                ICollection<CPPluginInterface> x = new List<CPPluginInterface>();
                x.Add(getPluginInstanceByName("testplugin"));
                RunPlugins(x);
            }
        }
    }
}
