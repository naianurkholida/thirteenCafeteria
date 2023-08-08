using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace thirteenCafeteria
{
    public partial class addMenu : Form
    {
        SqlConnection connection;
        SqlCommand command;
        SqlDataAdapter dataAdapter;
        string sql;

        public addMenu()
        {
            InitializeComponent();
        }
        void connect()
        {
            sql = @"Data Source=NAYA\SQLEXPRESS;Initial Catalog=db_canteen;Integrated Security=true";
            connection = new SqlConnection(sql);
            if(connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            connect();
            try
            {
                sql = "INSERT INTO menu values ('" + txt_menu.Text + "','" + txt_harga.Text + "', '" + kategori.Text + "', '" + txt_foto.Text + "','" + txt_desc.Text + "') ";
                command = new SqlCommand(sql, connection);
                command.ExecuteNonQuery();
                AdminForm pindah = new AdminForm();
                pindah.Show();
                this.Visible = false;
            }
            catch {
                MessageBox.Show("gagal");
            
            }
            finally
            {
                connection.Close();
            }

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminForm pindah = new AdminForm();
            pindah.Show();
            this.Visible = false;
        }
        string path;
        private void button1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "JPG Files(*jpg)|*.jpg|JPEG Files(*.jpeg)|*.jpeg\" + \"PNG Files(*.png)|*.png|BITMAP Files(*.bmp)|*.bmp\" + \"TIFF Files(*.tiff)|*.tiff";
            dialog.FileName = "";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(dialog.FileName);
                path = Path.Combine(Application.StartupPath + "/gambar/", dialog.FileName);
                txt_foto.Text = path;
            }
        }

        private void addMenu_Load(object sender, EventArgs e)
        { 
            
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            DialogResult res;
            res = MessageBox.Show("apakah anda yakin akan menghapus data yang telah di isi?", "Reset", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                txt_menu.Clear();
                txt_harga.Clear();
                txt_foto.Clear();
                txt_desc.Clear();
                kategori.SelectedIndex = -1;
            }
            else
            {
                this.Show();
            }
           


            
        }

        private void txt_harga_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_harga_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}
