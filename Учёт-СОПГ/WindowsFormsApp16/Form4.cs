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

namespace WindowsFormsApp16
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int countF22 = System.IO.File.ReadAllLines(Bank1.PutD).Length;
            StreamReader fr2 = new StreamReader(Bank1.PutD);

            string[] Mass = new string[countF22];
            int i = 0;
            string s;
            while ((s = fr2.ReadLine()) != null)
            {
                Mass[i] = s;
                
                i = i + 1;
            }
            fr2.Close();


            if (comboBox1.Text == "Количество посетителей за все время")
            {
            
                textBox1.Text = comboBox1.Text + " : " + countF22;
            }

            else if (comboBox1.Text == "Количество посетителей за последний (текущий) месяц")
            {
                    int SCH = 0;
                string S0 = System.DateTime.Now.ToShortDateString();
                double mes = Convert.ToDouble(Convert.ToString(S0[3]) + Convert.ToString(S0[4]));
                double year = Convert.ToDouble(Convert.ToString(S0[8]) + Convert.ToString(S0[9]));

                for (int j = 0; j < countF22; j++)
                    {
                      
                    string S = Mass[j];
                    double mes1 = Convert.ToDouble(Convert.ToString(S[3]) + Convert.ToString(S[4]));
                    double year1 = Convert.ToDouble(Convert.ToString(S[8]) + Convert.ToString(S[9]));
                    if (mes1 == mes && year1 == year)
                        {
                            SCH = SCH + 1;
                        }
                    }
                        textBox1.Text = comboBox1.Text+ " : " + SCH;
            }
            else if (comboBox1.Text == "Количество посетителей за последнюю (текущую) неделю")
            {
                string week = DateTime.Now.DayOfWeek.ToString();
                double z=0;
                if (week == "Monday") z = 0;
                if (week == "Tuesday") z = 1;
                if (week == "Wednesday") z = 2;
                if (week == "Thursday") z = 3;
                if (week == "Friday") z = 4;
                if (week == "Saturday") z = 5;
                if (week == "Sunday") z = 6;

                int SCH = 0;

                string S0 = System.DateTime.Now.ToShortDateString();
                double denb = Convert.ToDouble(Convert.ToString(S0[0]) + Convert.ToString(S0[1]));
                double mes = Convert.ToDouble(Convert.ToString(S0[3]) + Convert.ToString(S0[4]));
                double year = Convert.ToDouble(Convert.ToString(S0[8]) + Convert.ToString(S0[9]));

                for (int j = 0; j < countF22; j++)
                {

                    string S = Mass[j];
                    double denb1 = Convert.ToDouble(Convert.ToString(S[0]) + Convert.ToString(S[1]));
                    double mes1 = Convert.ToDouble(Convert.ToString(S[3]) + Convert.ToString(S[4]));
                    double year1 = Convert.ToDouble(Convert.ToString(S[8]) + Convert.ToString(S[9]));
                    if (denb1 >= (denb - z) && denb1 <= denb && denb > z && mes1 == mes && year1 == year)
                    {
                        SCH = SCH + 1;
                    }
                }
                textBox1.Text = comboBox1.Text + " : " + SCH;
            } 
            else if (comboBox1.Text == "Количество посетителей за последний (текущий) день")
            {
                int SCH = 0;
                string S0 = System.DateTime.Now.ToShortDateString();
                double denb = Convert.ToDouble(Convert.ToString(S0[0]) + Convert.ToString(S0[1]));
                double mes = Convert.ToDouble(Convert.ToString(S0[3]) + Convert.ToString(S0[4]));
                double year = Convert.ToDouble(Convert.ToString(S0[8]) + Convert.ToString(S0[9]));

                for (int j = 0; j < countF22; j++)
                { 
                    string S = Mass[j];
                    double denb1 = Convert.ToDouble(Convert.ToString(S[0]) + Convert.ToString(S[1]));
                    double mes1 = Convert.ToDouble(Convert.ToString(S[3]) + Convert.ToString(S[4]));
                    double year1 = Convert.ToDouble(Convert.ToString(S[8]) + Convert.ToString(S[9]));
                    if (denb1 == denb && mes1 == mes && year1 == year)
                    {
                        SCH = SCH + 1;
                    }
                }
                textBox1.Text = comboBox1.Text + " : " + SCH;
            }
            else if (comboBox1.Text == "Количество произведенных посещений проживающих за все время")
            {
                int SCH = 0;
                for (int j = 0; j < countF22; j++)
                {
                    string S = Mass[j];

                    if (S.Length > 10)
                    {
                        if (S[11] == 'P')
                        {
                            SCH = SCH + 1;
                        }
                    }
                }
                textBox1.Text = comboBox1.Text+" : "+SCH; }
            else if (comboBox1.Text == "Количество произведенных посещений администрации за все время")
            {
                int SCH = 0;
                for (int j = 0; j < countF22; j++)
                {
                    string S = Mass[j];

                    if (S.Length > 10)
                    {
                        if (S[11] == 'A')
                        {
                            SCH = SCH + 1;
                        }
                    }
                }
                textBox1.Text = comboBox1.Text + " : " + SCH;
            }
            else if (comboBox1.Text == "Количество произведенных посещений администрации за текущий день")
            {
                int SCH = 0;
                string S0 = System.DateTime.Now.ToShortDateString();
                double denb = Convert.ToDouble(Convert.ToString(S0[0]) + Convert.ToString(S0[1]));
                double mes = Convert.ToDouble(Convert.ToString(S0[3]) + Convert.ToString(S0[4]));
                double year = Convert.ToDouble(Convert.ToString(S0[8]) + Convert.ToString(S0[9]));

                for (int j = 0; j < countF22; j++)
                {
                    string S = Mass[j];
                    double denb1 = Convert.ToDouble(Convert.ToString(S[0]) + Convert.ToString(S[1]));
                    double mes1 = Convert.ToDouble(Convert.ToString(S[3]) + Convert.ToString(S[4]));
                    double year1 = Convert.ToDouble(Convert.ToString(S[8]) + Convert.ToString(S[9]));
                    if (denb1 == denb && mes1 == mes && year1 == year && S[11]=='A')
                    {
                        SCH = SCH + 1;
                    }
                }
                
                textBox1.Text = comboBox1.Text + " : " + SCH;
            }

            else if (comboBox1.Text == "Количество произведенных посещений проживающих за текущий день")
            {
                int SCH = 0;
                string S0 = System.DateTime.Now.ToShortDateString();
                double denb = Convert.ToDouble(Convert.ToString(S0[0]) + Convert.ToString(S0[1]));
                double mes = Convert.ToDouble(Convert.ToString(S0[3]) + Convert.ToString(S0[4]));
                double year = Convert.ToDouble(Convert.ToString(S0[8]) + Convert.ToString(S0[9]));

                for (int j = 0; j < countF22; j++)
                {
                    string S = Mass[j];
                    double denb1 = Convert.ToDouble(Convert.ToString(S[0]) + Convert.ToString(S[1]));
                    double mes1 = Convert.ToDouble(Convert.ToString(S[3]) + Convert.ToString(S[4]));
                    double year1 = Convert.ToDouble(Convert.ToString(S[8]) + Convert.ToString(S[9]));
                    if (denb1 == denb && mes1 == mes && year1 == year && S[11] == 'P')
                    {
                        SCH = SCH + 1;
                    }
                }
                    textBox1.Text = comboBox1.Text + " : " + SCH;
            }
            else if (comboBox1.Text != "")
            { textBox1.Text = comboBox1.Text; }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
