using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp16
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Width = 600;
            this.Height = 400;
            this.Text = "Учет СОПГ";
            button4.Text = "Выберите путь сохранения \"Журнала\" (txt)";
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
          
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            Form2 frm = new Form2();
                frm.Show();
           
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = openFileDialog1.FileName;
            textBox1.Text = filename;
            Bank1.Put = textBox1.Text;
            
            string s2 = Bank1.Put;
            s2 = s2.Remove(s2.Length-4,4);
            s2 += "d.txt";
            Bank1.PutD = s2;
            if (System.IO.File.Exists(Bank1.PutD))
            {
                //Ваши действия.....
            }
            else
            {
                StreamWriter f1 = new StreamWriter(Bank1.PutD);
                f1.Close();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string s = textBox1.Text;
            if (textBox1.Text.Length > 0)
            {
                StreamWriter f2 = new StreamWriter(Bank1.Put);
                f2.Close();
                StreamWriter f3 = new StreamWriter(Bank1.PutD);
                f3.Close();
                MessageBox.Show("Очистка файла выполнена успешно!");
            }
            else MessageBox.Show("Ошибка: не указан путь сохранения \"Журнала\"");
        }
    }
}
