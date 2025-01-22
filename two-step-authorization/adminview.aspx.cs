using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.two_step_authorization
{
    public partial class adminview : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadUsers();
                LoadRoles();
            }
        }

        private void LoadUsers()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT UserID, Username FROM A_Users", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                ddlUsers.DataSource = dt;
                ddlUsers.DataTextField = "Username";
                ddlUsers.DataValueField = "UserID";
                ddlUsers.DataBind();
            }
        }

        private void LoadRoles()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT RoleID, UserId FROM A_Users", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                ddlRoles.DataSource = dt;
                ddlRoles.DataTextField = "UserId";
                ddlRoles.DataValueField = "RoleID";
                ddlRoles.DataBind();
            }
        }

        protected void btnAssignRole_Click(object sender, EventArgs e)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "UPDATE A_Users SET RoleID=@RoleID WHERE UserID=@UserID";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@RoleID", ddlRoles.SelectedValue);
                    cmd.Parameters.AddWithValue("@UserID", ddlUsers.SelectedValue);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        protected void btnSavePermission_Click(object sender, EventArgs e)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "UPDATE RolePermissions SET CanView=@CanView, CanEdit=@CanEdit WHERE RoleID=@RoleID AND PageName=@PageName";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@CanView", chkView.Checked);
                    cmd.Parameters.AddWithValue("@CanEdit", chkEdit.Checked);
                    cmd.Parameters.AddWithValue("@RoleID", ddlRoles.SelectedValue);
                    cmd.Parameters.AddWithValue("@PageName", ddlPages.SelectedValue);
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}