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
    public partial class Form1 : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=TECH-NB\SQLEXPRESS;Initial Catalog=Vehicle_DB;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
            textBox2.PasswordChar = '*';
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            register.ShowDialog();
        }

        private void Login_BTN_Click(object sender, EventArgs e)
        {
            Admin_Login _Admin = new Admin_Login();
            Client_Login _Client = new Client_Login();
            conn.Open();
            SqlCommand cmd = new SqlCommand($"Select * from User_TB where Username = '{textBox1.Text}' AND Password = '{textBox2.Text}'", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            conn.Close();
            string role = "";
            if (radioButton1.Checked)
                role = "Administrator";
            else
                role = "Client";
            SqlCommand admin = new SqlCommand($"Select Role from User_TB where Role = '{role}'", conn);
            if(!radioButton1.Checked && !radioButton2.Checked)
            {
                MessageBox.Show("Try Again And Select Role");
                this.Close();
            }
            if (role == "Administrator")
                _Admin.ShowDialog();
            else _Client.ShowDialog();
            this.Close();
        }

    }
}
