namespace BugJumper
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;
    using BugJumper.Config;
    using BugJumper.Models;
    using BugJumper.Services;
    using BugJumper.Views;

    public class TrayBasedContext : ApplicationContext
    {
        private NotifyIcon trayIcon;
        private Dictionary<Keys, bool> controlState;
        private Dictionary<string, Form> forms = new Dictionary<string, Form>();
        private KeyPressState formLaunchShortcut;
        private IUrlLauncher launcher;
        private IConfigProvider optionProvider;
        private ConfigurationData data;
        private const string UrlFormatKey = "UrlFormat";
        private const string OptionsKey = "Options";
        private OptionsData dataObject;


        public TrayBasedContext(Icon appIcon, KeyPressState kps, IConfigProvider optionProvider)
        {
            this.formLaunchShortcut = kps;
            this.optionProvider = optionProvider;
            dynamic data = optionProvider.Load();
            if (!data.ContainsKey("Options"))
            {
                dataObject = new OptionsData(data);

                data.Add("Options", dataObject.GetData());
                data.Remove(UrlFormatKey);
                this.EnsureRequiredOptions(data.Options, optionProvider);
                optionProvider.Save(data);
            }
            else
            {
                dataObject = new OptionsData(data.Options);
            }

            launcher = new UrlLauncher();
            controlState = new Dictionary<Keys, bool>();

            foreach (var k in GlobalKeyboardHook.ControlKeys)
            {
                controlState.Add(k, false);
            }

            var launch = new MenuItem("Launch", Launch);
            var options = new MenuItem("Options", Options);
            var exit = new MenuItem("Exit", Exit);

            MenuItem[] main = { launch, exit };

            // Initialize Tray Icon
            trayIcon = new NotifyIcon()
            {
                Icon = appIcon,
                ContextMenu = new ContextMenu(main),
                Visible = true
            };
        }

        private ConfigurationData EnsureRequiredOptions(ConfigurationData data, IConfigProvider optionProvider, bool forceSave = false)
        {
            bool changed = false;
            changed = EnsureRequiredOption(data, UrlFormatKey) || changed;

            if (changed || forceSave)
            {
                optionProvider.Save(data);
            }

            return data;
        }

        private bool EnsureRequiredOption(ConfigurationData data, string optionName)
        {
            if (!data.ContainsKey(optionName))
            {
                data.Add(optionName, "UNSET_VALUE");
                return true;
            }

            return false;
        }

        private void Options(object sender, EventArgs e)
        {
        }

        public void Exit(object sender, EventArgs e)
        {
            // Hide tray icon, otherwise it will remain shown until user mouses over it
            trayIcon.Visible = false;

            Application.Exit();
        }

        public void HandleKey(object sender, GlobalKeyboardHookEventArgs args)
        {
            var data = args.KeyboardData;
            var state = args.KeyboardState;

            bool isSys = ((state == KeyboardState.SysKeyDown) || (state == KeyboardState.SysKeyUp));
            bool isDown = ((state == KeyboardState.KeyDown) || (state == KeyboardState.SysKeyDown));

            controlState[data.Key] = isDown;

            var kps = KeyPressState.Create(controlState, data.Key);
            VerifyFormState(kps, isDown);
        }

        private void VerifyFormState(KeyPressState kps, bool isDown)
        {
            if (isDown && this.ShouldShowForm(kps))
            {
                Launch(this, null);
            }
        }

        private bool ShouldShowForm(KeyPressState kps)
        {
            return kps.Equals(this.formLaunchShortcut);
        }

        public void Launch(object sender, EventArgs e)
        {
            var formName = Launchpad.CanonicalNameCore;

            if (!this.forms.ContainsKey(formName))
            {
                //Ensure makes sure this is available as a Key in the dict.
                this.forms[formName] = new Launchpad(launcher, dataObject.UrlFormat);
            }

            var form = (Launchpad)this.forms[formName];
            form.Show();
            form.Reset();
        }
    }
}