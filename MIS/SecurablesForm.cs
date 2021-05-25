using System;
using System.Linq;
using System.Windows.Forms;
using Security;

namespace MIS
{
    public partial class SecurablesForm : Form
    {
        private Securable currentSecurable;

        public SecurablesForm()
        {
            InitializeComponent();
            listViewSecurables.DoubleClick += listViewSecurables_DoubleClick;

            listViewSecurables.Anchor = AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top | AnchorStyles.Right;
            panelButtons.Anchor = AnchorStyles.Bottom | AnchorStyles.Top | AnchorStyles.Right;
        }

        void listViewSecurables_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (currentSecurable != null)
                {
                    SecurableForm rf = new SecurableForm();
                    rf.CurrentSecurable = currentSecurable;
                    rf.ShowDialog(this);
                    ShowSecurables();
                }
            }
            catch (Exception ex)
            {
                                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void ShowSecurables()
        {
            try
            {
                listViewSecurables.Items.Clear();

                Securables secs = SecurityFactory.GetSecurables();

                foreach (Securable sec in secs)
                {
                    ListViewItem li = listViewSecurables.Items.Add(sec.SecurableName);
                    li.Tag = sec;
                }
            }
            catch (Exception ex)
            {
                                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listViewSecurables_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewSecurables.SelectedItems != null && listViewSecurables.SelectedItems.Count > 0)
            {
                currentSecurable = (Securable)listViewSecurables.SelectedItems[0].Tag;
                EnableButtons(true, true);
            }
            else
            {
                currentSecurable = null;
                EnableButtons(false, false);
            }
        }

        private void EnableButtons(bool remove, bool permissions)
        {
            buttonRemove.Enabled = remove;
            buttonPermissions.Enabled = permissions;

            removeToolStripMenuItem.Visible = remove;
            permissionsToolStripMenuItem.Visible = permissions;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                SecurableForm sf = new SecurableForm();
                sf.ShowDialog(this);
                ShowSecurables();
            }
            catch (Exception ex)
            {
                                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void SecurablesForm_Load(object sender, EventArgs e)
        {
            EnableButtons(false, false);
            ShowSecurables();
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentSecurable != null)
                {
                    if (MessageBox.Show(this, "Are you sure you want to delete this securable?", "Delete securable", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        currentSecurable.Delete();
                        listViewSecurables.SelectedItems[0].Remove();
                    }
                }
            }
            catch (Exception ex)
            {
                                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void buttonPermissions_Click(object sender, EventArgs e)
        {
            SecurablePermissionsForm spf = new SecurablePermissionsForm();
            spf.CurrentSecurable = currentSecurable;
            spf.ShowDialog();

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
