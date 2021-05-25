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
    public partial class BankAccountsForm : Form
    {
        public BankAccountsForm()
        {
            InitializeComponent();
            GlobalsFactory.InitializeListView(this.listView);
        }

        private void BankAccountsForm_Load(object sender, EventArgs e)
        {
            try
            {
                LoadAccounts();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void LoadAccounts()
        {
            try
            {
                listView.Items.Clear();
                foreach (BankAccount record in MISFactory.GetBankAccounts())
                {
                    ListViewItem item = new ListViewItem(record.AccountName);
                    item.SubItems.Add(record.AccountNumber);
                    item.SubItems.Add(record.Currency);
                    item.SubItems.Add(record.BankName);
                    listView.Items.Add(item);
                    item.Tag = record;
                }
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
                AddBankAccountForm frm = new AddBankAccountForm
                {
                    Tag = new BankAccount()
                };
                frm.ShowDialog();

                LoadAccounts();
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
                    BankAccount obj = (BankAccount)listView.SelectedItems[0].Tag;

                    AddBankAccountForm frm = new AddBankAccountForm
                    {
                        Tag = obj
                    };
                    frm.ShowDialog();
                    LoadAccounts();
                }
                else
                {
                    MessageBox.Show("Please select Bank Account to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    BankAccount obj = (BankAccount)listView.SelectedItems[0].Tag;

                    AddBankAccountForm details = new AddBankAccountForm { Tag = obj };
                    details.ShowDialog();
                    LoadAccounts();
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
                    if (MessageBox.Show("Are you sure you want to delete this Bank Account?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        ((BankAccount)listView.SelectedItems[0].Tag).Delete();
                        LoadAccounts();
                    }
                }
                else
                {
                    MessageBox.Show("Please select Bank Account to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
    }
}
