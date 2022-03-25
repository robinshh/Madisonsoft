
//Date: 2 / 27 / 2022
  //  Name: Madeleine Duley and Dana El-Zoobi and Kit Harmon
//File Purpose: This file is the code behind for the company home page


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
    public partial class CompanyHomePage : System.Web.UI.Page
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

      

        protected void btnAddCompany_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddCompany.aspx");
        }

      

        protected void btnLoadCompanyData_Click(object sender, EventArgs e)
        {
            string sqlQuery = "Select CompanyName, CompanyAddress, Phone ";
            sqlQuery += "from Company ";
            sqlQuery += "where Company.CompanyID = " + ddlCompanyList.SelectedValue;

            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
            SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlQuery, sqlConnect);

            DataTable dtForGridView = new DataTable();
            sqlAdapter.Fill(dtForGridView);


            grdCompanyResults.DataSource = dtForGridView;
            grdCompanyResults.DataBind();
        }

        protected void btnShowAll_Click(object sender, EventArgs e)
        {
            string sqlQuery = "Select CompanyName, CompanyAddress, Phone ";
            sqlQuery += "from Company ";
           // sqlQuery += "where Company.CompanyID = " + ddlCompanyList.SelectedValue;

            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
            SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlQuery, sqlConnect);

            DataTable dtForGridView = new DataTable();
            sqlAdapter.Fill(dtForGridView);


            grdCompanyResults.DataSource = dtForGridView;
            grdCompanyResults.DataBind();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string sqlQuery = "UPDATE Company SET CompanyName=@CompanyName,CompanyAddress=@CompanyAddress,Phone=@Phone WHERE CompanyID= " + lstCompanies.SelectedValue;
            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);


            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnect;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlQuery;
            sqlCommand.Parameters.AddWithValue("@CompanyName", txtCompanyName.Text);
            sqlCommand.Parameters.AddWithValue("@CompanyAddress", txtCompanyAddress.Text);
            sqlCommand.Parameters.AddWithValue("@Phone", txtPhone.Text);


            sqlConnect.Open();
            //SqlDataReader queryResults = sqlCommand.ExecuteReader();
            sqlCommand.ExecuteScalar();
            sqlConnect.Close();
        }

        protected void lstCompanies_SelectedIndexChanged(object sender, EventArgs e)
        {
            String sqlQuery = "SELECT CompanyName, CompanyAddress, Phone from Company WHERE CompanyID = " + lstCompanies.SelectedValue;

            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);


            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnect;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlQuery;


            sqlConnect.Open();
            SqlDataReader queryResults = sqlCommand.ExecuteReader();


            while (queryResults.Read())
            {
                txtCompanyName.Text = queryResults["CompanyName"].ToString();
                txtCompanyAddress.Text = queryResults["CompanyAddress"].ToString();
                txtPhone.Text = queryResults["Phone"].ToString();







            }
            sqlConnect.Close();
        }
    }
}