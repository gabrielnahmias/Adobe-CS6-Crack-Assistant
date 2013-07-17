using AdobeCS6CrackAssistant.Properties;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using Utilities;

/* TODO:
 *  - Detect the parent process (CMD or Explorer) and conditionally show "Done." message.
 *  - Make it so if /c or /u options are used, then only gather the DLL paths for those directories (less time used).
 */

namespace AdobeCS6CrackAssistant
{
    class Program
    {
        public static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }
    }
}
