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
    public partial class serchwebuser : Form
    {
        public Applicant SelectedStaff { get; set; }
        public serchwebuser()
        {
            InitializeComponent();
        }

        private void serchwebuser_Load(object sender, EventArgs e)
        {

        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            listViewEmployees.Items.Clear();
            buttonOK.Enabled = false;

            if (textBoxName.Text.Trim().Length > 0)
            {
                Applicants emps = MISFactory.GetApplicants(textBoxName.Text);

                if (emps.Count > 0)
                {
                    foreach (Applicant emp in emps)
                    {
                        ListViewItem li = listViewEmployees.Items.Add(emp.UserName + " " + emp.LastName + " " + emp.FirstName + " " + emp.MiddleName);
                        li.SubItems.Add(emp.IDNumber);
                        li.Tag = emp;
                    }
                }
                else
                {
                    MessageBox.Show("No Applicant were found matching the name provided");
                }
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void listViewEmployees_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewEmployees.SelectedItems != null && listViewEmployees.SelectedItems.Count > 0)
            {
                SelectedStaff = (Applicant)listViewEmployees.SelectedItems[0].Tag;
                buttonOK.Enabled = true;
            }
            else
            {
                SelectedStaff = null;
                buttonOK.Enabled = false;
            }
        }

        private void listViewEmployees_DoubleClick(object sender, EventArgs e)
        {
            if (SelectedStaff != null)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }
    }
}
