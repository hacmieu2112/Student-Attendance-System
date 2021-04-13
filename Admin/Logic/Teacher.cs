using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Admin.Logic
{
    class Teacher
    {
        public int TeacherID { get; set; }
        public string TeacherName { get; set; }

        public Teacher(int teacherID, string teacherName)
        {
            TeacherID = teacherID;
            TeacherName = teacherName;
        }
    }

    class TeacherList
    {
        public static List<Teacher> GetAllTeacher()
        {
            List<Teacher> cats = new List<Teacher>();
            DataTable dt = Project.Database.GetDataBySQL("SELECT * FROM dbo.[User] WHERE type = 2");
            foreach (DataRow dr in dt.Rows)
                cats.Add(new Teacher(
                    Convert.ToInt32(dr["id"]),
                    dr["fullname"].ToString()
                    ));
            return cats;
        }
    }
}
