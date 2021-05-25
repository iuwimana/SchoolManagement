using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BrightIdeasSoftware;
using Security;

namespace MIS
{
    public partial class AuditTrailForm : Form
    {
        private AuditTrail currentTrail;
        private AuditTrails filteredTrails;
        private User loggedInUser;

        public AuditTrailForm()
        {
            InitializeComponent();

            groupBoxFilter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            treeListView.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            textBoxDescription.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            tableLayoutPanelButtons.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        }

        private void AuditTrailForm_Load(object sender, EventArgs e)
        {
            buttonClear.Enabled = false;
            buttonExport.Visible = false;

            DisplayAuditTrail();
        }

        private User user;
        public User User
        {
            get { return user; }
            set
            {
                user = value;

                if (user != null)
                {
                    comboBoxUsers.Enabled = false;
                }
            }
        }

        public void DisplayAuditTrail()
        {
            loggedInUser = Ticket.Instance.User;

            DateTime now = DateTime.Now;
            dateTimePickerStart.Value = now.AddDays(-1);
            dateTimePickerEnd.Value = now;

            List<string> actions = SecurityFactory.GetAuditActions();

            comboBoxActions.Items.Clear();
            comboBoxActions.Items.Add("All");

            foreach (String action in actions)
            {
                comboBoxActions.Items.Add(action);
            }

            comboBoxActions.SelectedIndex = 0;
            List<string> objects = SecurityFactory.GetAuditObjects();

            comboBoxSecurables.Items.Clear();
            comboBoxSecurables.Items.Add("All");

            foreach (String sec in objects)
            {
                comboBoxSecurables.Items.Add(sec);
            }
            comboBoxSecurables.SelectedIndex = 0;

            List<string> auditUsers = SecurityFactory.GetAuditUsers();

            comboBoxUsers.Items.Clear();
            comboBoxUsers.Items.Add("All");

            foreach (String item in auditUsers)
            {
                comboBoxUsers.Items.Add(item);
            }

            if (user == null)
                comboBoxUsers.SelectedIndex = 0;
            else
                comboBoxUsers.Text = user.UserName;

            //by default display 2 days audit trail for all users,all securables and all actions
            filteredTrails = new AuditTrails();
            DateTime start = dateTimePickerStart.Value.Date;
            DateTime end = dateTimePickerEnd.Value.AddDays(1).Date;

            if (user == null)
                filteredTrails.Load(start, end, "All", "All", "All");
            else
                filteredTrails.Load(start, end, "All", user.UserName, "All");

            ShowAuditTrails(filteredTrails);

        }

        private void AuditTrailView_Load(object sender, EventArgs e)
        {
            buttonClear.Enabled = false;
            buttonExport.Visible = false;
            //buttonExport.Enabled = false;

        }

        private void buttonApplyFilter_Click(object sender, EventArgs e)
        {
            AuditTrails trails = new AuditTrails();
            DateTime start = dateTimePickerStart.Value.Date;
            DateTime end = dateTimePickerEnd.Value.AddDays(1).Date;

            Cursor saveCursor = Cursor.Current;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                trails.Load(start, end, comboBoxActions.Text, comboBoxUsers.Text, comboBoxSecurables.Text);

                ShowAuditTrails(trails);
            }
            finally
            {
                Cursor.Current = saveCursor;
            }

        }

        private void ShowAuditTrails(AuditTrails trails)
        {
            treeListView.CanExpandGetter = delegate (object x)
            {
                AuditTrail trail = (AuditTrail)x;
                int childCount = filteredTrails.Where(t => t.ParentID == trail.TrailID).Count();

                return (childCount > 0);
            };

            treeListView.ChildrenGetter = delegate (object x)
            {
                AuditTrail trail = (AuditTrail)x;
                try
                {
                    return new ArrayList(filteredTrails.Where(t => t.ParentID == trail.TrailID).ToList());

                }
                catch (Exception ex)
                {
                                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return new ArrayList();
                }
            };

            var parents = trails.Where(t => t.ParentID == 0);

            treeListView.Roots = parents;

            textBoxDescription.Clear();

            bool enable = (trails.Count > 0);

            RolePermission auditPerm = loggedInUser.Permissions.Item("Audit Trail");
            buttonClear.Enabled = auditPerm.CanDelete && enable;
            buttonClear.Enabled = enable;

        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(this, "Are you sure you want to clear the audit trail entries?", "Clear audit trail", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            string remark = Environment.NewLine;

            if (result == DialogResult.Yes)
            {
                int i = 0;
                foreach (AuditTrail trail in treeListView.SelectedObjects)
                {
                    i++;
                    remark += trail.ToString() + Environment.NewLine;
                    trail.Delete();
                }

                if (i > 0)
                    AuditTrailManager.Instance.Add("CLEAR", "Audit Trail", "", "Audit trail entries cleared:" + remark, 0);

                buttonApplyFilter_Click(sender, e);
            }
        }

        private void treeListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                textBoxDescription.Text = "";

                currentTrail = (AuditTrail)treeListView.SelectedObject;

                if (currentTrail != null)
                {
                    textBoxDescription.Text = currentTrail.Remarks;

                    RolePermission auditPerm = loggedInUser.Permissions.Item("Audit Trail");

                    buttonClear.Enabled = auditPerm.CanDelete;
                    buttonExport.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

    }
}
