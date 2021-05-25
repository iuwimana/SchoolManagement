using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using Globals;

namespace MIS
{
    public partial class ReportViewerForm : Form
    {
        public GlobalsFactory.Report Report { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ToDate { get; set; }
        public bool boolValue { get; set; }
        public long Id { get; set; }
        public int staffId { get; set; }

        public ReportViewerForm()
        {
            InitializeComponent();
        }

        private void ReportViewerForm_Load(object sender, EventArgs e)
        {
            try
            {
                ReportDocument rpt = new ReportDocument();

                switch (Report)
                {

                    case GlobalsFactory.Report.Member:
                        rpt = new Reports.MemberContributionsReport();
                        rpt.SetDataSource(MISFactory.GetContributions(staffId));
                        crystalReportViewer1.ReportSource = rpt;
                        break;

                    case GlobalsFactory.Report.Annual:
                        rpt = new Reports.AnnualReport();
                        rpt.SetDataSource(MISFactory.GetAnnulContributions());
                        crystalReportViewer1.ReportSource = rpt;
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

    }
}
