using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProjectWinForm
{
    public partial class Attendance : Form
    {
        Form parent;
        int userId;
        public Attendance(Form parent, int userId)
        {
            this.parent = parent;
            this.userId = userId;
            InitializeComponent();
        }

        private DataTable getAllClassByTeacherId(int teacherId)
        {
            return Project.Database.GetDataBySQL($"SELECT b.id,b.name FROM TeacherNClass a join Class b on a.classId = b.id where a.teacherId = {teacherId}");
        }

        private void addSlot()
        {
            for (int i = 1; i < 7; i++)
            {
                comboBox3.Items.Add(i);
            }
        }


        private void setDate(DateTime date)
        {
            if (date == null)
            {
                date = DateTime.Today.Date;
            }
        }

        private DataTable getAllDateByTeacherIdAndClassId(int teacherId, int classId)
        {
            return Project.Database.GetDataBySQL($"SELECT distinct  [date] FROM attendance_report ar join [User] u on ar.studentId = u.id  where teacherId = {teacherId} and classesId = {classId}");
        }

        private void Attendance_Load(object sender, EventArgs e)
        {
            comboBox1.ValueMember = "id";
            comboBox1.DisplayMember = "name";
            comboBox1.DataSource = getAllClassByTeacherId(userId);

            comboBox2.DisplayMember = "date";
            comboBox2.ValueMember = "date";
            int classId = Convert.ToInt32(comboBox1.SelectedValue);
            DataTable dateByTeacher = getAllDateByTeacherIdAndClassId(userId, classId);
            if (!checkIfItHaveToday1())
            {
                dateByTeacher.Rows.Add(DateTime.Today.ToString("M/dd/yyyy"));
            }
            comboBox2.DataSource = dateByTeacher;
            addSlot();
            comboBox3.SelectedIndex = 0;
        }

        private int UpdateAttendance(int classId,int slot)
        {
            DataTable subjectIdData = Project.Database.GetDataBySQL($"SELECT subjectId FROM [User] u join StudentNClass snc on u.id = snc.studentId join classNSubject cns on snc.classId = cns.classId Where snc.classId = {classId} and cns.slot = {slot}");
            int subjectId;
            if (subjectIdData.Rows.Count != 0)
            {
                subjectId = Convert.ToInt32(subjectIdData.Rows[0]["subjectId"]);
            }
            else
            {
                subjectId = 1;
            }
            DataTable studentList = Project.Database.GetDataBySQL($@"SELECT u.id FROM [User] u join StudentNClass snc on u.id = snc.studentId 
                            join classNSubject cns on snc.classId = cns.classId WHERE snc.classId = {classId} and cns.subjectId = {subjectId}");
            if(studentList.Rows.Count == 0)
            {
                MessageBox.Show("There no student in this class");
            }
            String insertSql = "VALUES";
            foreach(DataRow row in studentList.Rows)
            {
               insertSql+=$"({row["id"]},{classId},{subjectId},1,{userId},0,{slot},CONVERT(DATE, GETDATE()),''),";
            }
            insertSql = insertSql.Remove(insertSql.Length - 1);
            string sql = @"INSERT INTO attendance_report(studentId,classesId,subjectId,roomId,teacherId,statusId,slot,date,comment) " + insertSql;
            return Project.Database.ExecuteSQL(sql);
        }

        private bool checkIfItHaveToday()
        {
            int classId = Convert.ToInt32(comboBox1.SelectedValue);
            DateTime date = Convert.ToDateTime(DateTime.Today.ToString("M/dd/yyyy"));
            int slot = Convert.ToInt32(comboBox3.SelectedIndex) + 1;
            DataTable numberOf  = Project.Database.GetDataBySQL($"SELECT count(id) as count FROM attendance_report WHERE [date] = CONVERT(DATE, GETDATE())  and classesId = {classId} and slot = {slot}");
            if(Convert.ToInt32(numberOf.Rows[0]["count"]) == 0)
            {
                return false;
            }
            return true;
        }

        private bool checkIfItHaveToday1()
        {
            int classId = Convert.ToInt32(comboBox1.SelectedValue);
            DataTable numberOf = Project.Database.GetDataBySQL($"SELECT count(id) as count FROM attendance_report WHERE [date] =CONVERT(DATE, GETDATE())  and classesId = {classId}");
            if (Convert.ToInt32(numberOf.Rows[0]["count"]) == 0)
            {
                return false;
            }
            return true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool haveToday = checkIfItHaveToday();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private DataTable getAttendance(int classId,int teacherId,int slot,DateTime date)
        {
            string sql = $"SELECT u.id,fullname,statusId FROM attendance_report ar join [User] u on ar.studentId = u.id  where teacherId = {teacherId} and classesId = {classId} and slot = {slot} and [date] = '{date.ToString("M/dd/yyyy")}'";
            return Project.Database.GetDataBySQL(sql);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool haveToday = checkIfItHaveToday();
            int classId = Convert.ToInt32(comboBox1.SelectedValue);
            DateTime date = Convert.ToDateTime(comboBox2.SelectedValue).Date;
            int slot = Convert.ToInt32(comboBox3.SelectedIndex) + 1;
            if (haveToday)
            {
                dataGridView1.DataSource = getAttendance(classId, userId, slot, date);
            }
            else
            {
              int result =  UpdateAttendance(classId, slot);
              dataGridView1.DataSource = getAttendance(classId, userId, slot,Convert.ToDateTime(DateTime.Today.ToString("M/dd/yyyy")));
            }
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private int updateAttendance(int studentId,string isAtttend)
        {
            int classId = Convert.ToInt32(comboBox1.SelectedValue);
            DateTime date = Convert.ToDateTime(comboBox2.SelectedValue).Date;
            int slot = Convert.ToInt32(comboBox3.SelectedIndex) + 1;
            string sql = $@"UPDATE attendance_report SET statusId = {isAtttend} WHERE studentId = {studentId} and classesId = {classId} and slot = {slot} and date = '{date.ToString("M/dd/yyyy")}'";
            return Project.Database.ExecuteSQL(sql);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++) { 
                string isAtttend = dataGridView1.Rows[i].Cells[2].Value.ToString();
                int studentId = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value);
                int result = updateAttendance(studentId, isAtttend);
                if (result > 0)
                {
                    MessageBox.Show("Update Success");
                }
                else
                {
                    MessageBox.Show("Update Failed");
                }
            }
            int classId = Convert.ToInt32(comboBox1.SelectedValue);
            DateTime date = Convert.ToDateTime(comboBox2.SelectedValue).Date;
            int slot = Convert.ToInt32(comboBox3.SelectedIndex) + 1;
            dataGridView1.DataSource = getAttendance(classId, userId, slot, date);
        }
    }
}
