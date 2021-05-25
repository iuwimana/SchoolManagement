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
    public partial class StaffTypesForm : Form
    {
        public StaffTypesForm()
        {
            InitializeComponent();
            GlobalsFactory.InitializeListView(this.listViewLookups);
        }

        private void StaffTypesForm_Load(object sender, EventArgs e)
        {
            try
            {
                LoadPersonnelCategories();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void LoadPersonnelCategories()
        {
            try
            {
                listViewLookups.Items.Clear();
                foreach (StaffType record in MISFactory.GetStaffTypes())
                {
                    ListViewItem item = new ListViewItem(record.StaffTypeName);
                    item.SubItems.Add(record.TypeofContract);
                    item.SubItems.Add(record.DurationofContract);
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
                AddStaffTypesForm frm = new AddStaffTypesForm
                {
                    Tag = new StaffType()
                };
                frm.ShowDialog();

                LoadPersonnelCategories();
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
                    StaffType obj = (StaffType)listViewLookups.SelectedItems[0].Tag;

                    AddStaffTypesForm frm = new AddStaffTypesForm
                    {
                        Tag = obj
                    };
                    frm.ShowDialog();
                    LoadPersonnelCategories();
                }
                else
                {
                    MessageBox.Show("Please select personnel category to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    StaffType obj = (StaffType)listViewLookups.SelectedItems[0].Tag;

                    AddStaffTypesForm details = new AddStaffTypesForm { Tag = obj };
                    details.ShowDialog();
                    LoadPersonnelCategories();
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
                    if (MessageBox.Show("Are you sure you want to delete this personnel category?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        ((StaffType)listViewLookups.SelectedItems[0].Tag).Delete();
                        LoadPersonnelCategories();
                    }
                }
                else
                {
                    MessageBox.Show("Please select personnel category to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
    }
}
