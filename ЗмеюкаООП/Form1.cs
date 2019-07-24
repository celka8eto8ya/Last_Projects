using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace ЗмеюкаООП
{
    public partial class Form1 : Form
    {
        Button[] MassSQ = new Button[1000];
        Button eat = new Button();
        
        public Form1()
        {
            InitializeComponent();

            for (int i = 0; i < 1000; i++)
            {
                MassSQ[i] = (Button)new SquareSnake();
                if (i < 3)
                {
                    MassSQ[i].Location = new Point(Bank.X - (i * 10), Bank.Y);
                    panel1.Controls.Add(MassSQ[i]);
                }
            }

            SquareSnake btn = new SquareSnake();
            btn.BackColor = SystemColors.ActiveCaption;
            eat = btn;
            SquareSnake.RandomPosition1(eat);
            panel1.Controls.Add(eat);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            timer2.Start();
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            SquareSnake.ChekKey(e);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            SquareSnake.Motion();
            SquareSnake.Motion1(MassSQ);

            for (int i = 1; i < Bank.Dlina; i++)
            {
                if (MassSQ[0].Location.X == MassSQ[i].Location.X && MassSQ[0].Location.Y == MassSQ[i].Location.Y)
                {
                    timer1.Stop();
                    timer2.Stop();
                    label1.Visible = true;
                    break;
                }
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            int z = 0;
            
            SquareSnake.Eat(out z, MassSQ[0],eat, MassSQ);

            if (z == 1)
            {
                label3.Text = "Счёт: " + Convert.ToString(Bank.Sch);
                panel1.Controls.Add(MassSQ[Bank.Dlina]);
                Bank.Dlina += 1;

                SquareSnake.RandomPosition1(eat);
               
            }

        }
    } 
    }
   


