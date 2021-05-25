using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Globals;

namespace MIS
{
    public partial class MemberReportForm : Form
    {
        Staffs members = null;

        public MemberReportForm()
        {
            InitializeComponent();
            GlobalsFactory.InitializeListView(this.listViewMembers);
        }

        private void MemberReportForm_Load(object sender, EventArgs e)
        {
            try
            {
                Cursor current = Cursor.Current;
                Cursor.Current = Cursors.WaitCursor;

                members = MISFactory.GetStaffs();
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
                    listViewMembers.Items.Add(item);
                    item.Tag = record;
                }
            }
            catch
            {
                throw;
            }
        }

        private void buttonContributions_Click(object sender, EventArgs e)
        {
            try
            {
                if (listViewMembers.SelectedItems.Count > 0)
                {
                    Staff obj = (Staff)listViewMembers.SelectedItems[0].Tag;

                    ReportViewerForm rpt = new ReportViewerForm();
                    rpt.Report = GlobalsFactory.Report.Member;
                    rpt.staffId = obj.StaffID;
                    rpt.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Please select member to view report.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

    }
}
