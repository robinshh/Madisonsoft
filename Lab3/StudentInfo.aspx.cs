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
    public partial class StudentInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String sqlQuery = "SELECT FirstName + ' ' + LastName AS StudentInfo, StudentID FROM Students WHERE Username = @Username";

            //define the connection to the DB:
            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            //create and structure the query command 
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnect;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlQuery;
           
            sqlCommand.Parameters.AddWithValue("@Username", Session["Username"]);



            //execute the query and retrieve the results 
            sqlConnect.Open();
            SqlDataReader queryResults = sqlCommand.ExecuteReader();
           // txtUsername.Text = queryResults["Username"].ToString();

            //read the results and populate the listbox 
            while (queryResults.Read())
            {
                lstEdit.Items.Add(
                    new ListItem(
                        queryResults["StudentInfo"].ToString(),
                        queryResults["StudentID"].ToString()));

            }
            sqlConnect.Close();
            queryResults.Close();
        }

        protected void lstEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            String sqlQuery = "SELECT FirstName, LastName, Email, Phone, GradYear, Major, InternshipStatus, EmploymentStatus, Username FROM Students  WHERE StudentID = " + lstEdit.SelectedValue;

            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);


            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnect;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlQuery;


            sqlConnect.Open();
            SqlDataReader queryResults = sqlCommand.ExecuteReader();


            while (queryResults.Read())
            {
                txtFirstName.Text = queryResults["FirstName"].ToString();
                txtLastName.Text = queryResults["LastName"].ToString();
                txtEmail.Text = queryResults["Email"].ToString();
                txtPhone.Text = queryResults["Phone"].ToString();
                txtGradYear.Text = queryResults["GradYear"].ToString();
                txtMajor.Text = queryResults["Major"].ToString();
                txtInternshipStatus.Text = queryResults["InternshipStatus"].ToString();
                txtEmploymentStatus.Text = queryResults["EmploymentStatus"].ToString();
                txtUsername.Text = queryResults["Username"].ToString();









            }
            sqlConnect.Close();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string sqlQuery = "UPDATE Students SET FirstName=@FirstName, LastName=@LastName, Email=@Email, Phone=@Phone, GradYear=@GradYear, Major=@Major, InternshipStatus=@InternshipStatus, EmploymentStatus=@EmploymentStatus, Username=@Username WHERE StudentID= " + lstEdit.SelectedValue;

            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);


            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnect;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlQuery;
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
            //SqlDataReader queryResults = sqlCommand.ExecuteReader();
            sqlCommand.ExecuteScalar();



            sqlConnect.Close();
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {

        }

        protected void ButtonResume_Click(object sender, EventArgs e)
        {
            Response.Redirect("Resume.aspx");
        }
    }
}