using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.two_step_authorization
{
    public partial class _4_dropdown_select : System.Web.UI.Page
    {
        string connStr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCategory1();
            }
        }

        private void LoadCategory1()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT ID, Name FROM Category1", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                ddlCategory1.DataSource = dt;
                ddlCategory1.DataTextField = "Name";
                ddlCategory1.DataValueField = "ID";
                ddlCategory1.DataBind();
                ddlCategory1.Items.Insert(0, new ListItem("-- Select --", "0"));
            }
        }

        protected void ddlCategory1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCategory1.SelectedValue != "0")
            {
                LoadCategory2(int.Parse(ddlCategory1.SelectedValue));
                ddlCategory2.Visible = true;
            }
        }

        private void LoadCategory2(int category1Id)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT ID, Name FROM Category2 WHERE Category1ID = @Category1ID", conn);
                da.SelectCommand.Parameters.AddWithValue("@Category1ID", category1Id);
                DataTable dt = new DataTable();
                da.Fill(dt);

                ddlCategory2.DataSource = dt;
                ddlCategory2.DataTextField = "Name";
                ddlCategory2.DataValueField = "ID";
                ddlCategory2.DataBind();
                ddlCategory2.Items.Insert(0, new ListItem("-- Select --", "0"));
            }
        }

        protected void ddlCategory2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCategory2.SelectedValue != "0")
            {
                LoadCategory3(int.Parse(ddlCategory2.SelectedValue));
                ddlCategory3.Visible = true;
            }
        }

        private void LoadCategory3(int category2Id)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT ID, Name FROM Category3 WHERE Category2ID = @Category2ID", conn);
                da.SelectCommand.Parameters.AddWithValue("@Category2ID", category2Id);
                DataTable dt = new DataTable();
                da.Fill(dt);

                ddlCategory3.DataSource = dt;
                ddlCategory3.DataTextField = "Name";
                ddlCategory3.DataValueField = "ID";
                ddlCategory3.DataBind();
                ddlCategory3.Items.Insert(0, new ListItem("-- Select --", "0"));
            }
        }

        protected void ddlCategory3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCategory3.SelectedValue != "0")
            {
                LoadCategory4(int.Parse(ddlCategory3.SelectedValue));
                ddlCategory4.Visible = true;
            }
        }

        private void LoadCategory4(int category3Id)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT ID, Name FROM Category4 WHERE Category3ID = @Category3ID", conn);
                da.SelectCommand.Parameters.AddWithValue("@Category3ID", category3Id);
                DataTable dt = new DataTable();
                da.Fill(dt);

                ddlCategory4.DataSource = dt;
                ddlCategory4.DataTextField = "Name";
                ddlCategory4.DataValueField = "ID";
                ddlCategory4.DataBind();
                ddlCategory4.Items.Insert(0, new ListItem("-- Select --", "0"));
            }
        }

        protected void ddlCategory4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCategory4.SelectedValue != "0")
            {
                LoadGridView(int.Parse(ddlCategory4.SelectedValue));
                gvData.Visible = true;
            }
        }

        private void LoadGridView(int category4Id)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM FinalData WHERE Category4ID = @Category4ID", conn);
                da.SelectCommand.Parameters.AddWithValue("@Category4ID", category4Id);
                DataTable dt = new DataTable();
                da.Fill(dt);

                gvData.DataSource = dt;
                gvData.DataBind();
            }
        }
    }
}



//CREATE TABLE Category1 (
//    ID INT PRIMARY KEY IDENTITY(1,1),
//    Name NVARCHAR(50)
//);

//CREATE TABLE Category2 (
//    ID INT PRIMARY KEY IDENTITY(1,1),
//    Name NVARCHAR(50),
//    Category1ID INT FOREIGN KEY REFERENCES Category1(ID)
//);

//CREATE TABLE Category3 (
//    ID INT PRIMARY KEY IDENTITY(1,1),
//    Name NVARCHAR(50),
//    Category2ID INT FOREIGN KEY REFERENCES Category2(ID)
//);

//CREATE TABLE Category4 (
//    ID INT PRIMARY KEY IDENTITY(1,1),
//    Name NVARCHAR(50),
//    Category3ID INT FOREIGN KEY REFERENCES Category3(ID)
//);

//CREATE TABLE FinalData (
//    ID INT PRIMARY KEY IDENTITY(1,1),
//    DataValue NVARCHAR(100),
//    Category4ID INT FOREIGN KEY REFERENCES Category4(ID)
//);
