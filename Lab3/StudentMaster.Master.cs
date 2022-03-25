//Dana El-Zoobi and Madeleine Duley and Kit Harmon
//    2/27/2022


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab2
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] != null)
            {
                lblUserStatus2.Text = Session["Username"].ToString();
            }
        }

        protected void Logoutbtn_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("HomePage.aspx");
        }

        protected void userInfobtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentInfo.aspx");
        }

        protected void internApplybtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("InternshipsApplyKit.aspx");
        }

        protected void jobApplybtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("JobsApply.aspx");
        }

        protected void scholarApplybtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("ScholarshipsApply.aspx");
        }
    }
}