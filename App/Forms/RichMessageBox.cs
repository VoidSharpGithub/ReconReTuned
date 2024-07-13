using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace App.Forms
{
    public partial class RichMessageBox : Form
    {
        public RichMessageBox()
        {
            InitializeComponent();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public static void Show(string caption, string message, string title)
        {
            RichMessageBox messageBox = new RichMessageBox();
            messageBox.CaptionLabel.Text = caption;
            messageBox.ContentsTextbox.Text = message;
            messageBox.Text = title;
            messageBox.ShowDialog();
        }

        public static void ShowXML(string caption, XmlDocument xmlDocument, string title)
        {
            RichMessageBox messageBox = new RichMessageBox();
            messageBox.CaptionLabel.Text = caption;
            messageBox.ContentsTextbox.Text = PrettyPrintXml(xmlDocument);
            messageBox.Text = title;
            messageBox.ShowDialog();
        }

        private static string PrettyPrintXml(XmlDocument xmlDocument)
        {
            using (StringWriter stringWriter = new StringWriter())
            {
                using (XmlTextWriter xmlTextWriter = new XmlTextWriter(stringWriter))
                {
                    xmlTextWriter.Formatting = Formatting.Indented;
                    xmlDocument.WriteTo(xmlTextWriter);
                    return stringWriter.ToString();
                }
            }
        }
    }
}
