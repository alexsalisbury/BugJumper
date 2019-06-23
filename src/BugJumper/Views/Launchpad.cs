namespace BugJumper.Views
{
    using System;
    using System.Windows.Forms;
    using BugJumper;

    public interface INamedForm
    {
        static string CanonicalName { get; }
    }

    public partial class Launchpad : Form, INamedForm
    {
        string urlFormat;

        public static string CanonicalName => "LAUNCHPAD";

        public event EventHandler<UrlFormatChangedEventArgs> UrlFormatChanged;

        public Launchpad(string urlFormat)
        {
            InitializeComponent();
            UrlFormatChanged += Launchpad_UrlFormatChanged;
            if (string.IsNullOrWhiteSpace(urlFormat))
            {
                this.Close();
            }
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
        }

        private void Launchpad_UrlFormatChanged(object sender, UrlFormatChangedEventArgs e)
        {
            this.urlFormat = e.UriFormat;
        }
    }
}
