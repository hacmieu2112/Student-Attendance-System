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
    public partial class Home : Form
    {
        private int userId;
        private string fullname;
        public Home(int UserId,string fullname)
        {
            userId = UserId;
            this.fullname = fullname;
            InitializeComponent();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void Home_Load(object sender, EventArgs e)
        {
            label2.Text = fullname;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var manage = new Manager();
            manage.Show();
            this.Hide();
        }
    }
}
