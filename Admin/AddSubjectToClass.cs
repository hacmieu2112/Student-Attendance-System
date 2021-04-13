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
    public partial class AddSubjectToClass : Form
    {
        public AddSubjectToClass()
        {
            InitializeComponent();
        }

        private void AddSubjectToClass_Load(object sender, EventArgs e)
        {
            cbClass.DisplayMember = "ClassName";
            cbClass.ValueMember = "ClassID";
            cbClass.DataSource = ClassList.GetAllClass();
            cbClass.SelectedIndex = 0;

            cbSlot.SelectedIndex = 0;

            cbSubject.DisplayMember = "SubjectName";
            cbSubject.ValueMember = "SubjectID";
            cbSubject.DataSource = SubjectList.GetAllSubject();
            cbSubject.SelectedIndex = 0;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Manager frm1 = new Manager();
            this.Hide();
            frm1.ShowDialog();
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            int classid = Convert.ToInt32(cbClass.SelectedValue);
            int slot = Convert.ToInt32(cbSlot.SelectedItem);
            int subjectid = Convert.ToInt32(cbSubject.SelectedValue);
            string sql = @"INSERT dbo.classNSubject
                                ( classId, slot, subjectId )
                            VALUES  ( " + classid + @", -- classId - int
                                    " + slot + @", -- slot - int
                                    " + subjectid + @"  -- subjectId - int
          )";
            if (Project.Database.GetDataBySQL("SELECT * FROM dbo.[classNSubject] WHERE classId = " + classid + " AND slot = " + slot).Rows.Count == 0)
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
