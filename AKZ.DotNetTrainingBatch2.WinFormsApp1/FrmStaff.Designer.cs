namespace AKZ.DotNetTrainingBatch2.WinFormsApp1
{
    partial class FrmStaff
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            txtCode = new TextBox();
            txtName = new TextBox();
            label2 = new Label();
            txtPassword = new TextBox();
            label3 = new Label();
            txtEmail = new TextBox();
            label4 = new Label();
            label5 = new Label();
            cboPosition = new ComboBox();
            btnSave = new Button();
            dgvData = new DataGridView();
            updateBtn = new Button();
            colEdit = new DataGridViewButtonColumn();
            colDelete = new DataGridViewButtonColumn();
            colId = new DataGridViewTextBoxColumn();
            colCode = new DataGridViewTextBoxColumn();
            colName = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvData).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(24, 21);
            label1.Name = "label1";
            label1.Size = new Size(99, 25);
            label1.TabIndex = 0;
            label1.Text = "Staff Code:";
            // 
            // txtCode
            // 
            txtCode.Location = new Point(24, 49);
            txtCode.Name = "txtCode";
            txtCode.Size = new Size(283, 31);
            txtCode.TabIndex = 1;
            // 
            // txtName
            // 
            txtName.Location = new Point(24, 120);
            txtName.Name = "txtName";
            txtName.Size = new Size(283, 31);
            txtName.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(24, 92);
            label2.Name = "label2";
            label2.Size = new Size(63, 25);
            label2.TabIndex = 2;
            label2.Text = "Name:";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(24, 262);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(283, 31);
            txtPassword.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(24, 234);
            label3.Name = "label3";
            label3.Size = new Size(91, 25);
            label3.TabIndex = 6;
            label3.Text = "Password:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(24, 191);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(283, 31);
            txtEmail.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(24, 163);
            label4.Name = "label4";
            label4.Size = new Size(58, 25);
            label4.TabIndex = 4;
            label4.Text = "Email:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(28, 307);
            label5.Name = "label5";
            label5.Size = new Size(79, 25);
            label5.TabIndex = 8;
            label5.Text = "Position:";
            // 
            // cboPosition
            // 
            cboPosition.FormattingEnabled = true;
            cboPosition.Items.AddRange(new object[] { "--Select one--", "Admin", "Staff" });
            cboPosition.Location = new Point(28, 335);
            cboPosition.Name = "cboPosition";
            cboPosition.Size = new Size(279, 33);
            cboPosition.TabIndex = 9;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(195, 391);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(112, 34);
            btnSave.TabIndex = 10;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // dgvData
            // 
            dgvData.AllowUserToAddRows = false;
            dgvData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvData.Columns.AddRange(new DataGridViewColumn[] { colEdit, colDelete, colId, colCode, colName });
            dgvData.Location = new Point(423, 21);
            dgvData.Name = "dgvData";
            dgvData.ReadOnly = true;
            dgvData.RowHeadersWidth = 62;
            dgvData.Size = new Size(814, 463);
            dgvData.TabIndex = 11;
            dgvData.CellContentClick += dgvData_CellContentClick;
            // 
            // updateBtn
            // 
            updateBtn.Location = new Point(77, 391);
            updateBtn.Name = "updateBtn";
            updateBtn.Size = new Size(112, 34);
            updateBtn.TabIndex = 12;
            updateBtn.Text = "Update";
            updateBtn.UseVisualStyleBackColor = true;
            updateBtn.Click += updateBtn_Click;
            // 
            // colEdit
            // 
            colEdit.HeaderText = "Edit";
            colEdit.MinimumWidth = 8;
            colEdit.Name = "colEdit";
            colEdit.ReadOnly = true;
            colEdit.Text = "Edit";
            colEdit.UseColumnTextForButtonValue = true;
            colEdit.Width = 150;
            // 
            // colDelete
            // 
            colDelete.HeaderText = "Delete";
            colDelete.MinimumWidth = 8;
            colDelete.Name = "colDelete";
            colDelete.ReadOnly = true;
            colDelete.Text = "Delete";
            colDelete.UseColumnTextForButtonValue = true;
            colDelete.Width = 150;
            // 
            // colId
            // 
            colId.DataPropertyName = "staffid";
            colId.HeaderText = "Id";
            colId.MinimumWidth = 8;
            colId.Name = "colId";
            colId.ReadOnly = true;
            colId.Width = 150;
            // 
            // colCode
            // 
            colCode.DataPropertyName = "staffcode";
            colCode.HeaderText = "Staff Code";
            colCode.MinimumWidth = 8;
            colCode.Name = "colCode";
            colCode.ReadOnly = true;
            colCode.Width = 150;
            // 
            // colName
            // 
            colName.DataPropertyName = "name";
            colName.HeaderText = "Staff Name";
            colName.MinimumWidth = 8;
            colName.Name = "colName";
            colName.ReadOnly = true;
            colName.Width = 150;
            // 
            // FrmStaff
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1249, 518);
            Controls.Add(updateBtn);
            Controls.Add(dgvData);
            Controls.Add(btnSave);
            Controls.Add(cboPosition);
            Controls.Add(label5);
            Controls.Add(txtPassword);
            Controls.Add(label3);
            Controls.Add(txtEmail);
            Controls.Add(label4);
            Controls.Add(txtName);
            Controls.Add(label2);
            Controls.Add(txtCode);
            Controls.Add(label1);
            Name = "FrmStaff";
            Text = "Form1";
            Load += FrmStaff_Load;
            ((System.ComponentModel.ISupportInitialize)dgvData).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtCode;
        private TextBox txtName;
        private Label label2;
        private TextBox txtPassword;
        private Label label3;
        private TextBox txtEmail;
        private Label label4;
        private Label label5;
        private ComboBox cboPosition;
        private Button btnSave;
        private DataGridView dgvData;
        private Button updateBtn;
        private DataGridViewButtonColumn colEdit;
        private DataGridViewButtonColumn colDelete;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colCode;
        private DataGridViewTextBoxColumn colName;
    }
}
