using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Configuration;

namespace Lab3
{
    public partial class Resume : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonUpload_Click(object sender, EventArgs e)
        {
            LabelResumeRequest.Visible = true;
            string filePath = ResumeUpload.PostedFile.FileName;
            string fileName = Path.GetFileName(filePath);
            string fileExtension = Path.GetExtension(fileName);
            string fileType = String.Empty;
            string Username = Session["Username"].ToString();

            if (!ResumeUpload.HasFile)
            {
                LabelResumeRequest.Text = "Please select a file";
            }

            else if (ResumeUpload.HasFile)
            {
                try
                {
                    switch (fileExtension)
                    {
                        case ".pdf":
                            fileType = "Student Resume";
                            break;
                    }

                    if (fileType != String.Empty)
                    {
                        //write sql query
                        String sqlQuery = "if exists(SELECT * FROM StudentResume WHERE Username=@Username) BEGIN UPDATE StudentResume SET ResumeName=@ResumeName, Type=@Type, Data=@Data WHERE Username=@Username END ELSE BEGIN INSERT INTO StudentResume (ResumeName,Type,Data,Username)" + "VALUES(@ResumeName, @Type, @Data,@Username) END";

                        //define the connection to the database 
                        SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["LAB3"].ConnectionString);

                        //stream
                        Stream fs = ResumeUpload.PostedFile.InputStream;

                        //data
                        BinaryReader br = new BinaryReader(fs);

                        //bytes
                        Byte[] bytes = br.ReadBytes((Int32)fs.Length);

                        //create and structure the query command 
                        SqlCommand sqlCommand = new SqlCommand();
                        sqlCommand.Connection = sqlConnect;
                        sqlCommand.CommandType = CommandType.Text;
                        sqlCommand.CommandText = sqlQuery;

                        sqlCommand.Parameters.AddWithValue("@ResumeName", fileName);
                        sqlCommand.Parameters.AddWithValue("@Type", fileType);
                        sqlCommand.Parameters.AddWithValue("@Data", bytes);

                        sqlCommand.Parameters.AddWithValue("@Username", Username);


                        //execute the query and retrive the results 
                        sqlConnect.Open();
                        sqlCommand.ExecuteScalar();
                        sqlConnect.Close();


                        LabelResumeRequest.Text = "Resume uploaded successfully!";
                    }

                    else
                    {
                        LabelResumeRequest.Text = "Select only PDF files";
                    }
                }
                catch (Exception ex)
                {
                    LabelResumeRequest.Text = "Error: " + ex.Message.ToString();
                }
            }




        }

        protected void ButtonViewResume_Click(object sender, EventArgs e)
        {
            string Username = Session["Username"].ToString();

            //create the query 
            String sqlQuery = "SELECT ResumeName,Type FROM StudentResume WHERE Username = @Username";

            //define the connection to the DB:
            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            //create and structure the query command 
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnect;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlQuery;
            sqlCommand.Parameters.AddWithValue("@Username", Username);

            //execute the query and retrieve the results 
            sqlConnect.Open();
            GridViewResume.DataSource = sqlCommand.ExecuteReader();
            GridViewResume.DataBind();
            sqlConnect.Close();

        }

        protected void GridViewResume_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Username = Session["Username"].ToString();

            //create the query 
            String sqlQuery = "SELECT ResumeName,Type,Data FROM StudentResume WHERE Username = @Username";

            //define the connection to the DB:
            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            //create and structure the query command 
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnect;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlQuery;
            sqlCommand.Parameters.AddWithValue("@Username", Username);

            //execute the query and retrieve the results 
            //https://www.c-sharpcorner.com/UploadFile/0c1bb2/uploading-and-downloading-pdf-files-from-database-using-asp/ used as reference
            sqlConnect.Open();
            SqlDataReader dr = sqlCommand.ExecuteReader();
            if (dr.Read())
            {
                Response.Clear();
                Response.Buffer = true;
                Response.ContentType = dr["Type"].ToString();
                Response.AddHeader("content-disposition", "attachment; filename = " + dr["ResumeName"].ToString());
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.BinaryWrite((byte[])dr["Data"]);
                Response.End();
            }
            sqlConnect.Close();
        }
    }
}