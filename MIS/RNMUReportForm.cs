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
    public partial class RNMUReportForm : Form
    {
        public RNMUReportForm()
        {
            InitializeComponent();
            GlobalsFactory.InitializeListView(this.listView);
        }

        private void MemberReportForm_Load(object sender, EventArgs e)
        {
            try
            {
                Cursor current = Cursor.Current;
                Cursor.Current = Cursors.WaitCursor;

                listView.Items.Clear();

                foreach (System.Data.DataRow row in MISFactory.GetAnnulContributions().Rows)
                {
                    ListViewItem item = new ListViewItem(row[0].ToString());
                    item.SubItems.Add(row[1].ToString());
                    item.SubItems.Add(string.Format("{0:#,#}", row[2]));
                    listView.Items.Add(item);
                    item.Tag = row;
                }

                Cursor.Current = current;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void buttonReport_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView.Items.Count > 0)
                {
                    ReportViewerForm rpt = new ReportViewerForm();
                    rpt.Report = GlobalsFactory.Report.Annual;
                    rpt.ShowDialog();
                }
                else
                {
                    MessageBox.Show("There are no contributions recorded in the system.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

    }
}
