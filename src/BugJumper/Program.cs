namespace BugJumperCore
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using BugJumper;
    using BugJumper.Properties;

    public static class Program
    {
        static TrayBasedContext Instance = null;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (GlobalKeyboardHook ghk = new GlobalKeyboardHook())
            {
                Instance = new TrayBasedContext(Resources.AppIcon);
                ghk.KeyboardPressed += Instance.HandleKey;

                Application.Run(Instance);
            }
        }
    }
}
