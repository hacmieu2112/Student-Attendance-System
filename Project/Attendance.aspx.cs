using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project
{
    public partial class Attendance : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                btnLogout.Attributes["onClick"] = ClientScript.GetPostBackEventReference(this, "ClickDiv");
                if (!Page.IsPostBack)
                {
                    int type = ((User)Session["currentUser"]).Type;
                    int userId = ((User)Session["currentUser"]).Id;
                    if (type == 1)
                    {
                        DropDownList1.DataTextField = "name";
                        DropDownList1.DataValueField = "id";
                        DropDownList1.DataSource = getAllClassByUserId(userId);
                        DropDownList1.DataBind();

                        int classId = Convert.ToInt32(DropDownList1.SelectedValue);
                        setSubject(classId, userId);

                        int subjectId = Convert.ToInt32(DropDownList2.SelectedValue);

                        GridView1.DataSource = getAttendanceReport(userId, classId, subjectId);
                        GridView1.DataBind();
                    }
                    else
                    {
                        btn_Click();
                    }
                }
                else
                {
                    if (Request["__EVENTTARGET"] == "__Page" && Request["__EVENTARGUMENT"] == "ClickDiv")
                    {
                        btn_Click();
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("~/Login.aspx");
            }
        }

        protected void btn_Click()
        {
            Session.Clear();
            Response.Redirect("~/Login.aspx");
        }

        private void setSubject(int classId, int userId)
        {
            DropDownList2.DataTextField = "subject_name";
            DropDownList2.DataValueField = "id";
            DropDownList2.DataSource = getAllSubjectByClassAndUserId(classId, userId);
            DropDownList2.DataBind();
        }

        private static DataTable getAllSubjectByClassAndUserId(int classId, int userId)
        {
            try
            {
                return Database.GetDataBySQL($@"SELECT s.id,s.subject_name FROM StudentNClass snc 
                        left join Class c on snc.classId = c.id
                        left join classNSubject cns on c.id = cns.classId
                        left join[Subject] s on s.id = cns.subjectId
                        WHERE snc.studentId = {userId} and c.id = {classId}");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static DataTable getAttendanceReport(int userId, int classId, int subjectId)
        {
            try
            {
                string sql = $@"SELECT [date] as Date,slot,r.roomName,s.subject_name as Subject,ur.fullname as TeacherName, ats.status,comment  FROM attendance_report ar join [User] u on ar.studentId = u.id 
				join Room r on ar.roomId = r.id 
				join Subject s on ar.subjectId = s.id
				join [User] ur on ar.teacherId = ur.id 
				join attendance_status ats on ar.statusId = ats.id
				where studentId = {userId} and classesId = {classId}  and subjectId = {subjectId}";
                return Database.GetDataBySQL(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static DataTable getAllClassByUserId(int userId)
        {
            return Database.GetDataBySQL($"SELECT c.id,c.name FROM StudentNClass snc left join Class c on snc.classId = c.id WHERE snc.studentId = {userId}");
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int userId = ((User)Session["currentUser"]).Id;
            int classId = Convert.ToInt32(DropDownList1.SelectedValue);
            setSubject(classId, userId);
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int userId = ((User)Session["currentUser"]).Id;
            int classId = Convert.ToInt32(DropDownList1.SelectedValue);
            int subjectId = Convert.ToInt32(DropDownList2.SelectedValue);
            GridView1.DataSource = getAttendanceReport(userId, classId, subjectId);
            GridView1.DataBind();
        }
    }
}