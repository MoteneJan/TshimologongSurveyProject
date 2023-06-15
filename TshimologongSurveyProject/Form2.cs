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
                        int eatOutResponse = GetEatOutResponseValue(groupBoxEatOut);
                        int watchMoviesResponse = GetMoviesResponseValue(groupBoxMovies);
                        int watchTVResponse = GetTVResponseValue(groupBoxTV);
                        int listenToRadioResponse = GetRadioResponseValue(groupBoxRadio);
                      
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
                                this.Hide();

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
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
        //Getting Selected response and conert to Number
        private int GetEatOutResponseValue(GroupBox groupBoxEatOut)
        {
            foreach (RadioButton radioButton in groupBoxEatOut.Controls)
            {
                if (radioButton1.Checked)
                {
                    return 1;
                }
                else if (radioButton5.Checked)
                {
                    return 2;
                }
                else if (radioButton2.Checked)
                {
                    return 3;
                }
                else if (radioButton3.Checked)
                {
                    return 4;
                }
                else if (radioButton4.Checked)
                {
                    return 5;
                }

            }
            return 0;
        }

        private int GetTVResponseValue(GroupBox groupBoxTV)
        {
            foreach (RadioButton radioButton in groupBoxEatOut.Controls)
            {
                if (radioButton10.Checked)
                {
                    return 1;
                }
                else if (radioButton6.Checked)
                {
                    return 2;
                }
                else if (radioButton9.Checked)
                {
                    return 3;
                }
                else if (radioButton8.Checked)
                {
                    return 4;
                }
                else if (radioButton7.Checked)
                {
                    return 5;
                }
            }
            return 0;
        }

        private int GetMoviesResponseValue(GroupBox groupBoxMovies)
        {
            foreach (RadioButton radioButton in groupBoxEatOut.Controls)
            {
                if (radioButton15.Checked)
                {
                    return 1;
                }
                else if (radioButton11.Checked)
                {
                    return 2;
                }
                else if (radioButton14.Checked)
                {
                    return 3;
                }
                else if (radioButton13.Checked)
                {
                    return 4;
                }
                else if (radioButton12.Checked)
                {
                    return 5;
                }

            }
            return 0;
        }
        private int GetRadioResponseValue(GroupBox groupBoxRadio)
        {
            foreach (RadioButton radioButton in groupBoxEatOut.Controls)
            {
                if (radioButton20.Checked)
                {
                    return 1;
                }
                else if (radioButton16.Checked)
                {
                    return 2;
                }
                else if (radioButton19.Checked)
                {
                    return 3;
                }
                else if (radioButton18.Checked)
                {
                    return 4;
                }
                else if (radioButton17.Checked)
                {
                    return 5;
                }

            }
            return 0; // Default value if no response is selected
        }
    }
}
