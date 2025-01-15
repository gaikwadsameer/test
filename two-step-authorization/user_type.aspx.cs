    using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.two_step_authorization
{
    public partial class user_type : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string userType = Session["UserType"] as string;

                if (string.IsNullOrEmpty(userType))
                {
                    // Redirect to login page if session is empty
                    //Response.Redirect("Login.aspx");
                }

                switch (userType)
                {
                    case "Admin":
                        adminPanel.Visible = true;
                        userPanel.Visible = false;
                        guestPanel.Visible = false;
                        break;

                    case "User":
                        adminPanel.Visible = false;
                        userPanel.Visible = true;
                        guestPanel.Visible = false;
                        break;

                    case "Guest":
                        adminPanel.Visible = false;
                        userPanel.Visible = false;
                        guestPanel.Visible = true;
                        break;

                    default:
                        //Response.Redirect("Login.aspx");
                        break;
                }
            }
        }


        protected void Login_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            string query = "SELECT UserType FROM Users_type WHERE Username = @Username AND Password = @Password";


            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);
                connection.Open();

                string userType = cmd.ExecuteScalar() as string;

                if (!string.IsNullOrEmpty(userType))
                {
                    Session["UserType"] = userType;
                    Response.Redirect("user_type.aspx");
                }
                else
                {
                    lblMessage.Text = "Invalid username or password.";
                }
            }
        }
    }
}