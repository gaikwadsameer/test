using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Data.SqlClient;

namespace WebApplication1.two_step_authorization
{
    public partial class MMM_YYYY_dropdown : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<MonthYearDropdown> months = GetFinancialYearMonths();
                dropdownMonthYear.DataSource = months;
                dropdownMonthYear.DataTextField = "DisplayValue";
                dropdownMonthYear.DataValueField = "NumericValue";
                dropdownMonthYear.DataBind();

                // Optionally add a default item
                dropdownMonthYear.Items.Insert(0, new ListItem("Select Month-Year", ""));
            }
        }

        public class MonthYearDropdown
        {
            public string DisplayValue { get; set; } // For dropdown display
            public int NumericValue { get; set; }    // For database storage
        }

        public List<MonthYearDropdown> GetFinancialYearMonths()
        {
            List<MonthYearDropdown> dropdownItems = new List<MonthYearDropdown>();
            DateTime currentDate = DateTime.Now;

            // Determine financial year range
            int startYear = currentDate.Month >= 4 ? currentDate.Year : currentDate.Year - 1; // FY starts in April
            int endYear = startYear + 1;

            // Generate months from April (startYear) to March (endYear)
            DateTime startDate = new DateTime(startYear, 4, 1); // April 1st of startYear
            for (int i = 0; i < 12; i++)
            {
                DateTime month = startDate.AddMonths(i);
                dropdownItems.Add(new MonthYearDropdown
                {
                    DisplayValue = month.ToString("MMM yyyy", CultureInfo.InvariantCulture),
                    NumericValue = month.Month + month.Year * 100 // E.g., 202504 for April 2025
                });
            }

            return dropdownItems;
        }



        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int selectedValue;
            if (int.TryParse(dropdownMonthYear.SelectedValue, out selectedValue))
            {

               

                    string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                    string query = "INSERT INTO MMMYYYY (MonthYearValue) VALUES (@Value)";

                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Value", selectedValue);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                lblMessage.Text = "Value inserted successfully.";
            }
            else
            {
                lblMessage.Text = "Please select a valid month-year.";
            }
        }


    }
}