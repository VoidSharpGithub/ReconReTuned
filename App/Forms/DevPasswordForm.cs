using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.Forms
{
    public partial class DevPasswordForm : Form
    {
        private bool PasswordRequired = true; // Set to False to Skip Password
        private string Password = "R3C0NT007Z"; // Set to new password for Public Applications
        public DevPasswordForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (PasswordTextbox.Text == Password || !PasswordRequired) 
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid Password, try again");
                PasswordTextbox.Clear();
                PasswordTextbox.Focus();
            }
        }

        private void DevPasswordForm_Load(object sender, EventArgs e)
        {
            if (!PasswordRequired)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
