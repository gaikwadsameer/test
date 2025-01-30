using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using OfficeOpenXml;

namespace WebApplication1.two_step_authorization
{
    public partial class xl_duplicates_SQL : System.Web.UI.Page
    {
        private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            lblMessage.Text = ""; // Clear previous messages



            if (FileUpload1.HasFile)
            {
                string filePath = Path.Combine(Server.MapPath("~/Uploads/"), FileUpload1.FileName);
                FileUpload1.SaveAs(filePath);

                DataTable dt = ReadExcelFile(filePath);
                GridView1.DataSource = dt;
                GridView1.DataBind();

                int insertedRecords = InsertDataWithCheck(dt);
                lblMessage.Text = $"Upload Successful. {insertedRecords} new records inserted.";
            }
            else
            {
                lblMessage.Text = "Please select an Excel file to upload.";
            }
        }

        private DataTable ReadExcelFile(string filePath)
        {
            DataTable dt = new DataTable();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            foreach (DataColumn col in dt.Columns)
            {
                System.Diagnostics.Debug.WriteLine($"Column: {col.ColumnName}");
            }

            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                int colCount = worksheet.Dimension.End.Column;
                int rowCount = worksheet.Dimension.End.Row;

                // Get column names from the first row
                for (int col = 1; col <= colCount; col++)
                {
                    string columnName = worksheet.Cells[1, col].Value?.ToString();
                    if (string.IsNullOrEmpty(columnName)) columnName = $"Column{col}";
                    dt.Columns.Add(columnName);
                }

                // Read data from row 2 onwards
                for (int row = 2; row <= rowCount; row++)
                {
                    DataRow dr = dt.NewRow();
                    for (int col = 1; col <= colCount; col++)
                    {
                        dr[col - 1] = worksheet.Cells[row, col].Value?.ToString();
                    }
                    dt.Rows.Add(dr);
                }
            }

            return dt;
        }

        private int InsertDataWithCheck(DataTable dt)
        {
            int insertedCount = 0;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                foreach (DataRow row in dt.Rows)
                {
                    if (row["UniqueColumn"] == DBNull.Value || string.IsNullOrWhiteSpace(row["UniqueColumn"].ToString()))
                    {
                        continue; // Skip rows where UniqueColumn is NULL or empty
                    }

                    string uniqueValue = row["UniqueColumn"].ToString();
                    //string uniqueValue = row["ActualExcelColumnName"].ToString();
                    // Check for duplicate records in SQL
                    string checkQuery = "SELECT COUNT(1) FROM YourTable WHERE UniqueColumn = @UniqueValue";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, con))
                    {
                        checkCmd.Parameters.AddWithValue("@UniqueValue", uniqueValue);
                        int exists = (int)checkCmd.ExecuteScalar();

                        if (exists == 0) // Insert only if not duplicate
                        {
                            string insertQuery = "INSERT INTO YourTable (UniqueColumn, Column1, Column2) VALUES (@UniqueValue, @Col1, @Col2)";
                            using (SqlCommand insertCmd = new SqlCommand(insertQuery, con))
                            {
                                insertCmd.Parameters.AddWithValue("@UniqueValue", uniqueValue);
                                insertCmd.Parameters.AddWithValue("@Col1", row["Column1"]);
                                insertCmd.Parameters.AddWithValue("@Col2", row["Column2"]);
                                insertCmd.ExecuteNonQuery();
                            }
                        }
                    }
                }

            }

            return insertedCount;
        }
    }
}
//package manager console install
//Install-Package EPPlus

//Install-Package ExcelDataReader
//Install-Package ExcelDataReader.DataSet



//CREATE TABLE[dbo].[YourTable] (
//    [ID][int] IDENTITY(1, 1) NOT NULL,

//    [UniqueColumn] [nvarchar] (100) NULL,

//    [Column1] [nvarchar] (255) NULL,

//    [Column2] [nvarchar] (255) NULL,
//PRIMARY KEY CLUSTERED 
//(

//    [ID] ASC
//)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON[PRIMARY],
//UNIQUE NONCLUSTERED
//(
//    [UniqueColumn] ASC
//)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON[PRIMARY]
//) ON[PRIMARY]
//GO