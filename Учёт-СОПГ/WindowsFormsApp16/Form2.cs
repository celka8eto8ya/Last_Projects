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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            button1.Text = "Записать";
            
            button4.Text = "Ф.И.О. посетителя";
            button5.Text = "К кому прибыл";
            button6.Text = "№ комнаты";
            button7.Text = "Наименование предъявленных документов";
          
            button10.Text = "Примечание";

        }

        private void label1_Click(object sender, EventArgs e)
        {
           // label1.Text = "№ п/п";
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) // кнопка "Записать"
        {
            int count = System.IO.File.ReadAllLines(Bank1.Put).Length;//длина текущего файла (журнал) в строках
            int countF2 = System.IO.File.ReadAllLines(Bank1.PutD).Length;//длина текущего файла Date в строках
            StreamWriter f1 = new StreamWriter(Bank1.Put, true);
            StreamWriter f2 = new StreamWriter(Bank1.PutD, true);
            if (textBox2.Text == "P" || textBox2.Text == "A")
                f2.WriteLine(System.DateTime.Now.ToShortDateString() + " " + textBox2.Text);
            else  MessageBox.Show("Ошибка поле \"К кому прибыл\" имело не верный формат ");
            f2.Close();
            if (count == 0)
            {
             

                f1.Write("{0, -10}|", "№ п/п ");
                f1.Write("{0, -15}|", "Дата ");
                f1.Write("{0, -15}|", "Время прибытия ");
                f1.Write("{0, -30}|", "Ф.И.О. посетителя ");
                f1.Write("{0, -30}|", "К кому прибыл ");
                f1.Write("{0, -10}|", "№ комнаты ");
                f1.Write("{0, -30}|", "Наимен. предъяв. док. ");
                f1.Write("{0, -30}|", "Примечание ");
                f1.Write("{0, -30}|", "ФИО проверявшего ");
                f1.WriteLine(" ");

                f1.Write("{0, -10}|", "----------");
                f1.Write("{0, -15}|", "---------------");
                f1.Write("{0, -15}|", "---------------");
                f1.Write("{0, -30}|", "------------------------------");
                f1.Write("{0, -30}|", "------------------------------");
                f1.Write("{0, -10}|", "----------");
                f1.Write("{0, -30}|", "------------------------------");
                f1.Write("{0, -30}|", "------------------------------");
                f1.Write("{0, -30}|", "------------------------------");
                f1.WriteLine(" ");

                f1.Write("{0, -10}|", 1);
                f1.Write("{0, -15}|", System.DateTime.Now.ToShortDateString());
                f1.Write("{0, -15}|", System.DateTime.Now.ToShortTimeString());
                f1.Write("{0, -30}|", textBox1.Text);
                f1.Write("{0, -30}|", textBox2.Text);
                f1.Write("{0, -10}|", textBox3.Text);
                f1.Write("{0, -30}|", textBox4.Text);
                f1.Write("{0, -30}|", textBox5.Text);
                f1.Write("{0, -30}|", textBox6.Text);
                f1.WriteLine("");



            }
            if (count != 0)
            {
                f1.Write("{0, -10}|", count-1);
                f1.Write("{0, -15}|", System.DateTime.Now.ToShortDateString());
                f1.Write("{0, -15}|", System.DateTime.Now.ToShortTimeString());
                f1.Write("{0, -30}|", textBox1.Text);
                f1.Write("{0, -30}|", textBox2.Text);
                f1.Write("{0, -10}|", textBox3.Text);
                f1.Write("{0, -30}|", textBox4.Text);
                f1.Write("{0, -30}|", textBox5.Text);
                f1.Write("{0, -30}|", textBox6.Text);
                f1.WriteLine("");
            }
            
          
            f1.Close();
            if (Bank1.Povt > 6) { Bank1.Povt = Bank1.Povt - 7; }
            if (Bank1.Povt == 0)
            {
                Bank1.MASS1[0] = Convert.ToString(Bank1.Sch); // № п/п
                Bank1.MASS1[1] = System.DateTime.Now.ToShortDateString(); // Дата
                Bank1.MASS1[2] = System.DateTime.Now.ToShortTimeString(); // Время прибытия
                Bank1.MASS1[3] = textBox1.Text; // ФИО посетителя
                Bank1.MASS1[4] = textBox2.Text; // К кому прибыл
                Bank1.MASS1[5] = textBox3.Text; // № комнаты
                Bank1.MASS1[6] = textBox4.Text; // Наименование предъявленных документов
                Bank1.MASS1[7] = textBox5.Text; // Примечание
                Bank1.MASS1[8] = textBox6.Text; //  ФИО проверявшего
            }
            if (Bank1.Povt == 1)
            {
                Bank1.MASS2[0] = Convert.ToString(Bank1.Sch); // № п/п
                Bank1.MASS2[1] = System.DateTime.Now.ToShortDateString(); // Дата
                Bank1.MASS2[2] = System.DateTime.Now.ToShortTimeString(); // Время прибытия
                Bank1.MASS2[3] = textBox1.Text; // ФИО посетителя
                Bank1.MASS2[4] = textBox2.Text; // К кому прибыл
                Bank1.MASS2[5] = textBox3.Text; // № комнаты
                Bank1.MASS2[6] = textBox4.Text; // Наименование предъявленных документов
                Bank1.MASS2[7] = textBox5.Text; // Примечание
                Bank1.MASS2[8] = textBox6.Text; //  ФИО проверявшего
            }
            if (Bank1.Povt == 2)
            {
                Bank1.MASS3[0] = Convert.ToString(Bank1.Sch); // № п/п
                Bank1.MASS3[1] = System.DateTime.Now.ToShortDateString(); // Дата
                Bank1.MASS3[2] = System.DateTime.Now.ToShortTimeString(); // Время прибытия
                Bank1.MASS3[3] = textBox1.Text; // ФИО посетителя
                Bank1.MASS3[4] = textBox2.Text; // К кому прибыл
                Bank1.MASS3[5] = textBox3.Text; // № комнаты
                Bank1.MASS3[6] = textBox4.Text; // Наименование предъявленных документов
                Bank1.MASS3[7] = textBox5.Text; // Примечание
                Bank1.MASS3[8] = textBox6.Text; //  ФИО проверявшего
            }
            if (Bank1.Povt == 3)
            {
                Bank1.MASS4[0] = Convert.ToString(Bank1.Sch); // № п/п
                Bank1.MASS4[1] = System.DateTime.Now.ToShortDateString(); // Дата
                Bank1.MASS4[2] = System.DateTime.Now.ToShortTimeString(); // Время прибытия
                Bank1.MASS4[3] = textBox1.Text; // ФИО посетителя
                Bank1.MASS4[4] = textBox2.Text; // К кому прибыл
                Bank1.MASS4[5] = textBox3.Text; // № комнаты
                Bank1.MASS4[6] = textBox4.Text; // Наименование предъявленных документов
                Bank1.MASS4[7] = textBox5.Text; // Примечание
                Bank1.MASS4[8] = textBox6.Text; //  ФИО проверявшего
            }
            if (Bank1.Povt == 4)
            {
                Bank1.MASS5[0] = Convert.ToString(Bank1.Sch); // № п/п
                Bank1.MASS5[1] = System.DateTime.Now.ToShortDateString(); // Дата
                Bank1.MASS5[2] = System.DateTime.Now.ToShortTimeString(); // Время прибытия
                Bank1.MASS5[3] = textBox1.Text; // ФИО посетителя
                Bank1.MASS5[4] = textBox2.Text; // К кому прибыл
                Bank1.MASS5[5] = textBox3.Text; // № комнаты
                Bank1.MASS5[6] = textBox4.Text; // Наименование предъявленных документов
                Bank1.MASS5[7] = textBox5.Text; // Примечание
                Bank1.MASS5[8] = textBox6.Text; //  ФИО проверявшего
            }
            if (Bank1.Povt == 5)
            {
                Bank1.MASS6[0] = Convert.ToString(Bank1.Sch); // № п/п
                Bank1.MASS6[1] = System.DateTime.Now.ToShortDateString(); // Дата
                Bank1.MASS6[2] = System.DateTime.Now.ToShortTimeString(); // Время прибытия
                Bank1.MASS6[3] = textBox1.Text; // ФИО посетителя
                Bank1.MASS6[4] = textBox2.Text; // К кому прибыл
                Bank1.MASS6[5] = textBox3.Text; // № комнаты
                Bank1.MASS6[6] = textBox4.Text; // Наименование предъявленных документов
                Bank1.MASS6[7] = textBox5.Text; // Примечание
                Bank1.MASS6[8] = textBox6.Text; //  ФИО проверявшего
            }
            if (Bank1.Povt == 6)
            {
                Bank1.MASS7[0] = Convert.ToString(Bank1.Sch); // № п/п
                Bank1.MASS7[1] = System.DateTime.Now.ToShortDateString(); // Дата
                Bank1.MASS7[2] = System.DateTime.Now.ToShortTimeString(); // Время прибытия
                Bank1.MASS7[3] = textBox1.Text; // ФИО посетителя
                Bank1.MASS7[4] = textBox2.Text; // К кому прибыл
                Bank1.MASS7[5] = textBox3.Text; // № комнаты
                Bank1.MASS7[6] = textBox4.Text; // Наименование предъявленных документов
                Bank1.MASS7[7] = textBox5.Text; // Примечание
                Bank1.MASS7[8] = textBox6.Text; //  ФИО проверявшего
            }
         

            Bank1.Povt = Bank1.Povt + 1;
            Bank1.Sch = Bank1.Sch + 1;


        }

        private void splitter1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form3 frM = new Form3();
            frM.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            textBox1.Text =""; 
            textBox2.Text = "";
            textBox3.Text = ""; 
            textBox4.Text = ""; 
            textBox5.Text = "";
            textBox6.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Form4 frM4 = new Form4();
            frM4.Show();
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Пункт \"К кому прибыл\" может иметь только 2 положения: P - (к) проживающим, A - (к) администрации ");
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}
