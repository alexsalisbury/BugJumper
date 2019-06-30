namespace BugJumper.Services
{
    using System;
    using System.Diagnostics;

    public interface IUrlLauncher
    {
        void Launch(string url);
    }

    //http://faithlife.codes/blog/2008/01/using_processstart_to_link_to/
    public class UrlLauncher : IUrlLauncher
    {
        public void Launch(string url)
        {
            try
            {
                Process.Start(url);
            }
            catch (Exception)
            {
                // This catch should only occur if the user doesn't have a default browser for some reason.
                Process.Start("iexplore.exe", url);
            }
            finally
            {
            }
        }
    }
}