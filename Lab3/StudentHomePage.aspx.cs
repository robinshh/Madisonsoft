
//Date: 2 / 27 / 2022
//Name: Madeleine Duley and Dana El-Zoobi and Kit Harmon
//File Purpose: This file is the code behind for the student home page


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;


//Dana El-Zoobi and Madeleine Duley

namespace Lab2
{
    public partial class StudentHomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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

        protected void btnAddUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddUser.aspx");
        }

       

        protected void btnShowAll_Click(object sender, EventArgs e)
        {
            string sqlQuery = "Select FirstName + ' ' + LastName as StudentName, Email, Phone, GradYear, Major, InternshipStatus, EmploymentStatus ";
            sqlQuery += "from Students ";
          

            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
            SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlQuery, sqlConnect);

            DataTable dtForGridView = new DataTable();
            sqlAdapter.Fill(dtForGridView);


            grdStudentResults.DataSource = dtForGridView;
            grdStudentResults.DataBind();
        }

        protected void btnLoadStudentData_Click(object sender, EventArgs e)
        {
            string sqlQuery = "Select FirstName + ' ' + LastName as StudentName, Email, Phone, GradYear, Major, InternshipStatus, EmploymentStatus ";
            sqlQuery += "from Students ";
            sqlQuery += "where Students.StudentID = " + ddlStudentList.SelectedValue;
           
            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
            SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlQuery, sqlConnect);

            DataTable dtForGridView = new DataTable();
            sqlAdapter.Fill(dtForGridView);
           

            grdStudentResults.DataSource = dtForGridView;
            grdStudentResults.DataBind();

        }

        protected void grdStudentResults_RowEditing(object sender, GridViewEditEventArgs e)
        {
            
        }

        protected void btnAssignMentor_Click(object sender, EventArgs e)
        {
            Response.Redirect("AssignMentor.aspx");
        }

        protected void lstEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            String sqlQuery = "SELECT FirstName, LastName, Email, Phone, GradYear, Major, InternshipStatus, EmploymentStatus FROM Students  WHERE StudentID = " + lstEdit.SelectedValue;

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
               
               





            }
            sqlConnect.Close();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string sqlQuery = "UPDATE Students SET FirstName=@FirstName, LastName=@LastName, Email=@Email, Phone=@Phone, GradYear=@GradYear, Major=@Major, InternshipStatus=@InternshipStatus, EmploymentStatus=@EmploymentStatus WHERE StudentID= " + lstEdit.SelectedValue; 

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

            sqlConnect.Open();
            //SqlDataReader queryResults = sqlCommand.ExecuteReader();
            sqlCommand.ExecuteScalar();



            sqlConnect.Close();
        }
    }
}