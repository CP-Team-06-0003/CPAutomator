using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPAutomatorInterface
{
    public interface CPUniversalInterface
    {
        /* Gets a plugin handle by name */
        Assembly getPluginByName(string name);
        /* Runs a native comand queue */
        bool runCommandQueue(CPPlugin.CPCommandQueue q);
        /* Log text to the automator */
        void Log(string text);
    }
}
