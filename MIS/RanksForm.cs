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
    public partial class RanksForm : Form
    {
        public RanksForm()
        {
            InitializeComponent();
            GlobalsFactory.InitializeListView(this.listViewLookups);
        }

        private void RanksForm_Load(object sender, EventArgs e)
        {
            try
            {
                LoadRanks();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void LoadRanks()
        {
            try
            {
                listViewLookups.Items.Clear();
                foreach (Rank record in MISFactory.GetRanks())
                {
                    ListViewItem item = new ListViewItem(record.RankName);
                    listViewLookups.Items.Add(item);
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
                AddRanksForm frm = new AddRanksForm
                {
                    Tag = new Rank()
                };
                frm.ShowDialog();

                LoadRanks();
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
                if (listViewLookups.SelectedItems.Count > 0)
                {
                    Rank obj = (Rank)listViewLookups.SelectedItems[0].Tag;

                    AddRanksForm frm = new AddRanksForm
                    {
                        Tag = obj
                    };
                    frm.ShowDialog();
                    LoadRanks();
                }
                else
                {
                    MessageBox.Show("Please select rank to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void listViewLookups_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                listViewLookups_DoubleClick(this, new EventArgs());
            }
        }

        private void listViewLookups_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (listViewLookups.SelectedItems.Count > 0)
                {
                    Rank obj = (Rank)listViewLookups.SelectedItems[0].Tag;

                    AddRanksForm details = new AddRanksForm { Tag = obj };
                    details.ShowDialog();
                    LoadRanks();
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
                if (listViewLookups.SelectedItems.Count > 0)
                {
                    if (MessageBox.Show("Are you sure you want to delete this rank?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        ((Rank)listViewLookups.SelectedItems[0].Tag).Delete();
                        LoadRanks();
                    }
                }
                else
                {
                    MessageBox.Show("Please select rank to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
    }
}
