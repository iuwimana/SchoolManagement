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
    public partial class AddStaffsForm : Form
    {
        public AddStaffsForm()
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
                string text = textBoxIDNumber.Text;
                string trim = text.Replace(" ", String.Empty); ;
                int result1 = trim.Length;
                if(result1!=16)
                {
                    MessageBox.Show("the character Number of Your IDNumber is incorrect .", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                //int parsedValue;
                //if (!int.TryParse(trim, out parsedValue))
                //{
                //    MessageBox.Show("IDNumber in Incorect Format.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;
                //}

                if (comboBoxRank.SelectedItem == null || textBoxSurname.Text == string.Empty
                    || comboBoxDepartment.SelectedItem == null 
                    || comboBoxNationality.SelectedItem == null || textBoxContribution.Text == string.Empty)
                {
                    MessageBox.Show("Some information is missing.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Staff obj = (Staff)this.Tag;

                obj.Surname = textBoxSurname.Text;
                obj.MiddleName = textBoxMiddleName.Text;
                obj.FirstName = textBoxFirstName.Text;
                obj.RankID = Convert.ToInt32(comboBoxRank.SelectedValue);
                obj.DepartmentID = Convert.ToInt32(comboBoxDepartment.SelectedValue);
                
                obj.StaffTypeID =  Convert.ToInt32(textBox4.Text);
                obj.NationalityID = Convert.ToInt32(comboBoxNationality.SelectedValue);
                obj.IdentificationNumber = textBoxIDNumber.Text;
                obj.Gender = radioButtonMale.Checked ? "M" : "F";
                obj.Profession = radioButton2.Checked ? "Nurse" : "Midwive";
                obj.Telephone = textBoxTelephone.Text;
                obj.Email = textBoxEmail.Text;
                obj.BirthDate = Convert.ToDateTime(dateTimePickerDOB.Value);
                obj.EmploymentDate = Convert.ToDateTime(dateTimePickerEmploymentDate.Value);
                obj.MembershipStartDate = Convert.ToDateTime(dateTimePickerMembershipStartDate.Value);
                obj.MembershipEndDate = Convert.ToDateTime(dateTimePickerMembershipEndDate.Value);
                obj.ContributionAmount = Convert.ToInt32(textBoxContribution.Text.Replace(",",""));
                obj.SocialSecurityNumber = comboBox1.Text;
                obj.IsActive = radioButtonActive.Checked ? true : false;
                obj.Profession = radioButton2.Checked ? "Nurse" : "Midwive";
                obj.HasDisability = checkBox1.Checked ? true : false;
                obj.EmploymentStatusID = Convert.ToInt32(comboBox2.SelectedValue);
                obj.Desability = textBox1.Text;
                obj.LisenceNumber = textBox2.Text;
                obj.Save();

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void AddStaffsForm_Load(object sender, EventArgs e)
        {
            
            try
            {
                listViewLookups.Select();
                listViewLookups.HideSelection = false;
             
                //StaffCategory objForm = new StaffCategory();
                //objForm.TopLevel = false;
                //panel1.Controls.Add(objForm);
                //objForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
                //objForm.Dock = DockStyle.Fill;
                //objForm.Show();
                if (checkBox1.Checked == true)
                {
                    textBox1.Visible = true;
                    label8.Visible = true;

                }
                else {
                    textBox1.Visible = false;
                    label8.Visible = false;
                }
                Staff obj = (Staff)this.Tag;

                Ranks ranks = MISFactory.GetRanks();
                comboBoxRank.DataSource = ranks.ToList();
                comboBoxRank.DisplayMember = "RankName";
                comboBoxRank.ValueMember = "RankID";
                comboBoxRank.DropDownStyle = ComboBoxStyle.DropDownList;

                //StaffTypes types = MISFactory.GetStaffTypes();
                //comboBoxStaffType.DataSource = types.ToList();
                //comboBoxStaffType.DisplayMember = "StaffTypeName";
                //comboBoxStaffType.ValueMember = "StaffTypeID";
                //panel1.Visible = true;
                comboBoxStaffType.DropDownStyle = ComboBoxStyle.DropDownList;

                Staffstatuses type = MISFactory.GetStaffStatus();
                comboBox2.DataSource = type.ToList();
                comboBox2.DisplayMember = "EmploymentStatusName";
                comboBox2.ValueMember = "EmploymentStatusID";
                comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;

                Departments departments = MISFactory.GetDepartments();
                comboBoxDepartment.DataSource = departments.ToList();
                comboBoxDepartment.DisplayMember = "DepartmentName";
                comboBoxDepartment.ValueMember = "DepartmentID";
                comboBoxDepartment.DropDownStyle = ComboBoxStyle.DropDownList;

                Countries countries = MISFactory.GetCountries();
                comboBoxNationality.DataSource = countries.ToList();
                comboBoxNationality.DisplayMember = "Nationality";
                comboBoxNationality.ValueMember = "CountryID";
                comboBoxNationality.DropDownStyle = ComboBoxStyle.DropDownList;

                textBoxSurname.Text = obj.Surname;
                textBoxMiddleName.Text = obj.MiddleName;
                textBoxFirstName.Text = obj.FirstName;
                comboBoxRank.Text = obj.RankName;
                textBox5.Text = obj.StaffTypeName;
                textBox4.Text = obj.StaffTypeID.ToString();
                comboBoxDepartment.Text = obj.DepartmentName;
                comboBoxNationality.Text = obj.Nationality;
                textBoxIDNumber.Text = obj.IdentificationNumber;
                radioButtonMale.Checked = obj.Gender == "M" ? true : false;
                radioButtonFemale.Checked = obj.Gender == "F" ? true : false;
                radioButton1.Checked = obj.Gender == "Nurse" ? true : false;
                radioButton2.Checked = obj.Gender == "Midwive" ? true : false;
                textBoxTelephone.Text = obj.Telephone;
                textBoxEmail.Text = obj.Email;
                dateTimePickerDOB.Value = obj.BirthDate;
                dateTimePickerEmploymentDate.Value = obj.EmploymentDate;
                dateTimePickerMembershipStartDate.Value = obj.MembershipStartDate;
                dateTimePickerMembershipEndDate.Value = obj.MembershipEndDate;
                textBoxContribution.Text = string.Format("{0:#,#}", obj.ContributionAmount);
                comboBox1.Text = obj.SocialSecurityNumber;
                comboBox2.Text = obj.EmploymentStatusName;
                radioButtonActive.Checked = obj.IsActive ? true : false;
                radioButtonNotActive.Checked = !obj.IsActive ? true : false;
                checkBox1.Checked = obj.HasDisability ? true : false;
                textBox1.Text = obj.Desability;
                textBox2.Text = obj.LisenceNumber;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            try
            {
                LoadPersonnelCategories();
                textBox5.Visible = false;
                panel1.Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        private void LoadPersonnelCategories()
        {
            try
            {
                listViewLookups.Items.Clear();
                foreach (StaffType record in MISFactory.GetStaffTypes())
                {
                    ListViewItem item = new ListViewItem(record.StaffTypeName);
                    item.SubItems.Add(record.TypeofContract);
                    item.SubItems.Add(record.DurationofContract);
                    item.SubItems.Add(record.StaffTypeID.ToString());
                    listViewLookups.Items.Add(item);
                    item.Tag = record;
                    

                }
                
               
            }
            catch
            {
                throw;
            }
        
    }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox1.Visible = true;
                label8.Visible = true;

            }
            else
            {
                textBox1.Visible = false;
                label8.Visible = false;
            }
        }

        private void comboBoxStaffType_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            listViewLookups.Select();
            listViewLookups.HideSelection = false;
        }

        private void comboBoxStaffType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox3.Text))
            {
                foreach (ListViewItem item in listViewLookups.Items)
                {
                    item.UseItemStyleForSubItems = false;
                    bool isVisible = false;

                    foreach (ListViewItem.ListViewSubItem subItem in item.SubItems)
                    {
                        subItem.ForeColor = Color.Black;
                        if (subItem.Text.ToLower().Contains(textBox3.Text.ToLower()))
                        {
                            subItem.ForeColor = Color.Red;
                            isVisible = true;
                        }
                    }

                    if (isVisible) { item.EnsureVisible(); }
                    else { item.Remove(); }
                }
            }

            else
            {
                MessageBox.Show("Please enter member to search.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void listViewLookups_DoubleClick(object sender, EventArgs e)
        {
            try
            {
               
                    ListViewItem item = listViewLookups.SelectedItems[0];
                    comboBoxStaffType.Text = item.SubItems[3].Text;

                if (item != null)
                    {
                    comboBoxStaffType.Text = item.SubItems[3].Text;
                        
                    }
                   
                    
                
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            panel1.Visible = false;
            listViewLookups.Select();
            listViewLookups.HideSelection = false;
        }

        private void listViewLookups_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                
                if (listViewLookups.SelectedIndices.Count <= 0)
                {
                    return;
                }
                int intselectedindex = listViewLookups.SelectedIndices[0];
                if (intselectedindex >= 0)
                {

                    
                    //MessageBox.Show(listViewLookups.SelectedItems[0].SubItems[3].Text);
                    comboBoxStaffType.Text = listViewLookups.SelectedItems[0].SubItems[0].Text;
                    textBox4.Text = listViewLookups.SelectedItems[0].SubItems[3].Text;
                    textBox5.Text = listViewLookups.SelectedItems[0].SubItems[0].Text + listViewLookups.SelectedItems[0].SubItems[1].Text; ;
                    comboBoxStaffType.DisplayMember = listViewLookups.SelectedItems[0].SubItems[0].Text;
                    comboBoxStaffType.ValueMember = listViewLookups.SelectedItems[0].SubItems[3].Text;
                    textBox5.Visible = true;
                    //listViewLookups.SelectedItems[0].SubItems[3].Text;
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }

        private void listViewLookups_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {

                if (listViewLookups.SelectedIndices.Count <= 0)
                {
                    return;
                }
                int intselectedindex = listViewLookups.SelectedIndices[0];
                if (intselectedindex >= 0)
                {


                    //MessageBox.Show(listViewLookups.SelectedItems[0].SubItems[3].Text);
                    comboBoxStaffType.Text = listViewLookups.SelectedItems[0].SubItems[0].Text;
                    textBox4.Text = listViewLookups.SelectedItems[0].SubItems[3].Text;
                    textBox5.Text = listViewLookups.SelectedItems[0].SubItems[0].Text + listViewLookups.SelectedItems[0].SubItems[1].Text; ;
                    comboBoxStaffType.DisplayMember = listViewLookups.SelectedItems[0].SubItems[0].Text;
                    comboBoxStaffType.ValueMember = listViewLookups.SelectedItems[0].SubItems[3].Text;
                    textBox5.Visible = true;
                    //listViewLookups.SelectedItems[0].SubItems[3].Text;
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

        }

        private void listViewLookups_DoubleClick_1(object sender, EventArgs e)
        {
            try
            {

                ListViewItem item = listViewLookups.SelectedItems[0];
                comboBoxStaffType.Text = item.SubItems[3].Text;

                if (item != null)
                {
                    
                    textBox4.Text = listViewLookups.SelectedItems[0].SubItems[3].Text;
                    textBox5.Text = listViewLookups.SelectedItems[0].SubItems[0].Text + listViewLookups.SelectedItems[0].SubItems[1].Text; ;
                    
                    textBox5.Visible = true;

                }




            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            panel1.Visible = false;
            listViewLookups.Select();
            listViewLookups.HideSelection = false;
            textBox5.Visible = true;
            comboBoxStaffType.Visible = false;
        }

        private void comboBoxStaffType_SelectedIndexChanged(object sender, EventArgs e)
        {
            panel1.Visible = true;

        }

        private void comboBoxStaffType_Click_1(object sender, EventArgs e)
        {
            panel1.Visible = true;
            listViewLookups.Select();
            listViewLookups.HideSelection = false;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            panel1.Visible = true;
            listViewLookups.Select();
            listViewLookups.HideSelection = false;
        }

        private void textBox5_DoubleClick(object sender, EventArgs e)
        {
            panel1.Visible = true;
            listViewLookups.Select();
            listViewLookups.HideSelection = false;
        }

        private void textBox5_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            listViewLookups.Select();
            listViewLookups.HideSelection = false;
        }
    }
}
