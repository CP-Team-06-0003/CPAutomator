using System;
using System.Reflection;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CPPlugin;

namespace CPAutomator_Windows
{
    public partial class MainWindow : MetroFramework.Forms.MetroForm
    {
        ICollection<Assembly> assemblies = new List<Assembly>();

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
            cpPlugins plug_struct = new cpPlugins();
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
                this.pluginGridView.Rows.Add(item.PrettyName);
            foreach (var item in plug_struct.rev_plugins)
                this.pluginGridView.Rows.Add(item.PrettyName + " (Rev)");
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
    }
}
