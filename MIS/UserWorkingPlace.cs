using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Security;
using Globals;


namespace MIS
{
    public partial class UserWorkingPlace : Form
    {
        public User CurrentUser { get; set; }
        
        public UserWorkingPlace()
        {
            InitializeComponent();
        }

        private void UserWorkingPlace_Load(object sender, EventArgs e)
        {
            int a = CurrentUser.RoleListID;
            if (CurrentUser.RoleListID==3)
            { 
            Provinces province = MISFactory.GetProvinces();
            comboBox3.DataSource = province.ToList();
            comboBox3.DisplayMember = "ProvinceName";
            comboBox3.ValueMember = "ProvinceID";
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox4.Visible = false;
            ultraLabel1.Visible = false;

            }
            else if (CurrentUser.RoleListID==4)
            {
                Districts districts = MISFactory.GetDistricts();
                comboBox4.DataSource = districts.ToList();
                comboBox4.DisplayMember = "DistrictName";
                comboBox4.ValueMember = "DistrictID";
                comboBox4.DropDownStyle = ComboBoxStyle.DropDownList;
                comboBox3.Visible = false;
                ultraLabel6.Visible = false;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                int WINUSERROLEARREARID = 0;
                int userId = CurrentUser.UserID;
                int ProvinceID = Convert.ToInt32(comboBox3.SelectedValue);
                int DistrictID = Convert.ToInt32(comboBox4.SelectedValue);
                if (CurrentUser.RoleListID == 3)
                {
                     ProvinceID = Convert.ToInt32(comboBox3.SelectedValue);
                     DistrictID = 0;

                }
                else if (CurrentUser.RoleListID == 4)
                {
                    DistrictID = Convert.ToInt32(comboBox4.SelectedValue);
                    ProvinceID = 0;
                }
                
                
                WINUSERROLEARREAR objw = MISFactory.CreateWINUSERROLEARREAR(WINUSERROLEARREARID, userId, ProvinceID, DistrictID);


                //WINUSERROLEARREAR obj = (WINUSERROLEARREAR)this.Tag;
                //obj.UserID = CurrentUser.UserID;
                //if (CurrentUser.RoleListID == 3)
                //{
                //    obj.ProvinceID = Convert.ToInt32(comboBox3.SelectedValue);

                //}
                //else if (CurrentUser.RoleListID == 4)
                //{
                //    obj.DistrictID= Convert.ToInt32(comboBox4.SelectedValue);
                //}
                //obj.Save();

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
    }
}
