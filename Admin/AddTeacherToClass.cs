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
    public partial class AddTeacherToClass : Form
    {
        public AddTeacherToClass()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            int teacherid = Convert.ToInt32(cbTeacher.SelectedValue);
            int classid = Convert.ToInt32(cbClass.SelectedValue);
            string sql = @"INSERT dbo.TeacherNClass
                                ( teacherId, classId )
                        VALUES  ( "+teacherid+@", -- teacherId - int
                                    "+classid+@"  -- classId - int
                                    )";
            if (Project.Database.GetDataBySQL("SELECT * FROM dbo.[TeacherNClass] WHERE teacherId = " + teacherid + " AND classId = " + classid).Rows.Count == 0)
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Manager frm1 = new Manager();
            this.Hide();
            frm1.ShowDialog();
            this.Close();
        }

        private void AddTeacherToClass_Load(object sender, EventArgs e)
        {
            cbClass.DisplayMember = "ClassName";
            cbClass.ValueMember = "ClassID";
            cbClass.DataSource = ClassList.GetAllClass();
            cbClass.SelectedIndex = 0;

            cbTeacher.DisplayMember = "TeacherName";
            cbTeacher.ValueMember = "TeacherID";
            cbTeacher.DataSource = TeacherList.GetAllTeacher();
            cbTeacher.SelectedIndex = 0;
        }
    }
}
