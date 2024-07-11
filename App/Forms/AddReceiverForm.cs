using App.Handlers;
using App.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace App.Forms
{
    public partial class AddReceiverForm : Form
    {
        public ReceiverObject? Receiver { get; private set; }
        public AddReceiverForm()
        {
            InitializeComponent();
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
                Receiver = await ReceiverObject.CreateReceiverObject(ReceiverNameTxtbox.Text, ipAddress);
                if (Receiver == null)
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

        private void AddReceiverForm_Load(object sender, EventArgs e)
        {
            HashSet<string> nameExclusions = Program.Receivers.Select(r => r.ReceiverName).ToHashSet();
            int index = 1;
            string receiverName;

            do
            {
                receiverName = $"Receiver {GenerateExcelStyleName(index)}";
                index++;
            } while (nameExclusions.Contains(receiverName));

            ReceiverNameTxtbox.Text = receiverName;
        }

        private string GenerateExcelStyleName(int index)
        {
            string columnName = String.Empty;
            int dividend = index;
            int modulo;

            while (dividend > 0)
            {
                modulo = (dividend - 1) % 26;
                columnName = Convert.ToChar(65 + modulo) + columnName;
                dividend = (dividend - modulo) / 26;
            }

            return columnName;
        }
    }
}
