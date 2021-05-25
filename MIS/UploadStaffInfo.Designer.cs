namespace MIS
{
    partial class UploadStaffInfo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.membercontributionallBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.membercontributionallBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Surname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MiddleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StaffTypeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RankID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DepartmentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NationalityID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdentificationNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BirthDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telephone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmploymentDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MembershipStartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MembershipEndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContributionAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsActive = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SocialSecurityNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Profession = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HasDisability = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Desability = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LisenceNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmploymentStatusID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rNMUDataSet = new MIS.RNMUDataSet();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.membercontributionallBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.membercontributionallBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rNMUDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Surname,
            this.FirstName,
            this.MiddleName,
            this.StaffTypeID,
            this.RankID,
            this.DepartmentID,
            this.NationalityID,
            this.IdentificationNumber,
            this.Gender,
            this.BirthDate,
            this.Telephone,
            this.Email,
            this.EmploymentDate,
            this.MembershipStartDate,
            this.MembershipEndDate,
            this.ContributionAmount,
            this.IsActive,
            this.SocialSecurityNumber,
            this.Profession,
            this.HasDisability,
            this.Desability,
            this.LisenceNumber,
            this.EmploymentStatusID});
            this.dataGridView1.DataSource = this.membercontributionallBindingSource1;
            this.dataGridView1.Location = new System.Drawing.Point(48, 13);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(1827, 561);
            this.dataGridView1.TabIndex = 7;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(550, 647);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(96, 28);
            this.button2.TabIndex = 13;
            this.button2.Text = "Import Data";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(98, 650);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 17);
            this.label2.TabIndex = 12;
            this.label2.Text = "Sheet Name";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(210, 650);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(300, 24);
            this.comboBox1.TabIndex = 11;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1072, 603);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(65, 28);
            this.button1.TabIndex = 10;
            this.button1.Text = "....";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(213, 605);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(849, 22);
            this.textBox1.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(98, 605);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "FileName";
            // 
            // membercontributionallBindingSource
            // 
            this.membercontributionallBindingSource.DataSource = this.rNMUDataSet;
            this.membercontributionallBindingSource.Position = 0;
            this.membercontributionallBindingSource.CurrentChanged += new System.EventHandler(this.membercontributionallBindingSource_CurrentChanged);
            // 
            // Surname
            // 
            this.Surname.HeaderText = "Surname";
            this.Surname.MinimumWidth = 6;
            this.Surname.Name = "Surname";
            this.Surname.Width = 125;
            // 
            // FirstName
            // 
            this.FirstName.HeaderText = "FirstName";
            this.FirstName.MinimumWidth = 6;
            this.FirstName.Name = "FirstName";
            this.FirstName.Width = 125;
            // 
            // MiddleName
            // 
            this.MiddleName.HeaderText = "MiddleName";
            this.MiddleName.MinimumWidth = 6;
            this.MiddleName.Name = "MiddleName";
            this.MiddleName.Width = 125;
            // 
            // StaffTypeID
            // 
            this.StaffTypeID.HeaderText = "StaffTypeID";
            this.StaffTypeID.MinimumWidth = 6;
            this.StaffTypeID.Name = "StaffTypeID";
            this.StaffTypeID.Width = 125;
            // 
            // RankID
            // 
            this.RankID.HeaderText = "RankID";
            this.RankID.MinimumWidth = 6;
            this.RankID.Name = "RankID";
            this.RankID.Width = 125;
            // 
            // DepartmentID
            // 
            this.DepartmentID.HeaderText = "DepartmentID";
            this.DepartmentID.MinimumWidth = 6;
            this.DepartmentID.Name = "DepartmentID";
            this.DepartmentID.Width = 125;
            // 
            // NationalityID
            // 
            this.NationalityID.HeaderText = "NationalityID";
            this.NationalityID.MinimumWidth = 6;
            this.NationalityID.Name = "NationalityID";
            this.NationalityID.Width = 125;
            // 
            // IdentificationNumber
            // 
            this.IdentificationNumber.HeaderText = "IdentificationNumber";
            this.IdentificationNumber.MinimumWidth = 6;
            this.IdentificationNumber.Name = "IdentificationNumber";
            this.IdentificationNumber.Width = 125;
            // 
            // Gender
            // 
            this.Gender.HeaderText = "Gender";
            this.Gender.MinimumWidth = 6;
            this.Gender.Name = "Gender";
            this.Gender.Width = 125;
            // 
            // BirthDate
            // 
            this.BirthDate.HeaderText = "BirthDate";
            this.BirthDate.MinimumWidth = 6;
            this.BirthDate.Name = "BirthDate";
            this.BirthDate.Width = 125;
            // 
            // Telephone
            // 
            this.Telephone.HeaderText = "Telephone";
            this.Telephone.MinimumWidth = 6;
            this.Telephone.Name = "Telephone";
            this.Telephone.Width = 125;
            // 
            // Email
            // 
            this.Email.HeaderText = "Email";
            this.Email.MinimumWidth = 6;
            this.Email.Name = "Email";
            this.Email.Width = 125;
            // 
            // EmploymentDate
            // 
            this.EmploymentDate.HeaderText = "EmploymentDate";
            this.EmploymentDate.MinimumWidth = 6;
            this.EmploymentDate.Name = "EmploymentDate";
            this.EmploymentDate.Width = 125;
            // 
            // MembershipStartDate
            // 
            this.MembershipStartDate.HeaderText = "MembershipStartDate";
            this.MembershipStartDate.MinimumWidth = 6;
            this.MembershipStartDate.Name = "MembershipStartDate";
            this.MembershipStartDate.Width = 125;
            // 
            // MembershipEndDate
            // 
            this.MembershipEndDate.HeaderText = "MembershipEndDate";
            this.MembershipEndDate.MinimumWidth = 6;
            this.MembershipEndDate.Name = "MembershipEndDate";
            this.MembershipEndDate.Width = 125;
            // 
            // ContributionAmount
            // 
            this.ContributionAmount.HeaderText = "ContributionAmount";
            this.ContributionAmount.MinimumWidth = 6;
            this.ContributionAmount.Name = "ContributionAmount";
            this.ContributionAmount.Width = 125;
            // 
            // IsActive
            // 
            this.IsActive.HeaderText = "IsActive";
            this.IsActive.MinimumWidth = 6;
            this.IsActive.Name = "IsActive";
            this.IsActive.Width = 125;
            // 
            // SocialSecurityNumber
            // 
            this.SocialSecurityNumber.HeaderText = "SocialSecurityNumber";
            this.SocialSecurityNumber.MinimumWidth = 6;
            this.SocialSecurityNumber.Name = "SocialSecurityNumber";
            this.SocialSecurityNumber.Width = 125;
            // 
            // Profession
            // 
            this.Profession.HeaderText = "Profession";
            this.Profession.MinimumWidth = 6;
            this.Profession.Name = "Profession";
            this.Profession.Width = 125;
            // 
            // HasDisability
            // 
            this.HasDisability.HeaderText = "HasDisability";
            this.HasDisability.MinimumWidth = 6;
            this.HasDisability.Name = "HasDisability";
            this.HasDisability.Width = 125;
            // 
            // Desability
            // 
            this.Desability.HeaderText = "Desability";
            this.Desability.MinimumWidth = 6;
            this.Desability.Name = "Desability";
            this.Desability.Width = 125;
            // 
            // LisenceNumber
            // 
            this.LisenceNumber.HeaderText = "LisenceNumber";
            this.LisenceNumber.MinimumWidth = 6;
            this.LisenceNumber.Name = "LisenceNumber";
            this.LisenceNumber.Width = 125;
            // 
            // EmploymentStatusID
            // 
            this.EmploymentStatusID.HeaderText = "EmploymentStatusID";
            this.EmploymentStatusID.MinimumWidth = 6;
            this.EmploymentStatusID.Name = "EmploymentStatusID";
            this.EmploymentStatusID.Width = 125;
            // 
            // rNMUDataSet
            // 
            this.rNMUDataSet.DataSetName = "RNMUDataSet";
            this.rNMUDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // UploadStaffInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 709);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Name = "UploadStaffInfo";
            this.Text = "UploadStaffInfo";
            this.Load += new System.EventHandler(this.UploadStaffInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.membercontributionallBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.membercontributionallBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rNMUDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource membercontributionallBindingSource1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource membercontributionallBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn Surname;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn MiddleName;
        private System.Windows.Forms.DataGridViewTextBoxColumn StaffTypeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn RankID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DepartmentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NationalityID;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdentificationNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gender;
        private System.Windows.Forms.DataGridViewTextBoxColumn BirthDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telephone;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmploymentDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn MembershipStartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn MembershipEndDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContributionAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsActive;
        private System.Windows.Forms.DataGridViewTextBoxColumn SocialSecurityNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Profession;
        private System.Windows.Forms.DataGridViewTextBoxColumn HasDisability;
        private System.Windows.Forms.DataGridViewTextBoxColumn Desability;
        private System.Windows.Forms.DataGridViewTextBoxColumn LisenceNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmploymentStatusID;
        private RNMUDataSet rNMUDataSet;
    }
}