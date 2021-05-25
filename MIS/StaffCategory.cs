using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MIS
{
    public partial class StaffCategory : Form
    {
        public StaffCategory()
        {
            InitializeComponent();
        }

        private void StaffCategory_Load(object sender, EventArgs e)
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
                    item.SubItems.Add(record.StaffTypeID.ToString());
                    listViewLookups.Items.Add(item);
                    item.Tag = record;

                }
            }
            catch
            {
                throw;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                foreach (ListViewItem item in listViewLookups.Items)
                {
                    item.UseItemStyleForSubItems = false;
                    bool isVisible = false;

                    foreach (ListViewItem.ListViewSubItem subItem in item.SubItems)
                    {
                        subItem.ForeColor = Color.Black;
                        if (subItem.Text.ToLower().Contains(textBox1.Text.ToLower()))
                        {
                            subItem.ForeColor = Color.Red;
                            isVisible = true;
                        }
                    }

                    if (isVisible) { item.EnsureVisible(); }
                    else { item.Remove(); }
                }
            }

            else
            {
                MessageBox.Show("Please enter member to search.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void listViewLookups_DoubleClick(object sender, EventArgs e)
        {

        }
    }
}
