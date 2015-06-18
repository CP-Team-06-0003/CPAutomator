using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;
using CPAutomator_Windows;

namespace CPAutomatorInterface
{
    public class CPLinuxAPI : CPUniversalAPI
    {
        public CPLinuxAPI(MainWindow w, String p) : base(w, p) { }
    }
}
