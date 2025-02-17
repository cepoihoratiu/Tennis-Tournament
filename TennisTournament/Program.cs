using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TennisTournament.Controller;

namespace TennisTournament
{
    internal static class Program
    {
        public static string[] SupportedCultures = new[] {
            "de-DE",
            "en-US",
            "ro"
        };
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            var culture = Properties.Settings.Default.Culture;
            Application.SetCompatibleTextRenderingDefault(false);
            if (SupportedCultures.Contains(culture))
            {
                Thread.CurrentThread.CurrentUICulture =
                    Thread.CurrentThread.CurrentCulture =
                    CultureInfo.GetCultureInfo(Properties.Settings.Default.Culture);
            }
            LoginController login = new LoginController();
            Application.Run(login.LoginControllerView());
        }
    }
}
