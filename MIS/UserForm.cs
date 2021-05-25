using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Security;

namespace MIS
{
    public partial class UserForm : Form
    {

        private Staff currentStaff;

        public UserForm()
        {
            InitializeComponent();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {

                

                //Some validation of user data
                if (textBoxUserName.TextLength * textBoxPassword.TextLength * textBoxConfirm.TextLength == 0)
                {
                    MessageBox.Show(this, "Please enter all the required data");
                    return;
                }

                string confirm = textBoxConfirm.Text;
                string password = textBoxPassword.Text;
                string username = textBoxUserName.Text;
                bool active = checkBoxActive.Checked;
                int staffID;
                if (textBoxEmployeeName.TextLength == 0)
                {
                    staffID = 0;
                }
                else
                { 
                staffID = currentStaff.StaffID;
                }

                if (confirm == password)
                {
                    User user = SecurityFactory.CreateUser(username, password, active, staffID);

                    long parentID = AuditTrailManager.Instance.Add("CREATE", "User", user.UserID.ToString(), user.UserName, 0);

                    this.Close();
                }
                else
                    MessageBox.Show(this, "The passwords do not match");
            }
            catch (Exception ex)
            {
                                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            buttonSave.Enabled = false;
            checkBoxActive.Checked = true;
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            SearchEmployeeForm sef = new SearchEmployeeForm();

            if (sef.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                currentStaff = sef.SelectedStaff;
                textBoxEmployeeName.Text = currentStaff.Surname + " " + currentStaff.FirstName + " " + currentStaff.MiddleName;
            }
        }

        private void textBoxUserName_TextChanged(object sender, EventArgs e)
        {
            if (textBoxUserName.Text.Trim().Length == 0)
                buttonSave.Enabled = false;
            else
                buttonSave.Enabled = true;
        }

    }
}
