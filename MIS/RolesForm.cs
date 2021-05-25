using System;
using System.Linq;
using System.Windows.Forms;
using Security;

namespace MIS
{
    public partial class RolesForm : Form
    {
        private Role currentRole;

        public RolesForm()
        {
            InitializeComponent();

            panelButtons.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            listViewRoles.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right;

            listViewRoles.DoubleClick += listViewRoles_DoubleClick;
        }

        void listViewRoles_DoubleClick(object sender, EventArgs e)
        {
            if (currentRole != null)
            {
                RoleForm roleForm = new RoleForm() { CurrentRole = currentRole };
                roleForm.ShowDialog();
                ShowRoles();
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            RoleForm rf = new RoleForm();
            rf.ShowDialog();
            ShowRoles();
        }

        private void ShowRoles()
        {
            listViewRoles.Items.Clear();

            Roles roles = SecurityFactory.GetRoles();

            foreach (Role role in roles)
            {
                ListViewItem li = listViewRoles.Items.Add(role.RoleName);
                li.SubItems.Add(role.Description);
                li.Tag = role;
            }

        }

        private void listViewRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewRoles.SelectedItems != null && listViewRoles.SelectedItems.Count > 0)
            {
                currentRole = (Role)listViewRoles.SelectedItems[0].Tag;

                bool remove;

                if (currentRole.IsSystemRole)
                    remove = false;
                else
                    remove = true;

                EnableButtons(remove, true, true);

            }
            else
            {
                EnableButtons(false, false, false);
            }
        }

        private void RolesForm_Load(object sender, EventArgs e)
        {
            ShowRoles();
            EnableButtons(false, false, false);
        }

        private void EnableButtons(bool remove, bool permissions, bool access)
        {
            buttonRemove.Enabled = removeToolStripMenuItem.Visible = remove;
            buttonPermissions.Enabled = permissionsToolStripMenuItem.Visible = permissions;
            buttonAccess.Enabled = accessToolStripMenuItem.Visible = access;
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (currentRole != null && !currentRole.IsSystemRole)
            {
                if (MessageBox.Show(this, "Are you sure you want to delete this role?", "Delete role", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    currentRole.Delete();
                    listViewRoles.SelectedItems[0].Remove();
                }
            }
        }

        private void buttonPermissions_Click(object sender, EventArgs e)
        {
            RolePermissionsForm rpf = new RolePermissionsForm() { CurrentRole = currentRole };

            rpf.ShowDialog(this);
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buttonRemove_Click(sender, e);
        }

        private void permissionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buttonPermissions_Click(sender, e);
        }

    }
}
