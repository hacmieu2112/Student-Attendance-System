
namespace Admin
{
    partial class Manager
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
            this.btnAddStudent = new System.Windows.Forms.Button();
            this.btnAddTeacher = new System.Windows.Forms.Button();
            this.btnAddClass = new System.Windows.Forms.Button();
            this.btnAStudentTClass = new System.Windows.Forms.Button();
            this.btnATeacherTClass = new System.Windows.Forms.Button();
            this.btnAddSubject = new System.Windows.Forms.Button();
            this.btnASubjectTClass = new System.Windows.Forms.Button();
            this.btnAddRoom = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAddStudent
            // 
            this.btnAddStudent.Location = new System.Drawing.Point(25, 21);
            this.btnAddStudent.Name = "btnAddStudent";
            this.btnAddStudent.Size = new System.Drawing.Size(157, 23);
            this.btnAddStudent.TabIndex = 0;
            this.btnAddStudent.Text = "Add Student";
            this.btnAddStudent.UseVisualStyleBackColor = false;
            this.btnAddStudent.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnAddTeacher
            // 
            this.btnAddTeacher.Location = new System.Drawing.Point(25, 67);
            this.btnAddTeacher.Name = "btnAddTeacher";
            this.btnAddTeacher.Size = new System.Drawing.Size(157, 23);
            this.btnAddTeacher.TabIndex = 1;
            this.btnAddTeacher.Text = "Add Teacher";
            this.btnAddTeacher.UseVisualStyleBackColor = true;
            this.btnAddTeacher.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnAddClass
            // 
            this.btnAddClass.Location = new System.Drawing.Point(25, 119);
            this.btnAddClass.Name = "btnAddClass";
            this.btnAddClass.Size = new System.Drawing.Size(157, 23);
            this.btnAddClass.TabIndex = 2;
            this.btnAddClass.Text = "Add Class";
            this.btnAddClass.UseVisualStyleBackColor = true;
            this.btnAddClass.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnAStudentTClass
            // 
            this.btnAStudentTClass.Location = new System.Drawing.Point(232, 21);
            this.btnAStudentTClass.Name = "btnAStudentTClass";
            this.btnAStudentTClass.Size = new System.Drawing.Size(157, 23);
            this.btnAStudentTClass.TabIndex = 3;
            this.btnAStudentTClass.Text = "Add Student To Class";
            this.btnAStudentTClass.UseVisualStyleBackColor = true;
            this.btnAStudentTClass.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnATeacherTClass
            // 
            this.btnATeacherTClass.Location = new System.Drawing.Point(232, 67);
            this.btnATeacherTClass.Name = "btnATeacherTClass";
            this.btnATeacherTClass.Size = new System.Drawing.Size(157, 23);
            this.btnATeacherTClass.TabIndex = 4;
            this.btnATeacherTClass.Text = "Add Teacher To Class";
            this.btnATeacherTClass.UseVisualStyleBackColor = true;
            this.btnATeacherTClass.Click += new System.EventHandler(this.button5_Click);
            // 
            // btnAddSubject
            // 
            this.btnAddSubject.Location = new System.Drawing.Point(25, 173);
            this.btnAddSubject.Name = "btnAddSubject";
            this.btnAddSubject.Size = new System.Drawing.Size(157, 23);
            this.btnAddSubject.TabIndex = 5;
            this.btnAddSubject.Text = "Add Subject";
            this.btnAddSubject.UseVisualStyleBackColor = true;
            this.btnAddSubject.Click += new System.EventHandler(this.button6_Click);
            // 
            // btnASubjectTClass
            // 
            this.btnASubjectTClass.Location = new System.Drawing.Point(232, 119);
            this.btnASubjectTClass.Name = "btnASubjectTClass";
            this.btnASubjectTClass.Size = new System.Drawing.Size(157, 23);
            this.btnASubjectTClass.TabIndex = 6;
            this.btnASubjectTClass.Text = "Add Subject To Class";
            this.btnASubjectTClass.UseVisualStyleBackColor = true;
            this.btnASubjectTClass.Click += new System.EventHandler(this.button7_Click);
            // 
            // btnAddRoom
            // 
            this.btnAddRoom.Location = new System.Drawing.Point(232, 173);
            this.btnAddRoom.Name = "btnAddRoom";
            this.btnAddRoom.Size = new System.Drawing.Size(157, 23);
            this.btnAddRoom.TabIndex = 7;
            this.btnAddRoom.Text = "Add Room";
            this.btnAddRoom.UseVisualStyleBackColor = true;
            this.btnAddRoom.Click += new System.EventHandler(this.btnAddRoom_Click);
            // 
            // Manager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 228);
            this.Controls.Add(this.btnAddRoom);
            this.Controls.Add(this.btnASubjectTClass);
            this.Controls.Add(this.btnAddSubject);
            this.Controls.Add(this.btnATeacherTClass);
            this.Controls.Add(this.btnAStudentTClass);
            this.Controls.Add(this.btnAddClass);
            this.Controls.Add(this.btnAddTeacher);
            this.Controls.Add(this.btnAddStudent);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Manager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manager";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddStudent;
        private System.Windows.Forms.Button btnAddTeacher;
        private System.Windows.Forms.Button btnAddClass;
        private System.Windows.Forms.Button btnAStudentTClass;
        private System.Windows.Forms.Button btnATeacherTClass;
        private System.Windows.Forms.Button btnAddSubject;
        private System.Windows.Forms.Button btnASubjectTClass;
        private System.Windows.Forms.Button btnAddRoom;
    }
}