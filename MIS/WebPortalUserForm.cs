using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Security;
using Globals;

namespace MIS
{
    public partial class WebPortalUserForm : Form
    {
        Departments members = null;
        private Applicant currentUser;
        public WebPortalUserForm()
        {
            InitializeComponent();
        }

        private void WebPortalUserForm_Load(object sender, EventArgs e)
        {
            try
            {
                Cursor current = Cursor.Current;
                Cursor.Current = Cursors.WaitCursor;
                //EnableButtons(false, false, false, false, false);
                //Load the users 
                Users users = SecurityFactory.GetwebUsers();
                //Users users = SecurityFactory.GetUsers();
                ShowUsers(users);
               Cursor.Current = current;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }






        private void ShowUsers(Users _users)
        {
            try
            {
                listViewUsers.Items.Clear();
                // foreach (Staff record in _members)
                foreach (User user in _users)
                {
                    ListViewItem item = new ListViewItem(user.UserName);
                    item.SubItems.Add(user.RoleList);
                    item.SubItems.Add(user.UserLocationDistrict);
                    item.SubItems.Add(user.UserLocationProvince);
                    listViewUsers.Items.Add(item);
                    item.Tag = user;


                }
            }
            catch
            {
                throw;
            }



            //private void EnableButtons(bool remove, bool roles, bool scope, bool disable, bool changepassword)
            //{
            //    buttonRemove.Enabled = removeToolStripMenuItem.Visible = remove;
            //    buttonDisable.Enabled = disableToolStripMenuItem.Visible = disable;
            //    buttonChangePassword.Enabled = changePasswordToolStripMenuItem.Visible = changepassword;
            //    buttonRoles.Enabled = rolesToolStripMenuItem.Visible = roles;
            //}
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AddWebUser uf = new AddWebUser();
            uf.ShowDialog();
            
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {

            try
            {
                Cursor current = Cursor.Current;
                Cursor.Current = Cursors.WaitCursor;
                //EnableButtons(false, false, false, false, false);
                //Load the users 
                Users users = SecurityFactory.GetwebUsers();
                //Users users = SecurityFactory.GetUsers();
                ShowUsers(users);
                Cursor.Current = current;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

        }

        private void buttonDisable_Click(object sender, EventArgs e)
        {
            if (currentUser != null)
            {
                MISFactory.Createdelete(currentUser.ApplicantID);
                currentUser.ApplicantID = currentUser.ApplicantID;
                int index = listViewUsers.SelectedItems[0].ImageIndex;
                listViewUsers.SelectedItems[0].ImageIndex = (index == 0) ? 1 : 0;
            }
        }
    }
}
