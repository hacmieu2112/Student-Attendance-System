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
    public partial class AddStudent : Form
    {
        public AddStudent()
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            string sql = @"INSERT dbo.[User]
                                    (username, password, fullname, type)
                            VALUES('" + tbUser.Text.Trim() + @"', --username - varchar(100)
                            '" + tbPass.Text.Trim() + @"', --password - varchar(100)
                            N'" + tbFullname.Text.Trim() + @"', --fullname - nvarchar(100)
                            1-- type - int
                            )";
            if (Project.Database.GetDataBySQL("SELECT * FROM dbo.[User] WHERE username = '" + tbUser.Text.Trim() + "'").Rows.Count == 0)
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
