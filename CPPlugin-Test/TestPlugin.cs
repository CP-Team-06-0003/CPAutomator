using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CPPlugin;

namespace CPPlugin_Test
{
    public class TestPlugin : CPPluginInterface
    {
        public string Name
        {
            get
            {
                return "testplugin";
            }
        }

        public string PrettyName
        {
            get
            {
                return "Test Plugin";
            }
        }

        public string Version
        {
            get
            {
                return "1.0.0";
            }
        }

        public void Run()
        {

        }

        public void onPluginLoad()
        {

        }

        public void onPluginUnload()
        {

        }

        public void openProperties()
        {

        }
    }

    public class TestPlugin2 : CPRevertablePluginInterface
    {
        public string Name
        {
            get
            {
                return "testplugin2";
            }
        }

        public string PrettyName
        {
            get
            {
                return "Test Plugin 2";
            }
        }

        public string Version
        {
            get
            {
                return "1.0.0";
            }
        }

        public void Run()
        {

        }

        public void onPluginLoad()
        {

        }

        public void onPluginUnload()
        {

        }

        public void openProperties()
        {

        }

        public void Revert()
        {

        }
    }
}
