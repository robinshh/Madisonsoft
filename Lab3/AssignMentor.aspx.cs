//Dana El-Zoobi and Madeleine Duley and Kit Harmon
//2/27/2022

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
    public partial class AssignMentor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnAssign_Click(object sender, EventArgs e)
        {
            
            lblStatus.Text = "Mentor Assigned! ";
            //String sqlQuery = "INSERT INTO Mentorship MemberID VALUES '" + ddlMemberList.SelectedValue + "' where StudentID = '" + ddlStudentList.SelectedValue + "'";
            String sqlQuery = "INSERT INTO Mentorship (StudentID,MemberID) VALUES ('" + ddlStudentList.SelectedValue + "','" + ddlMemberList.SelectedValue + "')";
            
            //define the connection to the database 
            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["LAB3"].ConnectionString);

            //create and structure the query command 
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnect;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlQuery;

            //execute the query and retrive the results 
            sqlConnect.Open();
            sqlCommand.ExecuteScalar();
            sqlConnect.Close();

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
           
            lblStatus.Text = "Saved! Leave the page and come back to see changes! ";
            String sqlQuery = "Update Mentorship SET MemberID = '" + ddlMemberList.SelectedValue + "'where StudentID = '" + ddlStudentList.SelectedValue + "'";
            //define the connection to the database 
            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["LAB3"].ConnectionString);

            //create and structure the query command 
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnect;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlQuery;

            //execute the query and retrive the results 
            sqlConnect.Open();
            sqlCommand.ExecuteScalar();
            sqlConnect.Close();

        }
    }
}