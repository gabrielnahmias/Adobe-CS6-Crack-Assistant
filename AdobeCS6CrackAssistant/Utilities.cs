using System;
using System.Collections.Generic;
using System.Drawing;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Utilities
{
    /**********************************************
     *             APPLICATION INFO               *
    /**********************************************/

    /// <summary>
    /// Assists in gathering assembly information about the application.
    /// </summary>
    public class ApplicationInfo
    {
        static object[] attributes = Assembly.GetCallingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
        public static Version Version { get { return Assembly.GetCallingAssembly().GetName().Version; } }

        /// <summary>
        /// Returns the title of the application.
        /// </summary>
        public static string Title
        {
            get
            {
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title.Length > 0) return titleAttribute.Title;
                }
                return Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        /// <summary>
        /// Returns the product name of the application.
        /// </summary>
        public static string ProductName
        {
            get
            {
                return attributes.Length == 0 ? "" : ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        /// <summary>
        /// Returns the description of the application.
        /// </summary>
        public static string Description
        {
            get
            {
                return attributes.Length == 0 ? "" : ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        /// <summary>
        /// Returns the copyright holder of the application.
        /// </summary>
        public static string CopyrightHolder
        {
            get
            {
                return attributes.Length == 0 ? "" : ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        /// <summary>
        /// Returns the name of the company who made the application.
        /// </summary>
        public static string CompanyName
        {
            get
            {
                return attributes.Length == 0 ? "" : ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }

    }

    /**********************************************
     *              CONSOLE HELPER                *
    /**********************************************/

    /// <summary>
    /// The structure for a console font.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ConsoleFont
    {
        public uint Index;
        public short SizeX, SizeY;
    }

    /// <summary>
    /// Assists in changing various console settings.
    /// </summary>
    public static class ConsoleHelper
    {
        public static void Pause(string sMsg = "Press any key to begin...")
        {
            Console.Write(sMsg);
            Console.ReadKey(true);
        }

        [DllImport("kernel32")]
        public static extern bool SetConsoleIcon(IntPtr hIcon);

        /// <summary>
        /// Sets the icon for the console (the top left one next to the console title).
        /// </summary>
        /// <param name="icon">The icon to set for the console.</param>
        /// <returns>True if the icon was set and false if not.</returns>
        public static bool SetConsoleIcon(Icon icon)
        {
            return SetConsoleIcon(icon.Handle);
        }

        [DllImport("kernel32")]
        private extern static bool SetConsoleFont(IntPtr hOutput, uint index);

        private enum StdHandle
        {
            OutputHandle = -11
        }

        [DllImport("kernel32")]
        private static extern IntPtr GetStdHandle(StdHandle index);

        /// <summary>
        /// Sets the font for the console (0-10).
        /// </summary>
        /// <param name="index">The positive integer representing the font to which to change.</param>
        /// <returns>True if the font was set and false if not.</returns>
        public static bool SetConsoleFont(uint index)
        {
            return SetConsoleFont(GetStdHandle(StdHandle.OutputHandle), index);
        }

        [DllImport("kernel32")]
        private static extern bool GetConsoleFontInfo(IntPtr hOutput, [MarshalAs(UnmanagedType.Bool)]bool bMaximize,
            uint count, [MarshalAs(UnmanagedType.LPArray), Out] ConsoleFont[] fonts);

        [DllImport("kernel32")]
        private static extern uint GetNumberOfConsoleFonts();

        /// <summary>
        /// Gets the number of console fonts available.
        /// </summary>
        public static uint ConsoleFontsCount
        {
            get
            {
                return GetNumberOfConsoleFonts();
            }
        }

        /// <summary>
        /// Contains a list of the console fonts available.
        /// </summary>
        public static ConsoleFont[] ConsoleFonts
        {
            get
            {
                ConsoleFont[] fonts = new ConsoleFont[GetNumberOfConsoleFonts()];
                if (fonts.Length > 0)
                    GetConsoleFontInfo(GetStdHandle(StdHandle.OutputHandle), false, (uint)fonts.Length, fonts);
                return fonts;
            }
        }

    }

    /**********************************************
     *             CONSOLE SPINNER                *
    /**********************************************/

    /// <summary>
    /// Loading animations for the console.
    /// </summary>
    class ConsoleSpinner
    {
        // Private
        bool increment = true,
             loop = false;

        int counter = 0,
            delay;

        string[] sequence;

        /// <summary>
        /// Constructs a new ConsoleSpinner object.
        /// </summary>
        /// <param name="sSequence">A string denoting the animation type (dots, slashes, circles, crosses, or arrows).</param>
        /// <param name="iDelay">The delay (in ms) between each "frame" of animation.</param>
        /// <param name="bLoop">Denotes whether to play the animation in reverse once it plays through.</param>
        public ConsoleSpinner(string sSequence = "dots", int iDelay = 100, bool bLoop = false)
        {
            delay = iDelay;
            sSequence = sSequence.ToLower();
            
            if (sSequence == "dots")
            {
                sequence = new string[] { ".   ", "..  ", "... ", "...." };
                loop = true;
            }
            else if (sSequence == "slashes")
                sequence = new string[] { "/", "-", "\\", "|" };
            else if (sSequence == "circles")
                sequence = new string[] { ".", "o", "0", "o" };
            else if (sSequence == "crosses")
                sequence = new string[] { "+", "x" };
            else if (sSequence == "arrows")
                sequence = new string[] { "V", "<", "^", ">" };
        }

        /// <summary>
        /// Clears the animation from the screen.
        /// </summary>
        public void Clear()
        {
            string spaces = new String(' ', sequence[counter].Length);
            Console.Write(spaces);
        }

        /// <summary>
        /// Animate the spinner.
        /// </summary>
        public void Turn()
        {
            if (loop)
            {
                if (counter >= sequence.Length - 1)
                    increment = false;
                if (counter <= 0)
                    increment = true;

                if (increment)
                    counter++;
                else if (!increment)
                    counter--;
            }
            else
            {
                counter++;

                if (counter >= sequence.Length)
                    counter = 0;
            }

            Console.Write(sequence[counter]);
            Console.SetCursorPosition(Console.CursorLeft - sequence[counter].Length, Console.CursorTop);

            Thread.Sleep(delay);
        }
    }

    /**********************************************
     *                FILE HELPER                 *
    /**********************************************/

    class FileHelper
    {
        /// <summary>
        /// Checks if a file is being used by another process or otherwise.
        /// </summary>
        /// <param name="file">The FileInfo object to check.</param>
        /// <returns>True if the file is locked and false if not.</returns>
        public static bool IsLocked(string sFilename)
        {
            FileInfo file = new FileInfo(sFilename);
            FileStream stream = null;

            try
            {
                stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            }
            catch (IOException)
            {
                // The file is unavailable because it is either:
                //  - Still being written to
                //  - Being processed by another thread
                //  - It does not exist (has already been processed)
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }

            // File is not locked.
            return false;
        }

        /// <summary>
        /// Finds files in a directory.
        /// </summary>
        /// <param name="sFilename">The filename for which to search (can include wildcards [*]).</param>
        /// <param name="sDir">The directory in which to search.</param>
        /// <param name="soOption">Optionally, specify where to search (top directory or all [default]).</param>
        /// <returns>An list of strings with paths to the found files.</returns>
        public static List<string> FindFiles(string sFilename, string sDir, SearchOption soOption = SearchOption.AllDirectories)
        {
            List<string> lFiles = Directory.GetFiles(sDir, sFilename, soOption).ToList();
            return lFiles;
        }
    }

    /**********************************************
     *                 LIST HELPER                *
    /**********************************************/

    static class ListHelper
    {
        public static int FindIndex<T>(this List<T> list, string value, bool skipMatches = false)
        {
            for (int i = 0; i < list.Count; i++)
            {
                string s = list[i].ToString();
                if (s.Contains(value, StringComparison.OrdinalIgnoreCase))
                {
                    if (skipMatches == false)
                        return i;
                }
            }

            return -1;
        }
    }

    /**********************************************
     *                 OS HELPER                  *
    /**********************************************/

    /// <summary>
    /// Helps with OS-related operations.
    /// </summary>
    class OSHelper
    {
        #region Is64Bit (IsWow64Process)

        /// <summary>
        /// The function determines whether the current operating system is a 
        /// 64-bit operating system.
        /// </summary>
        /// <returns>
        /// The function returns true if the operating system is 64-bit; 
        /// otherwise, it returns false.
        /// </returns>
        public static bool Is64Bit()
        {
            if (IntPtr.Size == 8)  // 64-bit programs run only on Win64
            {
                return true;
            }
            else  // 32-bit programs run on both 32-bit and 64-bit Windows
            {
                // Detect whether the current process is a 32-bit process 
                // running on a 64-bit system.
                bool flag;
                return ((DoesWin32MethodExist("kernel32.dll", "IsWow64Process") &&
                    IsWow64Process(GetCurrentProcess(), out flag)) && flag);
            }
        }

        /// <summary>
        /// The function determins whether a method exists in the export 
        /// table of a certain module.
        /// </summary>
        /// <param name="moduleName">The name of the module</param>
        /// <param name="methodName">The name of the method</param>
        /// <returns>
        /// The function returns true if the method specified by methodName 
        /// exists in the export table of the module specified by moduleName.
        /// </returns>
        static bool DoesWin32MethodExist(string moduleName, string methodName)
        {
            IntPtr moduleHandle = GetModuleHandle(moduleName);
            if (moduleHandle == IntPtr.Zero)
            {
                return false;
            }
            return (GetProcAddress(moduleHandle, methodName) != IntPtr.Zero);
        }

        [DllImport("kernel32.dll")]
        static extern IntPtr GetCurrentProcess();

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        static extern IntPtr GetModuleHandle(string moduleName);

        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true)]
        static extern IntPtr GetProcAddress(IntPtr hModule,
            [MarshalAs(UnmanagedType.LPStr)]string procName);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool IsWow64Process(IntPtr hProcess, out bool wow64Process);

        #endregion

        #region Is64Bit (WMI)

        /// <summary>
        /// The function determines whether the operating system of the 
        /// current machine of any remote machine is a 64-bit operating 
        /// system through Windows Management Instrumentation (WMI).
        /// </summary>
        /// <param name="machineName">
        /// The full computer name or IP address of the target machine. "." 
        /// or null means the local machine.
        /// </param>
        /// <param name="domain">
        /// NTLM domain name. If the parameter is null, NTLM authentication 
        /// will be used and the NTLM domain of the current user will be used.
        /// </param>
        /// <param name="userName">
        /// The user name to be used for the connection operation. If the 
        /// user name is from a domain other than the current domain, the 
        /// string may contain the domain name and user name, separated by a 
        /// backslash: string 'username' = "DomainName\\UserName". If the 
        /// parameter is null, the connection will use the currently logged-
        /// on user
        /// </param>
        /// <param name="password">
        /// The password for the specified user.
        /// </param>
        /// <returns>
        /// The function returns true if the operating system is 64-bit; 
        /// otherwise, it returns false.
        /// </returns>
        /// <exception cref="System.Management.ManagementException">
        /// The ManagementException exception is generally thrown with the  
        /// error code: System.Management.ManagementStatus.InvalidParameter.
        /// You need to check whether the parameters for ConnectionOptions 
        /// (e.g. user name, password, domain) are set correctly.
        /// </exception>
        /// <exception cref="System.Runtime.InteropServices.COMException">
        /// A common error accompanied with the COMException is "The RPC 
        /// server is unavailable. (Exception from HRESULT: 0x800706BA)". 
        /// This is usually caused by the firewall on the target machine that 
        /// blocks the WMI connection or some network problem.
        /// </exception>
        public static bool Is64Bit(string machineName, string domain, string userName, string password)
        {
            ConnectionOptions options = null;
            if (!string.IsNullOrEmpty(userName))
            {
                // Build a ConnectionOptions object for the remote connection 
                // if you plan to connect to the remote with a different user 
                // name and password than the one you are currently using.
                options = new ConnectionOptions();
                options.Username = userName;
                options.Password = password;
                options.Authority = "NTLMDOMAIN:" + domain;
            }
            // Else the connection will use the currently logged-on user

            // Make a connection to the target computer.
            ManagementScope scope = new ManagementScope("\\\\" +
                (string.IsNullOrEmpty(machineName) ? "." : machineName) +
                "\\root\\cimv2", options);
            scope.Connect();

            // Query Win32_Processor.AddressWidth which dicates the current 
            // operating mode of the processor (on a 32-bit OS, it would be 
            // "32"; on a 64-bit OS, it would be "64").
            // Note: Win32_Processor.DataWidth indicates the capability of 
            // the processor. On a 64-bit processor, it is "64".
            // Note: Win32_OperatingSystem.OSArchitecture tells the bitness
            // of OS too. On a 32-bit OS, it would be "32-bit". However, it 
            // is only available on Windows Vista and newer OS.
            ObjectQuery query = new ObjectQuery(
                "SELECT AddressWidth FROM Win32_Processor");

            // Perform the query and get the result.
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);
            ManagementObjectCollection queryCollection = searcher.Get();
            foreach (ManagementObject queryObj in queryCollection)
            {
                if (queryObj["AddressWidth"].ToString() == "64")
                {
                    return true;
                }
            }

            return false;
        }

        #endregion
    }

    /**********************************************
     *              PROCESS HELPER                *
    /**********************************************/

    public static class ProcessHelper
    {
        private static string FindIndexedProcessName(int pid)
        {
            var processName = Process.GetProcessById(pid).ProcessName;
            var processesByName = Process.GetProcessesByName(processName);
            string processIndexdName = null;

            for (var index = 0; index < processesByName.Length; index++)
            {
                processIndexdName = index == 0 ? processName : processName + "#" + index;
                var processId = new PerformanceCounter("Process", "ID Process", processIndexdName);
                if ((int)processId.NextValue() == pid)
                {
                    return processIndexdName;
                }
            }

            return processIndexdName;
        }

        private static Process FindPidFromIndexedProcessName(string indexedProcessName)
        {
            var parentId = new PerformanceCounter("Process", "Creating Process ID", indexedProcessName);
            return Process.GetProcessById((int)parentId.NextValue());
        }

        public static Process Parent(this Process process)
        {
            return FindPidFromIndexedProcessName(FindIndexedProcessName(process.Id));
        }
    }

    /**********************************************
     *               STRING HELPER                *
    /**********************************************/

    static class StringHelper
    {
        public static bool Contains(this string source, string toCheck, StringComparison comp = StringComparison.OrdinalIgnoreCase)
        {
            return source.IndexOf(toCheck, comp) >= 0;
        }
    }
}
