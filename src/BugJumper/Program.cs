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
                //TODO: Load Options from Config
                var kps = new KeyPressState()
                {
                    IsCtrl = true,
                    Key = Keys.Oemtilde
                };

                Instance = new TrayBasedContext(Resources.AppIcon, kps);
                ghk.KeyboardPressed += Instance.HandleKey;

                Application.Run(Instance);
            }
        }
    }
}
