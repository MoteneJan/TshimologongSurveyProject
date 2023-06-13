using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TshimologongSurveyProject
{
    public partial class Form3 : Form
    {
        private const string con = "Data Source=.;Initial Catalog=AppSurvey;Integrated Security=True";
        //private string ageColumNamee = "age";
        public Form3()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Hide();           
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            string query = $@"SELECT COUNT(*) AS TotalCount,
                                    AVG(Age) AS AverageAge,
                                    MIN(Age) AS YoungestAge,
                                    MAX(Age) AS OldestAge
                             FROM TableSurvey";

            using (SqlConnection connection = new SqlConnection(con))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        int totalCount = reader.GetInt32(0);
                        int averageAge = reader.GetInt32(1);
                        int youngestAge = reader.GetInt32(2);
                        int oldestAge = reader.GetInt32(3);

                        lstResults.Items.Add("Total Count: \t\t" + totalCount);
                        lstResults.Items.Add("Average Age: \t\t" + averageAge);
                        lstResults.Items.Add("Youngest Age: \t\t" + youngestAge);
                        lstResults.Items.Add("Oldest Age: \t\t" + oldestAge);
                    }

                    reader.Close();
                }
            }

        }
    }
}
