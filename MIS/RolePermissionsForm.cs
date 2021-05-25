using System;
using System.Linq;
using System.Windows.Forms;
using Security;

namespace MIS
{
    public partial class RolePermissionsForm : Form
    {
        public Role CurrentRole { get; set; }

        public RolePermissionsForm()
        {
            InitializeComponent();
            dataGridViewPermissions.CellValueChanged += dataGridViewPermissions_CellValueChanged;
        }

        void dataGridViewPermissions_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            buttonApply.Enabled = true;
        }

        private void SecurablePermissionsForm_Load(object sender, EventArgs e)
        {
            buttonApply.Enabled = false;

            groupBoxPermissions.Text = string.Format("Permissions for {0}", CurrentRole.RoleName);

            //Display the permissions for this role
            CurrentRole.GetPermissions();

            rolePermissionBindingSource.DataSource = CurrentRole.Permissions;
            dataGridViewPermissions.DataSource = rolePermissionBindingSource;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void buttonApply_Click(object sender, EventArgs e)
        {
            try
            {
                RolePermissions perms = CurrentRole.Permissions;
                SecurityFactory.UpdatePermissions(perms);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void dataGridViewPermissions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
