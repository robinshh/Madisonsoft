//Name: Dana El-Zoobi and Madeleine Duley and Kit Harmon
//Date: 2/27/2022
//File Purpose: This file is the code behind for adding an internship


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
    public partial class AddInternship : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           

            String sqlQuery = "SELECT InternshipName,InternshipID FROM Internships";

            
            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

           
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnect;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlQuery;

            
            sqlConnect.Open();
            SqlDataReader queryResults = sqlCommand.ExecuteReader();

           
            while (queryResults.Read())
            {
                lstInternships.Items.Add(
                    new ListItem(
                        queryResults["InternshipName"].ToString(),
                        queryResults["InternshipID"].ToString()));

            }
            sqlConnect.Close();
            queryResults.Close();
        }

        protected void btnAddInternship_Click(object sender, EventArgs e)
        {
            Boolean x = dup();
            if (x == true)
            {

                lblError.Text = "Duplicate Entry";
            }
            if (x == false)

            {
                lblError.Text = "Internship Added!";

                String sqlQuery = "INSERT INTO Internships (InternshipName,InternshipYear,DateStart,DateEnd) " +
                    "VALUES(@InternshipName, @InternshipYear, @DateStart, @DateEnd)";


                SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["LAB3"].ConnectionString);


                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnect;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = sqlQuery;
                sqlCommand.Parameters.AddWithValue("@InternshipName", txtInternshipName.Text);
                sqlCommand.Parameters.AddWithValue("@InternshipYear", txtInternshipYear.Text);

                sqlCommand.Parameters.AddWithValue("@DateStart", txtInternshipDateStart.Text);
                sqlCommand.Parameters.AddWithValue("@DateEnd", txtInternshipDateEnd.Text);


                sqlConnect.Open();
                sqlCommand.ExecuteScalar();
                sqlConnect.Close();


                lstInternships.Items.Clear();
                updateFromDB();


                txtInternshipName.Text = "";
                txtInternshipYear.Text = "";

                txtInternshipDateStart.Text = "";
                txtInternshipDateEnd.Text = "";
            }
        }
        protected void updateFromDB()
        {
            
            String sqlQuery = "SELECT InternshipName,InternshipID FROM Internships";

           
            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnect;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlQuery;

         
            sqlConnect.Open();
            SqlDataReader queryResults = sqlCommand.ExecuteReader();

            
            while (queryResults.Read())
            {
                lstInternships.Items.Add(
                    new ListItem(
                        queryResults["InternshipName"].ToString(),
                        queryResults["InternshipID"].ToString()));

            }
            sqlConnect.Close();
            queryResults.Close();
        }


        protected void btnPopulate_Click(object sender, EventArgs e)
        {
            txtInternshipName.Text = "testIntern";
            txtInternshipYear.Text = "2000";
            txtInternshipDateStart.Text = "02/21/2000";
            txtInternshipDateEnd.Text = "02/21/20001";
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtInternshipName.Text = "";
            txtInternshipYear.Text = "";
            txtInternshipDateStart.Text = "";
            txtInternshipDateEnd.Text = "";
        }

        protected void btnCommit_Click(object sender, EventArgs e)
        {

        }

        protected Boolean dup()
        {
            String count = "";
            string sqlQuery = "SELECT COUNT(InternshipName) AS Name FROM Internships WHERE InternshipName = @InternshipName";
            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["LAB3"].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnect;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlQuery;
            sqlCommand.Parameters.AddWithValue("@InternshipName", txtInternshipName.Text);
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