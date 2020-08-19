using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;


namespace Pr2_СУБД_MySQL_
{
    public partial class Form1 : Form
    {
        public void Reader(string put,out string [] Mass) // method for chteniya iz faila (v massiv)
        {
            int count = System.IO.File.ReadAllLines(put).Length;
            Mass = new string[count];
            string s1 = "";

          
            StreamReader f00 = new StreamReader(put);
            int i = 0;
            while ((s1 = f00.ReadLine()) != null)
            {
                Mass[i] = s1;
                i++;
            }
            f00.Close();
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            // проверка существующих дисков, создание если файла не существует
            string s = "";
            foreach (var drive in DriveInfo.GetDrives())
            {
                s = drive.Name;
            }
            // na ocnove exists diska, zapis v constantu dlya isp in future (v sozdan new files)
            Bank1.Disk = s;
            Bank1.Put = Bank1.Disk + "информация по пользователям" + ".txt";
            textBox1.Text = Bank1.Disk;

            StreamWriter f0 = new StreamWriter(Bank1.Put, true);
            f0.Close();
            // сокрытие (визуальное) элементов управления
            label1.Visible = false;
            textBox1.Visible = false;
           

            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;

            string s1 = "";
            string s2 = "";
            int j = 0;
            // чтение данных о учетн записях из файла
            int count = System.IO.File.ReadAllLines(Bank1.Put).Length;
            StreamReader f00 = new StreamReader(Bank1.Put);

            while ((s1 = f00.ReadLine()) != null)
            {
                if (j >1 && j % 2 == 0)
                {
                    s2 = "";
                    if (count > 1 && count % 2 == 0 )
                        for (int i = 5; i < 34; i++)
                        { s2 = s2 + Convert.ToString(s1[i]); }
                    comboBox1.Items.Add(s2);
                }
                j += 1;
            }
            f00.Close();

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text.Length != 0)
            {
                // считывание данных для использования (БД и\или Текстового файла)
                Bank1.CONNSTR = "server=" + textBox2.Text + ";user=" + textBox3.Text + ";database=" + textBox4.Text + ";password=" + textBox5.Text + ";";
                string[] Mass;
                Reader(Bank1.Put, out Mass);

                string s1 = "";
                string s2 = "";
                int j = 0;

                int count = System.IO.File.ReadAllLines(Bank1.Put).Length;
                StreamReader f00 = new StreamReader(Bank1.Put);

                string im1 = "";
                string im2 = "";

                while ((s1 = f00.ReadLine()) != null)
                {
                    if (j > 1 && j % 2 == 0)
                    {
                        im1 = "";
                        im2 = "";

                        for (int i = 5; i <= 35; i++)
                        {
                            if (s1[i] == ' ') { break; }
                            else { im1 += Convert.ToString(s1[i]); }
                        }
                        for (int i = 0; i < (comboBox1.Text).Length; i++)
                        {
                            if ((comboBox1.Text)[i] == ' ') { break; }
                            else { im2 += Convert.ToString((comboBox1.Text)[i]); }
                        }
                     
                        if (im1 == im2) // определение одного из 3-х вариантов (для выходных данных)
                        {
                            Bank1.INF = Mass[j];
                            if ((Mass[j])[36] == 'Ф' && (Mass[j])[56] != 'Б')
                            { Bank1.TIP = 1; }
                            if ((Mass[j])[36] == 'Б')
                            { Bank1.TIP = 2; }
                            if ((Mass[j])[36] == 'Ф' && (Mass[j])[56] == 'Б')
                            { Bank1.TIP = 3; }
                            Bank1.UchName = im1;
                            break;
                        }
                    }
                    j += 1;
                }
                f00.Close();

                Form2 frm2 = new Form2();
                frm2.Show();
               
            }
            else { MessageBox.Show("Ошибка: не выбрано имя учётной записи !"); }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label1.Visible = false; // для отображения элементов управления в зависимости от выбранного варианта(тип выходных данных)
            textBox1.Visible = false;
           

            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;

            if (radioButton1.Checked)
            {
               
                label1.Visible = true;
                textBox1.Visible = true;
                
            } // конец (для отображения ...)

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label1.Visible = false; // для отображения элементов управления в зависимости от выбранного варианта(тип выходных данных)
            textBox1.Visible = false;
           

            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;

