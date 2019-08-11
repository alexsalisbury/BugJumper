namespace BugJumper.Views
{
    using System;
    using System.Windows.Forms;

    public partial class Options : Form, INamedForm
    {
#if NETCOREAPP3_0
        public static string CanonicalNameCore => "LAUNCHPAD";
#else        
        public static string CanonicalNameCore => "OPTIONS";
        public string CanonicalName => "OPTIONS";
#endif

        public Options()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
