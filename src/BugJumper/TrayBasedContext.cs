using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BugJumper
{
    public interface IIconInfo
    {
        Icon Icon { get;}
    }

    public class TrayBasedContext : ApplicationContext
    {
        private NotifyIcon trayIcon;

        public TrayBasedContext(IIconInfo appIcon)
        {
            var exit = new MenuItem("Exit", Exit);

            MenuItem[] main = { exit };

            // Initialize Tray Icon
            trayIcon = new NotifyIcon()
            {
                Icon = appIcon?.Icon,
                ContextMenu = new ContextMenu(main),
                Visible = true
            };
        }

        public void Exit(object sender, EventArgs e)
        {
        }
    }
}