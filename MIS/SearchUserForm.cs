using System;
using System.Linq;
using System.Windows.Forms;
using Security;

namespace MIS
{
    public partial class SearchUserForm : Form
    {
        public User SelectedUser { get; set; }

        public SearchUserForm()
        {
            InitializeComponent();
            listViewUsers.DoubleClick += listViewUsers_DoubleClick;
        }

        void listViewUsers_DoubleClick(object sender, EventArgs e)
        {
            if (SelectedUser != null)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            //this.Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            //this.Close();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            listViewUsers.Items.Clear();
            buttonOK.Enabled = false;

            if (textBoxUsername.Text.Trim().Length > 0)
            {
                Users users = SecurityFactory.SearchUsers(textBoxUsername.Text);

                if (users.Count > 0)
                {
                    foreach (User user in users)
                    {
                        ListViewItem li = listViewUsers.Items.Add(user.UserName);
                        li.Tag = user;
                    }
                }
                else
                {
                    MessageBox.Show("No users were found matching the username provided");
                }

            }

        }

        private void listViewUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewUsers.SelectedItems != null && listViewUsers.SelectedItems.Count > 0)
            {
                SelectedUser = (User)listViewUsers.SelectedItems[0].Tag;
                buttonOK.Enabled = true;
            }
            else
            {
                SelectedUser = null;
                buttonOK.Enabled = false;
            }
        }

        private void SearchUserForm_Load(object sender, EventArgs e)
        {
            buttonOK.Enabled = false;
        }
    }
}
