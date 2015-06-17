using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPPlugin
{
    /* OS Type this plugin supports */
    public enum OS_TYPE
    {
        OS_WINDOWS,
        OS_LINUX
    }

    /* Queue of native shell commands */
    public class CPCommandQueue
    {
        private IList<string> commands;

        /// <summary>
        /// Adds a native command to the Command Queue
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns>
        /// Index of previous command
        /// </returns>
        public int addCommand(string cmd)
        {
            commands.Add(cmd);
            return commands.Count - 2; // Return index of last command
        }

        /// <summary>
        /// Adds a list of native commands to the Command Queue
        /// </summary>
        /// <param name="cmds"></param>
        /// <returns>
        /// Index of previous command
        /// </returns>
        public int addCommand(ICollection<string> cmds)
        {
            int ret = commands.Count - 1; // Index of last command
            foreach (string s in cmds)
                commands.Add(s);
            return ret;
        }

        /* Removes a command at the specified index */
        public void removeCommand(int index)
        {
            commands.RemoveAt(index);
        }

        public void clearCommands()
        {
            commands.Clear();
        }

        public IList<string> getCommands()
        {
            return commands;
        }
    }

    public interface CPPluginInterface
    {
        string Name { get; }
        string PrettyName { get; }
        string Version { get; }
        OS_TYPE SupportedOS { get; }
        void openProperties();
        void onPluginLoad();
        void onPluginUnload();
        void Run();
    }

    public interface CPRevertablePluginInterface : CPPluginInterface
    {
        void Revert(); 
    }
}
