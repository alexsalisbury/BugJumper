namespace BugJumper.Services
{
    using System;
    using System.Diagnostics;

    public interface IUrlLauncher
    {
        void Launch(string url);
    }

    //https://stackoverflow.com/questions/7693429/process-start-to-open-an-url-getting-an-exception
    public class UrlLauncher : IUrlLauncher
    {
        public void Launch(string url)
        {
            try
            {
                var ps = new ProcessStartInfo(url)
                {
                    UseShellExecute = true,
                    Verb = "open"
                };
                Process.Start(ps);
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