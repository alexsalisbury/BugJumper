namespace BugJumper.Views
{
    using System;
    using System.Windows.Forms;
    using BugJumper;

    public partial class Launchpad : Form
    {
        public Launchpad(string urlFormat)
        {
            InitializeComponent();
            if (string.IsNullOrWhiteSpace(urlFormat))
            {
                this.Close();
            }
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
        }
    }
}
