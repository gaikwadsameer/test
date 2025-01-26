using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace adminpanel
{
    public partial class gridview_button : System.Web.UI.Page
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
                string query = "SELECT UserID,Username,Password,UserType FROM Users_type";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvdata.DataSource = dt;
                gvdata.DataBind();
            }
        }

        protected void gvdata_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "add" || e.CommandName == "deletes")
            {
                string newStatus = e.CommandName == "add" ? "adds" : "deletess";
                int entryID = Convert.ToInt32(e.CommandArgument);

                string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    string query = "UPDATE Users_type SET UserType = @UserType WHERE Password = @Password";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserType", newStatus);
                        cmd.Parameters.AddWithValue("@Password", entryID);
                        cmd.ExecuteNonQuery();
                    }
                }
                LoadData();
            }
        }
    }
}