//Name: Dana El-Zoobi and Madeleine Duley and Kit Harmon
//Date: 2/27/2022
//File Purpose: This file is the code behind for adding user


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//sql imports 
using System.Data;
using System.Data.SqlClient;

//access to connection strings in web.config 
using System.Web.Configuration;

namespace Lab2
{
    public partial class AddUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           

            //if (!IsPostBack)
            //{
            //    Session["StudentArray"] = new StudentClass[30];
            //    Session["ArrayKeeper"] = 0;
            //}
            //create the query 
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

            //read the results and populate the listbox 
            while (queryResults.Read())
            {
                lstUsersDynamic.Items.Add(
                    new ListItem(
                        queryResults["StudentInfo"].ToString(),
                        queryResults["StudentID"].ToString()));

            }
            sqlConnect.Close();
            queryResults.Close();

        }

        protected void btnAddStudent_Click(object sender, EventArgs e)
        {
           
            Boolean x = dup();
            if (x == true)
            {

                lblError.Text = "Duplicate Entry";
            }
            if (x == false)

            {
                lblError.Text = "Student Added!";
                //create the query with concatenation of text boxes 
                String sqlQuery = "INSERT INTO Students (FirstName,LastName,Email,Phone,GradYear,Major,InternshipStatus,EmploymentStatus) " +
                    "VALUES (@FirstName, @LastName, @Email, @Phone, @GradYear, @Major, @InternshipStatus, @EmploymentStatus)";
                //instead of concatenation use parametized query to prevent cross site scripting and sql inkection 
            //define the connection to the database 
            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["LAB3"].ConnectionString);

            //create and structure the query command 
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnect;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlQuery;

            //execute the query and retrive the results 
            sqlConnect.Open();
            sqlCommand.ExecuteScalar();
            sqlConnect.Close();
                sqlCommand.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                sqlCommand.Parameters.AddWithValue("@LastName", txtLastName.Text);

                sqlCommand.Parameters.AddWithValue("@Email", txtEmail.Text);
                sqlCommand.Parameters.AddWithValue("@Phone", txtPhone.Text);
                sqlCommand.Parameters.AddWithValue("@GradYear", txtGradYear.Text);
                sqlCommand.Parameters.AddWithValue("@InternshipStatus", txtInternshipStatus.Text);
                sqlCommand.Parameters.AddWithValue("@EmploymentStatus", txtEmploymentStatus.Text);
                

                //2. Update the listbox 
                lstUsersDynamic.Items.Clear();
            updateFromDB();

            //3. clear the ui 
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
            txtGradYear.Text = "";
            txtInternshipStatus.Text = "";
            txtMajor.Text = "";
            txtEmploymentStatus.Text = "";
        }
        }
        protected void updateFromDB()
        {
            //create the query 
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

            //read the results and populate the listbox 
            while (queryResults.Read())
            {
                lstUsersDynamic.Items.Add(
                    new ListItem(
                        queryResults["StudentInfo"].ToString(),
                        queryResults["StudentID"].ToString()));

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
            txtMajor.Text = "CIS";
            txtGradYear.Text = "2022";
            txtEmploymentStatus.Text = "N/A";
            txtInternshipStatus.Text = "N/A";

        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
            txtMajor.Text = "";
            txtGradYear.Text = "";
            txtEmploymentStatus.Text = "";
            txtInternshipStatus.Text = "";
        }

       // protected void btnCommit_Click(object sender, EventArgs e)
       // {
        //    Boolean x = dup();
        //    if (x == true)
        //    {

        //        txtError1.Text = "Duplicate Entry";
        //    }
        //    if (x == false)

        //    {
        //        //create the query with concatenation of text boxes 
        //        String sqlQuery = "INSERT INTO Students (FirstName,LastName,Email,Phone,GradYear,Major,InternshipStatus,EmploymentStatus) VALUES ('" + txtFirstName.Text + "','" + txtLastName.Text + "','" + txtEmail.Text + "','" + txtPhone.Text + "','" + txtGradYear.Text + "','" + txtMajor.Text + "','" + txtInternshipStatus.Text + "','" + txtEmploymentStatus.Text + "')";

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
        //        lstUsersDynamic.Items.Clear();
        //    }
       // }

        //protected void btnSave_Click(object sender, EventArgs e)
        //{
        //    String firstName = txtFirstName.Text.ToString();
        //    String lastName = txtLastName.Text.ToString();
        //    String email = txtEmail.Text.ToString();
        //    String phone = txtPhone.Text.ToString();
        //    String gradYear = txtGradYear.Text.ToString();
        //    String major = txtMajor.Text.ToString();
        //    String internshipStatus = txtInternshipStatus.Text.ToString();
        //    String employmentStatus = txtEmploymentStatus.Text.ToString();


        //    StudentClass[] sArray = (StudentClass[])Session["StudentArray"];
        //    int keeper = (int)Session["ArrayKeeper"];

        //    sArray[keeper++] = new StudentClass(firstName, lastName, email, phone, gradYear, major, internshipStatus, employmentStatus);
        //    Session["ArrayKeeper"] = keeper;
        //    Session["StudentArray"] = sArray;

        //    lstUsersDynamic.Items.Clear();

        //    for (int i = 0; i < keeper; i++)
        //    {
        //        if (sArray[i] != null)
        //        {
        //            lstUsersDynamic.Items.Add(sArray[i].ToString());
        //        }
        //    }
        //}



        protected Boolean dup()
        {
            String count = "";
            string sqlQuery = "SELECT COUNT(Email) AS Email FROM Students WHERE Email = @Email";
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
