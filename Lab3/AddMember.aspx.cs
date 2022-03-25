//Name: Dana El-Zoobi and Madeleine Duley
//Date: 2/11/2022
//File Purpose: This file is the code behind for adding a member

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
    public partial class AddMember : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           

            String sqlQuery = "SELECT FirstName + ' ' + LastName AS MemberInfo, MemberID FROM Members";

            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

         
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnect;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlQuery;

            
            sqlConnect.Open();
            SqlDataReader queryResults = sqlCommand.ExecuteReader();

           
            while (queryResults.Read())
            {
                lstMembersDynamic.Items.Add(
                    new ListItem(
                        queryResults["MemberInfo"].ToString(),
                        queryResults["MemberID"].ToString()));

            }
            sqlConnect.Close();
            queryResults.Close();

        }

        protected void btnAddmember_Click(object sender, EventArgs e)
        {
            Boolean x = dup();
            if (x == true)
            {

                lblError.Text = "Duplicate Entry";
            }
            if (x == false)
            {
                lblError.Text = "Member Added!";

            String sqlQuery = "INSERT INTO Members (FirstName,LastName,Email,Phone,GradYear,JobTitle) " +
                    "VALUES (@FirstName, @LastName, @Email, @Phone, @GradYear, @JobTitle)";


            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["LAB3"].ConnectionString);


            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnect;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlQuery;
                sqlCommand.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                sqlCommand.Parameters.AddWithValue("@LastName", txtLastName.Text);

                sqlCommand.Parameters.AddWithValue("@Email", txtEmail.Text);
                sqlCommand.Parameters.AddWithValue("@Phone", txtPhone.Text);
                sqlCommand.Parameters.AddWithValue("@GradYear", txtGradYear.Text);
                sqlCommand.Parameters.AddWithValue("@JobTitle", txtJobTitle.Text);

               


                sqlConnect.Open();
            sqlCommand.ExecuteScalar();
            sqlConnect.Close();


            lstMembersDynamic.Items.Clear();
            updateFromDB();

            //3. clear the ui 
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
            txtGradYear.Text = "";
            txtJobTitle.Text = "";
        }
        }
        protected void updateFromDB()
        {
            //create the query 
            //create the query 
            String sqlQuery = "SELECT FirstName + ' ' + LastName AS MemberInfo, MemberID FROM Members";

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
                lstMembersDynamic.Items.Add(
                    new ListItem(
                        queryResults["MemberInfo"].ToString(),
                        queryResults["MemberID"].ToString()));

            }
            sqlConnect.Close();
            queryResults.Close();






        }

        protected void btnPopulate_Click(object sender, EventArgs e)
        {
            txtFirstName.Text = "test";
            txtLastName.Text = "testLastName";
            txtEmail.Text = "test@test.com";
            txtPhone.Text = "55544411";
            txtGradYear.Text = "2022";
            txtJobTitle.Text = "N/A";
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
            txtGradYear.Text = "";
            txtJobTitle.Text = "";
        }

        protected void btnCommit_Click(object sender, EventArgs e)
        {

        }
        protected Boolean dup()
        {
            String count = "";
            string sqlQuery = "SELECT COUNT(Email) AS Email FROM Members WHERE Email = @Email";
            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["LAB3"].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnect;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlQuery;
            sqlCommand.Parameters.AddWithValue("@Email", txtEmail.Text);
            sqlConnect.Open();
            SqlDataReader queryResults = sqlCommand.ExecuteReader();

            while (queryResults.Read())
            {
                count = queryResults["Email"].ToString();

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