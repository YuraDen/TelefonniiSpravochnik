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
    public partial class Form5 : Form
    {
        private Form1 form1;
        public Form5(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Hide();
            form1.Show();            
        }

        private void Form5_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            /*Form2 form2 = new Form2(this);
            Form3 form3 = new Form3(this);
            Form4 form4 = new Form4(this);*/
        }
    }
}
