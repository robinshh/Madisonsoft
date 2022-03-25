using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab3
{
    public partial class HomeOverview : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void bttnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("Homepage.aspx");
        }

        protected void bttnMission_Click(object sender, EventArgs e)
        {
            Response.Redirect("MissionPage.aspx");
        }

        protected void bttnEvents_Click(object sender, EventArgs e)
        {
            Response.Redirect("Events.aspx");
        }

        protected void bttnAward_Click(object sender, EventArgs e)
        {
            Response.Redirect("AwardsHomePage.aspx");
        }

        protected void bttnDonations_Click(object sender, EventArgs e)
        {
            Response.Redirect("Donations.aspx");
        }

        protected void bttnContact_Click(object sender, EventArgs e)
        {
            Response.Redirect("ContactUs.aspx");
        }

        protected void btnMemberLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void btnStudentLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentLogin.aspx");
        }

        protected void btnAdminLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminLogin.aspx");
        }
    }
}