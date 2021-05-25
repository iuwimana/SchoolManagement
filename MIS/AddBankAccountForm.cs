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
    public partial class AddBankAccountForm : Form
    {
        public AddBankAccountForm()
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
                if (comboBoxCurrency.SelectedItem == null || textBoxAccountName.Text == string.Empty
                    || textBoxAccountNumber.Text == string.Empty || comboBoxBank.SelectedItem == null)
                {
                    MessageBox.Show("Some information is missing.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                
                BankAccount obj = (BankAccount)this.Tag;

                obj.AccountName = textBoxAccountName.Text;
                obj.AccountNumber = textBoxAccountNumber.Text;
                obj.CurrencyID = Convert.ToInt32(comboBoxCurrency.SelectedValue);
                obj.BankID = Convert.ToInt32(comboBoxBank.SelectedValue);
                obj.Save();

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void AddBankAccountForm_Load(object sender, EventArgs e)
        {
            try
            {
                BankAccount obj = (BankAccount)this.Tag;

                Currencys currencys = MISFactory.GetCurrencys();
                comboBoxCurrency.DataSource = currencys.ToList();
                comboBoxCurrency.DisplayMember = "CurrencyName";
                comboBoxCurrency.ValueMember = "CurrencyID";
                comboBoxCurrency.DropDownStyle = ComboBoxStyle.DropDownList;

                Banks banks = MISFactory.GetBanks();
                comboBoxBank.DataSource = banks.ToList();
                comboBoxBank.DisplayMember = "BankName";
                comboBoxBank.ValueMember = "BankID";
                comboBoxBank.DropDownStyle = ComboBoxStyle.DropDownList;

                textBoxAccountName.Text = obj.AccountName;
                textBoxAccountNumber.Text = obj.AccountNumber;
                comboBoxBank.Text = obj.BankName;
                comboBoxCurrency.Text = obj.Currency;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

    }
}
