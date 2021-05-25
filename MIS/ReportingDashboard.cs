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
    public partial class ReportingDashboard : Form
    {
        public ReportingDashboard()
        {
            InitializeComponent();
        }

        private void ReportingDashboard_Load(object sender, EventArgs e)
        {
            Staffs types = MISFactory.GetStaffsexe();
           
            this.chart1.DataSource = types.ToList();

            //Mapping a field with x-value of chart
            this.chart1.Series[0].XValueMember= "Gender";

            //Mapping a field with y-value of Chart
            this.chart1.Series[0].YValueMembers = "StaffNumber";

            //Bind the DataTable with Chart
            this.chart1.DataBind();

            Staffs types1 = MISFactory.GetStaffprofession();

            this.chart2.DataSource = types1.ToList();

            //Mapping a field with x-value of chart
            this.chart2.Series[0].XValueMember = "Profession";

            //Mapping a field with y-value of Chart
            this.chart2.Series[0].YValueMembers = "StaffNumber";

            //Bind the DataTable with Chart
            this.chart2.DataBind();

            Staffs types2 = MISFactory.GetStaffHealtFacility();

            this.chart3.DataSource = types2.ToList();

            //Mapping a field with x-value of chart
            this.chart3.Series[0].XValueMember = "InstitutioncategoryName";

            //Mapping a field with y-value of Chart
            this.chart3.Series[0].YValueMembers = "StaffNumber";

            //Bind the DataTable with Chart
            this.chart3.DataBind();

            try
            {

                foreach (Staff st in  MISFactory.GetStaffsexef())
                 {
                    //label4.BackColor = Color.White;
                    label4.Text = string.Format("{0:#,#}",st.StaffNumber.ToString());

                 }

                foreach (Staff st in MISFactory.GetStaffsexem())
                {
                    //label4.BackColor = Color.White;
                    label11.Text = string.Format("{0:#,#}", st.StaffNumber.ToString());

                }
                foreach (Staff st in MISFactory.GetStaffsexet())
                {
                    //label4.BackColor = Color.White;
                    label22.Text = string.Format("{0:#,#}", st.StaffNumber.ToString());
                    label6.BackColor = Color.White;
                    label6.Text = string.Format("{0:#,#}", st.StaffNumber.ToString());

                }
                foreach (Staff st in MISFactory.GetStaffprofessionN())
                {
                    //label4.BackColor = Color.White;
                    label23.Text = string.Format("{0:#,#}", st.StaffNumber.ToString());

                }

                foreach (Staff st in MISFactory.GetStaffprofessionM())
                {
                    //label4.BackColor = Color.White;
                    label24.Text = string.Format("{0:#,#}", st.StaffNumber.ToString());

                }
                foreach (Staff st in MISFactory.GetStaffprofessionT())
                {
                    //label4.BackColor = Color.White;
                    label25.Text = string.Format("{0:#,#}", st.StaffNumber.ToString());
                    

                }
                foreach (Staff st in MISFactory.GetStaffHealtFacilityDH())
                {
                    //label4.BackColor = Color.White;
                    label12.Text = string.Format("{0:#,#}", st.StaffNumber.ToString());


                }
                foreach (Staff st in MISFactory.GetStaffHealtFacilityPH())
                {
                    //label4.BackColor = Color.White;
                    label5.Text = string.Format("{0:#,#}", st.StaffNumber.ToString());


                }
                foreach (Staff st in MISFactory.GetStaffHealtFacilityRH())
                {
                    //label4.BackColor = Color.White;
                    label1.Text = string.Format("{0:#,#}", st.StaffNumber.ToString());


                }
                foreach (Staff st in MISFactory.GetStaffHealtFacilityHC())
                {
                    //label4.BackColor = Color.White;
                    label28.Text = string.Format("{0:#,#}", st.StaffNumber.ToString());


                }
                foreach (Staff st in MISFactory.GetStaffHealtFacilityT())
                {
                    //label4.BackColor = Color.White;
                    label27.Text = string.Format("{0:#,#}", st.StaffNumber.ToString());


                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            //label4.Text= string.Format("{0:#,#}", st.StaffNumber);
            
        }
    }
}
