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
    public partial class DepartmentsForm : Form
    {
        Departments members = null;
        public DepartmentsForm()
        {
            InitializeComponent();
            GlobalsFactory.InitializeListView(this.listViewLookups);
        }

        private void DepartmentsForm_Load(object sender, EventArgs e)
        {
           
            try
            {
                Cursor current = Cursor.Current;
                Cursor.Current = Cursors.WaitCursor;
                members = MISFactory.GetDepartments();
                LoadDepartments(members);
                Cursor.Current = current;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void LoadDepartments(Departments _members)
        {
            try
            {
                listViewLookups.Items.Clear();
               // foreach (Staff record in _members)
                    foreach (Department record in _members)
                {
                    ListViewItem item = new ListViewItem(record.DepartmentName);
                     item.SubItems.Add (record.InstitutioncategoryName);
                    item.SubItems.Add(record.ProvinceName);
                    item.SubItems.Add(record.DistrictName);
                    item.SubItems.Add(record.SectorName);
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
                AddDepartmentsForm frm = new AddDepartmentsForm
                {
                    Tag = new Department()
                };
                frm.ShowDialog();

                DepartmentsForm_Load(this, new EventArgs());
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
                    Department obj = (Department)listViewLookups.SelectedItems[0].Tag;

                    AddDepartmentsForm frm = new AddDepartmentsForm
                    {
                        Tag = obj
                    };
                    frm.ShowDialog();
                    //LoadDepartments();
                    DepartmentsForm_Load(this, new EventArgs());
                }
                else
                {
                    MessageBox.Show("Please select department to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    Department obj = (Department)listViewLookups.SelectedItems[0].Tag;

                    AddDepartmentsForm details = new AddDepartmentsForm { Tag = obj };
                    details.ShowDialog();
                    DepartmentsForm_Load(this, new EventArgs());
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
                    if (MessageBox.Show("Are you sure you want to delete this department?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        ((Department)listViewLookups.SelectedItems[0].Tag).Delete();
                        DepartmentsForm_Load(this, new EventArgs());
                    }
                }
                else
                {
                    MessageBox.Show("Please select department to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
    }
}
