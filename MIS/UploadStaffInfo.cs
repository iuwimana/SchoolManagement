using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
//using Z.Dapper.Plus;

namespace MIS
{
    public partial class UploadStaffInfo : Form
    {
        public UploadStaffInfo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Excel 97-2003 Workbook|*.xls|Excel Workbook|*.xlsx" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    textBox1.Text = ofd.FileName;
                    using (var stream = File.Open(ofd.FileName, FileMode.Open, FileAccess.Read))
                    {
                        using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                        {
                            DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                            {
                                ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                                {
                                    UseHeaderRow = true
                                }
                            });
                            tables = result.Tables;
                            comboBox1.Items.Clear();
                            foreach (DataTable table in tables)
                                comboBox1.Items.Add(table.TableName);
                        }
                    }
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = tables[comboBox1.SelectedItem.ToString()];
            dataGridView1.DataSource = dt;

            if (dt != null)
            {
                List<Staff> list = new List<Staff>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Staff obj = new Staff();
                    
                    obj.Surname = dt.Rows[i]["Surname"].ToString();
                    obj.MiddleName = dt.Rows[i]["MiddleName"].ToString();
                    obj.FirstName = dt.Rows[i]["FirstName"].ToString();
                    obj.RankID = Convert.ToInt32(dt.Rows[i]["RankID"].ToString());
                    obj.DepartmentID = Convert.ToInt32(dt.Rows[i]["DepartmentID"].ToString());
                    obj.StaffTypeID = Convert.ToInt32(dt.Rows[i]["StaffTypeID"].ToString());
                    obj.NationalityID = Convert.ToInt32(dt.Rows[i]["NationalityID"].ToString());
                    obj.IdentificationNumber = dt.Rows[i]["IdentificationNumber"].ToString();
                    obj.Gender = dt.Rows[i]["Gender"].ToString();
                    obj.Profession = dt.Rows[i]["Profession"].ToString();
                    obj.Telephone = dt.Rows[i]["Telephone"].ToString();
                    obj.Email = dt.Rows[i]["Email"].ToString();
                    obj.BirthDate = Convert.ToDateTime(dt.Rows[i]["BirthDate"].ToString());
                    obj.EmploymentDate = Convert.ToDateTime(dt.Rows[i]["EmploymentDate"].ToString());
                    obj.MembershipStartDate = Convert.ToDateTime(dt.Rows[i]["MembershipStartDate"].ToString());
                    obj.MembershipEndDate = Convert.ToDateTime(dt.Rows[i]["MembershipEndDate"].ToString());
                    obj.ContributionAmount = Convert.ToInt32(dt.Rows[i]["ContributionAmount"].ToString());
                    obj.SocialSecurityNumber = dt.Rows[i]["SocialSecurityNumber"].ToString();
                    //obj.IsActive = Convert.ToBoolean(dt.Rows[i]["IsActive"].ToString());
                    obj.Profession = dt.Rows[i]["Profession"].ToString();
                    //obj.HasDisability = Convert.ToBoolean(dt.Rows[i]["HasDisability"].ToString());
                    obj.EmploymentStatusID = Convert.ToInt32(dt.Rows[i]["EmploymentStatusID"].ToString());
                    obj.Desability = dt.Rows[i]["Desability"].ToString();
                    obj.LisenceNumber = dt.Rows[i]["LisenceNumber"].ToString();

                    list.Add(obj);
                }
                membercontributionallBindingSource.DataSource = list;
            }

        }
        DataTableCollection tables;

        private void button2_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    string connectionstring = "Data Source=172.27.8.8;Initial Catalog=IPPISBSSDB;User ID=ippisuser;Password=ippisuser";
            //    DapperPlusManager.Entity<membercontributionall>().Table("MemberContributionbulk");
            //    List<membercontributionall> members = membercontributionallBindingSource.DataSource as List<membercontributionall>;
            //    if (members != null)
            //    {
            //        using (IDbConnection db = new SqlConnection(connectionstring))
            //        {
            //            db.BulkInsert(members);
            //        }
            //    }



            //    Staff obj = new Staff();
            //    {
            //        obj.loadinsert();
            //    }



            //    MessageBox.Show("Finished !");
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

            //this.Close();
        }

        private void membercontributionallBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void UploadStaffInfo_Load(object sender, EventArgs e)
        {

        }
    }
    
}
