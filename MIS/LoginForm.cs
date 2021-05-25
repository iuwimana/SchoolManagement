using System;
using System.Linq;
using System.Windows.Forms;
using Security;

namespace MIS
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            bool loggedIn = SecurityFactory.Login(textBoxUsername.Text, textBoxPassword.Text);

            if (loggedIn)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else
            {
                MessageBox.Show("The username and/or password are incorrect. Please try again", "Login failure", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            //Ease the pain of testing!!!
            if (Environment.MachineName.Contains("DESKTOP"))
            {
                textBoxUsername.Text = "admin";
                textBoxPassword.Text = "rnmuadmin";
            }
        }

        private void ultraGroupBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
