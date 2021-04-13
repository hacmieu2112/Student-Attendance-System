using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Project;

namespace Admin.Logic
{
    class Class
    {
        public int ClassID { get; set; }
        public string ClassName { get; set; }

        public Class()
        {
        }

        public Class(int classID, string className)
        {
            ClassID = classID;
            ClassName = className;
        }
    }
    class ClassList
    {
        public static List<Class> GetAllClass()
        {
            List<Class> cats = new List<Class>();
            DataTable dt = Project.Database.GetDataBySQL("SELECT * FROM dbo.[Class]");
            foreach (DataRow dr in dt.Rows)
                cats.Add(new Class(
                    Convert.ToInt32(dr["id"]),
                    dr["name"].ToString()
                    ));
            return cats;
        }
    }
}
