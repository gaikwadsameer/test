using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class _12_Download : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnDownload_Click(object sender, EventArgs e)
        {
            int documentId;
            if (int.TryParse(txtDocumentId.Text, out documentId))
            {
                string connStr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    string query = "SELECT EmployeeName, Document, DocumentName, ContentType FROM PDF_EmployeeDocuments WHERE Id = @Id";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", documentId);

                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string employeeName = reader["EmployeeName"].ToString();
                                byte[] fileData = (byte[])reader["Document"];
                                string fileName = reader["DocumentName"].ToString();
                                string contentType = reader["ContentType"].ToString();

                                Response.Clear();
                                Response.ContentType = contentType;
                                Response.AddHeader("Content-Disposition", "attachment; filename=" + fileName);
                                Response.BinaryWrite(fileData);
                                Response.End();
                            }
                            else
                            {
                                lblMessage.Text = "Document not found.";
                            }
                        }
                        conn.Close();
                    }
                }
            }
            else
            {
                lblMessage.Text = "Please enter a valid Document ID.";
            }
        }
    }
}