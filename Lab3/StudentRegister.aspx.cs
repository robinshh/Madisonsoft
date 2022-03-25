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
    public partial class StudentRegister : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCreateStudent_Click(object sender, EventArgs e)
        {
            lblError.Text = "Student Added!";
            //create the query with concatenation of text boxes 
            String sqlQuery = "INSERT INTO Students (FirstName,LastName,Email,Phone,GradYear,Major,InternshipStatus,EmploymentStatus,Username) " +
                "VALUES (@FirstName, @LastName, @Email, @Phone, @GradYear, @Major, @InternshipStatus, @EmploymentStatus, @Username)";

            //define the connection to the database 
            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["LAB3"].ConnectionString);

            //create and structure the query command 
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnect;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlQuery;

            //execute the query and retrive the results 
            sqlCommand.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
            sqlCommand.Parameters.AddWithValue("@LastName", txtLastName.Text);
            sqlCommand.Parameters.AddWithValue("@Email", txtEmail.Text);
            sqlCommand.Parameters.AddWithValue("@Phone", txtPhone.Text);
            sqlCommand.Parameters.AddWithValue("@GradYear", txtGradYear.Text);
            sqlCommand.Parameters.AddWithValue("@Major", txtMajor.Text);
            sqlCommand.Parameters.AddWithValue("@InternshipStatus", txtInternshipStatus.Text);
            sqlCommand.Parameters.AddWithValue("@EmploymentStatus", txtEmploymentStatus.Text);
            sqlCommand.Parameters.AddWithValue("@Username", txtUsername.Text);

            sqlConnect.Open();
            sqlCommand.ExecuteScalar();
            sqlConnect.Close();


            //2. Update the listbox 

            updateFromDB();
        }

        protected void updateFromDB()
        {
            //create the query 
            String sqlQuery = "SELECT FirstName + ' ' + LastName AS StudentInfo, StudentID FROM Students";

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

             
            
            sqlConnect.Close();
            queryResults.Close();






        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            String sqlQuery = "INSERT INTO UnapprovedStudents (Username,Pass) " +
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