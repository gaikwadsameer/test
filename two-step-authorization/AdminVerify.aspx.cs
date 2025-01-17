using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Controls;
using System.Collections;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WebApplication1.two_step_authorization
{
    public partial class AdminVerify : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT UserID,DataText, Status FROM DataEntry WHERE Status = 'Pending'";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvData.DataSource = dt;
                gvData.DataBind();
            }
        }

        protected void gvData_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Verify" || e.CommandName == "Reject")
            {
                string newStatus = e.CommandName == "Verify" ? "Verified" : "Rejected";
                int entryID = Convert.ToInt32(e.CommandArgument);

                string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    string query = "UPDATE DataEntry SET Status = @Status WHERE UserID = @UserID";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Status", newStatus);
                        cmd.Parameters.AddWithValue("@UserID", entryID);
                        cmd.ExecuteNonQuery();
                    }
                }
                LoadData();
            }
        }

        protected void btnSubmit_Click1(object sender, EventArgs e)
        {
            string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "INSERT INTO DataEntry (UserID, DataText) VALUES (@UserID, @DataText)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserID", txtUserID.Text);
                    cmd.Parameters.AddWithValue("@DataText", txtData.Text);
                    cmd.ExecuteNonQuery();
                    lblMessage.Text = "Data submitted!";
                    LoadData();
                }
            }
        }
    }
}
//CREATE TABLE DataEntry (
//    UserID INT ,
//    DataText NVARCHAR(255) NOT NULL,
//    Status NVARCHAR(20) DEFAULT 'Pending' -- ('Pending', 'Verified', 'Rejected'),
//);
