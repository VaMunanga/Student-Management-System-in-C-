using System.Windows.Forms;

namespace STUDENT_MANAGEMENT
{
    partial class Form1 : Form
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
            btnImport = new Button();
            label1 = new Label();
            txtStudentID = new TextBox();
            dgvStudents = new DataGridView();
            cmbCourse = new ComboBox();
            txtFullName = new TextBox();
            label2 = new Label();
            label3 = new Label();
            dtpEnrollmentDate = new DateTimePicker();
            label4 = new Label();
            btnDelete = new Button();
            btnExport = new Button();
            btnInsert = new Button();
            btnUpdate = new Button();
            lstLogs = new ListBox();
            ((System.ComponentModel.ISupportInitialize)dgvStudents).BeginInit();
            SuspendLayout();
            // 
            // btnImport
            // 
            btnImport.Location = new Point(474, 305);
            btnImport.Name = "btnImport";
            btnImport.Size = new Size(101, 47);
            btnImport.TabIndex = 0;
            btnImport.Text = "Import";
            btnImport.UseVisualStyleBackColor = true;
            btnImport.Click += btnImport_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(474, 28);
            label1.Name = "label1";
            label1.Size = new Size(75, 20);
            label1.TabIndex = 1;
            label1.Text = "StudentID";
            label1.Click += label1_Click;
            // 
            // txtStudentID
            // 
            txtStudentID.Location = new Point(597, 28);
            txtStudentID.Name = "txtStudentID";
            txtStudentID.ReadOnly = true;
            txtStudentID.Size = new Size(185, 27);
            txtStudentID.TabIndex = 2;
            // 
            // dgvStudents
            // 
            dgvStudents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStudents.Location = new Point(12, 12);
            dgvStudents.Name = "dgvStudents";
            dgvStudents.RowHeadersWidth = 51;
            dgvStudents.Size = new Size(456, 409);
            dgvStudents.TabIndex = 3;
            dgvStudents.CellClick += dgvStudents_CellClick;
            // 
            // cmbCourse
            // 
            cmbCourse.FormattingEnabled = true;
            cmbCourse.Items.AddRange(new object[] { "\"Computer Science\"", "\"Software Engineering\"", "\"Cyber Security\"" });
            cmbCourse.Location = new Point(597, 143);
            cmbCourse.Name = "cmbCourse";
            cmbCourse.Size = new Size(185, 28);
            cmbCourse.TabIndex = 4;
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(597, 86);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(185, 27);
            txtFullName.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(474, 86);
            label2.Name = "label2";
            label2.Size = new Size(76, 20);
            label2.TabIndex = 6;
            label2.Text = "Full Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(473, 140);
            label3.Name = "label3";
            label3.Size = new Size(54, 20);
            label3.TabIndex = 7;
            label3.Text = "Course";
            // 
            // dtpEnrollmentDate
            // 
            dtpEnrollmentDate.Location = new Point(597, 191);
            dtpEnrollmentDate.Name = "dtpEnrollmentDate";
            dtpEnrollmentDate.Size = new Size(185, 27);
            dtpEnrollmentDate.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(474, 196);
            label4.Name = "label4";
            label4.Size = new Size(117, 20);
            label4.TabIndex = 9;
            label4.Text = "Enrollment Date";
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(474, 382);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(224, 39);
            btnDelete.TabIndex = 10;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnExport
            // 
            btnExport.Location = new Point(597, 305);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(101, 47);
            btnExport.TabIndex = 11;
            btnExport.Text = "Export";
            btnExport.UseVisualStyleBackColor = true;
            btnExport.Click += btnExport_Click;
            // 
            // btnInsert
            // 
            btnInsert.Location = new Point(474, 237);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(101, 47);
            btnInsert.TabIndex = 12;
            btnInsert.Text = "Insert";
            btnInsert.UseVisualStyleBackColor = true;
            btnInsert.Click += btnInsert_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(597, 237);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(101, 47);
            btnUpdate.TabIndex = 13;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // lstLogs
            // 
            lstLogs.FormattingEnabled = true;
            lstLogs.Location = new Point(704, 237);
            lstLogs.Name = "lstLogs";
            lstLogs.Size = new Size(136, 184);
            lstLogs.TabIndex = 14;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(848, 439);
            Controls.Add(lstLogs);
            Controls.Add(btnUpdate);
            Controls.Add(btnInsert);
            Controls.Add(btnExport);
            Controls.Add(btnDelete);
            Controls.Add(label4);
            Controls.Add(dtpEnrollmentDate);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtFullName);
            Controls.Add(cmbCourse);
            Controls.Add(dgvStudents);
            Controls.Add(txtStudentID);
            Controls.Add(label1);
            Controls.Add(btnImport);
            Name = "Form1";
            Text = "Student Manager";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgvStudents).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnImport;
        private Label label1;
        private TextBox txtStudentID;
        private DataGridView dgvStudents;
        private ComboBox cmbCourse;
        private TextBox txtFullName;
        private Label label2;
        private Label label3;
        private DateTimePicker dtpEnrollmentDate;
        private Label label4;
        private Button btnDelete;
        private Button btnExport;
        private Button btnInsert;
        private Button btnUpdate;
        private ListBox lstLogs;
    }
}
