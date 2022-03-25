//Dana Elzoobi and Madeleine Duley and Kit Harmon
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
    public partial class AddJob : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

            String sqlQuery = "SELECT Title,JobID FROM JOBOPPORTUNITY";


            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);


            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnect;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlQuery;


            sqlConnect.Open();
            SqlDataReader queryResults = sqlCommand.ExecuteReader();


            while (queryResults.Read())
            {
                lstJobs.Items.Add(
                    new ListItem(
                        queryResults["Title"].ToString(),
                        queryResults["JobID"].ToString()));

            }
            sqlConnect.Close();
            queryResults.Close();

        }

        protected void btnAddJob_Click(object sender, EventArgs e)
        {
            Boolean x = dup();
            if (x == true)
            {

                lblError.Text = "Duplicate Entry";
            }
            if (x == false)

            {

                lblError.Text = "Job Added!";
            String sqlQuery = "INSERT INTO JobOpportunity (Title,Location) " +
                    "VALUES (@Title, @Location)";


            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["LAB3"].ConnectionString);


            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnect;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlQuery;
                sqlCommand.Parameters.AddWithValue("@Title", txtTitle.Text);
                sqlCommand.Parameters.AddWithValue("@Location", txtLocation.Text);


                sqlConnect.Open();
            sqlCommand.ExecuteScalar();
            sqlConnect.Close();


            lstJobs.Items.Clear();
            updateFromDB();


            txtTitle.Text = "";
            txtLocation.Text = "";

        }  
        }

        protected void btnPopulate_Click(object sender, EventArgs e)
        {
            txtTitle.Text = "sample title";
            txtLocation.Text = "alaska";
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtTitle.Text = "";
            txtLocation.Text = "";
        }

        protected void updateFromDB()
        {

            String sqlQuery = "SELECT Title,JobID FROM JOBOPPORTUNITY";


            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);


            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnect;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlQuery;


            sqlConnect.Open();
            SqlDataReader queryResults = sqlCommand.ExecuteReader();


            while (queryResults.Read())
            {
                lstJobs.Items.Add(
                    new ListItem(
                        queryResults["Title"].ToString(),
                        queryResults["JobID"].ToString()));

            }
            sqlConnect.Close();
            queryResults.Close();
        }
        protected Boolean dup()
        {
            String count = "";
            string sqlQuery = "SELECT COUNT(Title) AS Name FROM JobOpportunity WHERE Title = @Title";
            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["LAB3"].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnect;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlQuery;
            sqlCommand.Parameters.AddWithValue("@Title", txtTitle.Text);
            sqlConnect.Open();
            SqlDataReader queryResults = sqlCommand.ExecuteReader();

            while (queryResults.Read())
            {
                count = queryResults["Name"].ToString();

            }
            if (count == "1")
            {
                return true;
            }
            else
            {
                return false;
            }
            sqlConnect.Close();
            queryResults.Close();
        }
    }
}