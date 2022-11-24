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
    public partial class Client_Login : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=TECH-NB\SQLEXPRESS;Initial Catalog=Vehicle_DB;Integrated Security=True");
        public Client_Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand($"select * from Vehicles_TB", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }
        private float Price_Get()
        {
            float price = 0;
            conn.Open();
            SqlCommand cmd1 = new SqlCommand($"select price from Vehicles_TB where Id = '{textBox2.Text}'", conn);
            SqlDataAdapter sqlData = new SqlDataAdapter(cmd1);
            DataTable dt = new DataTable();
            foreach (DataRow item in dt.Rows)
            {
                price = Convert.ToSingle(item["price"]);
            }
            return price;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand($"select Name,Surname,Money_OnAccount from Client_TB where Username = '{textBox1.Text}' ", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView2.DataSource = dt;
            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand($"delete from Vehicles_TB where Id = '{textBox2.Text}'", conn);
            SqlCommand cmd1 = new SqlCommand($"update Client_TB Set Money_OnAccount = Money_OnAccount - '{Price_Get()}'", conn);
            SqlCommand cmd2 = new SqlCommand($"update User_TB Set Money = Money + '{Price_Get()}'", conn);
            cmd.ExecuteNonQuery();
            cmd1.ExecuteNonQuery();
            cmd2.ExecuteNonQuery();
            conn.Close();
        }
    }
}
