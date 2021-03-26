using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace notepad
{
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAbout_Load(object sender, EventArgs e)
        {
            lblProductName.Text = string.Format("Product name: {0}", Application.ProductName);
            lblProductVersion.Text = string.Format("Product version: {0}", Application.ProductVersion);
            lblCopyright.Text = "Copyright 2019 by IO";
        }

        private void lblCopyright_Click(object sender, EventArgs e)
        {

        }

        private void lblProductVersion_Click(object sender, EventArgs e)
        {

        }
    }
}
