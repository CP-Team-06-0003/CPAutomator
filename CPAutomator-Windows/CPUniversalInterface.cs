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
        Assembly getPluginByName(string name);
        void Log(string text);
    }
}
