﻿using System;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn_pesan_Click(object sender, EventArgs e)
        {
            pesan pindah = new pesan();
            pindah.Show();
            this.Visible = false;
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            Login pindah = new Login();
            pindah.Show();
            this.Visible = false;

        }
    }
}
