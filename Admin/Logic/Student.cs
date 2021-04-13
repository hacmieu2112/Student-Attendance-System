using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Admin.Logic
{
    class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }

        public Student(int studentID, string studentName)
        {
            StudentID = studentID;
            StudentName = studentName;
        }
    }

    class StudentList
    {
        public static List<Student> GetAllStudent()
        {
            List<Student> cats = new List<Student>();
            DataTable dt = Project.Database.GetDataBySQL("SELECT * FROM dbo.[User] WHERE type = 1");
            foreach (DataRow dr in dt.Rows)
                cats.Add(new Student(
                    Convert.ToInt32(dr["id"]),
                    dr["fullname"].ToString()
                    ));
            return cats;
        }
    }
}
