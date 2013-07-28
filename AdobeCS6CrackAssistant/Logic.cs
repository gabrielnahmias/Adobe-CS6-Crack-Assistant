using AdobeCS6CrackAssistant.Properties;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

using Utilities;

namespace AdobeCS6CrackAssistant
{
    class Logic
    {
        public static void Crack(bool bUncrack = false)
        {
            byte[] bAmt64 = Resources.amtlib64,
                   bAmt32 = Resources.amtlib32;
            
            // NOTE: You should possibly be checking if it's a 64-bit environment up here and leave out the
            //       sX86.. one. Research what the effect of being on a 32-bit system is and using this variable.
            string sProgFilesDir = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles),
                   sX86ProgFilesDir = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);

            List<int> lWhich = new List<int>();

            List<string> lNames = new List<string>(),
                         lPaths = new List<string>();

            //Console.Write("Finding existing copies of \"amtlib.dll\"");

            // Gather the existing paths to amtlib.dll.
            lPaths = FileHelper.FindFiles("amtlib.dll", sProgFilesDir);
            lPaths.AddRange(FileHelper.FindFiles("amtlib.dll", sX86ProgFilesDir));

            List<string> lTemp = new List<string>();

            // If /u is specified, assign the original files to the byte arrays.
            if (bUncrack)
            {
                bAmt64 = Resources.amtlib64o;
                bAmt32 = Resources.amtlib32o;
            }

            // Create checkboxes for this section?
            foreach (CheckBox c in frmMain.ActiveForm.Controls)
            {
                if (c is CheckBox)
                {
                    int iPlace = -1;
                    string sProg = c.Name.ToLower().Replace("chk", "");

                    if (c.Checked)
                    {
                        iPlace = lPaths.FindIndex(sProg);

                        lWhich.Add(iPlace);
                        lNames.Add(sProg);
                    }
                }
            }

            check:
            if (lWhich.Contains(-1))
            {
                MessageBox.Show("Control list improper.", AppInfo.Title, MessageBoxButtons.OK);
                goto end;
            }

            int iCount = lWhich.Count;

            Console.Write("You have selected to " + ((bUncrack) ? "un" : "") + "crack ");

            // Add the selected programs' amtlib paths to the temporary list.
            for (int i = 0; i < iCount; i++)
            {
                lTemp.Add(lPaths[lWhich[i]]);
                Console.Write("{0}{1}{2}", ((i == iCount - 1) ? ((iCount == 1) ? "" : (((iCount == 2) ? " " : "") + "and ")) : ""), lNames[i], ((i != iCount - 1) ? ((iCount == 2) ? "" : ", ") : ""));
            }

            Console.Write(".\n\n");

            // Overwrite the main path list with the temporary one.
            lPaths = lTemp;

            cracking:
            // Loops through the list of directories. If the file exists (it has to—they are found), it
            // detects whether the current OS is 64-bit and, if so, copies the 64-bit amtlib.dll; otherwise,
            // it copies the 32-bit version. Since the x86 installations are included, some conditional logic
            // for the path not containing "(x86)" in it is applied.
            for (int i = 0; i < lPaths.Count; i++)
            {
                string sPath = lPaths[i];

                FileInfo fiAmt = new FileInfo(sPath);

                if (fiAmt.Exists)
                {
                    // Gotta kill this.
                    fiAmt.IsReadOnly = false;

                    // Check if the file is being used by another process.
                    if (!FileHelper.IsLocked(sPath))
                    {
                        // Checks if a 64-bit OS is being used. If so, the 64-bit file is copied, otherwise, the 32-bit one.
                        // These are the best indicators of this condition of which I could think. If x86 program folder exists,
                        // the current platform is most assuredly 64-bit.
                        if (Environment.Is64BitOperatingSystem && !sPath.Contains("(x86)", StringComparison.OrdinalIgnoreCase))
                        {
                            Console.WriteLine("Overwriting 64-bit \"{0}\"...", sPath);
                            File.WriteAllBytes(sPath, bAmt64);
                        }
                        else
                        {
                            Console.WriteLine("Overwriting 32-bit \"{0}\"...", sPath);
                            File.WriteAllBytes(sPath, bAmt32);
                        }
                    }
                    else
                    {
                        Console.WriteLine("\"{0}\" is being used by another process. Could not copy.", sPath);
                    }
                }
                else
                {
                    // This should never happen.
                    Console.WriteLine("\"{0}\" does not exist.", sPath);
                }
            }

            Console.Write("\nDone.");

            Console.ReadKey(true);

            end:
            Console.WriteLine();
            Application.Exit();
        }
    }
}
