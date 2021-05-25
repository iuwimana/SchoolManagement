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
    public partial class AddContributionForm : Form
    {
        private List<int> years = new List<int>();
        private List<byte> months = new List<byte>();

        public AddContributionForm()
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
                if (textBoxAmount.Text == string.Empty || comboBoxMonth.SelectedItem == null || comboBoxYear.SelectedItem == null
                    || textBoxReference.Text == string.Empty || comboBoxAccount.SelectedItem == null)
                {
                    MessageBox.Show("Some information is missing.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Contribution obj = (Contribution)this.Tag;

                obj.StaffID = obj.StaffID;
                obj.Amount = Convert.ToInt32(textBoxAmount.Text.Replace(",", ""));
                obj.Month = Convert.ToByte(comboBoxMonth.SelectedValue);
                obj.Year = Convert.ToInt16(comboBoxYear.SelectedValue);
                obj.BankTransactionDate = Convert.ToDateTime(dateTimePickerTransactionDate.Value);
                obj.BankTransactionNumber = textBoxReference.Text;
                obj.BankAccountID = Convert.ToInt32(comboBoxAccount.SelectedValue);
                obj.UserID = Globals.GlobalsFactory.GetCurrentUserId();
                obj.Save();

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void AddContributionForm_Load(object sender, EventArgs e)
        {
            try
            {
                for (int y = 2016; y <= DateTime.Today.Year; y++)
                {
                    years.Add(y);
                }

                for (byte m = 1; m <= 12; m++)
                {
                    months.Add(m);
                }

                Contribution obj = (Contribution)this.Tag;

                BankAccounts accounts = MISFactory.GetBankAccounts();
                comboBoxAccount.DataSource = accounts.ToList();
                comboBoxAccount.DisplayMember = "AccountNumber";
                comboBoxAccount.ValueMember = "BankAccountID";
                comboBoxAccount.DropDownStyle = ComboBoxStyle.DropDownList;

                comboBoxYear.DataSource = years;
                comboBoxYear.DropDownStyle = ComboBoxStyle.DropDownList;

                comboBoxMonth.DataSource = months;
                comboBoxMonth.DropDownStyle = ComboBoxStyle.DropDownList;

                textBoxAmount.Text = string.Format("{0:#,#}", obj.Amount);
                dateTimePickerTransactionDate.Value = obj.BankTransactionDate;
                textBoxReference.Text = obj.BankTransactionNumber;

                comboBoxMonth.Text = obj.Month.ToString();
                comboBoxYear.Text = obj.Year.ToString();
                comboBoxAccount.Text = obj.AccountNumber;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

    }
}
