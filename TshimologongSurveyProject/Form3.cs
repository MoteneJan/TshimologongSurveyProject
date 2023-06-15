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
        private string tableName = "TableSurvey";
        private string ageColumnName = "Age";
        private string pizzaColumnName = "ItemValue";
        private string pastaColumnName = "ItemValue";
        private string papAndWorsColumnName = "ItemValue";
        private string eatOutColumnName = "EatOutResponse";
        private string tvColumnName = "TVResponse";
        private string moviesColumnName = "MovieResponse";
        private string radioColumnName = "RadioResponse";
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
            string query = $@"SELECT COUNT(*) AS TotalCount,AVG({ageColumnName}) AS AverageAge,MIN({ageColumnName}) AS YoungestAge,
                              MAX({ageColumnName}) AS OldestAge, (COUNT(CASE WHEN {pizzaColumnName} = 'Yes' THEN 1 END) / CAST(COUNT(*) AS FLOAT)) * 100 AS PizzaPercentage,
                              (COUNT(CASE WHEN {pastaColumnName} = 'Yes' THEN 1 END) / CAST(COUNT(*) AS FLOAT)) * 100 AS PastaPercentage,
                              (COUNT(CASE WHEN {papAndWorsColumnName} = 'Yes' THEN 1 END) / CAST(COUNT(*) AS FLOAT)) * 100 AS PapAndWorsPercentage,
                              AVG({eatOutColumnName}) AS AverageRatingEatOut, AVG({tvColumnName}) AS AverageRatingTV,AVG({moviesColumnName}) AS AverageRatingMovies,
                              AVG({radioColumnName}) AS AverageRatingRadio
                              FROM {tableName}";

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
                        lstResults.Items.Add("\nPercentage of people who like pizza: \t\t" + pizzaPercentage.ToString("0.0") + "%");
                        lstResults.Items.Add("\nPercentage of people who like pasta: \t\t" + pastaPercentage.ToString("0.0") + "%");
                        lstResults.Items.Add("\nPercentage of people who like pap and wors: \t" + papAndWorsPercentage.ToString("0.0") + "%");
                        lstResults.Items.Add("\nPeople like to Eat Out: \t\t\t" + averageRatingEatOut.ToString("0.0"));
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
