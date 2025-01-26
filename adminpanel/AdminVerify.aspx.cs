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
                LoadData();
                if (string.IsNullOrEmpty(userType))
                {
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

        private void LoadData()
        {
            string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {

                conn.Open();
                string query = "";

                if (Session["userType"].ToString() == "Admin")
                {
                    query = "SELECT * FROM DataEntry";
                }
                else if (Session["userType"].ToString() == "User")
                {
                    query = "SELECT * FROM DataEntry WHERE Status IN ('Entry', 'Pending')";
                }
                else
                {
                    query = "SELECT * FROM DataEntry WHERE Status = 'Verified'";
                }

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvData.DataSource = dt;
                gvData.DataBind();
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
    }
}