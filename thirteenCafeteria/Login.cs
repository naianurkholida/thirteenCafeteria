using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security;

namespace thirteenCafeteria
{
    public partial class Login : Form
    {
        SqlConnection connection;
        SqlCommand command;
        SqlDataAdapter dataAdapter;
        DataSet dataSet;
        string sql;
        public Login()
        {
            InitializeComponent();
        }
        void koneksi()
        {
            sql = @"Data Source=NAYA\SQLEXPRESS;Initial Catalog=db_canteen;Integrated Security=true";
            connection= new SqlConnection(sql);
            if((connection.State == ConnectionState.Closed) )
            {
                connection.Open();
            }
        }
        

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Form1 pindah = new Form1();
            pindah.Show();
            this.Visible= false;
        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            koneksi();
            string username, password;
            username = txt_user.Text;
            password = txt_pw.Text;
            

            try
            {
                dataAdapter = new SqlDataAdapter("SELECT * FROM users WHERE username ='" + txt_user.Text + "' AND password = '" + txt_pw.Text + "'", connection);

                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                
                if(dataTable.Rows.Count > 0)
                {
                    username = txt_user.Text;
                    password = txt_pw.Text;

                    AdminForm pindah = new AdminForm();
                    pindah.Show();
                    this.Visible = false;
                }
                else
                {
                    MessageBox.Show("Login gagal", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_user.Clear();
                    txt_pw.Clear();

                    txt_user .Focus();
                }
                
            }
            catch
            {
                MessageBox.Show("Login gagal");
            }
            finally { 
                connection.Close(); 
            }

           
        }

        private void txt_user_TextChanged(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {
           
        }
    }
}
