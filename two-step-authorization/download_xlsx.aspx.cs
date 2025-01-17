using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace WebApplication1.two_step_authorization
{
    public partial class download_xlsx : System.Web.UI.Page
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid(); // Load default data
            }
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void BindGrid()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM EmployeesLoctCate WHERE JoinDate BETWEEN @FromDate AND @ToDate";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FromDate", txtFromDate.Text);
                    cmd.Parameters.AddWithValue("@ToDate", txtToDate.Text);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
            }
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            ExportToExcel();
        }

        private void ExportToExcel()
        {
            using (ExcelPackage excel = new ExcelPackage())
            {
                ExcelWorksheet ws = excel.Workbook.Worksheets.Add("Sheet1");

                // Fetching Data from GridView
                DataTable dt = new DataTable();
                foreach (TableCell cell in GridView1.HeaderRow.Cells)
                {
                    dt.Columns.Add(cell.Text);
                }

                foreach (GridViewRow row in GridView1.Rows)
                {
                    DataRow dr = dt.NewRow();
                    for (int i = 0; i < row.Cells.Count; i++)
                    {
                        dr[i] = row.Cells[i].Text;
                    }
                    dt.Rows.Add(dr);
                }

                ws.Cells["A1"].LoadFromDataTable(dt, true);

                // Save the file
                string fileName = "Report_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";
                string filePath = Server.MapPath("~/Exports/") + fileName;

                File.WriteAllBytes(filePath, excel.GetAsByteArray());

                // Download the file
                Response.Clear();
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment; filename=" + fileName);
                Response.WriteFile(filePath);
                Response.End();
            }
        }
    }
}
//Install-Package EPPlus