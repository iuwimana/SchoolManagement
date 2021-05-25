using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Globals;
using Security;


namespace MIS
{
    public partial class StaffsForm : Form
    {
        public int CurrentUser;
        public int CurrentRole;
        Staffs members = null;
        

        public StaffsForm()
        {
            InitializeComponent();
            GlobalsFactory.InitializeListView(this.listViewMembers);
        }

        private void StaffsForm_Load(object sender, EventArgs e)
        {
            try
            {
               
                Cursor current = Cursor.Current;
                Cursor.Current = Cursors.WaitCursor;

                //int a = currentUser.UserID;

                members = MISFactory.GetProvencialStaffs(CurrentUser);

                //if (CurrentRole == 3)
                //{
                //    members = MISFactory.GetProvencialStaffs(CurrentUser);

                //}
                //else if (CurrentRole == 4)
                //{
                //    members = MISFactory.GetDistrictStaffs(CurrentUser);

                //}
                //else
                //{
                //    members = MISFactory.GetStaffs();
                //}
                //members = MISFactory.GetStaffs();
                

                LoadMembers(members);

                Cursor.Current = current;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void LoadMembers(Staffs _members)
        {
            try
            {
                listViewMembers.Items.Clear();

                foreach (Staff record in _members)
                {
                    ListViewItem item = new ListViewItem(record.Surname);
                    item.SubItems.Add(string.IsNullOrWhiteSpace(record.MiddleName) ? record.FirstName : record.MiddleName + " " + record.FirstName);
                    item.SubItems.Add(record.Gender);
                    
                    item.SubItems.Add(record.StaffTypeName);
                    item.SubItems.Add(record.DepartmentName);
                    item.SubItems.Add(record.Telephone);
                    item.SubItems.Add(string.Format("{0:#,#}", record.ContributionAmount));
                    item.SubItems.Add(record.IsActive ? "Yes" : "No");
                    item.SubItems.Add(record.MembershipStartDate.ToString("dd/MM/yyyy"));
                    item.SubItems.Add(record.MembershipEndDate.ToString("dd/MM/yyyy"));
                    item.SubItems.Add(record.Profession);
                    item.SubItems.Add(record.IdentificationNumber);
                    item.SubItems.Add(record.Email);
                    item.SubItems.Add(record.HasDisability ? "Yes" : "No");
                    item.SubItems.Add(record.Desability);
                    item.SubItems.Add(record.EmploymentStatusName);
                    item.SubItems.Add(record.LisenceNumber);
                    item.SubItems.Add(record.TypeofContract);
                    item.SubItems.Add(record.DurationofContract);
                    listViewMembers.Items.Add(item);
                    item.Tag = record;
                }
            }
            catch
            {
                throw;
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                AddStaffsForm frm = new AddStaffsForm
                {
                    Tag = new Staff()
                    {
                        BirthDate = DateTime.Today,
                        EmploymentDate = DateTime.Today,
                        MembershipStartDate = DateTime.Today,
                        MembershipEndDate = DateTime.Today,
                        Gender = "M",
                        Profession = "Nurse",
                        IsActive = true
                    }
                };
                frm.ShowDialog();

                StaffsForm_Load(this, new EventArgs());
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (listViewMembers.SelectedItems.Count > 0)
                {
                    Staff obj = (Staff)listViewMembers.SelectedItems[0].Tag;

                    AddStaffsForm frm = new AddStaffsForm
                    {
                        Tag = obj
                    };
                    frm.ShowDialog();
                    StaffsForm_Load(this, new EventArgs());
                }
                else
                {
                    MessageBox.Show("Please select Staff to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void listViewStaffs_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                listViewStaffs_DoubleClick(this, new EventArgs());
            }
        }

        private void listViewStaffs_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (listViewMembers.SelectedItems.Count > 0)
                {
                    Staff obj = (Staff)listViewMembers.SelectedItems[0].Tag;

                    AddStaffsForm details = new AddStaffsForm { Tag = obj };
                    details.ShowDialog();
                    StaffsForm_Load(this, new EventArgs());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (listViewMembers.SelectedItems.Count > 0)
                {
                    if (MessageBox.Show("Are you sure you want to delete this Staff?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        ((Staff)listViewMembers.SelectedItems[0].Tag).Delete();
                        StaffsForm_Load(this, new EventArgs());
                    }
                }
                else
                {
                    MessageBox.Show("Please select Staff to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void buttonContributions_Click(object sender, EventArgs e)
        {
            try
            {
                if (listViewMembers.SelectedItems.Count > 0)
                {
                    Staff obj = (Staff)listViewMembers.SelectedItems[0].Tag;

                    ContributionsForm frm = new ContributionsForm
                    {
                        Tag = obj
                    };
                    frm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Please select Staff to view contributions.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.members != null)
                {
                    LoadMembers(this.members);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void Search_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBoxMemberSearch.Text))
            {
                foreach (ListViewItem item in listViewMembers.Items)
                {
                    item.UseItemStyleForSubItems = false;
                    bool isVisible = false;

                    foreach (ListViewItem.ListViewSubItem subItem in item.SubItems)
                    {
                        subItem.ForeColor = Color.Black;
                        if (subItem.Text.ToLower().Contains(textBoxMemberSearch.Text.ToLower()))
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

        private void ultraGroupBox2_Click(object sender, EventArgs e)
        {

        }

        private void ultraGroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string connectString =
            //"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=c:\\data\\exceltest.xlsx;Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1;\"";
            //OleDbConnection conn = new OleDbConnection(connectString);
            //OleDbDataAdapter da = new OleDbDataAdapter("Select * From [Sheet1$]", conn);
            //DataTable dt = new DataTable();
            //da.Fill(dt);
            //conn.Close();
            //SqlConnection sqlc = new SqlConnection(@"Data Source=10.10.96.231;Initial Catalog=RNMU;User ID=rnmuuser;Password=ippisuser");
            //sqlc.Open();
            //SqlCommand cmd = new SqlCommand("select * from staffs", sqlc);
            //SqlDataAdapter sda = new SqlDataAdapter("select * from staffs", sqlc);
            //sda.InsertCommand = new SqlCommand("insert into staffs", sqlc);
            //DataTable dbset = new DataTable();
            //da.Fill(dbset);
            //SqlCommand cmdinsert = new SqlCommand();
            //cmdinsert.Connection = sqlc;
            //foreach (DataRow dsrc in dt.Rows)
            //{
            //    string insertcommand = "insert into Staffs" + dbset.TableName + " ";
            //    string cols = "";
            //    string vals = "";
            //    DataRow dr = dbset.NewRow();
            //    foreach (DataColumn clm in dt.Columns)
            //    {
            //        dr[clm.ColumnName] = dsrc[clm.ColumnName].ToString(); ;
            //        if (cols.Length > 0)
            //        {
            //            cols += ",[" + clm.ColumnName + "]";
            //        }
            //        else
            //        {
            //            cols = "[" + clm.ColumnName + "]";
            //        }
            //        if (vals.Length > 0)
            //        {
            //            vals += "," + "'" + dsrc[clm.ColumnName].ToString() + "'";
            //        }
            //        else
            //        {
            //            vals = "'" + dsrc[clm.ColumnName].ToString() + "'";
            //        }

            //    }
            //    insertcommand += "(" + cols + ") values(" + vals + ")";
            //    cmdinsert.CommandText = insertcommand;
            //    cmdinsert.ExecuteNonQuery();
            //    insertcommand = "";


            //}

            //sqlc.Close();
            //

            try
            {
                UploadStaffInfo frm = new UploadStaffInfo();
                

                frm.ShowDialog();
           
           

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

        }

        private void listViewMembers_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
