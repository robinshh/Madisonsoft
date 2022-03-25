
//Date: 2 / 27 / 2022
//Name: Madeleine Duley and Dana El-Zoobi and Kit Harmon
//File Purpose: This file is the code behind for the members home page


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace Lab2
{
    public partial class MembersHomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

//else
//            {
//                //Session["InvalidUse"] = 
//                Response.Redirect("Login.aspx");
//            }
        }

       

        protected void btnAddMember_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddMember.aspx");
        }

       
       

        protected void btnLoadMemberData_Click(object sender, EventArgs e)
        {
            string sqlQuery = "Select FirstName + ' ' + LastName as MemberName, Email, Phone, GradYear, JobTitle ";
            sqlQuery += "from Members ";
            sqlQuery += "where Members.MemberID = " + ddlMemberList.SelectedValue;

            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
            SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlQuery, sqlConnect);

            DataTable dtForGridView = new DataTable();
            sqlAdapter.Fill(dtForGridView);


            grdMemberResults.DataSource = dtForGridView;
            grdMemberResults.DataBind();
        }

        protected void btnShowAll_Click(object sender, EventArgs e)
        {
            string sqlQuery = "Select FirstName + ' ' + LastName as MemberName, Email, Phone, GradYear, JobTitle ";
            sqlQuery += "from Members ";
            //sqlQuery += "where Members.MemberID = " + ddlMemberList.SelectedValue;

            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
            SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlQuery, sqlConnect);

            DataTable dtForGridView = new DataTable();
            sqlAdapter.Fill(dtForGridView);


            grdMemberResults.DataSource = dtForGridView;
            grdMemberResults.DataBind();
        }

        protected void lstEdit_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditMembers.aspx");
        }
    }
}