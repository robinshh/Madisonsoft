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
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] != null)
            {
                lblUserStatus.Text = Session["Username"].ToString();
        }
    }

        protected void studentInfo_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentHomePage.aspx");
        }

        protected void memberInfo_Click(object sender, EventArgs e)
        {
            Response.Redirect("MembersHomePage.aspx");
        }

        protected void companyInfo_Click(object sender, EventArgs e)
        {
            Response.Redirect("CompanyHomePage.aspx");
        }

        protected void scholarshipInfo_Click(object sender, EventArgs e)
        {
            Response.Redirect("ScholarshipHomePage.aspx");
        }

        protected void internshipInfo_Click(object sender, EventArgs e)
        {
            Response.Redirect("InternshipHomePage.aspx");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            //clears data for that user in memory 
            Response.Redirect("HomePage.aspx");
        }

        protected void jobInfo_Click(object sender, EventArgs e)
        {
            Response.Redirect("JobHomePage.aspx");
        }
    }
}