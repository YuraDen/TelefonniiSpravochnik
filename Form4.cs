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
    public partial class Form4 : Form
    {
        static string abd = "Data Source=D:/TelefonniiSpravochnik/TelSprav.db";
        SQLiteConnection con = new SQLiteConnection(abd);
        public Form4()
        {
            InitializeComponent();
            FL();
            YL();
        }

        private void FL()
        {
            con.Open();
            SQLiteDataAdapter fiz = new SQLiteDataAdapter("select * from Физ_Лица", con);
            DataTable fl = new DataTable();
            fiz.Fill(fl);
            dataGridView1.DataSource = fl;
            con.Close();
            dataGridView1.Columns[0].HeaderText = "№";
            dataGridView1.Columns[0].Width = 40;
            dataGridView1.Columns[5].Width = 200;
        }

        private void YL()
        {
            con.Open();
            SQLiteDataAdapter yr = new SQLiteDataAdapter("select * from Юр_Лица", con);
            DataTable yl = new DataTable();
            yr.Fill(yl);
            dataGridView2.DataSource = yl;
            con.Close();
            dataGridView2.Columns[0].HeaderText = "№";
            dataGridView2.Columns[0].Width = 40;
            dataGridView2.Columns[1].Width = 200;
            dataGridView2.Columns[3].Width = 200;
        }

        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            //form5.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SQLiteCommand cVFF = new SQLiteCommand("SELECT * FROM Физ_Лица where Фамилия=@Фамилия", con);
            cVFF.Parameters.AddWithValue("@Фамилия", textBox1.Text);
            SQLiteDataAdapter aFF = new SQLiteDataAdapter(cVFF);
            DataTable Fam = new DataTable();
            aFF.Fill(Fam);
            dataGridView1.DataSource = Fam;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            FL();
            YL();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SQLiteCommand cVFT = new SQLiteCommand("SELECT * FROM Физ_Лица where Телефон=@Телефон", con);
            cVFT.Parameters.AddWithValue("@Телефон", textBox4.Text);
            SQLiteDataAdapter aFT = new SQLiteDataAdapter(cVFT);
            DataTable Tel = new DataTable();
            aFT.Fill(Tel);
            dataGridView1.DataSource = Tel;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SQLiteCommand cVFA = new SQLiteCommand("SELECT * FROM Физ_Лица where Адрес=@Адрес", con);
            cVFA.Parameters.AddWithValue("@Адрес", textBox5.Text);
            SQLiteDataAdapter aFA = new SQLiteDataAdapter(cVFA);
            DataTable Adr = new DataTable();
            aFA.Fill(Adr);
            dataGridView1.DataSource = Adr;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SQLiteCommand cVYN = new SQLiteCommand("SELECT * FROM Юр_Лица where Название=@Название", con);
            cVYN.Parameters.AddWithValue("@Название", textBox8.Text);
            SQLiteDataAdapter aYN = new SQLiteDataAdapter(cVYN);
            DataTable Nazv = new DataTable();
            aYN.Fill(Nazv);
            dataGridView2.DataSource = Nazv;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SQLiteCommand cVYT = new SQLiteCommand("SELECT * FROM Юр_Лица where Телефон=@Телефон", con);
            cVYT.Parameters.AddWithValue("@Телефон", textBox7.Text);
            SQLiteDataAdapter aYT = new SQLiteDataAdapter(cVYT);
            DataTable TY = new DataTable();
            aYT.Fill(TY);
            dataGridView2.DataSource = TY;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SQLiteCommand cVYA = new SQLiteCommand("SELECT * FROM Юр_Лица where Адрес=@Адрес", con);
            cVYA.Parameters.AddWithValue("@Адрес", textBox6.Text);
            SQLiteDataAdapter aYA = new SQLiteDataAdapter(cVYA);
            DataTable AY = new DataTable();
            aYA.Fill(AY);
            dataGridView2.DataSource = AY;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string F = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value);
            string I = Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value);
            string O = Convert.ToString(dataGridView1.CurrentRow.Cells[3].Value);
            string T = Convert.ToString(dataGridView1.CurrentRow.Cells[4].Value);
            string A = Convert.ToString(dataGridView1.CurrentRow.Cells[5].Value);
            textBox1.Text = F;
            textBox2.Text = I;
            textBox3.Text = O;
            textBox4.Text = T;
            textBox5.Text = A;
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string N = Convert.ToString(dataGridView2.CurrentRow.Cells[1].Value);
            string Ty = Convert.ToString(dataGridView2.CurrentRow.Cells[2].Value);
            string Ay = Convert.ToString(dataGridView2.CurrentRow.Cells[3].Value);
            textBox8.Text = N;
            textBox7.Text = Ty;
            textBox6.Text = Ay;
        }
    }
}
