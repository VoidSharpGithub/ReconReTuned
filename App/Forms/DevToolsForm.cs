using App.Handlers;
using App.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace App.Forms
{
    public partial class DevToolsForm : Form
    {
        public DevToolsForm()
        {
            InitializeComponent();
        }

        private void DevToolsForm_Load(object sender, EventArgs e)
        {
            ReceiverCombobox.Items.Clear();
            ReceiverCombobox.Items.AddRange(Program.Receivers.ToArray());
            ServiceTypeCombobox.Items.Clear();
            ServiceTypeCombobox.Items.AddRange(new[] { ServiceType.EchoSTB1, ServiceType.EchoSTB2 });
            ArgumentDataGridView.AutoGenerateColumns = false;
        }

        private void ReceiverCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ReceiverCombobox.SelectedIndex != -1)
                ServiceTypeCombobox.Enabled = true;
            else
                ServiceTypeCombobox.Enabled = false;
            ServiceTypeCombobox.SelectedIndex = -1;

            ActionResponseTreeView.Nodes.Clear();
            ActionResponseTreeView.Enabled = false;
        }

        private async void ServiceTypeCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ServiceTypeCombobox.SelectedIndex == -1)
            {
                ActionCombobox.SelectedIndex = -1;
                ActionCombobox.Items.Clear();
                ActionResponseTreeView.Nodes.Clear();
                ActionResponseTreeView.Enabled = false;
                ActionCombobox.Enabled = false;
                SendRequestButton.Enabled = false;
            }
            else
            {
                ReceiverObject SelectedReceiver = ReceiverCombobox.SelectedItem as ReceiverObject;
                ServiceType SelectedServiceType = ServiceTypeCombobox.SelectedItem as ServiceType;
                List<SOAPActionObject> Actions = await SOAPHandler.GetSOAPActionsForService(SelectedReceiver.ReceiverIP, SelectedServiceType);
                ActionCombobox.Items.Clear();
                ActionCombobox.Items.AddRange(Actions.ToArray());
                ActionCombobox.Enabled = true;
                ArgumentDataGridView.DataSource = null;
                ArgumentDataGridView.Rows.Clear();
                ArgumentDataGridView.Enabled = false;
                ActionResponseTreeView.Nodes.Clear();
                ActionResponseTreeView.Enabled = false;
            }
        }

        private async void ActionCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ActionCombobox.SelectedIndex == -1)
            {
                ArgumentDataGridView.DataSource = null;
                ArgumentDataGridView.Rows.Clear();
                ArgumentDataGridView.Enabled = false;
                SendRequestButton.Enabled = false;
                ActionResponseTreeView.Nodes.Clear();
                ActionResponseTreeView.Enabled = false;
            }
            else
            {
                ReceiverObject SelectedReceiver = ReceiverCombobox.SelectedItem as ReceiverObject;
                ServiceType SelectedServiceType = ServiceTypeCombobox.SelectedItem as ServiceType;
                SOAPActionObject SelectedAction = ActionCombobox.SelectedItem as SOAPActionObject;
                List<SOAPActionStateVariable> Variables = await SOAPHandler.GetSOAPActionVariablesForService(SelectedReceiver.ReceiverIP, SelectedServiceType);
                if (SelectedAction.Arguments == null)
                {
                    ArgumentDataGridView.DataSource = null;
                    ArgumentDataGridView.Rows.Clear();
                    ArgumentDataGridView.Enabled = false;
                }
                else
                {
                    List<SOAPActionArgument> InputArgs = new List<SOAPActionArgument>();
                    foreach (SOAPActionArgument arg in SelectedAction.Arguments)
                    {
                        if (arg.Direction == "in")
                            InputArgs.Add(arg);
                    }

                    if (InputArgs.Count <= 0)
                    {
                        ArgumentDataGridView.DataSource = null;
                        ArgumentDataGridView.Rows.Clear();
                        ArgumentDataGridView.Enabled = false;
                    }
                    else
                    {
                        List<SOAPActionDataGridArgument> DataGridArgs = new List<SOAPActionDataGridArgument>();
                        foreach (SOAPActionArgument arg in InputArgs)
                        {
                            SOAPActionStateVariable Variable = Variables.Find((N) => N.Name == arg.RelatedStateVariable);
                            if (Variable.AllowedValues != null)
                            {
                                DataGridArgs.Add(new SOAPActionDataGridArgument(arg, "Combo1", Variable));
                                continue;
                            }
                            if (Variable.AllowedValueRange != null)
                            {
                                DataGridArgs.Add(new SOAPActionDataGridArgument(arg, "Combo2", Variable));
                                continue;
                            }
                            DataGridArgs.Add(new SOAPActionDataGridArgument(arg));
                        }
                        ArgumentDataGridView.DataSource = DataGridArgs;
                        ArgumentDataGridView.Enabled = true;
                    }
                }
                SendRequestButton.Enabled = true;
                ActionResponseTreeView.Nodes.Clear();
                ActionResponseTreeView.Enabled = false;
            }
        }

        private async void SendRequestButton_Click(object sender, EventArgs e)
        {
            SendRequestButton.Enabled = false;
            ArgumentDataGridView.Enabled = false;
            ActionCombobox.Enabled = false;
            ServiceTypeCombobox.Enabled = false;
            ReceiverCombobox.Enabled = false;
            ReceiverObject SelectedReceiver = ReceiverCombobox.SelectedItem as ReceiverObject;
            ServiceType SelectedServiceType = ServiceTypeCombobox.SelectedItem as ServiceType;
            SOAPActionObject SelectedAction = ActionCombobox.SelectedItem as SOAPActionObject;
            List<SOAPActionStateVariable> Variables = await SOAPHandler.GetSOAPActionVariablesForService(SelectedReceiver.ReceiverIP, SelectedServiceType);
            foreach (DataGridViewRow row in ArgumentDataGridView.Rows)
            {
                SOAPActionDataGridArgument arg = row.DataBoundItem as SOAPActionDataGridArgument;
                SOAPActionStateVariable variable = Variables.Find((N) => N.Name == arg.Argument.RelatedStateVariable);
                if (variable.AllowedValues != null)
                {
                    if (!variable.AllowedValues.Contains(arg.Value))
                    {
                        MessageBox.Show("Invalid Argument!");
                        SendRequestButton.Enabled = true;
                        ArgumentDataGridView.Enabled = true;
                        ActionCombobox.Enabled = true;
                        ServiceTypeCombobox.Enabled = true;
                        ReceiverCombobox.Enabled = true;
                        return;
                    }
                }
                if (variable.AllowedValueRange != null)
                {
                    if (!int.TryParse(arg.Value, out int value))
                    {
                        MessageBox.Show("Invalid Argument!");
                        SendRequestButton.Enabled = true;
                        ArgumentDataGridView.Enabled = true;
                        ActionCombobox.Enabled = true;
                        ServiceTypeCombobox.Enabled = true;
                        ReceiverCombobox.Enabled = true;
                        return;
                    }
                    else
                    {
                        if (value > variable.AllowedValueRange.Maximum || value < variable.AllowedValueRange.Minimum)
                        {
                            MessageBox.Show("Invalid Argument!");
                            SendRequestButton.Enabled = true;
                            ArgumentDataGridView.Enabled = true;
                            ActionCombobox.Enabled = true;
                            ServiceTypeCombobox.Enabled = true;
                            ReceiverCombobox.Enabled = true;
                            return;
                        }
                    }
                }
            }

            //No Issues with Arguments, proceed
            XmlDocument xmlEnv = SOAPHandler.GenerateSoapEnvelope(SelectedAction.Name, ConvertRowsToDictionary(ArgumentDataGridView));
            XmlDocument xml = await SOAPHandler.PostSoapRequest(SelectedReceiver.ReceiverIP, xmlEnv, SelectedServiceType);
            ActionResponseTreeView.Nodes.Clear();
            if(xml == null)
            {
                MessageBox.Show("Error: No data responded", "Recon ReTuned", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ActionResponseTreeView.Enabled = true;
                SendRequestButton.Enabled = true;
                ArgumentDataGridView.Enabled = true;
                ActionCombobox.Enabled = true;
                ServiceTypeCombobox.Enabled = true;
                ReceiverCombobox.Enabled = true;
                return;
            }
            XmlNode bodyNode = xml.DocumentElement["s:Body"];
            if (bodyNode != null)
            {
                TreeNode treeNode = ActionResponseTreeView.Nodes.Add(bodyNode.LocalName);
                AddNode(bodyNode, treeNode);
            }
            ActionResponseTreeView.Enabled = true;
            SendRequestButton.Enabled = true;
            ArgumentDataGridView.Enabled = true;
            ActionCombobox.Enabled = true;
            ServiceTypeCombobox.Enabled = true;
            ReceiverCombobox.Enabled = true;
        }

        private void AddNode(XmlNode xmlNode, TreeNode treeNode)
        {
            foreach (XmlNode node in xmlNode.ChildNodes)
            {
                if (node.NodeType == XmlNodeType.Element)
                {
                    TreeNode childTreeNode = treeNode.Nodes.Add(node.LocalName);
                    if (node.HasChildNodes && node.FirstChild.NodeType == XmlNodeType.Text)
                    {
                        childTreeNode.Nodes.Add(node.InnerText);
                    }
                    else
                    {
                        AddNode(node, childTreeNode);
                    }
                }
            }
        }

        private Dictionary<string, string> ConvertRowsToDictionary(DataGridView dg)
        {
            var dictionary = new Dictionary<string, string>();

            foreach (DataGridViewRow row in dg.Rows)
            {
                if (row.DataBoundItem is SOAPActionDataGridArgument gridArgument)
                {
                    if (!string.IsNullOrEmpty(gridArgument.Value)) // Optionally check if the value is not empty
                    {
                        dictionary[gridArgument.Argument.Name] = gridArgument.Value;
                    }
                }
            }

            return dictionary;
        }

        private void ArgumentDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void ArgumentDataGridView_DataSourceChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < ArgumentDataGridView.Rows.Count; i++)
            {
                if (i >= 0)
                {
                    if (ArgumentDataGridView.Rows[i].DataBoundItem is SOAPActionDataGridArgument item && item != null)
                    {
                        DataGridViewCell cell = ArgumentDataGridView[1, i];
                        if (cell != null)
                        {
                            cell.Dispose();
                            switch (item.ControlType)
                            {
                                case "Combo1":
                                    var comboCell = new DataGridViewComboBoxCell();
                                    if (item.Variable?.AllowedValues != null)
                                    {
                                        comboCell.DataSource = item.Variable.AllowedValues;
                                        ArgumentDataGridView[1, i] = comboCell;
                                        comboCell.Value = item.Variable.AllowedValues[0];
                                    }
                                    break;
                                case "Combo2":
                                    comboCell = new DataGridViewComboBoxCell();
                                    if (item.Variable?.AllowedValueRange != null)
                                    {
                                        int min = item.Variable.AllowedValueRange.Minimum;
                                        int max = item.Variable.AllowedValueRange.Maximum;
                                        comboCell.DataSource = Enumerable.Range(min, max - min + 1).Select(i => i.ToString()).ToArray();
                                        ArgumentDataGridView[1, i] = comboCell;
                                        comboCell.Value = Enumerable.Range(min, max - min + 1).Select(i => i.ToString()).ToArray()[0];
                                    }
                                    break;
                                default:
                                    ArgumentDataGridView[1, i] = new DataGridViewTextBoxCell();
                                    break;
                            }
                        }
                    }
                }
            }
        }

        private void ArgumentDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.RowIndex >= 0)
            {
                if(ArgumentDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex] is DataGridViewComboBoxCell)
                {
                    ArgumentDataGridView.CurrentCell = ArgumentDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    ArgumentDataGridView.BeginEdit(true);
                    System.Windows.Forms.ComboBox comboBox = (System.Windows.Forms.ComboBox)ArgumentDataGridView.EditingControl;
                    comboBox.DroppedDown = true;
                }
            }
        }
    }
}
