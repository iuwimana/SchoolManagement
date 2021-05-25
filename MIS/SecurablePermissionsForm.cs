using System;
using System.Linq;
using System.Windows.Forms;
using Security;

namespace MIS
{
    public partial class SecurablePermissionsForm : Form
    {
        public Securable CurrentSecurable { get; set; }

        public SecurablePermissionsForm()
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
            groupBoxPermissions.Text = string.Format("Permissions for {0}", CurrentSecurable.SecurableName);
            //Display the permissions for this securable

            rolePermissionBindingSource.DataSource = CurrentSecurable.Permissions;
            dataGridViewPermissions.DataSource = rolePermissionBindingSource;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void buttonApply_Click(object sender, EventArgs e)
        {
            RolePermissions perms = CurrentSecurable.Permissions;
            SecurityFactory.UpdatePermissions(perms);
            this.Close();

        }


    }
}
