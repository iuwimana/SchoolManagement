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
    public partial class AddDepartmentsForm : Form
    {
        public AddDepartmentsForm()
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
                
                Department obj = (Department)this.Tag;
                obj.DepartmentName = textBoxValue.Text;
                obj.InstitutioncategoryId = Convert.ToInt32(comboBoxRank.SelectedValue);
                obj.DistrictID = Convert.ToInt32(ComboDistrict.SelectedValue);

                obj.Save();

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void AddDepartmentsForm_Load(object sender, EventArgs e)
        {
            Department obj = (Department)this.Tag;
            textBoxValue.Text = obj.DepartmentName;

            institutioncategories institutioncategories = MISFactory.Getinstitutioncategories();
            comboBoxRank.DataSource = institutioncategories.ToList();
            comboBoxRank.DisplayMember = "InstitutioncategoryName";
            comboBoxRank.ValueMember = "InstitutioncategoryId";
            comboBoxRank.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxRank.Text = obj.InstitutioncategoryName;


            ComboProvince.SelectedIndexChanged -= new EventHandler(ComboProvince_SelectedIndexChanged);
            LoadProvinces();
            ComboProvince.Text = obj.ProvinceName;
            ComboProvince.SelectedIndexChanged += new EventHandler(ComboProvince_SelectedIndexChanged);

            ComboDistrict.SelectedIndexChanged -= new EventHandler(ComboDistrict_SelectedIndexChanged);
            LoadDistricts();
            ComboDistrict.Text = obj.DistrictName;
            ComboDistrict.SelectedIndexChanged += new EventHandler(ComboDistrict_SelectedIndexChanged);

            //ComboSector.SelectedIndexChanged -= new EventHandler(ComboSector_SelectedIndexChanged);
            //LoadSectors();
            //ComboSector.Text = obj.SectorName;
            //ComboSector.SelectedIndexChanged += new EventHandler(ComboSector_SelectedIndexChanged);
            LoadSectors();
            ComboSector.Text = obj.SectorName;
        }
        private void ComboProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ComboDistrict.SelectedIndexChanged -= new EventHandler(ComboDistrict_SelectedIndexChanged);
                LoadDistricts();
                ComboDistrict.SelectedIndexChanged += new EventHandler(ComboDistrict_SelectedIndexChanged);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void ComboDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadSectors();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        //private void ComboSector_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        LoadSectors();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        //    }
        //}
        private void LoadProvinces()
        {
            try
            {
                ComboProvince.Items.Clear();
                ComboProvince.DataSource = MISFactory.GetProvinces().ToList();
                ComboProvince.DisplayMember = "ProvinceName";
                ComboProvince.ValueMember = "ProvinceID";
                ComboProvince.SelectedIndex = -1;
                ComboProvince.DropDownStyle = ComboBoxStyle.DropDownList;
            }
            catch
            {
                throw;
            }
        }

        private void LoadDistricts()
        {
            try
            {
                ComboDistrict.DataSource = null;
                ComboDistrict.Items.Clear();
                ComboDistrict.DataSource = MISFactory.GetProvinceDistricts(Convert.ToInt32(ComboProvince.SelectedValue)).ToList();
                ComboDistrict.DisplayMember = "DistrictName";
                ComboDistrict.ValueMember = "DistrictID";
                ComboDistrict.DropDownStyle = ComboBoxStyle.DropDownList;
            }
            catch
            {
                throw;
            }
        }
        private void LoadSectors()
        {
            try
            {
                ComboSector.DataSource = null;
                ComboSector.Items.Clear();
                ComboSector.DataSource = MISFactory.GetDistrictSectors(Convert.ToInt32(ComboDistrict.SelectedValue)).ToList();
                ComboSector.DisplayMember = "SectorName";
                ComboSector.ValueMember = "SectorID";
                ComboSector.DropDownStyle = ComboBoxStyle.DropDownList;
            }
            catch
            {
                throw;
            }
        }
    }
}
