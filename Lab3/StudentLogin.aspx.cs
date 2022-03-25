//Dana El-Zoobi and Madeleine Duley and Kit Harmon
//    2/27/2022


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Drawing;
using System.Data;
using Lab3;

namespace Lab2
{
    public partial class StudentLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["NeedLogin"] != null)
            {
                lblStat.Text = Session["NeedLogin"].ToString();
            }
           if (Session["LoggedOut"] != null)
            {
                lblStat.Text = Session["LoggedOut"].ToString();
            }
           if (Request.QueryString.Get("loggedout") == "true")
            {
                lblStat.ForeColor = Color.Green;
                lblStat.Text = "User Successfully Logged Out!";
            }
        }
        protected void btnLog_Click(object sender, EventArgs e)
        {
            //connect to the db and use saved procedure
            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["AUTH"].ConnectionString.ToString());
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnect;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "Lab3StoredProcedure";
            sqlCommand.Parameters.AddWithValue("@Username", txtUser.Text);
            sqlCommand.Parameters.AddWithValue("@Password", PasswordHash.HashPassword(txtPass.Text));
            sqlConnect.Open();
            
            SqlDataReader loginResults = sqlCommand.ExecuteReader();

            if (loginResults.HasRows)
            {
                while (loginResults.Read())
                {

                    string storedHash = loginResults["Pass"].ToString();

                    if (PasswordHash.ValidatePassword(txtPass.Text, storedHash))
                    {
                        lblStat.Text = "Login successful!";
                        btnLog.Enabled = false;
                        txtUser.Enabled = false;
                        txtPass.Enabled = false;
                        Session["Username"] = txtUser.Text;
                        Response.Redirect("StudentInfo.aspx");
                    }
                    else
                    {
                        lblStat.ForeColor = Color.Red;
                        lblStat.Font.Bold = true;
                        lblStat.Text = "Incorrect password. Please try again!";
                    }

                }
            }
            else
                lblStat.Text = "Login failed. Please try again!";
        }

        protected void btnRegisterStudent_Click(object sender, EventArgs e)
        {

        }
    }

}