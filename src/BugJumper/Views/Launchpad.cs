namespace BugJumper.Views
{
    using System;
    using System.Windows.Forms;
    using BugJumper;

    public partial class Launchpad : Form
    {
        string urlFormat;
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
