using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace thirteenCafeteria
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 pindah= new Form1();
            pindah.Show();
            this.Visible= false;

        }

        private void btn_tambah_Click(object sender, EventArgs e)
        {
            addMenu move = new addMenu();
            move.Show();
            this.Visible= false;
        }
    }
}
