namespace BugJumperCore
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using BugJumper;
    using BugJumper.Config;
    using BugJumper.Models;
    using BugJumper.Properties;

    public static class Program
    {
        static TrayBasedContext Instance = null;
        static ConfigurationData configData;
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
                JsonConfigProvider optionsProvider = new JsonConfigProvider(GetConfigFileName());
                configData = optionsProvider.Load();

                //TODO: Load this from configData
                var kps = new KeyPressState()
                {
                    IsCtrl = true,
                    Key = Keys.Oemtilde
                };

                Instance = new TrayBasedContext(Resources.AppIcon, kps, optionsProvider);
                ghk.KeyboardPressed += Instance.HandleKey;

                Application.Run(Instance);
            }
        }

        static string GetConfigFileName()
        {
            return @"D:\temp\BugJumperConfig.json";
        }
    }
}
