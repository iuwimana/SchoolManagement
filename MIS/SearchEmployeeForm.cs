using System;
using System.Linq;
using System.Windows.Forms;
using Security;

namespace MIS
{
    public partial class SearchEmployeeForm : Form
    {
        public Staff SelectedStaff { get; set; }

        public SearchEmployeeForm()
        {
            InitializeComponent();
            listViewEmployees.DoubleClick += listViewEmployees_DoubleClick;
        }

        void listViewEmployees_DoubleClick(object sender, EventArgs e)
        {
            if (SelectedStaff != null)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            listViewEmployees.Items.Clear();
            buttonOK.Enabled = false;

            if (textBoxName.Text.Trim().Length > 0)
            {
                Staffs emps = MISFactory.GetStaffsByName(textBoxName.Text);

                if (emps.Count > 0)
                {
                    foreach (Staff emp in emps)
                    {
                        ListViewItem li = listViewEmployees.Items.Add(emp.RankName + " " + emp.Surname + " " + emp.FirstName + " " + emp.MiddleName);
                        li.SubItems.Add(emp.DepartmentName);
                        li.Tag = emp;
                    }
                }
                else
                {
                    MessageBox.Show("No staff were found matching the name provided");
                }
            }
        }

        private void listViewEmployees_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewEmployees.SelectedItems != null && listViewEmployees.SelectedItems.Count > 0)
            {
                SelectedStaff = (Staff)listViewEmployees.SelectedItems[0].Tag;
                buttonOK.Enabled = true;
            }
            else
            {
                SelectedStaff = null;
                buttonOK.Enabled = false;
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void SearchEmployeeForm_Load(object sender, EventArgs e)
        {
            buttonOK.Enabled = false;
        }
    }
}
