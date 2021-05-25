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
    public partial class FrmSchoolcs : Form
    {
        schools members = null;
        public FrmSchoolcs()
        {
            InitializeComponent();
        }

        private void FrmSchoolcs_Load(object sender, EventArgs e)
        {

            try
            {
                Cursor current = Cursor.Current;
                Cursor.Current = Cursors.WaitCursor;
                members = MISFactory.Getschools();
                Loadschools(members);
                Cursor.Current = current;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        private void Loadschools(schools _members)
        {
            try
            {
                listViewLookups.Items.Clear();
                // foreach (Staff record in _members)
                foreach (school record in _members)
                {
                    ListViewItem item = new ListViewItem(record.EntityName);
                    item.SubItems.Add(record.Acronym);
                    item.SubItems.Add(record.StartDate.ToString());
                    item.SubItems.Add(record.EndDate.ToString());
                    item.SubItems.Add(record.TIN);
                    listViewLookups.Items.Add(item);
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
                FrmAddSchool frm = new FrmAddSchool
                {
                    Tag = new school()
                };
                frm.ShowDialog();

                schoolsForm_Load(this, new EventArgs());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        private void schoolsForm_Load(object sender, EventArgs e)
        {

            try
            {
                Cursor current = Cursor.Current;
                Cursor.Current = Cursors.WaitCursor;
                members = MISFactory.Getschools();
                Loadschools(members);
                Cursor.Current = current;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

    }
}
