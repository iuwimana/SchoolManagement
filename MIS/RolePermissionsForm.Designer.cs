namespace MIS
{
    partial class RolePermissionsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RolePermissionsForm));
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonApply = new System.Windows.Forms.Button();
            this.groupBoxPermissions = new System.Windows.Forms.GroupBox();
            this.dataGridViewPermissions = new System.Windows.Forms.DataGridView();
            this.rolePermissionIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.roleIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.roleNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.securableIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.securableNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.canAccessDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.canCreateDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.canViewDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.canModifyDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.canDeleteDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.canExecuteDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.rolePermissionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBoxPermissions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPermissions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rolePermissionBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(728, 396);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 30);
            this.buttonClose.TabIndex = 6;
            this.buttonClose.Text = "&Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonApply
            // 
            this.buttonApply.Location = new System.Drawing.Point(629, 396);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(75, 30);
            this.buttonApply.TabIndex = 5;
            this.buttonApply.Text = "&Apply";
            this.buttonApply.UseVisualStyleBackColor = true;
            this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
            // 
            // groupBoxPermissions
            // 
            this.groupBoxPermissions.Controls.Add(this.dataGridViewPermissions);
            this.groupBoxPermissions.Location = new System.Drawing.Point(12, 12);
            this.groupBoxPermissions.Name = "groupBoxPermissions";
            this.groupBoxPermissions.Size = new System.Drawing.Size(820, 378);
            this.groupBoxPermissions.TabIndex = 4;
            this.groupBoxPermissions.TabStop = false;
            this.groupBoxPermissions.Text = "Role Permissions for ";
            // 
            // dataGridViewPermissions
            // 
            this.dataGridViewPermissions.AllowUserToAddRows = false;
            this.dataGridViewPermissions.AllowUserToDeleteRows = false;
            this.dataGridViewPermissions.AutoGenerateColumns = false;
            this.dataGridViewPermissions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPermissions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.rolePermissionIDDataGridViewTextBoxColumn,
            this.roleIDDataGridViewTextBoxColumn,
            this.roleNameDataGridViewTextBoxColumn,
            this.securableIDDataGridViewTextBoxColumn,
            this.securableNameDataGridViewTextBoxColumn,
            this.canAccessDataGridViewCheckBoxColumn,
            this.canCreateDataGridViewCheckBoxColumn,
            this.canViewDataGridViewCheckBoxColumn,
            this.canModifyDataGridViewCheckBoxColumn,
            this.canDeleteDataGridViewCheckBoxColumn,
            this.canExecuteDataGridViewCheckBoxColumn});
            this.dataGridViewPermissions.DataSource = this.rolePermissionBindingSource;
            this.dataGridViewPermissions.Location = new System.Drawing.Point(21, 31);
            this.dataGridViewPermissions.Name = "dataGridViewPermissions";
            this.dataGridViewPermissions.Size = new System.Drawing.Size(779, 327);
            this.dataGridViewPermissions.TabIndex = 0;
            this.dataGridViewPermissions.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPermissions_CellContentClick);
            // 
            // rolePermissionIDDataGridViewTextBoxColumn
            // 
            this.rolePermissionIDDataGridViewTextBoxColumn.DataPropertyName = "RolePermissionID";
            this.rolePermissionIDDataGridViewTextBoxColumn.Frozen = true;
            this.rolePermissionIDDataGridViewTextBoxColumn.HeaderText = "RolePermissionID";
            this.rolePermissionIDDataGridViewTextBoxColumn.Name = "rolePermissionIDDataGridViewTextBoxColumn";
            this.rolePermissionIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.rolePermissionIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // roleIDDataGridViewTextBoxColumn
            // 
            this.roleIDDataGridViewTextBoxColumn.DataPropertyName = "RoleID";
            this.roleIDDataGridViewTextBoxColumn.Frozen = true;
            this.roleIDDataGridViewTextBoxColumn.HeaderText = "RoleID";
            this.roleIDDataGridViewTextBoxColumn.Name = "roleIDDataGridViewTextBoxColumn";
            this.roleIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.roleIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // roleNameDataGridViewTextBoxColumn
            // 
            this.roleNameDataGridViewTextBoxColumn.DataPropertyName = "RoleName";
            this.roleNameDataGridViewTextBoxColumn.Frozen = true;
            this.roleNameDataGridViewTextBoxColumn.HeaderText = "RoleName";
            this.roleNameDataGridViewTextBoxColumn.Name = "roleNameDataGridViewTextBoxColumn";
            this.roleNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.roleNameDataGridViewTextBoxColumn.Visible = false;
            // 
            // securableIDDataGridViewTextBoxColumn
            // 
            this.securableIDDataGridViewTextBoxColumn.DataPropertyName = "SecurableID";
            this.securableIDDataGridViewTextBoxColumn.Frozen = true;
            this.securableIDDataGridViewTextBoxColumn.HeaderText = "SecurableID";
            this.securableIDDataGridViewTextBoxColumn.Name = "securableIDDataGridViewTextBoxColumn";
            this.securableIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.securableIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // securableNameDataGridViewTextBoxColumn
            // 
            this.securableNameDataGridViewTextBoxColumn.DataPropertyName = "SecurableName";
            this.securableNameDataGridViewTextBoxColumn.HeaderText = "Securable";
            this.securableNameDataGridViewTextBoxColumn.Name = "securableNameDataGridViewTextBoxColumn";
            // 
            // canAccessDataGridViewCheckBoxColumn
            // 
            this.canAccessDataGridViewCheckBoxColumn.DataPropertyName = "CanAccess";
            this.canAccessDataGridViewCheckBoxColumn.HeaderText = "Can Access";
            this.canAccessDataGridViewCheckBoxColumn.Name = "canAccessDataGridViewCheckBoxColumn";
            // 
            // canCreateDataGridViewCheckBoxColumn
            // 
            this.canCreateDataGridViewCheckBoxColumn.DataPropertyName = "CanCreate";
            this.canCreateDataGridViewCheckBoxColumn.HeaderText = "Can Create";
            this.canCreateDataGridViewCheckBoxColumn.Name = "canCreateDataGridViewCheckBoxColumn";
            // 
            // canViewDataGridViewCheckBoxColumn
            // 
            this.canViewDataGridViewCheckBoxColumn.DataPropertyName = "CanView";
            this.canViewDataGridViewCheckBoxColumn.HeaderText = "Can View";
            this.canViewDataGridViewCheckBoxColumn.Name = "canViewDataGridViewCheckBoxColumn";
            // 
            // canModifyDataGridViewCheckBoxColumn
            // 
            this.canModifyDataGridViewCheckBoxColumn.DataPropertyName = "CanModify";
            this.canModifyDataGridViewCheckBoxColumn.HeaderText = "Can Modify";
            this.canModifyDataGridViewCheckBoxColumn.Name = "canModifyDataGridViewCheckBoxColumn";
            // 
            // canDeleteDataGridViewCheckBoxColumn
            // 
            this.canDeleteDataGridViewCheckBoxColumn.DataPropertyName = "CanDelete";
            this.canDeleteDataGridViewCheckBoxColumn.HeaderText = "Can Delete";
            this.canDeleteDataGridViewCheckBoxColumn.Name = "canDeleteDataGridViewCheckBoxColumn";
            // 
            // canExecuteDataGridViewCheckBoxColumn
            // 
            this.canExecuteDataGridViewCheckBoxColumn.DataPropertyName = "CanExecute";
            this.canExecuteDataGridViewCheckBoxColumn.HeaderText = "Can Execute";
            this.canExecuteDataGridViewCheckBoxColumn.Name = "canExecuteDataGridViewCheckBoxColumn";
            // 
            // rolePermissionBindingSource
            // 
            this.rolePermissionBindingSource.AllowNew = false;
            this.rolePermissionBindingSource.DataSource = typeof(Security.RolePermission);
            // 
            // RolePermissionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 438);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonApply);
            this.Controls.Add(this.groupBoxPermissions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RolePermissionsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Securable Permissions";
            this.Load += new System.EventHandler(this.SecurablePermissionsForm_Load);
            this.groupBoxPermissions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPermissions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rolePermissionBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonApply;
        private System.Windows.Forms.GroupBox groupBoxPermissions;
        private System.Windows.Forms.DataGridView dataGridViewPermissions;
        private System.Windows.Forms.BindingSource rolePermissionBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn rolePermissionIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn roleIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn roleNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn securableIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn securableNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn canAccessDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn canCreateDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn canViewDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn canModifyDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn canDeleteDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn canExecuteDataGridViewCheckBoxColumn;
    }
}