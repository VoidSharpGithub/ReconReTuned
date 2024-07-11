using App.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.Forms
{
    public partial class EditReceiverForm : Form
    {
        public ReceiverObject AfterReceiver { get; private set; }
        private ReceiverObject BeforeReceiver;
        public EditReceiverForm(ReceiverObject receiver)
        {
            InitializeComponent();
            BeforeReceiver = receiver;
            AfterReceiver = receiver;
        }

        private async void OKBtn_Click(object sender, EventArgs e)
        {
            OKBtn.Enabled = false;
            if (!IPAddress.TryParse(ReceiverIPTxtbox.Text, out IPAddress ipAddress) || ReceiverNameTxtbox.Text == string.Empty)
            {
                MessageBox.Show("Could not parse IP Address or Name is invalid. Please try again.", "Recon ReTuned", MessageBoxButtons.OK, MessageBoxIcon.Error);
                OKBtn.Enabled = true;
                return;
            }
            else
            {
                AfterReceiver = await ReceiverObject.CreateReceiverObject(ReceiverNameTxtbox.Text, ipAddress);
                if (AfterReceiver == null)
                {
                    MessageBox.Show("The IP Address could not be reached. \n\nPlease try again or verify that a connection can be made to this IP.", "Recon ReTuned", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    OKBtn.Enabled = true;
                    return;
                }
            }
            OKBtn.Enabled = true;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void EditReceiverForm_Load(object sender, EventArgs e)
        {
            ReceiverNameTxtbox.Text = BeforeReceiver.ReceiverName;
            ReceiverIPTxtbox.Text = BeforeReceiver.ReceiverIP.ToString();
            ReceiverNameTxtbox.TextChanged += Txtbox_TextChanged;
            ReceiverIPTxtbox.TextChanged += Txtbox_TextChanged;
        }

        private void Txtbox_TextChanged(object? sender, EventArgs e)
        {
            if(ReceiverIPTxtbox.Text == BeforeReceiver.ReceiverIP.ToString() &&
                ReceiverNameTxtbox.Text == BeforeReceiver.ReceiverName)
            {
                OKBtn.Enabled = false;
            }
            else
            {
                OKBtn.Enabled = true;
            }
        }
    }
}
