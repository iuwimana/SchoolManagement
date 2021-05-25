using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MIS
{
    public partial class AddRanksForm : Form
    {
        public AddRanksForm()
        {
            InitializeComponent();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxValue.Text == string.Empty)
                {
                    MessageBox.Show("Some information is missing.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                
                Rank obj = (Rank)this.Tag;
                obj.RankName = textBoxValue.Text;

                obj.Save();

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void AddRanksForm_Load(object sender, EventArgs e)
        {
            Rank obj = (Rank)this.Tag;
            textBoxValue.Text = obj.RankName;
        }
    }
}
