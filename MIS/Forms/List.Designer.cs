namespace MIS.Forms
{
    partial class frmList
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvStudent = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnNameSearch = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnNoSearch = new System.Windows.Forms.Button();
            this.txtNo = new System.Windows.Forms.TextBox();
            this.btnResetNo = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cbClass = new System.Windows.Forms.ComboBox();
            this.btnClassSearch = new System.Windows.Forms.Button();
            this.StudentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ParentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ParentMobile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Note = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsExtractFeature = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClassName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.StudentDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudent)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvStudent);
            this.groupBox2.Location = new System.Drawing.Point(12, 121);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(984, 606);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "学生列表";
            // 
            // dgvStudent
            // 
            this.dgvStudent.AllowUserToAddRows = false;
            this.dgvStudent.AllowUserToDeleteRows = false;
            this.dgvStudent.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvStudent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStudent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StudentID,
            this.StudentName,
            this.Gender,
            this.StudentNo,
            this.ParentName,
            this.ParentMobile,
            this.Note,
            this.IsExtractFeature,
            this.ClassName,
            this.StudentEdit,
            this.StudentDelete});
            this.dgvStudent.Location = new System.Drawing.Point(6, 19);
            this.dgvStudent.Name = "dgvStudent";
            this.dgvStudent.ReadOnly = true;
            this.dgvStudent.Size = new System.Drawing.Size(972, 581);
            this.dgvStudent.TabIndex = 0;
            this.dgvStudent.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStudent_CellClick);
            this.dgvStudent.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvStudent_CellFormatting);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnNameSearch);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Location = new System.Drawing.Point(12, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(313, 58);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "按姓名检索";
            // 
            // btnNameSearch
            // 
            this.btnNameSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNameSearch.Location = new System.Drawing.Point(223, 20);
            this.btnNameSearch.Name = "btnNameSearch";
            this.btnNameSearch.Size = new System.Drawing.Size(75, 23);
            this.btnNameSearch.TabIndex = 3;
            this.btnNameSearch.Text = "检索";
            this.btnNameSearch.UseVisualStyleBackColor = true;
            this.btnNameSearch.Click += new System.EventHandler(this.btnNameSearch_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(17, 22);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(200, 20);
            this.txtName.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnNoSearch);
            this.groupBox3.Controls.Add(this.txtNo);
            this.groupBox3.Location = new System.Drawing.Point(348, 22);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(314, 58);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "按学号检索";
            // 
            // btnNoSearch
            // 
            this.btnNoSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNoSearch.Location = new System.Drawing.Point(223, 20);
            this.btnNoSearch.Name = "btnNoSearch";
            this.btnNoSearch.Size = new System.Drawing.Size(75, 23);
            this.btnNoSearch.TabIndex = 3;
            this.btnNoSearch.Text = "检索";
            this.btnNoSearch.UseVisualStyleBackColor = true;
            this.btnNoSearch.Click += new System.EventHandler(this.btnNoSearch_Click);
            // 
            // txtNo
            // 
            this.txtNo.Location = new System.Drawing.Point(17, 22);
            this.txtNo.Name = "txtNo";
            this.txtNo.Size = new System.Drawing.Size(200, 20);
            this.txtNo.TabIndex = 0;
            // 
            // btnResetNo
            // 
            this.btnResetNo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnResetNo.Location = new System.Drawing.Point(921, 92);
            this.btnResetNo.Name = "btnResetNo";
            this.btnResetNo.Size = new System.Drawing.Size(75, 23);
            this.btnResetNo.TabIndex = 4;
            this.btnResetNo.Text = "清除";
            this.btnResetNo.UseVisualStyleBackColor = true;
            this.btnResetNo.Click += new System.EventHandler(this.btnResetNo_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cbClass);
            this.groupBox4.Controls.Add(this.btnClassSearch);
            this.groupBox4.Location = new System.Drawing.Point(682, 22);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(314, 58);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "按班级检索";
            // 
            // cbClass
            // 
            this.cbClass.FormattingEnabled = true;
            this.cbClass.Location = new System.Drawing.Point(15, 22);
            this.cbClass.Name = "cbClass";
            this.cbClass.Size = new System.Drawing.Size(200, 21);
            this.cbClass.TabIndex = 4;
            // 
            // btnClassSearch
            // 
            this.btnClassSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClassSearch.Location = new System.Drawing.Point(223, 20);
            this.btnClassSearch.Name = "btnClassSearch";
            this.btnClassSearch.Size = new System.Drawing.Size(75, 23);
            this.btnClassSearch.TabIndex = 3;
            this.btnClassSearch.Text = "检索";
            this.btnClassSearch.UseVisualStyleBackColor = true;
            this.btnClassSearch.Click += new System.EventHandler(this.btnClassSearch_Click);
            // 
            // StudentID
            // 
            this.StudentID.DataPropertyName = "ID";
            this.StudentID.HeaderText = "编号";
            this.StudentID.Name = "StudentID";
            this.StudentID.ReadOnly = true;
            this.StudentID.Visible = false;
            // 
            // StudentName
            // 
            this.StudentName.DataPropertyName = "Name";
            this.StudentName.HeaderText = "姓名";
            this.StudentName.Name = "StudentName";
            this.StudentName.ReadOnly = true;
            this.StudentName.Width = 90;
            // 
            // Gender
            // 
            this.Gender.DataPropertyName = "Gender";
            this.Gender.HeaderText = "性别";
            this.Gender.Name = "Gender";
            this.Gender.ReadOnly = true;
            this.Gender.Width = 90;
            // 
            // StudentNo
            // 
            this.StudentNo.DataPropertyName = "StudentNo";
            this.StudentNo.HeaderText = "学号";
            this.StudentNo.Name = "StudentNo";
            this.StudentNo.ReadOnly = true;
            this.StudentNo.Width = 90;
            // 
            // ParentName
            // 
            this.ParentName.DataPropertyName = "ParentName";
            this.ParentName.HeaderText = "监护人姓名";
            this.ParentName.Name = "ParentName";
            this.ParentName.ReadOnly = true;
            this.ParentName.Width = 90;
            // 
            // ParentMobile
            // 
            this.ParentMobile.DataPropertyName = "ParentMobile";
            this.ParentMobile.HeaderText = "监护人手机";
            this.ParentMobile.Name = "ParentMobile";
            this.ParentMobile.ReadOnly = true;
            this.ParentMobile.Width = 90;
            // 
            // Note
            // 
            this.Note.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Note.DataPropertyName = "Note";
            this.Note.HeaderText = "备注";
            this.Note.Name = "Note";
            this.Note.ReadOnly = true;
            // 
            // IsExtractFeature
            // 
            this.IsExtractFeature.DataPropertyName = "IsExtractFeature";
            this.IsExtractFeature.HeaderText = "已提取特征";
            this.IsExtractFeature.Name = "IsExtractFeature";
            this.IsExtractFeature.ReadOnly = true;
            this.IsExtractFeature.Width = 90;
            // 
            // ClassName
            // 
            this.ClassName.DataPropertyName = "ClassName";
            this.ClassName.HeaderText = "班级";
            this.ClassName.Name = "ClassName";
            this.ClassName.ReadOnly = true;
            // 
            // StudentEdit
            // 
            this.StudentEdit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.StudentEdit.HeaderText = "编辑";
            this.StudentEdit.Name = "StudentEdit";
            this.StudentEdit.ReadOnly = true;
            this.StudentEdit.Text = "编辑";
            this.StudentEdit.UseColumnTextForButtonValue = true;
            this.StudentEdit.Width = 50;
            // 
            // StudentDelete
            // 
            this.StudentDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.StudentDelete.HeaderText = "删除";
            this.StudentDelete.Name = "StudentDelete";
            this.StudentDelete.ReadOnly = true;
            this.StudentDelete.Text = "删除";
            this.StudentDelete.UseColumnTextForButtonValue = true;
            this.StudentDelete.Width = 50;
            // 
            // frmList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.btnResetNo);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "管理学生";
            this.Load += new System.EventHandler(this.frmList_Load);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudent)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvStudent;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnNameSearch;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnNoSearch;
        private System.Windows.Forms.TextBox txtNo;
        private System.Windows.Forms.Button btnResetNo;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnClassSearch;
        private System.Windows.Forms.ComboBox cbClass;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gender;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ParentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ParentMobile;
        private System.Windows.Forms.DataGridViewTextBoxColumn Note;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsExtractFeature;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClassName;
        private System.Windows.Forms.DataGridViewButtonColumn StudentEdit;
        private System.Windows.Forms.DataGridViewButtonColumn StudentDelete;
    }
}