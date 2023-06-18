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
        private const string connectionString = "Data Source=.;Initial Catalog=AppSurvey;Integrated Security=True";
        
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
            string query = $@"SELECT COUNT(*) AS TotalCount,AVG(age) AS AverageAge,MIN(age) AS YoungestAge,
                              MAX(age) AS OldestAge, (COUNT(CASE WHEN ItemValue = 'Pizza' THEN 1 END) / CAST(COUNT(*) AS FLOAT)) * 100 AS PizzaPercentage,
                              (COUNT(CASE WHEN ItemValue = 'Pasta' THEN 1 END) / CAST(COUNT(*) AS FLOAT)) * 100 AS PastaPercentage,
                              (COUNT(CASE WHEN ItemValue = 'Pap and Wors' THEN 1 END) / CAST(COUNT(*) AS FLOAT)) * 100 AS PapAndWorsPercentage, 
							  AVG(EatOutResponse) AS AverageRatingEatOut, AVG(TVResponse) AS AverageRatingTV, AVG(MovieResponse) AS AverageRatingMovies,
							  AVG(RadioResponse) AS AverageRatingRadio
                              FROM TableSurvey";

            using (SqlConnection connection = new SqlConnection(connectionString))
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
                        double pizzaPercentage = (double)reader.GetDouble(4);
                        double pastaPercentage = (double)reader.GetDouble(5);
                        double papAndWorsPercentage = (double)reader.GetDouble(6);
                        int averageRatingEatOut = (int)reader.GetInt32(7);
                        int averageRatingTV = (int)reader.GetInt32(7);
                        int averageRatingMovies = (int)reader.GetInt32(7);
                        int averageRatingRadio = (int)reader.GetInt32(7);

                        lstResults.Items.Add("Total number of survey: \t\t\t" + totalCount);
                        lstResults.Items.Add("Average Age: \t\t\t\t" + averageAge.ToString("0"));
                        lstResults.Items.Add("Youngest person who paricipated in survey: \t" + youngestAge);
                        lstResults.Items.Add("Oldest person who paricipated in survey: \t" + oldestAge);
                        lstResults.Items.Add(" ");
                        lstResults.Items.Add("Percentage of people who like pizza: \t\t" + pizzaPercentage.ToString("0.0") + "%");
                        lstResults.Items.Add("Percentage of people who like pasta: \t\t" + pastaPercentage.ToString("0.0") + "%");
                        lstResults.Items.Add("Percentage of people who like pap and wors: \t" + papAndWorsPercentage.ToString("0.0") + "%");
                        lstResults.Items.Add(" ");
                        lstResults.Items.Add("People like to Eat Out: \t\t\t" + averageRatingEatOut.ToString("0.0"));
                        lstResults.Items.Add("People like to watch Movies: \t\t\t" + averageRatingMovies.ToString("0.0"));
                        lstResults.Items.Add("People like to watch TV: \t\t\t" + averageRatingTV.ToString("0.0"));
                        lstResults.Items.Add("People like to listen to Radio: \t\t" + averageRatingRadio.ToString("0.0"));
                    }
                    reader.Close();
                }
            }
        }
    }
    
}
