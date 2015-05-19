using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPPlugin
{
    public interface CPPluginInterface
    {
        string Name { get; }
        string PrettyName { get; }
        string Version { get; }
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
