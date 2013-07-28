using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;

namespace AdobeCS6CrackAssistant
{
    /// <summary>
    /// Assists in gathering assembly information about the application.
    /// </summary>
    public class AppInfo
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
}