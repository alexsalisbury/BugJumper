using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BugJumper
{
    public class TrayBasedContext : ApplicationContext
    {
        private NotifyIcon trayIcon;

        public TrayBasedContext(Icon appIcon)
        {
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
        }
    }
}