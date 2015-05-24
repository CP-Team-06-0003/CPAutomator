using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPAutomator_Windows
{
#if __MonoCS__
    public class CPUniversalForm : System.Windows.Forms.Form
#else
    public class CPUniversalForm : MetroFramework.Forms.MetroForm
#endif
    {
        /// Universal Form ///
    }
}
