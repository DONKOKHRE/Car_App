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

namespace Car_App
{
    public partial class Register : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=TECH-NB\SQLEXPRESS;Initial Catalog=Vehicle_DB;Integrated Security=True");
        public Register()
        {
            InitializeComponent();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Admin_Register _Register = new Admin_Register();
            Client_Register _Register1 = new Client_Register();
            if (radioButton1.Checked)
            {
                _Register.ShowDialog();
            }
            else
            {
                _Register1.ShowDialog();
            }
            this.Close();
        }
    }
}
