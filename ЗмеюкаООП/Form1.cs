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

        List<int> lstX = new List<int>();
        List<int> lstY = new List<int>();
        

        public Form1()
        {
            InitializeComponent();

            for (int i = 0; i < 1000; i++)
            {
                MassSQ[i] = (Button)new Button1();
                if (i < 3)
                {
                    MassSQ[i].Location = new Point(Bank.X - (i * 10), Bank.Y);
                    panel1.Controls.Add(MassSQ[i]);
                }
            }
            Button1 btn = new Button1();
            btn.BackColor = SystemColors.ActiveCaption;
            eat = btn;
            Button1.Random(eat);
            
           
            panel1.Controls.Add(eat);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            timer1.Start();
            timer2.Start();
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Button1.Chek(e);
           
           

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Button1.Motion();
          
            lstX.Add(Bank.X);
            lstY.Add(Bank.Y);
            for (int i = 0; i < Bank.Dlina; i++)
            {
                if (i > 0 && lstX.Count > 2)
                {
                    MassSQ[i].Location = new Point(lstX[lstX.Count - i - 1], lstY[lstY.Count - i - 1]);
                }
                else
                {
                    MassSQ[i].Location = new Point(Bank.X - (10 * i), Bank.Y);
                }
            }
            for (int i = 1; i < Bank.Dlina; i++)
            {
                if (MassSQ[0].Location.X == MassSQ[i].Location.X && MassSQ[0].Location.Y == MassSQ[i].Location.Y)
                {

                    timer1.Stop();
                    timer2.Stop();
                   
                    break;
                }
            }
            if (lstX.Count == MassSQ.Length)
            {
                lstX.RemoveAt(0);
                lstY.RemoveAt(0);
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            int z = 0;
            
            Button1.Eat(out z, MassSQ[0],eat);

            if (z == 1)
            {
                label3.Text = "Счёт: " + Convert.ToString(Bank.Sch);

                MassSQ[Bank.Dlina].Location = new Point(lstX[lstX.Count - Bank.Dlina - 1], lstY[lstY.Count - Bank.Dlina - 1]);
                panel1.Controls.Add(MassSQ[Bank.Dlina]);
                Bank.Dlina += 1;
                Random rand = new Random();
                Random rand1 = new Random();
                int x = 0; int y = 0; int zz = 0;
                for (; ; )
                {
                    x = rand.Next(10, 410);
                    y = rand.Next(10, 300);
                    for (int i = 0; i < lstX.Count; i++)
                    {
                        if (lstX[i] == x && lstY[i] == y)
                        { z = 1; break; }
                    }
                    if (zz != 1)
                    {
                        if ((x + 1) % 10 == 0 && (y + 1) % 10 == 0)
                        {
                            eat.Location = new Point(x, y);
                            eat.Visible = true;
                            break;
                        }
                    }
                }
            }

        }
    } 
    }
   


