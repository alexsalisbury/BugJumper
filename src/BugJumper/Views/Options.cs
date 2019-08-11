namespace BugJumper.Views
{
    using System;
    using System.Windows.Forms;

    public partial class Options : Form
    {
        public Options()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