            if (radioButton2.Checked)
            {
               
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = true;
                textBox4.Visible = true;
                textBox5.Visible = true;
            } // конец (для отображения ...)
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            label1.Visible = false; // для отображения элементов управления в зависимости от выбранного варианта(радиобаттон)(тип выходных данных)
            textBox1.Visible = false;
          

            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;

            label1.Visible = true;
            textBox1.Visible = true;
            

            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = true; // конец (для отображения ...)
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int z = 0; // проверка на полноту необходимых данных
            if (radioButton1.Checked)
            {
                if ((textBox1.Text).Length == 0) { MessageBox.Show("Ошибка! Не указан путь сохранения файла!"); } else z = 5;

            }
            if (radioButton2.Checked)
            {
                if ((textBox2.Text).Length == 0) { MessageBox.Show("Ошибка! Не заполнен пункт: \"Server\" !"); } else z+= 1;
                if ((textBox3.Text).Length == 0) { MessageBox.Show("Ошибка! Не заполнен пункт: \"Users\" !"); } else z+= 1;
                if ((textBox4.Text).Length == 0) { MessageBox.Show("Ошибка! Не заполнен пункт: \"Database\" !"); } else z+= 1;
                if ((textBox5.Text).Length == 0) { MessageBox.Show("Ошибка! Не заполнен пункт: \"Password\" !"); } else z+= 2;
               
            }
            if (radioButton3.Checked)
            {
                if ((textBox1.Text).Length == 0) { MessageBox.Show("Ошибка! Не указан путь сохранения файла!"); } else z += 1;
                if ((textBox2.Text).Length == 0) { MessageBox.Show("Ошибка! Не заполнен пункт: \"Server\" !"); } else z += 1;
                if ((textBox3.Text).Length == 0) { MessageBox.Show("Ошибка! Не заполнен пункт: \"Users\" !"); } else z += 1;
                if ((textBox4.Text).Length == 0) { MessageBox.Show("Ошибка! Не заполнен пункт: \"Database\" !"); } else z += 1;
                if ((textBox5.Text).Length == 0) { MessageBox.Show("Ошибка! Не заполнен пункт: \"Password\" !"); } else z += 1;
                
            }

