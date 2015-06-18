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

        public static CPUniversalInterface createApiInstance(OS_TYPE t,
            CPAutomator_Windows.MainWindow w, string name)
        {
            switch (t)
            {
                case OS_TYPE.OS_WINDOWS:
                    return new CPWindowsAPI(w, name);
                case OS_TYPE.OS_LINUX:
                    return new CPLinuxAPI(w, name);
                case OS_TYPE.OS_GENERIC:
                default:
                    return new CPUniversalAPI(w, name);
            }
        }
    }
}
