using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CPAutomatorInterface;

namespace CPPlugin
{
    public class CPAPI
    {
        private static CPUniversalInterface API = null;

        public static void setAPI(CPUniversalInterface iface)
        {
            API = iface;
        }

        public static CPUniversalInterface getAPI()
        {
            return API;
        }
    }
}
