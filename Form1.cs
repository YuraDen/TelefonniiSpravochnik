using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TelefonniiSpravochnik
{
    public partial class Form1 : Form
    {
        static string abd = "Data Source=D:/TelefonniiSpravochnik/TelSprav.db";
        SQLiteConnection con = new SQLiteConnection(abd);                  
        public Form1()
        {
            InitializeComponent();
            A();
        }

        public void A()
        {
            con.Open();
            SQLiteDataAdapter a = new SQLiteDataAdapter("select * from прАбонентов", con);
            DataTable Ab = new DataTable();
            a.Fill(Ab);
            dataGridView1.DataSource = Ab;
            con.Close();
            dataGridView1.Columns[0].HeaderText = "№";
            dataGridView1.Columns[0].Width = 40;
            dataGridView1.Columns[4].HeaderText = "Телефон ФЛ";
            dataGridView1.Columns[4].Width = 75;
            dataGridView1.Columns[5].Width = 200;
            dataGridView1.Columns[6].HeaderText = "Телефон ЮЛ";
            dataGridView1.Columns[6].Width = 75;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(); 
            form2.Show();
            form2.Visible = false;
            Form3 form3 = new Form3();
            form3.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
            Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*Form5 form5 = new Form5(this);
            form5.ShowDialog();*/
        }
    }
}
