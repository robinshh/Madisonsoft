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
using System.Drawing;
using Lab3;


namespace Lab2
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["MustLogin"] != null)
            {
                lblStatus.Text = Session["MustLogin"].ToString();
                //tried they are bad user  
            }
            else
            {
                lblStatus.Text = "Please login to continue";
                //first time accessing - good user 
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["AUTH"].ConnectionString.ToString());
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnect;
            sqlCommand.Parameters.AddWithValue("@Username", txtUsername.Text);
            sqlCommand.Parameters.AddWithValue("@Password", PasswordHash.HashPassword(txtPassword.Text));
            sqlCommand.CommandText = "SELECT Pass from MemberCredentials WHERE Username = @Username";

            sqlConnect.Open();
            SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string storedHash = reader["Pass"].ToString();
                    if (PasswordHash.ValidatePassword(txtPassword.Text, storedHash))
                    {
                        lblStatus.Text = "Login successful!";
                        btnLogin.Enabled = false;
                        txtUsername.Enabled = false;
                        txtPassword.Enabled = false;
                        Session["Username"] = txtUsername.Text;
                        Response.Redirect("MembersHomePage.aspx");
                    }
                    else
                        lblStatus.Text = "Incorrect password. Please try again!";
                }

            }
            else
                lblStatus.Text = "Login failed. Please try again!";
        }

        protected void btnRegisterMember_Click(object sender, EventArgs e)
        {
            Response.Redirect("MemberRegister.aspx");
        }
    }
}