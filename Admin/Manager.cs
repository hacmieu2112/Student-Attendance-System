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
    public partial class Manager : Form
    {
        public Manager()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddStudent frm1 = new AddStudent();
            this.Hide();
            frm1.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddTeacher frm2 = new AddTeacher();
            this.Hide();
            frm2.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddClass frm3 = new AddClass();
            this.Hide();
            frm3.ShowDialog();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AddSubject frm6 = new AddSubject();
            this.Hide();
            frm6.ShowDialog();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddStudentToClass frm4 = new AddStudentToClass();
            this.Hide();
            frm4.ShowDialog();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AddTeacherToClass frm5 = new AddTeacherToClass();
            this.Hide();
            frm5.ShowDialog();
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            AddSubjectToClass frm7 = new AddSubjectToClass();
            this.Hide();
            frm7.ShowDialog();
            this.Close();
        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            AddRoom frm8 = new AddRoom();
            this.Hide();
            frm8.ShowDialog();
            this.Close();
        }
    }
}
