using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Script.Serialization;
using System.Text;
using System.Web.UI;

namespace WebApplication1.two_step_authorization
{
    public partial class Chart : System.Web.UI.Page
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
            string connString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
  // Update with your DB connection
            string query = "SELECT * FROM FinancialData ORDER BY Year ASC";

            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }

            GridView1.DataSource = dt;
            GridView1.DataBind();

            // Prepare Data for Chart.js
            StringBuilder labels = new StringBuilder();
            StringBuilder gstPayments = new StringBuilder();
            StringBuilder gstReturns = new StringBuilder();
            StringBuilder taxPayments = new StringBuilder();
            StringBuilder taxReturns = new StringBuilder();

            labels.Append("[");
            gstPayments.Append("[");
            gstReturns.Append("[");
            taxPayments.Append("[");
            taxReturns.Append("[");

            foreach (DataRow row in dt.Rows)
            {
                labels.Append("'" + row["Year"] + "',");
                gstPayments.Append(row["GST_Payment"] + ",");
                gstReturns.Append(row["GST_Return"] + ",");
                taxPayments.Append(row["Tax_Payment"] + ",");
                taxReturns.Append(row["Tax_Return"] + ",");
            }

            labels.Append("]");
            gstPayments.Append("]");
            gstReturns.Append("]");
            taxPayments.Append("]");
            taxReturns.Append("]");

            string script = "loadChart(" + labels.ToString() + "," + gstPayments.ToString() + "," +
                            gstReturns.ToString() + "," + taxPayments.ToString() + "," + taxReturns.ToString() + ");";
            ScriptManager.RegisterStartupScript(this, GetType(), "loadChartScript", script, true);
        }

    }
}




//CREATE TABLE FinancialData (
//    ID INT IDENTITY(1,1) PRIMARY KEY,
//    Year INT,
//    GST_Payment DECIMAL(18,2),
//    GST_Return DECIMAL(18,2),
//    Tax_Payment DECIMAL(18,2),
//    Tax_Return DECIMAL(18,2)
//);

//--Insert sample data for 5 years
//INSERT INTO FinancialData (Year, GST_Payment, GST_Return, Tax_Payment, Tax_Return)
//VALUES 
//(2020, 5000, 4500, 7000, 6500),
//(2021, 5200, 4700, 7200, 6700),
//(2022, 5400, 4900, 7400, 6900),
//(2023, 5600, 5100, 7600, 7100),
//(2024, 5800, 5300, 7800, 7300);

//select* from FinancialData