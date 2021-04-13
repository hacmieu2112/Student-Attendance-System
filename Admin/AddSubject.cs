using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Admin
{
    public partial class AddSubject : Form
    {
        public AddSubject()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string sql = @"INSERT dbo.Subject
                                ( subject_name )
                            VALUES  ( '" + tbName.Text.Trim() + @"'  -- subject_name - varchar(100)
                            )";
            if (Project.Database.GetDataBySQL("SELECT * FROM dbo.[Subject] WHERE subject_name = '" + tbName.Text.Trim() + "'").Rows.Count == 0)
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
    }
}
