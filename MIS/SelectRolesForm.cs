using System;
using System.Linq;
using System.Windows.Forms;
using Security;

namespace MIS
{
    public partial class SelectRolesForm : Form
    {
        public Role SelectedRole { get; set; }

        public SelectRolesForm()
        {
            InitializeComponent();
            treeViewRoles.NodeMouseDoubleClick += treeViewRoles_NodeMouseDoubleClick;
        }

        void treeViewRoles_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Text.StartsWith("Roles", StringComparison.OrdinalIgnoreCase))
            {
                SelectedRole = null;
            }
            else
            {
                SelectedRole = (Role)e.Node.Tag;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }

        }

        private void SelectRolesForm_Load(object sender, EventArgs e)
        {
            try
            {
                Roles roles = new Roles();
                roles.Load(true);


                Role root = new Role();
                root.RoleName = "Roles";


                ShowAllRoles(roles, root);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowAllRoles(Roles Roles, Role root)
        {
            TreeNode rootNode = treeViewRoles.Nodes.Add(root.RoleName);
            rootNode.Tag = root;


            foreach (Role role in Roles)
            {
                TreeNode child = new TreeNode(role.RoleName);
                child.Name = role.RoleID.ToString();
                child.Tag = role;
                rootNode.Nodes.Add(child);

            }

            rootNode.Expand();
        }

        private void treeViewRoles_AfterSelect(object sender, TreeViewEventArgs e)
        {


            if (e.Node.Text.StartsWith("Roles"))
            {
                SelectedRole = null;
                buttonSelect.Enabled = false;
            }
            else
            {
                SelectedRole = (Role)e.Node.Tag;
                buttonSelect.Enabled = true;
            }
        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
