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
        static void Main(string[] args)
        {
            byte[] bAmt64 = Resources.amtlib64,
                   bAmt32 = Resources.amtlib32;

            string sTitle = ApplicationInfo.Title,
                   sProgFilesDir = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles),
                   sX86ProgFilesDir = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);

            List<int> lWhich = new List<int>();

            List<string> lArgs = new List<string>(args),
                         lNames = new List<string>(),
                         lPaths = new List<string>();

            ConsoleSpinner spinner = new ConsoleSpinner();
            
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            CancellationToken ct = tokenSource.Token;

            // Constants and constant-like strings.
            string TEXT_USAGE = "Copies cracked versions of \"amtlib.dll\" to the proper\n" +
                                "Adobe CS6 program directories.\n\n" +
                                "ACS6CA [/?] [/c ...] [/u [...]]\n\n" +
                                "\t/?\t\tDisplays this help message.\n" +
                                "\t/c ...\t\tCracks only the designated programs. They are separated\n\t\t\tby spaces and can include any of these: \n" +
                                "\t\t\tdw or Dreamweaver, fw or Fireworks, f or Flash,\n" +
                                "\t\t\tid or InDesign, p or Prelude, a or Audition,\n" +
                                "\t\t\ti or Illustrator, fb or FlashBuilder, ps or Photoshop,\n" +
                                "\t\t\tb or Bridge, c or Acrobat, sg or SpeedGrade,\n" +
                                "\t\t\te or Encore, pr or Premiere, ae or AfterEffects,\n" +
                                "\t\t\tme or MediaEncoder\n" +
                                "\t/u [...]\tUncracks all (default) or only the designated programs.\n\t\t\tRefer to the list above.",

                   TEXT_WELCOME = String.Format("Welcome to the {0}!\n" +
                                                "This will automatically copy \"amtlib.dll\" into the\n" +
                                                "folders it should be in for everything to work.\n\n", sTitle);

            // Set the foreground to green, the font to some tiny one, and the icon to the program's.
            Console.ForegroundColor = ConsoleColor.Green;
            //ConsoleHelper.SetConsoleFont(4);
            ConsoleHelper.SetConsoleIcon(Icon.ExtractAssociatedIcon(Assembly.GetExecutingAssembly().Location));
            
            Console.Title = sTitle + " v" + ApplicationInfo.Version.ToString();

            if (lArgs.Count >= 1 && lArgs[0].Equals("/?"))
            {
                Console.Write(TEXT_USAGE);
                goto end;
            }

            Console.Write(TEXT_WELCOME);
            ConsoleHelper.Pause();
            Console.Write("\n\n");

            // Make the cursor invisible while the loading animation is running so
            // it doesn't move with the text.
            Console.CursorVisible = false;

            // Start the loading animation while files are being found.
            Task task = Task.Factory.StartNew(() =>
            {
                Console.Write("Finding existing copies of \"amtlib.dll\"");

                while (spinner != null)
                    spinner.Turn();
            }, ct);

            // Gather the existing paths to amtlib.dll.
            lPaths = FileHelper.FindFiles("amtlib.dll", sProgFilesDir);
            lPaths.AddRange(FileHelper.FindFiles("amtlib.dll", sX86ProgFilesDir));

            // Stop the spinner, kill it, and cancel the task.
            spinner.Clear();
            spinner = null;
            tokenSource.Cancel();

            Console.Write("\n\n");

            Console.CursorVisible = true;

            // Handle command-line arguments.
            if (lArgs.Count >= 1)
            {
                string sCommand = lArgs[0].ToLower();
                switch (sCommand)
                {
                    case "/c":
                    case "/u":
                        List<string> lTemp = new List<string>();

                        // If /u is specified, assign the original files to the byte arrays.
                        if (sCommand.Equals("/u"))
                        {
                            bAmt64 = Resources.amtlib64o;
                            bAmt32 = Resources.amtlib32o;
                        }

                        if (lArgs.Count > 1)
                        {
                            for (int i = 1; i < lArgs.Count; i++)
                            {
                                int iPlace = -1;
                                string arg = lArgs[i].ToLower(),
                                       sProg = "";

                                switch (arg)
                                {
                                    case "dw":
                                    case "dreamweaver":
                                        sProg = "Dreamweaver";
                                        break;
                                    case "fw":
                                    case "fireworks":
                                        sProg = "Fireworks";
                                        break;
                                    case "f":
                                    case "flash":
                                        sProg = "Flash";
                                        break;
                                    case "id":
                                    case "indesign":
                                        sProg = "InDesign";
                                        break;
                                    case "p":
                                    case "prelude":
                                        sProg = "Prelude";
                                        break;
                                    case "a":
                                    case "audition":
                                        sProg = "Audition";
                                        break;
                                    case "i":
                                    case "illustrator":
                                        sProg = "Illustrator";
                                        break;
                                    case "fb":
                                    case "flashbuilder":
                                        sProg = "Flash Builder";
                                        break;
                                    case "ps":
                                    case "photoshop":
                                        sProg = "Photoshop";
                                        break;
                                    case "b":
                                    case "bridge":
                                        sProg = "Bridge";
                                        break;
                                    case "ac":
                                    case "acrobat":
                                        sProg = "Acrobat";
                                        break;
                                    case "sg":
                                    case "speedgrade":
                                        sProg = "SpeedGrade";
                                        break;
                                    case "e":
                                    case "encore":
                                        sProg = "Encore";
                                        break;
                                    case "pr":
                                    case "premiere":
                                        sProg = "Photoshop";
                                        break;
                                    case "ae":
                                    case "aftereffects":
                                        sProg = "After Effects";
                                        break;
                                    case "me":
                                    case "mediaencoder":
                                        sProg = "Media Encoder";
                                        break;
                                    default:
                                        lWhich.Add(-1);
                                        goto check;
                                        break;
                                }

                                iPlace = lPaths.FindIndex(sProg);

                                lWhich.Add(iPlace);
                                lNames.Add(sProg);
                            }

                            check:
                            if (lWhich.Contains(-1))
                            {
                                Console.Write("You have some errors in your program list. Try again.");
                                goto end;
                            }

                            int iCount = lWhich.Count;

                            Console.Write("You have selected to " + ((sCommand.Equals("/u")) ? "un" : "") + "crack ");

                            // Add the selected programs' amtlib paths to the temporary list.
                            for (int i = 0; i < iCount; i++)
                            {
                                lTemp.Add(lPaths[lWhich[i]]);
                                Console.Write("{0}{1}{2}", ((i == iCount - 1) ? ((iCount == 1) ? "" : (((iCount == 2) ? " " : "") + "and ")) : ""), lNames[i], ((i != iCount - 1) ? ((iCount == 2) ? "" : ", ") : ""));
                            }

                            Console.Write(".\n\n");

                            // Overwrite the main path list with the temporary one.
                            lPaths = lTemp;
                        }
                        else
                        {
                            if (lArgs.Count >= 1 && lArgs[0].Equals("/u"))
                                Console.Write("Uncracking...\n\n");

                            // No programs specified.
                            goto cracking;
                        }
                        break;
                    // No need to handle /? here since I took care of it earlier.
                    /*case "/?":
                        
                        break;*/
                }
            }

            cracking:
            // Loops through the list of directories. If the file exists (it has to—they are found), it
            // detects whether the current OS is 64-bit and, if so, copies the 64-bit amtlib.dll; otherwise,
            // it copies the 32-bit version. The same routine is performed on the list of x86 installations.
            for (int i = 0; i < lPaths.Count; i++)
            {
                string sPath = lPaths[i];
                       
                FileInfo fiAmt = new FileInfo(sPath);

                if (fiAmt.Exists)
                {
                    fiAmt.IsReadOnly = false;

                    // Check if the file is being used by another process.
                    if (!FileHelper.IsLocked(sPath))
                    {
                        // Checks if a 64-bit OS is being used. If so, the 64-bit file is copied, otherwise, the 32-bit one.
                        // These are the best indicators of this condition of which I could think. If x86 program folder exists,
                        // the current platform is most assuredly 64-bit.
                        if (Environment.Is64BitOperatingSystem && !sPath.Contains("(x86)", StringComparison.OrdinalIgnoreCase) )
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
