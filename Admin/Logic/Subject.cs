using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Admin.Logic
{
    class Subject
    {
        public int SubjectID { get; set; }
        public string SubjectName { get; set; }

        public Subject(int subjectID, string subjectName)
        {
            SubjectID = subjectID;
            SubjectName = subjectName;
        }
    }
    class SubjectList
    {
        public static List<Subject> GetAllSubject()
        {
            List<Subject> cats = new List<Subject>();
            DataTable dt = Project.Database.GetDataBySQL("SELECT * FROM dbo.[Subject]");
            foreach (DataRow dr in dt.Rows)
                cats.Add(new Subject(
                    Convert.ToInt32(dr["id"]),
                    dr["subject_name"].ToString()
                    ));
            return cats;
        }
    }
}
