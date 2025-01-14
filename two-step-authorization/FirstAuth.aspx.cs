using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.two_step_authorization
{
    public partial class FirstAuth : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        //private bool ValidateFirstAuthCode(string authCode)
        //{
        //    // Example: Validate against a hardcoded or database-stored value
        //    const string validCode = "12345"; // Replace with your logic or data source
        //    return authCode == validCode;
        //}

        protected void btnAuthorize_Click(object sender, EventArgs e)
        {
            int userId = (int)Session["UserId"];
            string firstAuthCode = txtFirstAuthCode.Text;

            if (txtFirstAuthCode.Text != "0") // Custom validation logic
            {
                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT UserId, IsFirstAuthorized FROM A_Users WHERE UserId=@UserId";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    cmd.ExecuteNonQuery();
                }

                LogAuthorization(userId, "First", "Success");
                Response.Redirect("Dashboard.aspx");
            }
            else
            {
                lblMessage.Text = "Authorization failed.";
                LogAuthorization(userId, "First", "Failure");
            }
        }

        private void LogAuthorization(int userId, string step, string status)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO A_AuthorizationLogs (UserId, AuthorizationStep, Status, Timestamp) VALUES (@UserId, @Step, @Status, @Timestamp)";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.Parameters.AddWithValue("@Step", step);
                cmd.Parameters.AddWithValue("@Status", status);
                cmd.Parameters.AddWithValue("@Timestamp", DateTime.Now);
                cmd.ExecuteNonQuery();
            }
        }

    }
}