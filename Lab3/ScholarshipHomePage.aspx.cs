
//Date: 2 / 27 / 2022
//Name: Madeleine Duley and Dana El-Zoobi and Kit Harmon
//File Purpose: This file is the code behind for the scholarships home page


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
    public partial class ScholarshipHomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String sqlQuery = "SELECT ScholarshipName,ScholarshipID FROM SCHOLARSHIPS";

            //define the connection to the DB:
            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            //create and structure the query command 
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnect;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlQuery;

            //execute the query and retrieve the results 
            sqlConnect.Open();
            SqlDataReader queryResults = sqlCommand.ExecuteReader();

            //read the results and populate the listbox 
            while (queryResults.Read())
            {
                lstScholarship.Items.Add(
                    new ListItem(
                        queryResults["ScholarshipName"].ToString(),
                        queryResults["ScholarshipID"].ToString()));

            }
            sqlConnect.Close();
            queryResults.Close();
        }

        protected void btnAddScholarship_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddScholarship.aspx");
        }

        protected void btnCommit_Click(object sender, EventArgs e)
        {

        }

        protected void btnLoadScholarshipData_Click(object sender, EventArgs e)
        {
            string sqlQuery = "Select ScholarshipName, ScholarshipYear, ScholarshipAmount ";
            sqlQuery += "from Scholarships ";
            sqlQuery += "where Scholarships.ScholarshipID = " + ddlScholarshipList.SelectedValue;

            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
            SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlQuery, sqlConnect);

            DataTable dtForGridView = new DataTable();
            sqlAdapter.Fill(dtForGridView);


            grdScholarshipResults.DataSource = dtForGridView;
            grdScholarshipResults.DataBind();
        }

        protected void btnShowAll_Click(object sender, EventArgs e)
        {
            string sqlQuery = "Select ScholarshipName, ScholarshipYear, ScholarshipAmount ";
            sqlQuery += "from Scholarships ";
            //sqlQuery += "where Scholarships.ScholarshipID = " + ddlScholarshipList.SelectedValue;

            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
            SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlQuery, sqlConnect);

            DataTable dtForGridView = new DataTable();
            sqlAdapter.Fill(dtForGridView);


            grdScholarshipResults.DataSource = dtForGridView;
            grdScholarshipResults.DataBind();
        }

        protected void btnAward_Click(object sender, EventArgs e)
        {
            Response.Redirect("AwardScholarship.aspx");
        }

        protected void lstScholarship_SelectedIndexChanged(object sender, EventArgs e)
        {
            String sqlQuery = "SELECT ScholarshipName, ScholarshipAmount, ScholarshipYear from Scholarships WHERE ScholarshipID = " + lstScholarship.SelectedValue;

            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);


            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnect;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlQuery;


            sqlConnect.Open();
            SqlDataReader queryResults = sqlCommand.ExecuteReader();


            while (queryResults.Read())
            {
                txtScholarshipName.Text = queryResults["ScholarshipName"].ToString();
                txtScholarshipAmount.Text = queryResults["ScholarshipAmount"].ToString();
                txtScholarshipYear.Text = queryResults["ScholarshipYear"].ToString();
               







            }
            sqlConnect.Close();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string sqlQuery = "UPDATE Scholarships SET ScholarshipName=@ScholarshipName, ScholarshipAmount=@ScholarshipAmount, ScholarshipYear=@ScholarshipYear WHERE ScholarshipID= " + lstScholarship.SelectedValue;

            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);


            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnect;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlQuery;
            sqlCommand.Parameters.AddWithValue("@ScholarshipName", txtScholarshipName.Text);
            sqlCommand.Parameters.AddWithValue("@ScholarshipAmount", txtScholarshipAmount.Text);

            sqlCommand.Parameters.AddWithValue("@ScholarshipYear", txtScholarshipYear.Text);


            sqlConnect.Open();
            //SqlDataReader queryResults = sqlCommand.ExecuteReader();
            sqlCommand.ExecuteScalar();
            sqlConnect.Close();
        }
    }
}