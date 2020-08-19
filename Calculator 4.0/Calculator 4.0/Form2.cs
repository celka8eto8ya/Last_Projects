using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator_4._0
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            this.Text = "О программе";
            this.Width = 700;
            this.Height = 400;

           
            label1.Text = "Калькулятор производит вычисления строго последовательно, и только так.";
            label2.Text = "Создатель: Костючик Андрей Михайлович";
            label3.Text = "Дата создания: 17.02.2019";
            label4.Text = "Собственность: ПолесГУ";




        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
           
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
