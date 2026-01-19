using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TelefonniiSpravochnik
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "75698")
            {
                Form2 form2 = new Form2();
                form2.Visible = true;
                Hide();
            }
            else
            {
                MessageBox.Show("Пароль НЕ верный!","Ошибка");
                textBox1.Text = "";
            }
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            //form5.Hide();
        }
    }
}
