using App.Handlers;
using App.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.Forms
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void OKBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        //TODO: Fix Github Linking
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string GitHubURL = Settings.Default.repo_url;
            if (e.Button == MouseButtons.Left)
            {
                try
                {
                    Process.Start(new ProcessStartInfo(GitHubURL) { UseShellExecute = true });
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("An error occurred: " + ex.Message);
                }
            }
            else
            {
                Clipboard.SetText(GitHubURL);
                MessageBox.Show("Github URL Coppied to Clipboard.");
            }
        }

        private void Aboutfrm_Load(object sender, EventArgs e)
        {
            label1.Text = $"Recon ReTuned v{Settings.Default.version}";
        }
    }
}
