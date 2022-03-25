//Dana El-Zoobi and Madeleine Duley and Kit Harmon
//    2/27/2022


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
    public partial class JobHomePage : System.Web.UI.Page
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

        //protected void btnAddJob_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("AddJob.aspx");
        //}

       

        

       

        protected void btnLoadJobData_Click(object sender, EventArgs e)
        {
            string sqlQuery = "Select Title, Location ";
            sqlQuery += "from JobOpportunity ";
            sqlQuery += "where JobOpportunity.JobID = " + ddlJobList.SelectedValue;

            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
            SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlQuery, sqlConnect);

            DataTable dtForGridView = new DataTable();
            sqlAdapter.Fill(dtForGridView);


            grdJobResults.DataSource = dtForGridView;
            grdJobResults.DataBind();
        }

        protected void btnShowAll_Click(object sender, EventArgs e)
        {
            string sqlQuery = "Select Title, Location ";
            sqlQuery += "from JobOpportunity ";
            //sqlQuery += "where JobOpportunity.JobID = " + ddlJobList.SelectedValue;

            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
            SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlQuery, sqlConnect);

            DataTable dtForGridView = new DataTable();
            sqlAdapter.Fill(dtForGridView);


            grdJobResults.DataSource = dtForGridView;
            grdJobResults.DataBind();
        }

        //protected void btnAddJob_Click1(object sender, EventArgs e)
        //{
            
        //}

        protected void btnjob_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddJob.aspx");
        }

        protected void btnAward_Click(object sender, EventArgs e)
        {
            Response.Redirect("AwardJob.aspx");
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string sqlQuery = "UPDATE JobOpportunity SET Title=@Title, Location=@Location WHERE JobID= " + lstJobs.SelectedValue;

            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);


            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnect;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlQuery;
            sqlCommand.Parameters.AddWithValue("@Title", txtTitle.Text);
            sqlCommand.Parameters.AddWithValue("@Location", txtLocation.Text);


            sqlConnect.Open();
            //SqlDataReader queryResults = sqlCommand.ExecuteReader();
            sqlCommand.ExecuteScalar();
            sqlConnect.Close();
        }

        protected void lstJobs_SelectedIndexChanged(object sender, EventArgs e)
        {
            String sqlQuery = "SELECT Title, Location from JobOpportunity WHERE JobID = " + lstJobs.SelectedValue;

            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);


            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnect;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlQuery;


            sqlConnect.Open();
            SqlDataReader queryResults = sqlCommand.ExecuteReader();


            while (queryResults.Read())
            {
                txtTitle.Text = queryResults["Title"].ToString();
                txtLocation.Text = queryResults["Location"].ToString();


            }
            sqlConnect.Close();
        }
    }
}