using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


using System.Web.Configuration;




namespace Lab3
{
    public partial class MemberRegister : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCreateMember_Click(object sender, EventArgs e)
        {
            lblError.Text = "Member Added!";

            String sqlQuery = "INSERT INTO Members (FirstName,LastName,Email,Phone,GradYear,JobTitle,Username) " +
                "VALUES (@FirstName, @LastName, @Email, @Phone, @GradYear, @JobTitle, @Username)";


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
            sqlCommand.Parameters.AddWithValue("@Username", txtUsername.Text);
           


            sqlConnect.Open();
            sqlCommand.ExecuteScalar();
            sqlConnect.Close();


            
            updateFromDB();

            //3. clear the ui 
            //txtFirstName.Text = "";
            //txtLastName.Text = "";
            //txtEmail.Text = "";
            //txtPhone.Text = "";
            //txtGradYear.Text = "";
            //txtJobTitle.Text = "";
            //txtUsername.Text = "";

           


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
           
            sqlConnect.Close();
            queryResults.Close();






        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            String sqlQuery = "INSERT INTO UnapprovedCredentials (Username,Pass) " +
                "VALUES (@Username, @Pass)";


            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["AUTH"].ConnectionString);


            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnect;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlQuery;
            sqlCommand.Parameters.AddWithValue("@Username", txtUsername.Text);
            sqlCommand.Parameters.AddWithValue("@Pass", PasswordHash.HashPassword(txtPassword.Text));

            


            sqlConnect.Open();
            sqlCommand.ExecuteScalar();
            sqlConnect.Close();

            Response.Redirect("HomePage.aspx");
        }
    }
}