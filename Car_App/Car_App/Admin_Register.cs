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
    public partial class Admin_Register : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=TECH-NB\SQLEXPRESS;Initial Catalog=Vehicle_DB;Integrated Security=True");
        public Admin_Register()
        {
            InitializeComponent();
        }

        private bool Check_User()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand($"select * from User_TB where Username = '{textBox1.Text}'", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            conn.Close();
            adapter.Fill(dt);
            if (dt.Rows.Count > 0)
                return false;
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
        string role = "Administrator";
        if (Check_User())
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand($"Insert Into User_TB(Username,Password,Role) values('{textBox1.Text}', '{textBox2.Text}','{role}')' ", conn);
            cmd.ExecuteNonQuery();
                conn.Close();
        }
        this.Close();
    }
}
}
