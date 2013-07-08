using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities;

namespace AdobeCS6CrackAssistant
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("ParentPid: " + Process.GetProcessById(ProcessHelper.Parent(Process.GetCurrentProcess()).Id).MainWindowTitle);
            
            string sTitle = ApplicationInfo.Title,
                   sProgFilesDir = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles),
                   sX86ProgFilesDir = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);

            // Constants and constant-like strings.
            string TEXT_WELCOME = String.Format("Welcome to the {0}!\n" +
                                                "This will automatically copy \"amtlib.dll\" into the\n" +
                                                "folders it should be in for everything to work.\n\n", sTitle);

            List<int> lWhich = new List<int> { };

            List<string> lArgs = new List<string>(args),
                         lNames = new List<string> { };

            List<string> lDirs = new List<string> { sProgFilesDir + @"\Adobe\Adobe Dreamweaver CS6",
                                                    sProgFilesDir + @"\Adobe\Adobe Fireworks CS6",
                                                    sProgFilesDir + @"\Adobe\Adobe Flash CS6",
                                                    sProgFilesDir + @"\Adobe\Adobe InDesign CS6",
                                                    sProgFilesDir + @"\Adobe\Adobe Prelude CS6",
                                                    sProgFilesDir + @"\Adobe\Adobe Audition CS6",
                                                    sProgFilesDir + @"\Adobe\Adobe Illustrator CS6\Support Files\Contents\Windows",
                                                    sProgFilesDir + @"\Adobe\Adobe Flash Builder 4.6\eclipse\plugins\com.adobe.flexide.amt_4.6.1.335153\os\win32\x86",
                                                    sProgFilesDir + @"\Adobe\Adobe Photoshop CS6",
                                                    sProgFilesDir + @"\Adobe\Adobe Bridge CS6",
                                                    sProgFilesDir + @"\Adobe\Acrobat 10.0\Acrobat",
                                                    sProgFilesDir + @"\Adobe\Adobe SpeedGrade CS6\bin",
                                                    sProgFilesDir + @"\Adobe\Adobe Encore CS6",
                                                    sProgFilesDir + @"\Adobe\Adobe Premiere CS6",
                                                    sProgFilesDir + @"\Adobe\Adobe After Effects CS6\Support Files",
                                                    sProgFilesDir + @"\Adobe\Adobe Media Encoder CS6" };
            
            ConsoleSpinner spinner = new ConsoleSpinner();

            // Set the foreground to green, the font to some tiny one, and the icon to the program's.
            Console.ForegroundColor = ConsoleColor.Green;
            //ConsoleHelper.SetConsoleFont(4);
            ConsoleHelper.SetConsoleIcon(Icon.ExtractAssociatedIcon(Assembly.GetExecutingAssembly().Location));

            Console.Title = sTitle + " v" + ApplicationInfo.Version.ToString();

            if (lArgs.Count >= 1)
            {
                if (lArgs[0] != "/?")
                {
                    Console.Write(TEXT_WELCOME);
                }
            }
            else
            {
                Console.Write(TEXT_WELCOME);
            }

            if (lArgs.Count >= 1)
            {
                string sCommand = lArgs[0].ToLower();
                switch (sCommand)
                {
                    case "/c":
                    case "/crack":
                        List<string> lTemp = new List<string> { };

                        if (lArgs.Count > 1)
                        {
                            for (int i = 1; i < lArgs.Count; i++)
                            {
                                string arg = lArgs[i].ToLower();
                                switch (arg)
                                {
                                    case "dw":
                                    case "dreamweaver":
                                        lWhich.Add(0);
                                        lNames.Add("Dreamweaver");
                                        break;
                                    case "fw":
                                    case "fireworks":
                                        lWhich.Add(1);
                                        lNames.Add("Fireworks");
                                        break;
                                    case "f":
                                    case "flash":
                                        lWhich.Add(2);
                                        lNames.Add("Flash");
                                        break;
                                    case "id":
                                    case "indesign":
                                        lWhich.Add(3);
                                        lNames.Add("InDesign");
                                        break;
                                    case "p":
                                    case "prelude":
                                        lWhich.Add(4);
                                        lNames.Add("Prelude");
                                        break;
                                    case "a":
                                    case "audition":
                                        lWhich.Add(5);
                                        lNames.Add("Audition");
                                        break;
                                    case "i":
                                    case "illustrator":
                                        lWhich.Add(6);
                                        lNames.Add("Illustrator");
                                        break;
                                    case "fb":
                                    case "flashbuilder":
                                        lWhich.Add(7);
                                        lNames.Add("Flash Builder");
                                        break;
                                    case "ps":
                                    case "photoshop":
                                        lWhich.Add(8);
                                        lNames.Add("Photoshop");
                                        break;
                                    case "b":
                                    case "bridge":
                                        lWhich.Add(9);
                                        lNames.Add("Bridge");
                                        break;
                                    case "ac":
                                    case "acrobat":
                                        lWhich.Add(10);
                                        lNames.Add("Acrobat");
                                        break;
                                    case "sg":
                                    case "speedgrade":
                                        lWhich.Add(11);
                                        lNames.Add("SpeedGrade");
                                        break;
                                    case "e":
                                    case "encore":
                                        lWhich.Add(12);
                                        lNames.Add("Encore");
                                        break;
                                    case "pr":
                                    case "premiere":
                                        lWhich.Add(13);
                                        lNames.Add("Photoshop");
                                        break;
                                    case "ae":
                                    case "aftereffects":
                                        lWhich.Add(14);
                                        lNames.Add("After Effects");
                                        break;
                                    case "me":
                                    case "mediaencoder":
                                        lWhich.Add(15);
                                        lNames.Add("Media Encoder");
                                        break;
                                    default:
                                        lWhich.Add(-1);
                                        break;
                                }
                            }

                            if (lWhich.Contains(-1))
                            {
                                Console.WriteLine("You have some errors in your program list. Try again.");
                                goto end;
                            }

                            int iCount = lWhich.Count;
                            
                            Console.Write("You have selected to crack ");

                            for (int i = 0; i < iCount; i++)
                            {
                                lTemp.Add(lDirs[lWhich[i]]);
                                Console.Write("{0}{1}{2}", ((i == iCount - 1) ? ((iCount == 1) ? "" : (((iCount == 2) ? " " : "") + "and ")) : ""), lNames[i], ((i != iCount - 1) ? ((iCount == 2) ? "" : ", ") : ""));
                            }

                            Console.Write(".");

                            lDirs = lTemp;
                        }
                        else
                        {
                            Console.WriteLine("You must select programs to crack! Use ACS6CA /?\n" +
                                              "to get a list of the available options.");
                            goto end;
                        }

                        Console.Write("\n\n");
                        break;
                    case "/?":
                        Console.WriteLine("Copies cracked versions of \"amtlib.dll\" to the proper\n" +
                                          "Adobe CS6 program directories.\n\n" +
                                          "ACS6CA [/?] [/c(rack) programs]\n\n" +
                                           "\t/?\t\tDisplays this help message.\n" +
                                          "\t/c programs\tCracks only the designated programs. They are separated\n\t\t\tby spaces and can include any of these: \n" +
                                          "\t\t\tdw or Dreamweaver, fw or Fireworks, f or Flash,\n" +
                                          "\t\t\tid or InDesign, p or Prelude, a or Audition,\n" +
                                          "\t\t\ti or Illustrator, fb or FlashBuilder, ps or Photoshop,\n" +
                                          "\t\t\tb or Bridge, c or Acrobat, sg or SpeedGrade,\n" +
                                          "\t\t\te or Encore, pr or Premiere, ae or AfterEffects,\n" +
                                          "\t\t\tme or MediaEncoder");
                        goto end;
                        break;
                }
            }

            if (lArgs.Count >= 1)
            {
                if (lArgs[0] != "/?")
                {
                    ConsoleHelper.Pause();
                    Console.Write("\n\n");
                }
            }
            else
            {
                ConsoleHelper.Pause();
                Console.Write("\n\n");
            }

            Console.Write("Working");

            Console.CursorVisible = false;

            // A little fake loading action...
            for(int i = 0; i < 10; i++)
                spinner.Turn();

            spinner.Clear();

            Console.CursorVisible = true;

            Console.Write("\n\n");
            
            // Loops through the list of directories. If the current directory exists, it detects whether
            // the current OS is 64-bit and, if so, copies the 64-bit amtlib.dll; otherwise, it copies the
            // 32-bit version. If the directory does not exist, it checks whether the same directory exists
            // within the x86 Program Files directory and, if so, copies the 32-bit file.
            for (int i = 0; i < lDirs.Count; i++)
            {
                string sDir = lDirs[i],
                       sAmtPath = sDir + @"\amtlib.dll";

                FileInfo fiAmt = new FileInfo(sAmtPath);

                if (fiAmt.Exists)
                {
                    fiAmt.IsReadOnly = false;

                    // Check if the file is being used by another process.
                    if (!FileHelper.IsLocked(sAmtPath))
                    {
                        // Checks if a 64-bit OS is being used. If so, the 64-bit file is copied, otherwise, the 32-bit one.
                        // These are the best indicators of this condition of which I could think. If x86 program folder exists,
                        // the current platform is most assuredly 64-bit.
                        if (Environment.Is64BitOperatingSystem/* && Directory.Exists(@"\Program Files (x86)")*/)
                        {
                            Console.WriteLine("Copying 64-bit \"amtlib.dll\" to \"{0}\"...", sDir);
                            File.WriteAllBytes(sAmtPath, AdobeCS6CrackAssistant.Properties.Resources.amtlib_64);
                        }
                        else
                        {
                            Console.WriteLine("Copying 32-bit \"amtlib.dll\" to \"{0}\"...", sDir);
                            File.WriteAllBytes(sAmtPath, AdobeCS6CrackAssistant.Properties.Resources.amtlib_32);
                        }
                    }
                    else
                    {
                        Console.WriteLine("\"{0}\" is being used by another process. Could not copy.", sAmtPath);
                    }
                }
                else
                {
                    string sX86Dir = sDir.Replace(sProgFilesDir, sX86ProgFilesDir),
                           sX86AmtPath = sX86Dir + @"\amtlib.dll";

                    FileInfo fiX86Amt = new FileInfo(sX86AmtPath);

                    Console.WriteLine("\"{0}\" does not exist.", sAmtPath);

                    if (fiX86Amt.Exists)
                    {
                        fiX86Amt.IsReadOnly = false;

                        // Check if the file is being used by another process.
                        if (!FileHelper.IsLocked(sX86AmtPath))
                        {
                            Console.WriteLine("Copying 32-bit \"amtlib.dll\" to \"{0}\"...", sX86Dir);
                            File.WriteAllBytes(sX86AmtPath, AdobeCS6CrackAssistant.Properties.Resources.amtlib_32);
                        }
                        else
                        {
                            Console.WriteLine("\"{0}\" is being used by another process. Could not copy.", sX86AmtPath);
                        }
                    }
                    else
                    {
                        Console.WriteLine("\"{0}\" does not exist.", sX86AmtPath);
                    }
                }
            }


            Console.Write("\nDone.");

            pause: Console.ReadKey(true);
            end: ;
        }
    }
}
