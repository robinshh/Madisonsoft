//Name: Dana El-Zoobi and Madeleine Duley and Kit Harmon
//Date: 2/27/2022
//File Purpose: This file is the code behind for adding a scholarship


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
    public partial class AddScholarship : System.Web.UI.Page
    {

        //private ScholarshipClass currentScholarship;
        protected void Page_Load(object sender, EventArgs e)
        {
           
            //if (!IsPostBack)
            //{
            //    Session["ScholarshipArray"] = new ScholarshipClass[30];
            //    Session["ArrayKeeper"] = 0;
            //}

            //create the query 
            //create the query 
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
            Boolean x = dup();
            if (x == true)
            {

                lblError.Text = "Duplicate Entry";
            }
            if (x == false)
            {
                lblError.Text = "Scholarship Added!";
                //1. add to the db first 
                //create the query with concatenation of text boxes 
                String sqlQuery = "INSERT INTO Scholarships (ScholarshipName,ScholarshipAmount,ScholarshipYear) " +
                    "VALUES (@ScholarshipName, @ScholarshipAmount, @ScholarshipYear)";

                //define the connection to the database 
                SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["LAB3"].ConnectionString);

                //create and structure the query command 
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnect;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = sqlQuery;
                sqlCommand.Parameters.AddWithValue("@ScholarshipName", txtScholarshipName.Text);
                sqlCommand.Parameters.AddWithValue("@ScholarshipAmount", txtScholarshipAmount.Text);

                sqlCommand.Parameters.AddWithValue("@ScholarshipYear", txtScholarshipYear.Text);
                

                //execute the query and retrive the results 
                sqlConnect.Open();
                sqlCommand.ExecuteScalar();
                sqlConnect.Close();

                //2. Update the listbox 
                lstScholarship.Items.Clear();
                updateFromDB();

                //3. clear the ui 
                txtScholarshipName.Text = "";
                txtScholarshipAmount.Text = "";
                txtScholarshipYear.Text = "";

            }

        }
        protected void updateFromDB()
        {
            //create the query 
            //create the query 
            String sqlQuery = "SELECT ScholarshipName,ScholarshipID FROM Scholarships";

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


        protected void btnPopulate_Click(object sender, EventArgs e)
        {
            txtScholarshipName.Text = "testLastName";
            txtScholarshipAmount.Text = "test@test.com";
            txtScholarshipYear.Text = "5554";
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtScholarshipName.Text = "";
            txtScholarshipAmount.Text = "";
            txtScholarshipYear.Text = "";
        }


        //protected void btnSave_Click(object sender, EventArgs e)
        //{
        //    String scName = txtScholarshipName.Text.ToString();
        //    String scYear = txtScholarshipYear.Text.ToString();
        //    String scAmount = txtScholarshipAmount.Text.ToString();


        //   ScholarshipClass[] sArray = (ScholarshipClass[])Session["ScholarshipArray"];
        //    int keeper = (int)Session["ArrayKeeper"];

        //    sArray[keeper++] = new ScholarshipClass(scName, scAmount, scYear);
        //    Session["ArrayKeeper"] = keeper;
        //    Session["StudentArray"] = sArray;

        //    lstScholarship.Items.Clear();

        //    for (int i=0; i<keeper; i++)
        //    {
        //        if (sArray[i] != null)
        //        {
        //            lstScholarship.Items.Add(sArray[i].ToString());
        //        }
        //    }

           
        //}

        //protected void btnCommit_Click(object sender, EventArgs e)
        //{
        //    Boolean x = dup();
        //    if (x == true)
        //    {
                
        //        txtError.Text = "Duplicate Entry";
        //    }
        //    if (x == false)
        //    {

        //        String sqlQuery = "INSERT INTO Scholarships (ScholarshipName,ScholarshipAmount,ScholarshipYear) VALUES ('" + txtScholarshipName.Text + "','" + txtScholarshipAmount.Text + "','" + txtScholarshipYear.Text + "')";
        //        //////define the connection to the database 
        //        SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["LAB2"].ConnectionString);

        //        //////create and structure the query command 
        //        SqlCommand sqlCommand = new SqlCommand();
        //        sqlCommand.Connection = sqlConnect;
        //        sqlCommand.CommandType = CommandType.Text;
        //        sqlCommand.CommandText = sqlQuery;

        //        //////execute the query and retrive the results 
        //        sqlConnect.Open();
        //        sqlCommand.ExecuteScalar();
        //        sqlConnect.Close();

        //        //////2. Update the listbox 
        //        lstScholarship.Items.Clear();
        //    }
            
        //}

        protected Boolean dup()
        {
            String count = "";
            string sqlQuery = "SELECT COUNT(ScholarshipName) AS Name FROM Scholarships WHERE ScholarshipName = @ScholarshipName";
            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["LAB3"].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnect;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlQuery;
            sqlCommand.Parameters.AddWithValue("@ScholarshipName", txtScholarshipName.Text);
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
