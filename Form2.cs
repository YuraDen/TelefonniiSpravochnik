using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TelefonniiSpravochnik
{
    public partial class Form2 : Form
    {
        static string abd = "Data Source=D:/TelefonniiSpravochnik/TelSprav.db";
        SQLiteConnection con = new SQLiteConnection(abd);
        int IDf = 0, IDy = 0;
        public Form2() //Form5 form5, Form1 form1
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
            dataGridView1.Columns[0].Width = 40;
            dataGridView1.Columns[5].Width = 180;
        }

        private void YL()
        {
            con.Open();
            SQLiteDataAdapter yr = new SQLiteDataAdapter("select * from Юр_Лица", con);
            DataTable yl = new DataTable();
            yr.Fill(yl);
            dataGridView2.DataSource = yl;
            con.Close();
            dataGridView2.Columns[0].Width = 40;
            dataGridView2.Columns[1].Width = 200;
            dataGridView2.Columns[3].Width = 170;
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 form1 = new Form1();
            form1.A();
            form1.Show();
            //form5.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SQLiteCommand cdf = new SQLiteCommand("INSERT INTO Физ_Лица (Фамилия, Имя, Отчество, Телефон, Адрес) VALUES (@Фамилия, @Имя, @Отчество, @Телефон, @Адрес)", con);
            cdf.Parameters.AddWithValue("@Фамилия", textBox1.Text);
            cdf.Parameters.AddWithValue("@Имя", textBox2.Text);
            cdf.Parameters.AddWithValue("@Отчество", textBox3.Text);
            cdf.Parameters.AddWithValue("@Телефон", textBox4.Text);
            cdf.Parameters.AddWithValue("@Адрес", textBox5.Text);
            cdf.ExecuteNonQuery();
            con.Close();
            FL();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            IDf = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
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
            IDy = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            SQLiteCommand cuf = new SQLiteCommand("delete from Физ_Лица where IDФЛ=@IDФЛ",con);
            cuf.Parameters.AddWithValue("@IDФЛ", IDf);
            cuf.ExecuteNonQuery();
            SQLiteCommand cpuf = new SQLiteCommand("delete from Абоненты where IDФЛ=@IDФЛ", con);
            cpuf.Parameters.AddWithValue("@IDФЛ", IDf);
            cpuf.ExecuteNonQuery();
            con.Close();
            FL();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            IDy = Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value);
            string N = Convert.ToString(dataGridView2.CurrentRow.Cells[1].Value);
            string Ty = Convert.ToString(dataGridView2.CurrentRow.Cells[2].Value);
            string Ay = Convert.ToString(dataGridView2.CurrentRow.Cells[3].Value);
            textBox8.Text = N;
            textBox7.Text = Ty;
            textBox6.Text = Ay;
            IDf = 0;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            con.Open();
            SQLiteCommand cdy = new SQLiteCommand("INSERT INTO Юр_Лица (Название, Телефон, Адрес) VALUES (@Название, @Телефон, @Адрес)", con);
            cdy.Parameters.AddWithValue("@Название", textBox8.Text);
            cdy.Parameters.AddWithValue("@Телефон", textBox7.Text);
            cdy.Parameters.AddWithValue("@Адрес", textBox6.Text);
            cdy.ExecuteNonQuery();
            con.Close();
            YL();
            textBox8.Text = "";
            textBox7.Text = "";
            textBox6.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            con.Open();
            SQLiteCommand ciy = new SQLiteCommand("update Юр_Лица set Название=@Название, Телефон=@Телефон, Адрес=@Адрес where IDЮЛ=@IDЮЛ", con);
            ciy.Parameters.AddWithValue("@Название", textBox8.Text);
            ciy.Parameters.AddWithValue("@Телефон", textBox7.Text);
            ciy.Parameters.AddWithValue("@Адрес", textBox6.Text);
            ciy.Parameters.AddWithValue("@IDЮЛ", IDy);
            ciy.ExecuteNonQuery();
            con.Close();
            YL();
            textBox8.Text = "";
            textBox7.Text = "";
            textBox6.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            SQLiteCommand cuy = new SQLiteCommand("delete from Юр_Лица where IDЮЛ=@IDЮЛ", con);
            cuy.Parameters.AddWithValue("@IDЮЛ", IDy);
            cuy.ExecuteNonQuery();
            SQLiteCommand cpuy = new SQLiteCommand("delete from Абоненты where IDЮЛ=@IDЮЛ", con);
            cpuy.Parameters.AddWithValue("@IDЮЛ", IDy);
            cpuy.ExecuteNonQuery();
            con.Close();
            YL();
            textBox8.Text = "";
            textBox7.Text = "";
            textBox6.Text = "";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if(IDf>0 & IDy == 0)
            {
                con.Open();
                SQLiteCommand cpaf = new SQLiteCommand("INSERT INTO Абоненты (IDФЛ) VALUES (@IDФЛ)", con);
                cpaf.Parameters.AddWithValue("@IDФЛ", IDf);
                cpaf.ExecuteNonQuery();
                con.Close();
            }
            if (IDf == 0 & IDy > 0)
            {
                con.Open();
                SQLiteCommand cpay = new SQLiteCommand("INSERT INTO Абоненты (IDЮЛ) VALUES (@IDЮЛ)", con);
                cpay.Parameters.AddWithValue("@IDЮЛ", IDy);
                cpay.ExecuteNonQuery();
                con.Close();
            }
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox8.Text = "";
            textBox7.Text = "";
            textBox6.Text = "";
            MessageBox.Show("Абонент добавлен","Проводка выполнена успешно!");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            MessageBox.Show("!!! Проводятся только добавления !!!\nПравила выполнения проводок:\n1) Внести данные в соответствующие поля и нажать соответствующую кнопку добавить\n2) Выделить новую строчку в соответствующей таблице и нажать провести\n3) При выполении других операций НЕ нужно нажимать провести, просто ввести данные в поля и нажать нужную кнопку для совершения операции!","Инструкция");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox8.Text = "";
            textBox7.Text = "";
            textBox6.Text = "";
            FL();
            YL();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SQLiteCommand cif = new SQLiteCommand("update Физ_Лица set Фамилия=@Фамилия, Имя=@Имя, Отчество=@Отчество, Телефон=@Телефон, Адрес=@Адрес where IDФЛ=@IDФЛ", con);
            cif.Parameters.AddWithValue("@Фамилия", textBox1.Text);
            cif.Parameters.AddWithValue("@Имя", textBox2.Text);
            cif.Parameters.AddWithValue("@Отчество", textBox3.Text);
            cif.Parameters.AddWithValue("@Телефон", textBox4.Text);
            cif.Parameters.AddWithValue("@Адрес", textBox5.Text);
            cif.Parameters.AddWithValue("@IDФЛ", IDf);
            cif.ExecuteNonQuery();
            con.Close();
            FL();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }
    }
}
