using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace adminpanel
{
    public partial class AdminVerify : System.Web.UI.Page
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
                        LoadData();
                        break;

                    case "User":
                        adminPanel.Visible = false;
                        userPanel.Visible = true;
                        guestPanel.Visible = false;
                        LoadDatauser();
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

        private void LoadDatauser()
        {
            string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT UserID,DataText, Status FROM DataEntry WHERE Status = 'Rejected'";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvUser.DataSource = dt;
                gvUser.DataBind();
            }
        }



        protected void gvUser_RowCommand(object sender, GridViewCommandEventArgs e)
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



        protected void Button1_Click(object sender, EventArgs e)
        {
            string username = txtname.Text;
            string dataEntry = txtData.Text;

            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO UserEntries (UserName, DataEntry) VALUES (@UserName, @DataEntry)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserName", username);
                cmd.Parameters.AddWithValue("@DataEntry", dataEntry);
                //cmd.Parameters.AddWithValue("@CreatedBy", username);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }

            //lblMessage.Text = "Data submitted successfully!";
            txtname.Text = "";
            txtData.Text = "";
        }
    }
}