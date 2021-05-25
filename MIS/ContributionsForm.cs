using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Globals;

namespace MIS
{
    public partial class ContributionsForm : Form
    {
        public ContributionsForm()
        {
            InitializeComponent();
            GlobalsFactory.InitializeListView(this.listView);
        }

        private void ContributionsForm_Load(object sender, EventArgs e)
        {
            try
            {
                Staff obj = (Staff)this.Tag;

                this.Text = obj.Surname + " " + obj.FirstName + " " + obj.MiddleName + " CONTRIBUTIONS";
                LoadContributions();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void LoadContributions()
        {
            try
            {
                Staff obj = (Staff)this.Tag;
                long totalContribution = 0;

                listView.Items.Clear();
                foreach (Contribution record in MISFactory.GetContributionsForMember(obj.StaffID))
                {
                    totalContribution += record.Amount;

                    ListViewItem item = new ListViewItem(string.Format("{0:#,#}", record.Amount));
                    item.SubItems.Add(record.BankTransactionDate.ToString("dd/MM/yyyy"));
                    item.SubItems.Add(record.Year.ToString());
                    item.SubItems.Add(record.Month.ToString());
                    item.SubItems.Add(record.BankName);
                    item.SubItems.Add(record.AccountNumber);
                    item.SubItems.Add(record.AccountName);
                    listView.Items.Add(item);
                    item.Tag = record;
                }

                textBoxTotalContribution.Text = totalContribution == 0 ? "0" : string.Format("{0:#,#}", totalContribution);
            }
            catch
            {
                throw;
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Staff obj = (Staff)this.Tag;

                AddContributionForm frm = new AddContributionForm
                {
                    Tag = new Contribution() { StaffID = obj.StaffID, BankTransactionDate = DateTime.Today }
                };
                frm.ShowDialog();

                LoadContributions();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView.SelectedItems.Count > 0)
                {
                    Contribution obj = (Contribution)listView.SelectedItems[0].Tag;

                    AddContributionForm frm = new AddContributionForm
                    {
                        Tag = obj
                    };
                    frm.ShowDialog();
                    LoadContributions();
                }
                else
                {
                    MessageBox.Show("Please select contribution to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void listView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                listView_DoubleClick(this, new EventArgs());
            }
        }

        private void listView_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (listView.SelectedItems.Count > 0)
                {
                    Contribution obj = (Contribution)listView.SelectedItems[0].Tag;

                    AddContributionForm details = new AddContributionForm { Tag = obj };
                    details.ShowDialog();
                    LoadContributions();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView.SelectedItems.Count > 0)
                {
                    if (MessageBox.Show("Are you sure you want to delete this contribution?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)
                        == DialogResult.OK)
                    {
                        ((Contribution)listView.SelectedItems[0].Tag).Delete(Globals.GlobalsFactory.GetCurrentUserId());
                        LoadContributions();
                    }
                }
                else
                {
                    MessageBox.Show("Please select contribution to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
    }
}