            if (z == 5)
            {
              
                // проверка имени уч записи на повторение в уже существующем списке учетн записей
                int count = System.IO.File.ReadAllLines(Bank1.Put).Length;
                string s1 = "";
                string s2 = "";

                int ii = 0;
                if (count > 1)
                {
                    StreamReader f00 = new StreamReader(Bank1.Put);
                    while ((s1 = f00.ReadLine()) != null)
                    {
                      
                        for (int i = 34; i >5; i--)
                        {
                            if (s1[i] != ' ') //
                            {
                                ii = i;
                                break;
                            }
                        }
                        for (int i = 5; i <=ii; i++) //
                        {
                            s2 = s2 + Convert.ToString(s1[i]);
                        }

                        if (s2==textBox6.Text)
                        {
                            MessageBox.Show("Ошибка! Данное имя учётной записи уже использовано!");
                            Bank1.Isp = 1;
                            break;
                        }
                        else
                        { Bank1.Isp = 0; }

                        s2 = "";
                    }
                    f00.Close();

                }

                string Rtext = "";
                if (radioButton1.Checked) { Rtext = radioButton1.Text; }
                if (radioButton2.Checked) { Rtext = radioButton2.Text; }
                if (radioButton3.Checked) { Rtext = radioButton3.Text; }

               // запись данных в файл с учетными записями
                StreamWriter f1 = new StreamWriter(Bank1.Put, true);
                if (count <= 1)
                {
                   
                    f1.Write("{0, -4}|", "№");
                    f1.Write("{0, -30}|", "Имя уч.записи");
                    f1.Write("{0, -30}|", "Тип выходных данных");
                      f1.Write("{0, -30}|", "Путь сохр.фала \"Поступления\" ");
                        f1.Write("{0, -15}|", "Server");
                        f1.Write("{0, -15}|", "Users");
                        f1.Write("{0, -15}|", "Database");
                        f1.Write("{0, -15}|", "Password");
                    f1.WriteLine(" ");

                    f1.Write("{0, -4}|", "----");
                    f1.Write("{0, -30}|", "------------------------------");
                    f1.Write("{0, -30}|", "------------------------------");
                      f1.Write("{0, -30}|", "------------------------------");
                        f1.Write("{0, -15}|", "---------------");
                        f1.Write("{0, -15}|", "---------------");
                        f1.Write("{0, -15}|", "---------------");
                        f1.Write("{0, -15}|", "---------------");
                        f1.WriteLine(" ");

                    f1.Write("{0, -4}|", 1);
                    f1.Write("{0, -30}|", textBox6.Text);
                    f1.Write("{0, -30}|", Rtext);
                  if (radioButton1.Checked || radioButton3.Checked)
                  {
                    f1.Write("{0, -30}|", textBox1.Text);
                  }
                  else { f1.Write("{0, -30}|", ""); }
                  if (radioButton2.Checked || radioButton3.Checked)
                  {
                    f1.Write("{0, -15}|", textBox2.Text);
                    f1.Write("{0, -15}|", textBox3.Text);
                    f1.Write("{0, -15}|", textBox4.Text);
                    f1.Write("{0, -15}|", textBox5.Text);
                  }
                  else
                  {
                        f1.Write("{0, -15}|", "");
                        f1.Write("{0, -15}|", "");
                        f1.Write("{0, -15}|", "");
                        f1.Write("{0, -15}|", "");
                  }
                    f1.WriteLine(" ");

                    f1.Write("{0, -4}|", "----");
                    f1.Write("{0, -30}|", "------------------------------");
                    f1.Write("{0, -30}|", "------------------------------");
                    f1.Write("{0, -30}|", "------------------------------");
                    f1.Write("{0, -15}|", "---------------");
                    f1.Write("{0, -15}|", "---------------");
                    f1.Write("{0, -15}|", "---------------");
                    f1.Write("{0, -15}|", "---------------");
                    f1.WriteLine(" ");
                }
                if (count >= 3 && count%2==0 && Bank1.Isp == 0)
                {
                 
                    f1.Write("{0, -4}|", ((count - 2) / 2) + 1);
                    f1.Write("{0, -30}|", textBox6.Text);
                    f1.Write("{0, -30}|", Rtext);
                    if (radioButton1.Checked || radioButton3.Checked)
                    {
                        f1.Write("{0, -30}|", textBox1.Text);
                    }
                    else { f1.Write("{0, -30}|", ""); }
                    if (radioButton2.Checked || radioButton3.Checked)
                    {
                        f1.Write("{0, -15}|", textBox2.Text);
                        f1.Write("{0, -15}|", textBox3.Text);
                        f1.Write("{0, -15}|", textBox4.Text);
                        f1.Write("{0, -15}|", textBox5.Text);
                    }
                    else
                    {
                        f1.Write("{0, -15}|", "");
                        f1.Write("{0, -15}|", "");
                        f1.Write("{0, -15}|", "");
                        f1.Write("{0, -15}|", "");
                    }
                    f1.WriteLine(" ");

                    f1.Write("{0, -4}|", "----");
                    f1.Write("{0, -30}|", "------------------------------");
                    f1.Write("{0, -30}|", "------------------------------");
                    f1.Write("{0, -30}|", "------------------------------");
                    f1.Write("{0, -15}|", "---------------");
                    f1.Write("{0, -15}|", "---------------");
                    f1.Write("{0, -15}|", "---------------");
                    f1.Write("{0, -15}|", "---------------");
                    f1.WriteLine(" ");
                }
                f1.Close();

                // если создана новая запись она добавляется в комбобокс
                if (comboBox1.Items.Count > 0)
                {
                    for (int i = 0; i < comboBox1.Items.Count; i++)
                    {
                        if ((textBox6.Text).Length != 0 && Bank1.Isp == 0)
                        {
                            comboBox1.Items.Add(textBox6.Text);
                            break;
                        }
                    }
                }
                else if (comboBox1.Items.Count == 0 )
                {
                    comboBox1.Items.Add(textBox6.Text);
                }

            }


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
