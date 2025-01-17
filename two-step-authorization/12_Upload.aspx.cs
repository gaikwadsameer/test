using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class _12_Upload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (fileUpload.HasFile)
            {
                string employeeName = txtEmployeeName.Text;
                byte[] fileData = fileUpload.FileBytes;
                string fileName = Path.GetFileName(fileUpload.FileName);
                string contentType = fileUpload.PostedFile.ContentType;


                string connStr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    string query = "INSERT INTO PDF_EmployeeDocuments (EmployeeName, Document, DocumentName, ContentType) VALUES (@EmployeeName, @Document, @DocumentName, @ContentType)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@EmployeeName", employeeName);
                        cmd.Parameters.AddWithValue("@Document", fileData);
                        cmd.Parameters.AddWithValue("@DocumentName", fileName);
                        cmd.Parameters.AddWithValue("@ContentType", contentType);
                        //conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }

                //lblMessage.Text = "File uploaded successfully.";
            }
            //else
            //{
                //lblMessage.Text = "Please select a file to upload.";
            //}
        }
    }
//}