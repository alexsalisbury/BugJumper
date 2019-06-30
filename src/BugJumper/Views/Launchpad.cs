namespace BugJumper.Views
{
    using System;
    using System.Windows.Forms;
    using BugJumper;
    using BugJumper.Services;

    public interface INamedForm
    {
        static string CanonicalName { get; }
    }

    public partial class Launchpad : Form, INamedForm
    {
        public static string CanonicalName => "LAUNCHPAD";
        public event EventHandler<UrlFormatChangedEventArgs> UrlFormatChanged;

        private string urlFormat;
        private IUrlLauncher launcher;

        public Launchpad(IUrlLauncher launcher, string urlFormat)
        {
            InitializeComponent();
            
            if (string.IsNullOrWhiteSpace(urlFormat))
            {
                this.Close();
            }

            UrlFormatChanged += Launchpad_UrlFormatChanged;
            this.launcher = launcher;
            this.urlFormat = urlFormat;
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            string target = string.Empty;

            if (int.TryParse(mtxtNumber.Text, out int value))
            {
                target = string.Format(urlFormat, value.ToString());
            }
            //else
            //{
            //    //Check if entered value is a known keyword and launch that url instead.
            //}

            if(!string.IsNullOrWhiteSpace(target))
            {
                launcher.Launch(target);
            }
        }

        private void Launchpad_UrlFormatChanged(object sender, UrlFormatChangedEventArgs e)
        {
            this.urlFormat = e.UriFormat;
        }
    }
}
