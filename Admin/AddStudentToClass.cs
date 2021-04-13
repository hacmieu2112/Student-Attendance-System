using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Admin.Logic;

namespace Admin
{
    public partial class AddStudentToClass : Form
    {
        public AddStudentToClass()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Manager frm1 = new Manager();
            this.Hide();
            frm1.ShowDialog();
            this.Close();
        }

        private void AddStudentToClass_Load(object sender, EventArgs e)
        {
            cbClass.DisplayMember = "ClassName";
            cbClass.ValueMember = "ClassID";
            cbClass.DataSource = ClassList.GetAllClass();
            cbClass.SelectedIndex = 0;

            cbStudent.DisplayMember = "StudentName";
            cbStudent.ValueMember = "StudentID";
            cbStudent.DataSource = StudentList.GetAllStudent();
            cbStudent.SelectedIndex = 0;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            int studentid = Convert.ToInt32(cbStudent.SelectedValue);
            int classid = Convert.ToInt32(cbClass.SelectedValue);
            string sql = @"INSERT dbo.StudentNClass
                                ( studentId, classId )
                            VALUES  ( "+studentid+@", -- studentId - int
                                        "+classid+@"  -- classId - int
                                    )";
            if (Project.Database.GetDataBySQL("SELECT * FROM dbo.[StudentNClass] WHERE studentId = " + studentid).Rows.Count == 0)
            {
                if (Project.Database.ExecuteSQL(sql) > 0)
                {
                    MessageBox.Show("Create successfully");
                }
                else
                {
                    MessageBox.Show("Create fail");
                }
            }
            else
            {
                MessageBox.Show("Create fail");
            }
        }
    }
}
