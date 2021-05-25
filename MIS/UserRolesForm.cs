using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
//using IPPIS.Framework.PluginServices;
using Security;
//using IPPIS.Organization;

namespace MIS
{
    public partial class UserRolesForm : Form
    {
        public User CurrentUser;
        private Roles removed;
        private Roles added;

        public UserRolesForm()
        {
            InitializeComponent();
            listViewUserRoles.Resize += listViewUserRoles_Resize;
        }

        void listViewUserRoles_Resize(object sender, EventArgs e)
        {
            columnHeaderRole.Width = listViewUserRoles.Width - 20;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                //Remove the 'removed' Roles
                if (removed != null)
                {
                    List<int> removedRoles = GetRoleIDs(removed);
                    SecurityFactory.DeleteUserRoles(CurrentUser.UserID, removedRoles);

                    foreach (Role role in removed)
                    {
                        AuditTrailManager.Instance.Add("REMOVE", "User Role", role.RoleID.ToString(), CurrentUser.UserName + " - " + role.RoleName, 0);
                    }
                }

                //Add the 'new' Roles
                if (added != null)
                {
                    List<int> addedRoles = GetRoleIDs(added);
                    SecurityFactory.SaveUserRoles(addedRoles, CurrentUser.UserID);

                    foreach (Role role in added)
                    {
                        AuditTrailManager.Instance.Add("CREATE", "User Role", role.RoleID.ToString(), CurrentUser.UserName + " - " + role.RoleName, 0);
                    }
                }

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<int> GetRoleIDs(Roles group)
        {
            List<int> ids = new List<int>();

            foreach (Role role in group)
            {
                ids.Add(role.RoleID);
            }
            return ids;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            SelectRolesForm srf = new SelectRolesForm();

            if (srf.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                Role selected = srf.SelectedRole;
                ListViewItem li = listViewUserRoles.Items.Add(selected.RoleName);
                li.Tag = selected;

                if (added == null)
                    added = new Roles();

                added.Add(selected);

                buttonSave.Enabled = true;
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (listViewUserRoles.SelectedItems != null && listViewUserRoles.SelectedItems.Count > 0)
            {
                Role remove = (Role)listViewUserRoles.SelectedItems[0].Tag;

                if (removed == null)
                    removed = new Roles();

                removed.Add(remove);

                listViewUserRoles.SelectedItems[0].Remove();

                buttonSave.Enabled = true;
            }
        }

        private void UserRoleForm_Load(object sender, EventArgs e)
        {
            try
            {
                buttonSave.Enabled = false;

                this.Text = CurrentUser.UserName + "'s roles";

                groupBox3.Text = "Roles that " + CurrentUser.UserName.ToUpper() + " is a member of";

                RolesUsers userRoles = SecurityFactory.GetUserRoles(CurrentUser.UserID);

                foreach (RolesUser obj in userRoles)
                {

                    Role role = new Role(obj.RoleID, obj.RoleName);
                    ListViewItem li = listViewUserRoles.Items.Add(role.RoleName);
                    li.Tag = role;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
