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
        private int rowIndexFromMouseDown;
        private DataGridViewRow rw;

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
        /// Gets the OS type running the Automator
        /// </summary>
        /// <returns></returns>
        public OS_TYPE getOperatingSystem()
        {
            OperatingSystem os = Environment.OSVersion;
            PlatformID pid = os.Platform;
            switch (pid)
            {
                case PlatformID.Win32NT:
                case PlatformID.Win32S:
                case PlatformID.Win32Windows:
                case PlatformID.WinCE:
                    return OS_TYPE.OS_WINDOWS;
                case PlatformID.Unix:
                    return OS_TYPE.OS_LINUX;
                default:
                    Log("Unsupported operating system detected!");
                    return OS_TYPE.OS_GENERIC;
            }
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
                if (item.SupportedOS != this.getOperatingSystem()
                    && item.SupportedOS != OS_TYPE.OS_GENERIC)
                    continue;
                CPAPI.setAPI(CPAPI.createApiInstance(
                    this.getOperatingSystem(), this, item.Name));
                this.pluginGridView.Rows.Add(item.PrettyName,
                    "Run", "Settings", "Unload", "0", item.Name);
                item.onPluginLoad();
            }
            foreach (var item in plug_struct.rev_plugins)
            {
                if (item.SupportedOS != this.getOperatingSystem()
                    && item.SupportedOS != OS_TYPE.OS_GENERIC)
                    continue;
                CPAPI.setAPI(CPAPI.createApiInstance(
                    this.getOperatingSystem(), this, item.Name));
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
                    Type[] types;
                    try
                    {
                        types = assembly.GetTypes();
                    }
                    catch (Exception)
                    {
                        Log("Unable to load assembly -- Skipping...");
                        continue;
                    }
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

        private void pluginGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == pluginGridView.Columns["RunPlugin"].Index && e.RowIndex >= 0)
            {
                Log("Run button clicked on " + e.RowIndex);
                ICollection<CPPluginInterface> x = new List<CPPluginInterface>();
                x.Add(getPluginInstanceByName("testplugin"));
                RunPlugins(x);
            }
            // TODO
        }

        private void pluginGridView_MouseClick(object sender, MouseEventArgs e)
        {
            if (pluginGridView.SelectedRows.Count == 1)
            {
                if (e.Button == MouseButtons.Left)
                {
                    rw = pluginGridView.SelectedRows[0];
                    rowIndexFromMouseDown = pluginGridView.SelectedRows[0].Index;
                    pluginGridView.DoDragDrop(rw, DragDropEffects.Move);
                }
            }
        }

        private void pluginGridView_DragEnter(object sender, DragEventArgs e)
        {
            if (pluginGridView.SelectedRows.Count > 0)
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private void pluginGridView_DragDrop(object sender, DragEventArgs e)
        {

            int rowIndexOfItemUnderMouseToDrop;
            Point clientPoint = pluginGridView.PointToClient(new Point(e.X, e.Y));
            rowIndexOfItemUnderMouseToDrop =
                pluginGridView.HitTest(clientPoint.X, clientPoint.Y).RowIndex;
            if (e.Effect == DragDropEffects.Move &&
                rowIndexOfItemUnderMouseToDrop >= 0)
            {
                pluginGridView.Rows.RemoveAt(rowIndexFromMouseDown);
                pluginGridView.Rows.Insert(rowIndexOfItemUnderMouseToDrop, rw);
            }
        }

        private void btnRunAll_Click(object sender, EventArgs e)
        {
            if ((plug_struct.plugins.Count | plug_struct.rev_plugins.Count) == 0)
            {
                // No plugins :C
                MessageBox.Show("No plugins found, please add some and then try again.");
                return;
            }
        }
    }
}
