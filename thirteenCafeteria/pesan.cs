using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;

namespace thirteenCafeteria
{
    public partial class pesan : Form
    {
        SqlConnection connection;
        SqlCommand command;
        SqlDataAdapter dataAdapter;
        string sql;
        public pesan()
        {
            InitializeComponent();
        }
        void connect()
        {
            sql = @"Data Source=NAYA\SQLEXPRESS;Initial Catalog=db_canteen;Integrated Security=true";
            connection = new SqlConnection(sql);
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
        }
        string connectionString = @"Data Source=NAYA\SQLEXPRESS;Initial Catalog=db_canteen;Integrated Security=true";
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_reset_Click(object sender, EventArgs e)
        {

        }

        private void label_total_Click(object sender, EventArgs e)
        {

        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int krng = int.Parse(txt_jumlah.Text);
            krng--;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(int.Parse(txt_jumlah.Text) == 0)
            {
                btn_kurang.Enabled = true;
            }

        }

        private void txt_jumlah_TextChanged(object sender, EventArgs e)
        {
            if(int.Parse(txt_jumlah.Text) == 0 )
            {
                btn_kurang.Enabled = false;
            }
        }

        private void btn_kembali_Click(object sender, EventArgs e)
        {
            Form1 pindah = new Form1();
            pindah.Show();
            this.Visible = false;
        }
        private Control CloneControl(Control originalControl)
        {
            Control clonedControl = (Control)Activator.CreateInstance(originalControl.GetType());
            clonedControl.Name = originalControl.Name;
            clonedControl.Text = originalControl.Text;
            clonedControl.Size = originalControl.Size;
            clonedControl.Location = originalControl.Location;

            if(originalControl is Panel originalPanel)
            {
                foreach(Control innerControl in originalPanel.Controls)
                {
                    clonedControl.Controls.Add(CloneControl(innerControl));
                }
            }

            return clonedControl;

        }
        private GroupBox CloneGroupBox(GroupBox original)
        {
            GroupBox clonedGroupBox = (GroupBox)CloneControl(original);
            foreach (Control control in original.Controls)
            {

                
                clonedGroupBox.Controls.Add(CloneControl(control));
            }

            return clonedGroupBox;
        }
        private void CloneGroupBoxesInPanel(Panel panel_tengah)
        {
            foreach(Control control in panel_tengah.Controls)
            {
                if (control is GroupBox groupBox)
                {
                    GroupBox clonedGroupBox = CloneGroupBox(groupBox);
                    clonedGroupBox.Top += panel_tengah.Bottom + 10; // Geser ke bawah sejauh 10px dari `sourcePanel`

                    this.Controls.Add(clonedGroupBox);  // Tambahkan ke Form
                }
            }
        }



        private void LoadDataAndDuplicateGroupBox()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT nm_menu, harga, picture FROM menu";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                int yOffset = 10;
                GroupBox originalGroupBox = panel_tengah.Controls.OfType<GroupBox>().FirstOrDefault();

                while (reader.Read())
                {
                    
                    if (originalGroupBox != null)
                    {
                        GroupBox clonedGroupBox = CloneGroupBox(originalGroupBox);

                        Label menuLabel = clonedGroupBox.Controls["txt_menu"] as Label;
                        if(menuLabel != null)
                        {
                            menuLabel.Text = reader["nm_menu"].ToString();
                            menuLabel.Size = new Size(106, 39);
                            menuLabel.Text = menuLabel.Text;
                            menuLabel.Location = menuLabel.Location;
                            menuLabel.AutoSize = true;
                            menuLabel.Font = new Font(txt_menu.Font, FontStyle.Bold);
                        }

                        Panel hargaPanel = clonedGroupBox.Controls["panel_harga"] as Panel;
                        if (hargaPanel != null)
                        {
                            Label hargaLabel = hargaPanel.Controls["txt_harga"] as Label;
                            if(hargaLabel != null)
                            {
                                hargaLabel.Text = reader["harga"].ToString();
                                hargaLabel.AutoSize = true;
                            }
                            
                        }

                        Panel catatanPanel = clonedGroupBox.Controls["panel_catatan"] as Panel;
                        if (catatanPanel != null)
                        {
                            TextBox catatanTxt = catatanPanel.Controls["txt_catatan"] as TextBox;
                            if(catatanTxt != null)
                            {
                                catatanTxt.Multiline= true;
                            }
                        }
                        PictureBox pictureBox = clonedGroupBox.Controls["picture"] as PictureBox;
                        string imagePath = reader["picture"].ToString();
                        if(!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
                        {
                            pictureBox.Image = Image.FromFile(imagePath);
                            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                        }

                        clonedGroupBox.Top = yOffset;
                        panel_tengah.Controls.Add(clonedGroupBox);
                        yOffset += clonedGroupBox.Height + 10;
                    }
                   


                }
                connection.Close();


            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void pesan_Load(object sender, EventArgs e)
        {
            //groupBox2.Controls.Add()
            LoadDataAndDuplicateGroupBox();
            //GroupBox groupBox = CloneGroupBox(gpMenu);
            //this.Controls.Add(groupBox);
            //CloneGroupbox cl = new CloneGroupbox();
            /*using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                string query = $"SELECT * FROM menu";

                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection)) // Change 'connection' to 'sqlConnection'
                {
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            GroupBox groupBox = cl.clone(gpMenu, reader["nm_menu"].ToString(), reader["harga"].ToString());
                            this.Controls.Add(groupBox);
                        }
                    }
                }
            }*/

        }

        private void btn_kembali_Click_1(object sender, EventArgs e)
        {
            Form1 pindah = new Form1();
            pindah.Show();
            this.Visible = false;
        }
    }
}
