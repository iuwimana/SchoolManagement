using System;
using System.Linq;
using System.Windows.Forms;
using Security;

namespace MIS
{
    public partial class ChangePasswordForm : Form
    {
        public User CurrentUser { get; set; }


        public ChangePasswordForm()
        {
            InitializeComponent();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            string confirm = textBoxConfirm.Text;
            string password = textBoxPassword.Text;

            if (confirm == password)
            {
                SecurityFactory.ChangeUserPassword(CurrentUser.UserID, password);
                this.Close();
            }
            else
                MessageBox.Show("Passwords do not match");
        }

        private void ChangePasswordForm_Load(object sender, EventArgs e)
        {
            buttonSave.Enabled = false;
        }

        private void textBoxConfirm_TextChanged(object sender, EventArgs e)
        {
            if (textBoxConfirm.TextLength > 0)
                buttonSave.Enabled = true;
            else
                buttonSave.Enabled = false;
        }

    }
}
