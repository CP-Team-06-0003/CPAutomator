using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPPlugin
{
    public enum OS_TYPE
    {
        OS_WINDOWS,
        OS_LINUX
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
