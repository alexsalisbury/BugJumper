namespace BugJumper
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;

    public class TrayBasedContext : ApplicationContext
    {
        private NotifyIcon trayIcon;
        private Dictionary<Keys, bool> controlState;

        public TrayBasedContext(Icon appIcon)
        {
            controlState = new Dictionary<Keys, bool>();
            foreach (var k in GlobalKeyboardHook.ControlKeys)
            {
                controlState.Add(k, false);
            }

            var exit = new MenuItem("Exit", Exit);

            MenuItem[] main = { exit };

            // Initialize Tray Icon
            trayIcon = new NotifyIcon()
            {
                Icon = appIcon,
                ContextMenu = new ContextMenu(main),
                Visible = true
            };
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
        }
    }
}