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
    public partial class Veh_Add : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=TECH-NB\SQLEXPRESS;Initial Catalog=Vehicle_DB;Integrated Security=True");
        public Veh_Add()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand($"Insert Into Vehicles_TB(RentOrSell,Manufacturer,Model,Category,Year,Price,Engine,Customs_Clearance,Technical_Inspection) values ('{comboBox1.Text}','{textBox2.Text}','{textBox3.Text}', '{comboBox2.Text}',{comboBox3.Text},{textBox6.Text},{textBox7.Text},'{comboBox4.Text}','{comboBox5.Text}') ", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
