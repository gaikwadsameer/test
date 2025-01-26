using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace adminpanel
{
    public partial class login : System.Web.UI.Page
    {
        public string connStr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnLogin_Click(object sender, EventArgs e)
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
                    Response.Redirect("AdminVerify.aspx");
                }
                else
                {
                    lblMessage.Text = "Invalid username or password.";
                }
            }
        }
    }
}





//CREATE TABLE [dbo].[DataEntry](
//	[UserID] [int] NULL,
//	[DataText] [nvarchar](255) NOT NULL,
//	[Status] [nvarchar](20) NULL
//) ON [PRIMARY]
//GO

//ALTER TABLE [dbo].[DataEntry] ADD  DEFAULT ('Pending') FOR [Status]
//GO


//CREATE TABLE [dbo].[Users_type](
//	[UserID] [int] IDENTITY(1,1) NOT NULL,
//	[Username] [nvarchar](50) NOT NULL,
//	[Password] [nvarchar](50) NOT NULL,
//	[UserType] [nvarchar](20) NOT NULL,
//)CREATE TABLE [dbo].[DataEntry](
//	[UserID] [int] NULL,
//	[DataText] [nvarchar](255) NOT NULL,
//	[Status] [nvarchar](20) NULL
//) ON [PRIMARY]
//GO

//ALTER TABLE [dbo].[DataEntry] ADD  DEFAULT ('Pending') FOR [Status]
//GO


//CREATE TABLE [dbo].[Users_type](
//	[UserID] [int] IDENTITY(1,1) NOT NULL,
//	[Username] [nvarchar](50) NOT NULL,
//	[Password] [nvarchar](50) NOT NULL,
//	[UserType] [nvarchar](20) NOT NULL,
//)