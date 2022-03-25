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
    public partial class EditMembers : System.Web.UI.Page
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
                lstEdit.Items.Add(
                    new ListItem(
                        queryResults["MemberInfo"].ToString(),
                        queryResults["MemberID"].ToString()));

            }
            sqlConnect.Close();
            queryResults.Close();

        }

        protected void lstEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            String sqlQuery = "SELECT FirstName, LastName, Email, Phone, GradYear, JobTitle FROM Members WHERE MemberID = " + lstEdit.SelectedValue;

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
                txtJobTitle.Text = queryResults["JobTitle"].ToString();






            }
            sqlConnect.Close();
           // queryResults.Close();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string sqlQuery = "UPDATE Members SET FirstName=@FirstName, LastName=@LastName, Email=@Email, Phone=@Phone, GradYear=@GradYear, JobTitle=@JobTitle WHERE MemberID= " + lstEdit.SelectedValue;
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
            sqlCommand.Parameters.AddWithValue("@JobTitle", txtJobTitle.Text);


            sqlConnect.Open();
            //SqlDataReader queryResults = sqlCommand.ExecuteReader();
            sqlCommand.ExecuteScalar();


          
            sqlConnect.Close();
            // queryResults.Close();
        }
    }
}