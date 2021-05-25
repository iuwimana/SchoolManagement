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
    public partial class AddWebUser : Form
    {
        private Applicant currentStaff;
        public AddWebUser()
        {
            InitializeComponent();
        }

        private void AddWebUser_Load(object sender, EventArgs e)
        {
            Countries countries = MISFactory.GetCountries();
            comboBoxNationality.DataSource = countries.ToList();
            comboBoxNationality.DisplayMember = "Nationality";
            comboBoxNationality.ValueMember = "CountryID";
            comboBoxNationality.DropDownStyle = ComboBoxStyle.DropDownList;

            //MaritalStatuses MaritalStatus = MISFactory.GetmaritalStatus();
            //comboBox1.DataSource = MaritalStatus.ToList();
            //comboBox1.DisplayMember = "MaritalStatusName";
            //comboBox1.ValueMember = "MaritalStatusID";
            //comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;

            RNMUMemberRoles RNMUMemberRoles = MISFactory.GetRNMUMemberRoles();
            comboBox2.DataSource = RNMUMemberRoles.ToList();
            comboBox2.DisplayMember = "RNMUMemberRoleName";
            comboBox2.ValueMember = "RNMUMemberRoleId";
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;

            //RNMUMemberRoles RNMUMemberRoleArrear = MISFactory.GetMemberRoleArrear();
            //comboBox2.DataSource = RNMUMemberRoleArrear.ToList();
            //comboBox2.DisplayMember = "RNMUMemberRoleName";
            //comboBox2.ValueMember = "RNMUMemberRoleId";
            //comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;

            Provinces province = MISFactory.GetProvinces();
            comboBox3.DataSource = province.ToList();
            comboBox3.DisplayMember = "ProvinceName";
            comboBox3.ValueMember = "ProvinceID";
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;

            Districts districts = MISFactory.GetDistricts();
            comboBox4.DataSource = districts.ToList();
            comboBox4.DisplayMember = "DistrictName";
            comboBox4.ValueMember = "DistrictID";
            comboBox4.DropDownStyle = ComboBoxStyle.DropDownList;




        }
       

        

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int roleid = Convert.ToInt32(comboBox2.SelectedValue);
            if (roleid == 3)
            {
                //comboBox3.Location=new Point(658, 62);
                comboBox3.Visible = true;
                ultraLabel6.Visible = true;
                comboBox4.Visible = false;
                ultraLabel10.Visible = false;
            }
            else if (roleid == 4)
            {
                //comboBox4.Location = new Point(662, 62);
                comboBox4.Visible = true;
                ultraLabel10.Visible = true;
                comboBox3.Visible = false;
                ultraLabel6.Visible = false;
            }
            else 
            {
                
                comboBox3.Visible = false;
                comboBox4.Visible = false;
                ultraLabel6.Visible = false;
            }



        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            serchwebuser sef = new serchwebuser();

            if (sef.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                currentStaff = sef.SelectedStaff;
                textBoxEmployeeName.Text = currentStaff.UserName;
                textBox1.Text = currentStaff.ApplicantID.ToString();
                textBoxSurname.Text = currentStaff.LastName;
                textBoxMiddleName.Text = currentStaff.MiddleName; 
                textBoxFirstName.Text = currentStaff.FirstName;
                textBoxIDNumber.Text = currentStaff.IDNumber;
                textBoxTelephone.Text = currentStaff.PhoneNumber;
                textBoxEmail.Text = currentStaff.Email;
                comboBoxNationality.Text = currentStaff.Nationality;
                dateTimePickerDOB.Value = currentStaff.DateOfBirth;
                if (currentStaff.Gender == "M")
                {
                    radioButtonMale.Checked = true;
                    radioButtonFemale.Checked = false;

                }
                else if (currentStaff.Gender == "F")
                {
                    radioButtonMale.Checked = false;
                    radioButtonFemale.Checked = true;

                }

            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {



            try
            {


                int ApplicantID = Convert.ToInt32(textBox1.Text.ToString());
                string UserName = textBoxEmployeeName.Text;
                string LastName = textBoxSurname.Text;
                string MiddleName = textBoxMiddleName.Text;
                string FirstName = textBoxFirstName.Text;
                int NationalityID = Convert.ToInt32(comboBoxNationality.SelectedValue);
                string IDNumber = textBoxIDNumber.Text;
                string Gender = radioButtonMale.Checked ? "M" : "F";
                string PhoneNumber = textBoxTelephone.Text;
                string Email = textBoxEmail.Text;
                DateTime DateOfBirth = Convert.ToDateTime(dateTimePickerDOB.Value);

                Applicant obj = MISFactory.CreateApplicant(ApplicantID, UserName, LastName, MiddleName, FirstName, NationalityID, IDNumber, Gender, PhoneNumber, Email, DateOfBirth);

                int rnmumemberuserid = 0;
                int userId = Convert.ToInt32(textBox1.Text.ToString());
                int RNMUMemberRoleid = Convert.ToInt32(comboBox2.SelectedValue);
                RNMUMemberRole objw = MISFactory.CreateRNMUMemberRole(rnmumemberuserid, userId, RNMUMemberRoleid);



                int roleid = Convert.ToInt32(comboBox2.SelectedValue);
                if (roleid == 3 && roleid == 4)
                {
                    int RNMUMEMBERUSERARREARID = 0;

                    int DistrictID = Convert.ToInt32(comboBox4.SelectedValue);
                    int ProvinceID = Convert.ToInt32(comboBox3.SelectedValue);

                    if (roleid == 3)
                    {
                        ProvinceID = Convert.ToInt32(comboBox3.SelectedValue);
                        DistrictID = 0;
                    }
                    else if (roleid == 4)
                    {
                        DistrictID = Convert.ToInt32(comboBox4.SelectedValue);
                        ProvinceID = 0;
                    }




                    RNMUMemberRole objw1 = MISFactory.CreateRNMUMemberRoleArrear(RNMUMEMBERUSERARREARID, userId, ProvinceID, DistrictID);
                }


                //RNMUMemberRole objw1 = (RNMUMemberRole)this.Tag;
                //objw1.userId = Convert.ToInt32(textBox1.Text.ToString());
                //if (comboBox2.Text == "Provincial Officer")
                //{
                //    objw1.ProvinceID = Convert.ToInt32(comboBox3.SelectedValue);
                //    objw1.DistrictID = Convert.ToInt32("");
                //}
                //else if (comboBox2.Text == "District Officer")
                //{
                //    objw1.DistrictID = Convert.ToInt32(comboBox4.SelectedValue);
                //    objw1.ProvinceID = Convert.ToInt32("");
                //}
                //else
                //{

                //    objw1.ProvinceID = Convert.ToInt32("");
                //    objw1.DistrictID = Convert.ToInt32("");
                //}



                //objw1.SaveMEMBERUSER();



                this.Close();
            }
            
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
}
    }
}
