using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project
{
    public partial class WebForm1 : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
              
            }
        }


        private DataTable login(string username,string password)
        {
            string sql = "SELECT * FROM [User] WHERE username ='" + username + "' AND [password] ='" + password + "' AND type = 1";
           return Database.GetDataBySQL(sql);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            DataTable loginResult = login(username, password);
            if (loginResult.Rows.Count > 0)
            {
                var id = loginResult.Rows[0].Field<int>("id");
                var userName = loginResult.Rows[0].Field<string>("username");
                var fullName = loginResult.Rows[0].Field<string>("fullname");
                var type = loginResult.Rows[0].Field<int>("type");
                User currentUser = new User(id,userName, fullName,type);
                Session["currentUser"] = currentUser;

                Response.Redirect("~/Home.aspx");
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }

        }
    }
}