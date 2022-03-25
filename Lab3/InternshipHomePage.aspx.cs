
//Date: 2 / 27 / 2022
//Name: Madeleine Duley and Dana El-Zoobi and Kit Harmon
//File Purpose: This file is the code behind for the internship home page



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
    public partial class InternshipHomePage : System.Web.UI.Page
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
                lstEdit.Items.Add(
                    new ListItem(
                        queryResults["InternshipName"].ToString(),
                        queryResults["InternshipID"].ToString()));

            }
            sqlConnect.Close();
            queryResults.Close();
        }

        protected void btnAddInternship_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddInternship.aspx");
        }

      

        protected void btnLoadInternshipData_Click(object sender, EventArgs e)
        {
            string sqlQuery = "Select InternshipName, InternshipYear, DateStart, DateEnd ";
            sqlQuery += "from Internships ";
            sqlQuery += "where Internships.InternshipID = " + ddlInternshipList.SelectedValue;

            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
            SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlQuery, sqlConnect);

            DataTable dtForGridView = new DataTable();
            sqlAdapter.Fill(dtForGridView);


            grdInternshipResults.DataSource = dtForGridView;
            grdInternshipResults.DataBind();
        }

        protected void btnShowAll_Click(object sender, EventArgs e)
        {
            string sqlQuery = "Select InternshipName, InternshipYear, DateStart, DateEnd ";
            sqlQuery += "from Internships ";
            //sqlQuery += "where Internships.InternshipID = " + ddlInternshipList.SelectedValue;

            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
            SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlQuery, sqlConnect);

            DataTable dtForGridView = new DataTable();
            sqlAdapter.Fill(dtForGridView);


            grdInternshipResults.DataSource = dtForGridView;
            grdInternshipResults.DataBind();
        }

        protected void btnAward_Click(object sender, EventArgs e)
        {
            Response.Redirect("AwardInternship.aspx");
        }

        protected void lstEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            String sqlQuery = "SELECT InternshipName, InternshipYear, DateStart, DateEnd from Internships WHERE InternshipID = " + lstEdit.SelectedValue;

            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);


            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnect;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlQuery;


            sqlConnect.Open();
            SqlDataReader queryResults = sqlCommand.ExecuteReader();


            while (queryResults.Read())
            {
                txtInternshipName.Text = queryResults["InternshipName"].ToString();
                txtInternshipYear.Text = queryResults["InternshipYear"].ToString();
                txtInternshipDateStart.Text = queryResults["DateStart"].ToString();
                txtInternshipDateEnd.Text = queryResults["DateEnd"].ToString();
                






            }
            sqlConnect.Close();
            // queryResults.Close();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string sqlQuery = "UPDATE Internships SET InternshipName=@InternshipName,InternshipYear=@InternshipYear,DateStart=@DateStart,DateEnd=@DateEnd WHERE InternshipID= " + lstEdit.SelectedValue;
            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);


            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnect;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlQuery;
            sqlCommand.Parameters.AddWithValue("@InternshipName", txtInternshipName.Text);
            sqlCommand.Parameters.AddWithValue("@InternshipYear", txtInternshipYear.Text);

            sqlCommand.Parameters.AddWithValue("@DateStart", txtInternshipDateStart.Text);
            sqlCommand.Parameters.AddWithValue("@DateEnd", txtInternshipDateEnd.Text);


            sqlConnect.Open();
            //SqlDataReader queryResults = sqlCommand.ExecuteReader();
            sqlCommand.ExecuteScalar();
            sqlConnect.Close();
        }
    }
}