using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.two_step_authorization
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim(); // Hash the password before storing (not done here for simplicity)
            //string UserId = txtUserId.Text.Trim();
            string RoleId = txtRoleId.Text.Trim();
            string firstAuthCode = txtFirstAuthCode.Text.Trim();
            string secondAuthCode = txtSecondAuthCode.Text.Trim();


            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Insert the data into the Users table
                //string connectionString = "ConnectionString"; // Replace with your connection string
                //using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        //conn.Open();
                        string query = @"
                        INSERT INTO A_Users (Username, Password, RoleId,IsFirstAuthorized, IsSecondAuthorized) 
                        VALUES ('sam','123','1','1','0')";
//(@UserId,@Username, @Password,@RoleId, @IsFirstAuthorized, @IsSecondAuthorized)";

                        SqlCommand cmd = new SqlCommand(query, connection);
                        //cmd.Parameters.AddWithValue("@UserId", UserId);
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", password); // Use a hashed value in production
                        cmd.Parameters.AddWithValue("@RoleId", RoleId); // Use a hashed value in production
                        cmd.Parameters.AddWithValue("@IsFirstAuthorized", firstAuthCode);
                        cmd.Parameters.AddWithValue("@IsSecondAuthorized", secondAuthCode);
                        //cmd.Parameters.AddWithValue("@Email", email);
                        cmd.ExecuteNonQuery();
                        //int rowsAffected = cmd.ExecuteNonQuery();
                        //if (rowsAffected > 0)
                        //{
                        //    lblMessage.ForeColor = System.Drawing.Color.Green;
                        //    lblMessage.Text = "User registered successfully!";
                        //}
                        //else
                        //{
                        //    lblMessage.Text = "Error: User registration failed.";
                        //}
                    }
                    catch (Exception ex)
                    {
                        lblMessage.Text = "Error: " + ex.Message;
                    }
                }
            }
        }
    }
}