using System;
using System.Linq;
using System.Windows.Forms;
using Security;

namespace MIS
{
    public partial class RoleForm : Form
    {
        private User selectedUser;
        public Role CurrentRole { get; set; }

        public RoleForm()
        {
            InitializeComponent();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxName.TextLength == 0)
                {
                    return;
                }

                Users members = GetMembersFromListView();

                if (CurrentRole == null)
                {
                    Role role = SecurityFactory.CreateRole(textBoxName.Text, textBoxDescription.Text);

                    long parentID = AuditTrailManager.Instance.Add("CREATE", "Role", role.RoleID.ToString(), role.RoleName, 0);

                    SecurityFactory.CreateRoleMembers(role, members);

                    foreach (User member in members)
                    {
                        AuditTrailManager.Instance.Add("CREATE", "Role member", member.UserID.ToString(), role.RoleName + " - " + member.UserName, parentID);
                    }
                }
                else
                {
                    CurrentRole.RoleName = textBoxName.Text;
                    CurrentRole.Description = textBoxDescription.Text;
                    SecurityFactory.UpdateRole(CurrentRole);

                    long parentID = AuditTrailManager.Instance.Add("MODIFY", "Role", CurrentRole.RoleID.ToString(), CurrentRole.RoleName, 0);

                    SecurityFactory.UpdateRoleMembers(CurrentRole, members);

                    foreach (User member in members)
                    {
                        AuditTrailManager.Instance.Add("MODIFY", "Role member", member.UserID.ToString(), CurrentRole.RoleName + " - " + member.UserName, parentID);
                    }

                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private Users GetMembersFromListView()
        {
            Users members = new Users();

            foreach (ListViewItem li in listViewUsers.Items)
            {
                User member = (User)li.Tag;
                members.Add(member);
            }

            return members;
        }



        private void RoleForm_Load(object sender, EventArgs e)
        {
            buttonRemove.Enabled = false;
            buttonSave.Enabled = false;

            if (CurrentRole != null)
            {
                textBoxName.Text = CurrentRole.RoleName;
                textBoxDescription.Text = CurrentRole.Description;

                //Show the users in this role
                CurrentRole.GetMembers();

                Users members = CurrentRole.Members;

                foreach (User mem in members)
                {
                    ListViewItem li = listViewUsers.Items.Add(mem.UserName);
                    li.Tag = mem;
                }
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            SearchUserForm suf = new SearchUserForm();

            if (suf.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                User user = suf.SelectedUser;

                ListViewItem[] items = listViewUsers.Items.Find(user.UserName, true);

                if (items == null || items.Length == 0)
                {
                    ListViewItem li = listViewUsers.Items.Add(user.UserName);
                    li.Name = user.UserName;
                    li.Tag = user;

                    buttonSave.Enabled = true;
                }
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (selectedUser != null)
            {
                listViewUsers.SelectedItems[0].Remove();
                buttonSave.Enabled = true;
            }
        }

        private void listViewUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewUsers.SelectedItems != null && listViewUsers.SelectedItems.Count > 0)
            {
                selectedUser = (User)listViewUsers.SelectedItems[0].Tag;

                if (selectedUser.IsSystemUser)
                    buttonRemove.Enabled = false;
                else
                    buttonRemove.Enabled = true;
            }
            else
            {
                selectedUser = null;
                buttonRemove.Enabled = false;
            }
        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            if (textBoxName.TextLength > 0)
                buttonSave.Enabled = true;
            else
                buttonSave.Enabled = false;
        }

        private void textBoxDescription_TextChanged(object sender, EventArgs e)
        {
            buttonSave.Enabled = true;
        }
    }
}
