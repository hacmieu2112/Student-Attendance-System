using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Project;

namespace ProjectWinForm
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private DataTable Login(string username, string password)
        {
            string sql = "SELECT * FROM [User] WHERE username ='" + username + "' AND [password] ='" + password + "' AND type = 2";
            return Project.Database.GetDataBySQL(sql);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();

            DataTable loginResult = Login(username, password);
            if (loginResult.Rows.Count > 0)
            {
                int userId = loginResult.Rows[0].Field<int>("id");
                string fullname = loginResult.Rows[0].Field<string>("fullname");
                var newHome = new Home(userId, fullname);
                newHome.Show();
                this.Hide();
            }
            else
            {
                errorMessage.Text = "Login Failed!";
            }
        }

        private void txtLogin_Click(object sender, EventArgs e)
        {

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
