using System;
using System.Linq;
using System.Windows.Forms;
using Security;

namespace MIS
{
    public partial class SecurableForm : Form
    {
        public Securable CurrentSecurable { get; set; }

        public SecurableForm()
        {
            InitializeComponent();
        }

        private void SecurableForm_Load(object sender, EventArgs e)
        {
            buttonSave.Enabled = false;

            if (CurrentSecurable != null)
            {
                textBoxName.Text = CurrentSecurable.SecurableName;
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Securable sec = (CurrentSecurable == null) ? new Securable() : CurrentSecurable;
            sec.SecurableName = textBoxName.Text;
            sec.Save();
            this.Close();
        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            if (textBoxName.TextLength > 0)
                buttonSave.Enabled = true;
            else
                buttonSave.Enabled = false;
        }
    }
}
