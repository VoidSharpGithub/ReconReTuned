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
        public DevPasswordForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (PasswordTextbox.Text == Program.DevPassword || !Program.DevPasswordRequired) 
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
            if (!Program.DevPasswordRequired)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
