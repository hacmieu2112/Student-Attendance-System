using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                btnLogout.Attributes["onClick"] = ClientScript.GetPostBackEventReference(this, "ClickDiv"); 
                if (!Page.IsPostBack)
                {
                    Label1.Text = ((User)Session["currentUser"]).FullName;

                }
                else
                {
                    if (Request["__EVENTTARGET"] == "__Page" &&
                       Request["__EVENTARGUMENT"] == "ClickDiv")
                    {
                        btn_Click();
                    }
                }
            }catch(Exception ex)
            {
                Response.Redirect("~/Login.aspx");
            }
        }
        protected  void btn_Click()
        {
            Session.Clear();
            Response.Redirect("~/Login.aspx");
        }

    }
}