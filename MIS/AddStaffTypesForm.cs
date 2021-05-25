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
    public partial class AddStaffTypesForm : Form
    {
        public AddStaffTypesForm()
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
                if (textBoxValue.Text == string.Empty || comboBox1.Text == string.Empty|| comboBox2.Text == string.Empty)
                {
                    MessageBox.Show("Some information is missing.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                
                StaffType obj = (StaffType)this.Tag;
                obj.StaffTypeName = textBoxValue.Text;
                obj.TypeofContract = comboBox1.Text;
                obj.DurationofContract = comboBox2.Text;

                obj.Save();

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void AddStaffTypesForm_Load(object sender, EventArgs e)
        {
            StaffType obj = (StaffType)this.Tag;
            textBoxValue.Text = obj.StaffTypeName;
            comboBox1.Text = obj.TypeofContract;
            comboBox2.Text = obj.DurationofContract;
                           
                textBoxValue.Items.Add("PUBLIC");
                textBoxValue.Items.Add("PRIVATE"); 
            
           
                comboBox1.Items.Add("Under statute");
                comboBox1.Items.Add("Under Contract");
           
                
                    comboBox2.Items.Add("open");
                    comboBox2.Items.Add("<= 3 Months");
                    comboBox2.Items.Add("4-6 Months");
                    comboBox2.Items.Add("7-12 Months");
                    comboBox2.Items.Add("> 1 year");
                
            


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            if (comboBox1.Text == "Under statute")
            {
                comboBox2.Enabled = false;
                comboBox2.Text = "open";

            }
            else
            {
                comboBox2.Items.Clear();
                comboBox2.Enabled = true;
                comboBox2.Items.Add("open");
                comboBox2.Items.Add("<= 3 Months");
                comboBox2.Items.Add("4-6 Months");
                comboBox2.Items.Add("7-12 Months");
                comboBox2.Items.Add("> 1 year");
            }

            }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
           
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void comboBox2_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text == "")
            {
                if (comboBox1.Text == "Under statute")
                {
                    comboBox2.Enabled = false;
                    comboBox2.Items.Add("open");

                }
                else
                {
                    comboBox2.Items.Add("open");
                    comboBox2.Items.Add("<= 3 Months");
                    comboBox2.Items.Add("4-6 Months");
                    comboBox2.Items.Add("7-12 Months");
                    comboBox2.Items.Add("> 1 year");
                }
            }
        }
    }
}
