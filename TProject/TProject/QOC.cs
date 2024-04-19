﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TProject
{
    public partial class QOC : Form
    {
        public QOC()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Program.qc.Hide();
            Program.em.Show();
            dataGridView1.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            SqlConnection con = new SqlConnection(Program.conistring);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand("select distinct id_client,fname, dateOfBirth, gender, telephone, house, street, neighbourhood, city, country, zipcode, mobile, nationality, social_status, spouceName, birthPlace, clienttable.username, email, password from clienttable, accounts where accounts.accountType=2 and clienttable.username = accounts.username", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Program.qc.Hide();
            Program.fr.Show();
            dataGridView1.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            Program.ac.Show();
            Program.qc.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            Program.qc.Hide();
            Program.uc.Show();
        }
    }
}
