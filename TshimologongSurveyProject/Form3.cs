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
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=DB_Student;Integrated Security=True");
        public Form3()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            
        }
    }
}
