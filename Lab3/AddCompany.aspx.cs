//Name: Dana El-Zoobi and Madeleine Duley and Kit Harmon
//Date: 2/27/2022
//File Purpose: This file is our code behind for adding a company


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
    public partial class AddCompany : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

            String sqlQuery = "SELECT CompanyName,CompanyID FROM COMPANY";

            
            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnect;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlQuery;

            
            sqlConnect.Open();
            SqlDataReader queryResults = sqlCommand.ExecuteReader();

           
            while (queryResults.Read())
            {
                lstCompanies.Items.Add(
                    new ListItem(
                        queryResults["CompanyName"].ToString(),
                        queryResults["CompanyID"].ToString()));

            }
            sqlConnect.Close();
            queryResults.Close();
        }

        protected void btnCompany_Click(object sender, EventArgs e)
        {

        }

        protected void btnAddCompany_Click(object sender, EventArgs e)
        {
            Boolean x = dup();
            if (x == true)
            {

                lblError.Text = "Duplicate Entry";
            }
            if (x == false)

            {
                lblError.Text = "Company Added!";

                // String sqlQuery = "INSERT INTO Company (CompanyName,CompanyAddress,Phone) VALUES ('" + txtCompanyName.Text + "','" + txtCompanyAddress.Text + "','" + txtPhone.Text + "')";
                String sqlQuery = "INSERT INTO Company (CompanyName,CompanyAddress,Phone) " +
                    "VALUES (@CompanyName,@CompanyAddress,@Phone)";
                

                SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["LAB3"].ConnectionString);


            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnect;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlQuery;
                sqlCommand.Parameters.AddWithValue("@CompanyName", txtCompanyName.Text);
                sqlCommand.Parameters.AddWithValue("@CompanyAddress", txtCompanyAddress.Text);
                sqlCommand.Parameters.AddWithValue("@Phone", txtPhone.Text);



                sqlConnect.Open();
            sqlCommand.ExecuteScalar();
            sqlConnect.Close();


            lstCompanies.Items.Clear();
            updateFromDB();


            txtCompanyName.Text = "";
            txtCompanyAddress.Text = "";

            txtPhone.Text = "";
        }
        }
        protected void updateFromDB()
        {
             
            String sqlQuery = "SELECT CompanyName,CompanyID FROM COMPANY";

           
            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

           
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnect;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlQuery;

            
            sqlConnect.Open();
            SqlDataReader queryResults = sqlCommand.ExecuteReader();

           
            while (queryResults.Read())
            {
                lstCompanies.Items.Add(
                    new ListItem(
                        queryResults["CompanyName"].ToString(),
                        queryResults["CompanyID"].ToString()));

            }
            sqlConnect.Close();
            queryResults.Close();
        }

        protected void btnPopulate_Click(object sender, EventArgs e)
        {
            txtCompanyName.Text = "testLastName";
            txtCompanyAddress.Text = "test@test.com";
            txtPhone.Text = "55544411";
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtCompanyName.Text = "";
            txtCompanyAddress.Text = "";
            txtPhone.Text = "";
        }

        //protected void btnCommit_Click(object sender, EventArgs e)
        //{
        //    Boolean x = dup();
        //    if (x == true)
        //    {

        //        txtError2.Text = "Duplicate Entry";
        //    }
        //    if (x == false)

        //    {
        //        //create the query with concatenation of text boxes 
        //        String sqlQuery = "INSERT INTO Mentorship (StudentID,Phone) VALUES ('" + txtCompanyName.Text + "','" + txtCompanyAddress.Text + "','" + txtPhone.Text + "')";

        //        //define the connection to the database 
        //        SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["LAB2"].ConnectionString);

        //        //create and structure the query command 
        //        SqlCommand sqlCommand = new SqlCommand();
        //        sqlCommand.Connection = sqlConnect;
        //        sqlCommand.CommandType = CommandType.Text;
        //        sqlCommand.CommandText = sqlQuery;

        //        //execute the query and retrive the results 
        //        sqlConnect.Open();
        //        sqlCommand.ExecuteScalar();
        //        sqlConnect.Close();

        //        //2. Update the listbox 
        //        lstCompanies.Items.Clear();
        //    }
        //}

        protected Boolean dup()
        {
            String count = "";
            //string sqlQuery = "SELECT COUNT(CompanyName) AS Name FROM Company WHERE CompanyName=" + "'" + txtCompanyName.Text + "'";
            string sqlQuery = "SELECT COUNT(CompanyName) AS Name FROM Company WHERE CompanyName = @CompanyName";
            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["LAB3"].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnect;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlQuery;
            sqlCommand.Parameters.AddWithValue("@CompanyName", txtCompanyName.Text);
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