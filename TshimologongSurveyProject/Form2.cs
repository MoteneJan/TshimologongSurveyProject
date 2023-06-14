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
    public partial class Form2 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=AppSurvey;Integrated Security=True");
        public Form2()
        {
            InitializeComponent();
        }

        //Getting Selected response and conert to Number
        private int GetResponseValue(GroupBox groupBox)
        {
            foreach (RadioButton radioButton in groupBox.Controls)
            {
                if (radioButton.Checked)
                {
                    // Map the Likert scale responses to numeric values (1 to 5)
                    switch (radioButton.Text)
                    {
                        case "Strongly Agree":
                            return 5;
                        case "Agree":
                            return 4;
                        case "Neutral":
                            return 3;
                        case "Disagree":
                            return 2;
                        case "Strongly Disagree":
                            return 1;
                    }
                }
            }
            return 0; // Default value if no response is selected
        }

        private void bntSubmit_Click(object sender, EventArgs e)
        {
            if (txtSurname.Text.Length > 0 && txtFname.Text.Length > 0 && txtContactNum.Text.Length > 0 )
            {
                if (txtAge.Text.Length >= 5 || txtAge.Text.Length <= 120 )
                {                                            
                    try
                        {
                            con.Open();
                        // Get the selected responses from the Likert scale RadioButtons
                        int eatOutResponse = GetResponseValue(groupBoxEatOut);
                        int watchMoviesResponse = GetResponseValue(groupBoxMovies);
                        int watchTVResponse = GetResponseValue(groupBoxTV);
                        int listenToRadioResponse = GetResponseValue(groupBoxRadio);
                      
                        SqlCommand com = new SqlCommand("INSERT INTO TableSurvey (Surname, FirstNames, ContactNumber, Date,Age ,ItemValue , EatOutResponse, TVResponse,MovieResponse, RadioResponse) VALUES('" + txtSurname.Text + "' , '" + txtFname.Text + "' , '" + txtContactNum.Text + "' , '" + dateTimePicker1.Value + "' , '" + txtAge.Text + "', +" +
                            "@ItemValue, @EatOutResponse, @TVResponse, @MovieResponse, @RadioResponse)", con);

                        // Add a parameter for each selected item in the CheckedListBox
                        foreach (var selectedItem in chkFoodChoice.CheckedItems)
                        {
                            com.Parameters.Clear();
                            com.Parameters.AddWithValue("@ItemValue", selectedItem.ToString());
                        }

                            // Add parameters for each response
                        com.Parameters.AddWithValue("@EatOutResponse", eatOutResponse);
                        com.Parameters.AddWithValue("@MovieResponse", watchMoviesResponse);
                        com.Parameters.AddWithValue("@TVResponse", watchTVResponse);
                        com.Parameters.AddWithValue("@RadioResponse", listenToRadioResponse);

                        try
                        {
                            // Execute the SQL command
                            com.ExecuteNonQuery();

                                MessageBox.Show("Your Application is Successful!. " );
                                txtSurname.Clear();
                                txtFname.Clear();
                                txtContactNum.Clear();
                                dateTimePicker1.Value = DateTime.Now;
                                txtAge.Clear();

                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Your Application Failed!. " + ex);
                            }

                            con.Close();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Could not Connect to Database!. ");
                        }
                    
                }
                else
                {
                    MessageBox.Show("Age Should Range From 5 years to 120 Years! ");
                }
            }
            else
            {
                MessageBox.Show("Please Fill all the Fields!. ");
            }

            this.Hide();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
