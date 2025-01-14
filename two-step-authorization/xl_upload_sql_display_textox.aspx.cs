using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using ExcelDataReader;

namespace WebApplication1.two_step_authorization
{
    public partial class xl_upload_sql_display_textox : System.Web.UI.Page
    {
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                // Save the uploaded file temporarily
                string filePath = Path.Combine(Server.MapPath("~/Uploads"), FileUpload1.FileName);
                FileUpload1.SaveAs(filePath);

                // Read Excel file
                DataTable dataTable = ReadExcel(filePath);

                // Save data to MSSQL database
                SaveToDatabase(dataTable);

                // Display specific data in textboxes
                if (dataTable.Rows.Count > 0)
                {
                    txtData1.Text = dataTable.Rows[0]["Column1"].ToString();
                    txtData2.Text = dataTable.Rows[0]["Column2"].ToString();
                    //txtData3.Text = dataTable.Rows[0]["Column3"].ToString();
                }

                // Clean up the uploaded file
                File.Delete(filePath);
            }
        }

        private DataTable ReadExcel(string filePath)
        {
            DataTable dt;
            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = _ => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true
                        }
                    });
                    dt = result.Tables[0];
                }
            }
            return dt;
        }

        private void SaveToDatabase(DataTable dataTable)
        {

            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
              
                foreach (DataRow row in dataTable.Rows)
                {
                    string query = "INSERT INTO YourTable (Column1, Column2) VALUES (@Column1, @Column2)";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Column1", row["Column1"]);
                        cmd.Parameters.AddWithValue("@Column2", row["Column2"]);
                        //cmd.Parameters.AddWithValue("@Column3", row["Column3"]);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}