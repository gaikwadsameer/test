using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO.Compression;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _2_XLSL_1
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Install-Package EPPlus
        }

        protected void btnCompare_Click(object sender, EventArgs e)
        {
            if (!FileUpload1.HasFile || !FileUpload2.HasFile)
            {
                lblMessage.Text = "Please upload both Excel files.";
                return;
            }

            try
            {
                // Save uploaded files to server
                string filePath1 = Path.Combine(Server.MapPath("~/Uploads"), FileUpload1.FileName);
                string filePath2 = Path.Combine(Server.MapPath("~/Uploads"), FileUpload2.FileName);
                Directory.CreateDirectory(Server.MapPath("~/Uploads"));

                FileUpload1.SaveAs(filePath1);
                FileUpload2.SaveAs(filePath2);

                // Read and compare Excel files
                DataTable dt1 = ReadExcelFile(filePath1);
                DataTable dt2 = ReadExcelFile(filePath2);
                DataTable matchedData = CompareFirstNameColumn(dt1, dt2);

                // Generate new Excel file with matched data
                string resultFilePath = Path.Combine(Server.MapPath("~/Downloads"), "MatchedData.xlsx");
                Directory.CreateDirectory(Server.MapPath("~/Downloads"));
                GenerateExcelFile(matchedData, resultFilePath);

                // Provide download link
                DownloadLink.NavigateUrl = "~/Downloads/MatchedData.xlsx";
                DownloadLink.Visible = true;
                lblMessage.Text = "Comparison completed. Click the link to download.";
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error: " + ex.Message;
            }
        }

        private DataTable ReadExcelFile(string filePath)
        {
            DataTable dt = new DataTable();
            using (ExcelPackage package = new ExcelPackage(new FileInfo(filePath)))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                foreach (var firstRowCell in worksheet.Cells[1, 1, 1, worksheet.Dimension.End.Column])
                    dt.Columns.Add(firstRowCell.Text);

                for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
                {
                    DataRow dr = dt.NewRow();
                    for (int col = 1; col <= worksheet.Dimension.End.Column; col++)
                        dr[col - 1] = worksheet.Cells[row, col].Text;
                    dt.Rows.Add(dr);
                }
            }
            return dt;
        }

        private DataTable CompareFirstNameColumn(DataTable dt1, DataTable dt2)
        {
            var matchedRows = dt1.AsEnumerable()
                .Join(dt2.AsEnumerable(),
                      row1 => row1.Field<string>("id"),
                      row2 => row2.Field<string>("id"),
                      (row1, row2) => row1)
                .CopyToDataTable();

            return matchedRows;
        }

        private void GenerateExcelFile(DataTable dt, string filePath)
        {
            using (ExcelPackage package = new ExcelPackage())
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("MatchedData");

                // Add column names
                for (int col = 0; col < dt.Columns.Count; col++)
                    worksheet.Cells[1, col + 1].Value = dt.Columns[col].ColumnName;

                // Add rows
                for (int row = 0; row < dt.Rows.Count; row++)
                    for (int col = 0; col < dt.Columns.Count; col++)
                        worksheet.Cells[row + 2, col + 1].Value = dt.Rows[row][col];

                package.SaveAs(new FileInfo(filePath));
            }
        }
    }
}