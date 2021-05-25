#region using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Infragistics.Win;
using Infragistics.Win.UltraWinStatusBar;
using Security;

#endregion

namespace MIS
{
    public partial class MDIParent : Form
    {
        private User currentUser;
        public MDIParent()
        {
            InitializeComponent();
            SetControls();
        }

        private bool DisplayForm(Type t)
        {
            bool isOpen = false;
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == t)
                {
                    isOpen = true;
                }
            }
            return isOpen;
        }

        private void CloseOpenForms()
        {
            Form[] openForms = this.MdiChildren;

            foreach (Form child in openForms)
            {
                child.Close();
            }
        }

        private void ultraToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            try

            {

                switch (e.Tool.Key)
                {
                    case "Logout":

                        //expire the ticket

                        string username = Ticket.Instance.User.UserName;
                        string userId = Ticket.Instance.User.UserID.ToString();

                        AuditTrailManager.Instance.Add("LOG OUT", "User", userId, username, 0);

                        //Close all child forms and hide the main form
                        CloseOpenForms();

                        Ticket.Instance.Expire();

                        this.Hide();


                        if (new LoginForm().ShowDialog() == DialogResult.OK)
                        {
                            MDIParent_Load(sender, e);
                            this.Show();
                        }
                        else
                        {
                            this.Close();
                        }
                        break;

                    case "Close":
                        CloseOpenForms();
                        break;

                    case "Exit":
                        this.Close();
                        break;

                    case "About":
                        AboutForm abt = new AboutForm();
                        abt.ShowDialog();
                        break;
                    case "School":
                        if (DisplayForm(typeof(FrmSchoolcs)))
                        {
                            Form search = Application.OpenForms["FrmSchoolcs"];
                            search.Activate();
                        }
                        else
                        {
                            FrmSchoolcs frm = new FrmSchoolcs();
                            frm.MdiParent = this;
                            frm.WindowState = FormWindowState.Maximized;
                            frm.Show();
                        }
                        break;

                    case "Institutions":
                        if (DisplayForm(typeof(DepartmentsForm)))
                        {
                            Form search = Application.OpenForms["DepartmentsForm"];
                            search.Activate();
                        }
                        else
                        {
                            DepartmentsForm frm = new DepartmentsForm();
                            frm.MdiParent = this;
                            frm.WindowState = FormWindowState.Maximized;
                            frm.Show();
                        }
                        break;


                    case "EducationLevels":
                        if (DisplayForm(typeof(RanksForm)))
                        {
                            Form search = Application.OpenForms["RanksForm"];
                            search.Activate();
                        }
                        else
                        {
                            RanksForm frm = new RanksForm();
                            frm.MdiParent = this;
                            frm.WindowState = FormWindowState.Maximized;
                            frm.Show();
                        }
                        break;
                        
                      case "DashBoard":
                        if (DisplayForm(typeof(ReportingDashboard)))
                        {
                            Form search = Application.OpenForms["ReportingDashboard"];
                            search.Activate();
                        }
                        else
                        {
                            ReportingDashboard frm = new ReportingDashboard();
                            frm.MdiParent = this;
                            frm.WindowState = FormWindowState.Maximized;
                            frm.Show();
                        }
                        break;

                    case "StaffCategories":
                        if (DisplayForm(typeof(StaffTypesForm)))
                        {
                            Form search = Application.OpenForms["StaffTypesForm"];
                            search.Activate();
                        }
                        else
                        {
                            StaffTypesForm frm = new StaffTypesForm();
                            frm.MdiParent = this;
                            frm.WindowState = FormWindowState.Maximized;
                            frm.Show();
                        }
                        break;

                    case "Members":
                        if (DisplayForm(typeof(StaffsForm)))
                        {
                            Form search = Application.OpenForms["StaffsForm"];
                            search.Activate();
                        }
                        else
                        {
                            
                            int user1Id = Ticket.Instance.User.UserID;
                            int roleId = Ticket.Instance.User.UserID;
                            StaffsForm frm = new StaffsForm();
                            frm.MdiParent = this;
                            frm.WindowState = FormWindowState.Maximized;
                            frm.CurrentUser = user1Id;
                            frm.CurrentRole = roleId;
                            frm.Show();
                        }
                        break;

                    case "Users":
                        if (DisplayForm(typeof(UsersForm)))
                        {
                            Form search = Application.OpenForms["UsersForm"];
                            search.Activate();
                        }
                        else
                        {
                            UsersForm frm = new UsersForm();
                            frm.MdiParent = this;
                            frm.WindowState = FormWindowState.Maximized;
                            frm.Show();
                        }
                        break;


                    case "Roles":
                        if (DisplayForm(typeof(RolesForm)))
                        {
                            Form search = Application.OpenForms["RolesForm"];
                            search.Activate();
                        }
                        else
                        {
                            RolesForm frm = new RolesForm();
                            frm.MdiParent = this;
                            frm.WindowState = FormWindowState.Maximized;
                            frm.Show();
                        }
                        break;

                    case "Securables":
                        if (DisplayForm(typeof(SecurablesForm)))
                        {
                            Form search = Application.OpenForms["SecurablesForm"];
                            search.Activate();
                        }
                        else
                        {
                            SecurablesForm frm = new SecurablesForm();
                            frm.MdiParent = this;
                            frm.WindowState = FormWindowState.Maximized;
                            frm.Show();
                        }
                        break;


                    case "AuditTrail":
                        if (DisplayForm(typeof(AuditTrailForm)))
                        {
                            Form search = Application.OpenForms["AuditTrailForm"];
                            search.Activate();
                        }
                        else
                        {
                            AuditTrailForm frm = new AuditTrailForm();
                            frm.MdiParent = this;
                            frm.WindowState = FormWindowState.Maximized;
                            frm.Show();
                        }
                        break;

                    case "WebPortalUser":
                        if (DisplayForm(typeof(WebPortalUserForm)))
                        {
                            Form search = Application.OpenForms["WebPortalUserForm"];
                            search.Activate();
                        }
                        else
                        {
                            WebPortalUserForm frm = new WebPortalUserForm();
                            frm.MdiParent = this;
                            frm.WindowState = FormWindowState.Maximized;
                            frm.Show();
                        }
                        break;

                    case "AccountsBank":
                        if (DisplayForm(typeof(BankAccountsForm)))
                        {
                            Form search = Application.OpenForms["BankAccountsForm"];
                            search.Activate();
                        }
                        else
                        {
                            BankAccountsForm frm = new BankAccountsForm();
                            frm.MdiParent = this;
                            frm.WindowState = FormWindowState.Maximized;
                            frm.Show();
                        }
                        break;

                    case "MemberReport":
                        if (DisplayForm(typeof(MemberReportForm)))
                        {
                            Form search = Application.OpenForms["MemberReportForm"];
                            search.Activate();
                        }
                        else
                        {
                            MemberReportForm frm = new MemberReportForm();
                            frm.MdiParent = this;
                            frm.WindowState = FormWindowState.Maximized;
                            frm.Show();
                        }
                        break;

                    case "RNMU Report":
                        if (DisplayForm(typeof(RNMUReportForm)))
                        {
                            Form search = Application.OpenForms["RNMUReportForm"];
                            search.Activate();
                        }
                        else
                        {
                            RNMUReportForm frm = new RNMUReportForm();
                            frm.MdiParent = this;
                            frm.WindowState = FormWindowState.Maximized;
                            frm.Show();
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

        }

        private void SetControls()
        {
            ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2007;
            ultraTabbedMdiManager1.ViewStyle = Infragistics.Win.UltraWinTabbedMdi.ViewStyle.Office2007;
            ultraTabbedMdiManager1.TabSettings.DisplayFormIcon = Infragistics.Win.DefaultableBoolean.True;
            ultraTabbedMdiManager1.TabSettings.TabAppearance.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            ultraTabbedMdiManager1.TabGroupSettings.CloseButtonLocation = Infragistics.Win.UltraWinTabs.TabCloseButtonLocation.Tab;
            ultraStatusBar1.Appearance.FontData.Italic = Infragistics.Win.DefaultableBoolean.True;

            // Set the border style for the status bar control
            this.ultraStatusBar1.BorderStyle = UIElementBorderStyle.Default;

            // Set the default border style for panels
            this.ultraStatusBar1.BorderStylePanel = UIElementBorderStyle.Default;

            // Set the style for button type panels
            this.ultraStatusBar1.ButtonStyle = UIElementButtonStyle.Default;

            // Set the # of pixels between panels 
            this.ultraStatusBar1.InterPanelSpacing = 3;

            // Specify the margins inside the status bar control.			
            this.ultraStatusBar1.Padding = new UIElementMargins(2, 1, 1, 2);

            // Set some apperance setting for the control
            this.ultraStatusBar1.Appearance.BackGradientStyle = GradientStyle.Default;

            // Set the default appearance for panels
            this.ultraStatusBar1.PanelAppearance.BackColor = Color.Transparent;

            // Set some additional properties on the control
            this.ultraStatusBar1.PanelsVisible = true;
            this.ultraStatusBar1.ResizeStyle = ResizeStyle.Immediate;
            this.ultraStatusBar1.ScaledImageSize = new Size(8, 8);
            this.ultraStatusBar1.ScaleImages = ScaleImage.OnlyWhenNeeded;
            this.ultraStatusBar1.ShowToolTips = true;
            this.ultraStatusBar1.SizeGripVisible = DefaultableBoolean.True;
            this.ultraStatusBar1.UseMnemonic = true;
            this.ultraStatusBar1.WrapText = true;

            // Add some panels to the collection
            UltraStatusPanel panel;

            // Add a date style panel 
            panel = this.ultraStatusBar1.Panels.Add("P1", PanelStyle.Date);
            panel.DateTimeFormat = "dd-MMMM-yyyy";
            panel.Width = 120;

            // Add a time style panel 
            panel = this.ultraStatusBar1.Panels.Add("P2", PanelStyle.Time);
            panel.DateTimeFormat = "hh:mm:ss tt";
        }

        private void MDIParent_Load(object sender, EventArgs e)
        {
            try
            {
                PermissionChecks();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void PermissionChecks()
        {
            if (!Guard.CheckPermissions("Security", Guard.Actions.CanView))
            {
                ultraToolbarsManager1.Ribbon.Tabs["Security"].Visible = false;
            }

            if (!Guard.CheckPermissions("Settings", Guard.Actions.CanView))
            {
                ultraToolbarsManager1.Ribbon.Tabs["Settings"].Visible = false;
            }

        }

        private void MDIParent_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.DoEvents();
            Application.Exit();
        }
    }
}
