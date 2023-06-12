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
                        SqlCommand com = new SqlCommand("INSERT INTO TableSurvey VALUES('" + txtSurname.Text + "' , '" + txtFname.Text + "' , '" + txtContactNum.Text + "' , '" + dateTimePicker1.Value + "' , '" + txtAge.Text + "')", con);

                        try
                        {
                            com.ExecuteNonQuery();

                            MessageBox.Show("Your Application is Successful!. ");
                            txtSurname.Clear();
                            txtFname.Clear();
                            txtContactNum.Clear();
                            dateTimePicker1.Value = DateTime.Now;
                            txtAge.Clear();

                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Your Application Failed!. ");
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

        private void GetSelectedFoodChoice()
        {
            
            foreach (string s in chkFoodChoice.CheckedItems)
                chkFoodChoice.Items.Add(s);

        }

    }
}
