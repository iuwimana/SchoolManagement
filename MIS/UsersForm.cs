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
    public partial class UsersForm : Form
    {
        private User currentUser;

        public UsersForm()
        {
            InitializeComponent();
            listViewUsers.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom;
            panelButtons.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            GlobalsFactory.InitializeListView(this.listViewUsers);
        }

        private void UsersForm_Load(object sender, EventArgs e)
        {
            EnableButtons(false, false, false, false, false);
            //Load the users 
            button1.Enabled = false;
            ShowUsers();
        }

        private void ShowUsers()
        {

            listViewUsers.Items.Clear();

            Users users = SecurityFactory.GetUsers();

            foreach (User user in users)
            {
                ListViewItem li = listViewUsers.Items.Add(user.UserName);
                li.SubItems.Add(user.RoleList);
                li.SubItems.Add(user.workingArrear);
                li.ImageIndex = (user.Active) ? 0 : 1;
                li.Tag = user;
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            UserForm uf = new UserForm();
            uf.ShowDialog();
            ShowUsers();
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (currentUser != null && currentUser.UserName != "admin")
            {
                if (MessageBox.Show(this, "Are you sure you want to delete this user?", "Delete user", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    SecurityFactory.DeleteUser(currentUser);
                    listViewUsers.SelectedItems[0].Remove();
                }
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listViewUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewUsers.SelectedItems != null && listViewUsers.SelectedItems.Count > 0)
            {
                currentUser = (User)listViewUsers.SelectedItems[0].Tag;
                int rolelist = currentUser.RoleListID;
                textBox1.Text = rolelist.ToString();
                int a= Convert.ToInt32(textBox1.Text);
                if (a== 3 || a == 4)
                {
                    button1.Enabled = true; 
                }
                else
                {
                    button1.Enabled = false;
                }

                buttonDisable.Text = disableToolStripMenuItem.Text = currentUser.Active ? "Disable" : "Enable";


                if (currentUser.IsSystemUser )
                {
                    
                    EnableButtons(false, true, false, false, true);
                }
                else
                    EnableButtons(true, true, true, true, true);
                    
            }
            else
            {
                currentUser = null;
                EnableButtons(false, false, false, false, false);
            }
        }

        private void buttonDisable_Click(object sender, EventArgs e)
        {
            if (currentUser != null)
            {
                SecurityFactory.ChangeUserStatus(currentUser.UserID, !currentUser.Active);
                currentUser.Active = !currentUser.Active;
                int index = listViewUsers.SelectedItems[0].ImageIndex;
                listViewUsers.SelectedItems[0].ImageIndex = (index == 0) ? 1 : 0;
            }

        }

        private void buttonChangePassword_Click(object sender, EventArgs e)
        {
            ChangePasswordForm cpf = new ChangePasswordForm();
            cpf.CurrentUser = currentUser;
            cpf.ShowDialog(this);
        }

        private void buttonRoles_Click(object sender, EventArgs e)
        {
            UserRolesForm urf = new UserRolesForm();
            urf.CurrentUser = currentUser;

            if (urf.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                ShowUsers();
            }
        }


        private void EnableButtons(bool remove, bool roles, bool scope, bool disable, bool changepassword)
        {
            buttonRemove.Enabled = removeToolStripMenuItem.Visible = remove;
            buttonDisable.Enabled = disableToolStripMenuItem.Visible = disable;
            buttonChangePassword.Enabled = changePasswordToolStripMenuItem.Visible = changepassword;
            buttonRoles.Enabled = rolesToolStripMenuItem.Visible = roles;
            
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buttonRemove_Click(sender, e);
        }

        private void disableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buttonDisable_Click(sender, e);
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buttonChangePassword_Click(sender, e);
        }

        private void rolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buttonRoles_Click(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
           

                    UserWorkingPlace cpf = new UserWorkingPlace();
                    cpf.CurrentUser = currentUser;
                    cpf.ShowDialog(this);
               
            
        }

        private void listViewUsers_Click(object sender, EventArgs e)
        {
            //currentUser = (User)listViewUsers.SelectedItems[0].Tag;
            //int rolelist = currentUser.RoleListID;
            //textBox1.Text = rolelist.ToString();
            //if (rolelist != 3 || rolelist != 4)
            //{ button1.Enabled = false; }
        }
    }
}
