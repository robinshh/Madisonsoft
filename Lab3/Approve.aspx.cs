using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Drawing;
using System.Data;

namespace Lab3
{
    public partial class Approve : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAllow_Click(object sender, EventArgs e)
        {
            //Session["UN"] = ddlMemberUnapprovedList.SelectedItem.ToString();
            //Session["PS"] = ddlMemberUnapprovedList.SelectedValue.ToString();
            //lblU.Text = Session["UN"].ToString();
            //lblP.Text = Session["PS"].ToString();
            lblError.Text = "Member Access Granted!";
            String sqlQuery = "INSERT INTO MemberCredentials (Username,Pass) VALUES ('" + ddlMemberUnapprovedList.SelectedItem + "','" + ddlMemberUnapprovedList.SelectedValue + "')";


            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["AUTH"].ConnectionString);


            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnect;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlQuery;


            sqlConnect.Open();
            sqlCommand.ExecuteScalar();
            sqlConnect.Close();

        }

        protected void btnAllowS_Click(object sender, EventArgs e)
        {
            lblError.Text = "Student Access Granted!";
            String sqlQuery = "INSERT INTO StudentCredentials (Username,Pass) VALUES ('" + ddlStudentUnapprovedList.SelectedItem + "','" + ddlStudentUnapprovedList.SelectedValue + "')";


            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["AUTH"].ConnectionString);


            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnect;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlQuery;


            sqlConnect.Open();
            sqlCommand.ExecuteScalar();
            sqlConnect.Close();
        }
    }
}