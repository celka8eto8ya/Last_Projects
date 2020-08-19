using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;

using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator_4._0
{
    public partial class Calculator4 : Form
    {
        public Calculator4()
        {
            InitializeComponent();

            this.Text = "Calculator 4.0"; // название данной формы
            this.Width = 280; // высота данной формы
            this.Height = 330; // ширина данной формы


            

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e) // в textBox1 записывается текст данной кнопки "8"
        {
            textBox1.Text = textBox1.Text + button8.Text; 
        }

        private void button10_Click(object sender, EventArgs e) // в textBox1 записывается текст данной кнопки "/"
        {
            textBox1.Text = textBox1.Text + button10.Text;
        }

        private void button1_Click(object sender, EventArgs e) // в textBox1 записывается текст данной кнопки "1"
        {
            textBox1.Text = textBox1.Text + button1.Text; 
        }

        private void button16_Click(object sender, EventArgs e) // в textBox1 записывается текст данной кнопки "0"
        {
            textBox1.Text = textBox1.Text + button16.Text; 
        }

        private void button18_Click(object sender, EventArgs e) // в textBox1 записывается текст данной кнопки ","
        {
            textBox1.Text = textBox1.Text + button18.Text; 
        }
         
        private void button19_Click(object sender, EventArgs e) // в textBox1 записывается текст данной кнопки "+"
        {
            textBox1.Text = textBox1.Text + button19.Text; 
        }
        
        private void button20_Click(object sender, EventArgs e) // в textBox1 записывается текст данной кнопки "="
        {
            if (System.IO.File.Exists("E:\\Story.txt") == false) // создание файла, если его не существует
            {

                FileStream file1 = new FileStream("E:\\Story.txt", FileMode.CreateNew); // создание файла 

                file1.Close();
            }

            int count = System.IO.File.ReadAllLines(@"E:\Story.txt").Length; // размер (в строках) файла
            StreamWriter Hist = new StreamWriter(@"E:\Story.txt", true); // открывается поток для записи (без предвар удал содерж файла)

            try                            // логика вычисления
            {
                string s = textBox1.Text;
                double b;
                int a = s.Length;
                
                string[] Mass1 = new string[s.Length];
                char[] Zn = new char[s.Length];

                int u = 0;
                string tumbl = "";
                int zn = 0; // счетчик знаков

                for (int i = 0; i < a; i++)
                {
                    if (s[i] == '(') { tumbl = "1"; }
                    if (tumbl == "1") { if (s[i] != '(' && s[i] != ')') { Mass1[u] = Mass1[u] + s[i]; } }
                    else
                    {

                        if ((s[i] != '+') && (s[i] != '-') && (s[i] != '*') && (s[i] != '/')) { Mass1[u] = Mass1[u] + s[i]; }
                        if ((s[i] == '+') || (s[i] == '-') || (s[i] == '*') || (s[i] == '/')) { Zn[zn] = s[i]; zn = zn + 1; u = u + 1; }
                    }
                    if (s[i] == ')') { tumbl = "0"; }
                }

                int sch = 0;

                for (int i = 0; i < s.Length; i++)
                {
                    if (i > zn) { Zn[i] = '+'; }
                    if (i > u) { Mass1[i] = "0"; }
                    if ((Zn[i] == '+') || (Zn[i] == '-') || (Zn[i] == '*') || (Zn[i] == '/')) { sch = sch + 1; }
                }

                sch = sch + 1;
                double[] Mass = new double[sch];

                for (int i = 0; i < sch; i++)
                {
                    string e1 = ""; // начало синуса
                    if (Mass1[i].IndexOf("sin") >= 0)
                    {
                        for (int k = Mass1[i].IndexOf("sin") + 3; k < Mass1[i].Length; k++)
                        {
                            string e3 = Mass1[i];
                            if ((e3[k] != '+') || (e3[k] != '-') || (e3[k] != '/') || (e3[k] != '*'))
                            { e1 = e1 + e3[k]; }
                            else { break; }
                        }
                        Mass1[i] = Convert.ToString(Math.Sin(Convert.ToDouble(e1) * Math.PI / 180));
                        Console.WriteLine("sinus" + Mass1[i]);
                    } // конец синуса

                    if (Mass1[i].IndexOf("cos") >= 0) // начао косинуса
                    {
                        for (int k = Mass1[i].IndexOf("cos") + 3; k < Mass1[i].Length; k++)
                        {
                            string e3 = Mass1[i];
                            if ((e3[k] != '+') || (e3[k] != '-') || (e3[k] != '/') || (e3[k] != '*'))
                            {
                                e1 = e1 + e3[k];
                                Console.WriteLine(e1);
                            }
                            else { break; }
                        }
                        Mass1[i] = Convert.ToString(Math.Cos(Convert.ToDouble(e1) * Math.PI / 180));
                        Console.WriteLine("cosinus" + Mass1[i]);
                    } // конец косинуса

                    if (Mass1[i].IndexOf("tg") >= 0) // начао тангенса
                    {
                        for (int k = Mass1[i].IndexOf("tg") + 2; k < Mass1[i].Length; k++)
                        {
                            string e3 = Mass1[i];
                            if ((e3[k] != '+') || (e3[k] != '-') || (e3[k] != '/') || (e3[k] != '*'))
                            {
                                e1 = e1 + e3[k];
                                Console.WriteLine(e1);
                            }
                            else { break; }
                        }
                        Mass1[i] = Convert.ToString(Math.Tan(Convert.ToDouble(e1) * Math.PI / 180));
                    } // конец тангенса

                    if (Mass1[i].IndexOf("^") >= 0) // начао степени
                    {
                        string[] MASS = new string[2];
                        int f = 0;
                        for (int k = 0; k < Mass1[i].Length; k++)
                        {
                            string e3 = Mass1[i];

                            if (e3[k] == '^')
                            {
                                f = f + 1;
                            }
                            if (e3[k] != '^')
                            { MASS[f] = MASS[f] + e3[k]; }

                        } 
                        Mass1[i] = Convert.ToString(Math.Pow(Convert.ToDouble(MASS[0]), Convert.ToDouble(MASS[1])));
                    } // конец степени

                    if (Mass1[i].IndexOf("ctg") >= 0) // начао котангенса
                    {
                        for (int k = Mass1[i].IndexOf("ctg") + 3; k < Mass1[i].Length; k++)
                        {
                            string e3 = Mass1[i];
                            if ((e3[k] != '+') || (e3[k] != '-') || (e3[k] != '/') || (e3[k] != '*'))
                            {
                                e1 = e1 + e3[k];
                            }
                            else { break; }
                        }
                        Mass1[i] = Convert.ToString(Math.Cos(Convert.ToDouble(e1) * Math.PI / 180) / Math.Sin(Convert.ToDouble(e1) * Math.PI / 180));
                    } // конец котангенса

                    if (Mass1[i].IndexOf("-") >= 0) // начало отриц числ
                    {

                        for (int k = 1; k < Mass1[i].Length; k++)
                        {
                            string e3 = Mass1[i];
                            if (e3[k] != '-')
                            {
                                e1 = e1 + e3[k];
                                Console.WriteLine(e1);
                            }
                            else { break; }
                        }
                        double f1 = Convert.ToDouble(e1);
                        f1 = f1 * (-1);
                        Mass1[i] = Convert.ToString(f1);
                        Console.WriteLine("скобка" + Mass1[i]);
                    }  // начало отриц числа

                } // если строка содержит син/cos/tg/ctg/^/minus то строке присваивается значение вычесленного син/cos/tg/ctg/^/minus


                for (int i = 0; i < sch; i++)
                {

                    Mass[i] = Convert.ToDouble(Mass1[i]);
                } // конвертирование из стринг в доубл

                // начало непосвредственного вычисления
                int sCH = 1;
                b = Mass[0];

                for (int i = 0; i < a; i++)
                {
                    if ((Zn[i] == '+') || (Zn[i] == '-') || (Zn[i] == '*') || (Zn[i] == '/'))
                    {
                        if (Zn[i] == '+')
                        {
                            b = b + Mass[sCH];
                            sCH = sCH + 1;
                        }
                        if (Zn[i] == '-')
                        {
                            b = b - Mass[sCH];
                            sCH = sCH + 1;
                        }
                        if (Zn[i] == '*')
                        {
                            b = b * Mass[sCH];
                            sCH = sCH + 1;
                        }
                        if (Zn[i] == '/')
                        {
                            b = b / Mass[sCH];
                            sCH = sCH + 1;
                        }
                    }

                }

                string Answer = Convert.ToString(b);
                textBox1.Text = Answer;

                Hist.WriteLine(count+". "+s+ "=" + Answer);    // вывод в текстовый документ( находится в папке проекта)   
                Hist.Close();

                Bank.Text = Answer; // значение ответа присваивается отдельному классу для последующего использования на других формах

                Bank.Sch = Bank.Sch + 1; // счетчик для вывода на форму "История"

                Bank.IST.Add(Bank.Sch+". "+s+"=" + Bank.Text); // вывод на форму "История"
                Bank.IST.Add("    ");
                


            }
            catch (Exception ex)
            {
                textBox1.Text = "Error";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + button2.Text; // в textBox1 записывается текст данной кнопки "2"
        }

        private void button3_Click(object sender, EventArgs e) // в textBox1 записывается текст данной кнопки "3"
        {
            textBox1.Text = textBox1.Text + button3.Text;
        }

        private void button14_Click(object sender, EventArgs e) // в textBox1 записывается текст данной кнопки "-"
        {
            textBox1.Text = textBox1.Text + button14.Text; 
        }

        private void button15_Click(object sender, EventArgs e) // в textBox1 записывается текст данной кнопки "√"
        {
            if (System.IO.File.Exists("E:\\Story.txt") == false) // если файл не существует, то создается
            {

                FileStream file1 = new FileStream("E:\\Story.txt", FileMode.CreateNew); //создание нового файла

                file1.Close();
            }

            try {
                string s = textBox1.Text;
            double s1 = Convert.ToDouble(textBox1.Text); // конвертирование стринг в доубл
                s1 = Math.Sqrt(s1); // вычисление кв корня

                textBox1.Text = Convert.ToString(s1); // конвертирование доубл в стринг
               
                int count = System.IO.File.ReadAllLines(@"E:\Story.txt").Length;   // длина (в строках) документа
                StreamWriter Hist = new StreamWriter(@"E:\Story.txt", true);       // открытие потока на запись в файл
                Hist.WriteLine(count + ". " + "√" + s + " = " + textBox1.Text);    // вывод в текстовый документ( находится в папке проекта)   
                Hist.Close(); // закрытие потока на запись в файл

                Bank.Sch = Bank.Sch + 1; // счетчик для вывода на форму "История"
                Bank.IST.Add(Bank.Sch + ". "+ "√" + s + " = " + textBox1.Text); // вывод на форму "История"
                Bank.IST.Add("    ");
            }
            catch (Exception ex) { textBox1.Text = "Error"+ex; }

           
        }

        private void button4_Click(object sender, EventArgs e) // в textBox1 записывается текст данной кнопки "4"
        {
            textBox1.Text = textBox1.Text + button4.Text;
        }

        private void button5_Click(object sender, EventArgs e) // в textBox1 записывается текст данной кнопки "5"
        {
            textBox1.Text = textBox1.Text + button5.Text;
        }

        private void button6_Click(object sender, EventArgs e) // в textBox1 записывается текст данной кнопки "6"
        {
            textBox1.Text = textBox1.Text + button6.Text;
        }

        private void button12_Click(object sender, EventArgs e) // в textBox1 записывается текст данной кнопки "*"
        {
            textBox1.Text = textBox1.Text + button12.Text;
        }

        private void button13_Click(object sender, EventArgs e) // в textBox1 записывается текст данной кнопки "CE"
        {
            textBox1.Text = "";
        }

        private void button7_Click(object sender, EventArgs e) // в textBox1 записывается текст данной кнопки "7"
        {
            textBox1.Text = textBox1.Text + button7.Text;
        }

        private void button9_Click(object sender, EventArgs e) // в textBox1 записывается текст данной кнопки "9"
        {
            textBox1.Text = textBox1.Text + button9.Text;
        }

        private void button11_Click(object sender, EventArgs e) // в textBox1 удаляется один символ
        {
            string sItog = "";
            string s = textBox1.Text;
            for (int i =0; i< s.Length - 1;i++) // процесс удаления одного символа в textBox1
            { sItog = sItog + s[i]; }
            textBox1.Text = sItog ;
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
            Form2 frm2 = new Form2(); // создается объект формы 2 (О программе)
            frm2.Show(); // открывается форма 2 (О программе)


        }

        private void button17_Click(object sender, EventArgs e) // в textBox1 записывается текст данной кнопки "(" or ")"
        {
            string s = textBox1.Text;
            string c = "";
            for (int i = 0; i < s.Length;i++) // в зависимости от того какая скобка была перед этим пишется противоположная
            {
                if (s[i] == '(') { c = "("; }
              
                if (s[i] == ')') { c = ")"; } 
                if (s == "") { c = ""; } 

            }
            if (c == "(") { textBox1.Text = textBox1.Text + ")"; }
            else
        if (c == ")") { textBox1.Text = textBox1.Text + "("; }
            else
        if (s == "") { textBox1.Text = textBox1.Text + "("; }
            else { textBox1.Text = textBox1.Text + "("; }



        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void историяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
         
        }

        private void button21_Click(object sender, EventArgs e) // в textBox1 записывается текст данной кнопки "sin"
        {
            textBox1.Text =textBox1.Text + "sin";
        }

        private void button22_Click(object sender, EventArgs e) // в textBox1 записывается текст данной кнопки "cos"
        {
            textBox1.Text = textBox1.Text + "cos";
        }

        private void button24_Click(object sender, EventArgs e) // в textBox1 записывается текст данной кнопки "tg"
        {
            textBox1.Text = textBox1.Text + "tg";
        }

        private void button25_Click(object sender, EventArgs e) // в textBox1 записывается текст данной кнопки "ctg"
        {
            textBox1.Text = textBox1.Text + "ctg";
        }

        private void button23_Click(object sender, EventArgs e) // в textBox1 записывается текст данной кнопки "^"
        {
           
            textBox1.Text = textBox1.Text + "^";
           
        }
        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
            
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Form3 frm = new Form3(); // создается объект формы 3 (История)
            frm.Show(); // открывается форма 3 (История)

        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e) // стирает файл
        {
            if (System.IO.File.Exists("E:\\Story.txt") == false) // если файл не существует, создается новый
            {

                FileStream file1 = new FileStream("E:\\Story.txt", FileMode.CreateNew); //создание нового файла
                
                file1.Close();
            }
          
            StreamWriter Hist = new StreamWriter("E:\\Story.txt"); 
            Hist.Close();
        }
    }
}
