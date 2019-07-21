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
        string[] Mass = new string[18];

        int sch = 0;

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
            btn.Random();
           eat = btn;
           
            panel1.Controls.Add(eat);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            timer1.Start();
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            (new Button1()).Chek(e);
           
            if (e.KeyData == Keys.F)
            {
                if (Bank.X > -11 && Bank.Y > -11 && Bank.X < 429 && Bank.Y < 319 && progressBar1.Value == 100)
                { Bank.Shift = 1; Bank.ShiftTime = DateTime.Now.Second; progressBar1.Value = 0; }
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            (new Button1()).Motion();

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
                    //label2.Visible = true;
                    //button1.Visible = true;
                    //button2.Visible = true;
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
            
            (new Button1()).Eat(out z, MassSQ[0],eat);
           

            if (progressBar1.Value < 100) progressBar1.Value += 10;
            label3.Text = "Счёт: " + Convert.ToString(Bank.Sch);

            MassSQ[Bank.Dlina].Location = new Point(lstX[lstX.Count - Bank.Dlina - 1], lstY[lstY.Count - Bank.Dlina - 1]);
            panel1.Controls.Add(MassSQ[Bank.Dlina]);
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
                        this.Location = new Point(x, y);
                        this.Visible = true;
                        break;
                    }
                }
            }
            //if (Bank.Slog == "Змея" && sch == 5000) { label7.Visible = true; timer1.Stop(); timer2.Stop(); }
            //if (Bank.Slog == "Гадюка" && sch == 10000) { label7.Visible = true; timer1.Stop(); timer2.Stop(); }
            //if (Bank.Slog == "Змеюка" && sch == 12000) { label7.Visible = true; timer1.Stop(); timer2.Stop(); }

        }
    } 
    }
   


