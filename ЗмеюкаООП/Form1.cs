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

        int xx = 49;
        int yy = 49;
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
                    MassSQ[i].Location = new Point(xx - (i * 10), yy);
                    panel1.Controls.Add(MassSQ[i]);
                }
            }


            Button1 btn = new Button1();
            btn.BackColor = SystemColors.ActiveCaption;
            btn.Random();
            Button btn4 = btn;
            panel1.Controls.Add(btn4);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.W)
            {
                if (Bank.Where != "Down" && xx > -11 && yy > -11 && xx < 429 && yy < 319)
                    Bank.Where = "Up";
            }
            if (e.KeyData == Keys.S)
            {
                if (Bank.Where != "Up" && xx > -11 && yy > -11 && xx < 429 && yy < 319)
                    Bank.Where = "Down";
            }
            if (e.KeyData == Keys.A)
            {
                if (Bank.Where != "Right" && xx > -11 && yy > -11 && xx < 429 && yy < 319)
                    Bank.Where = "Left";
            }
            if (e.KeyData == Keys.D)
            {
                if (Bank.Where != "Left" && xx > -11 && yy > -11 && xx < 429 && yy < 319)
                    Bank.Where = "Right";
            }
            if (e.KeyData == Keys.F)
            {
                if (xx > -11 && yy > -11 && xx < 429 && yy < 319 && progressBar1.Value == 100)
                { Bank.Shift = 1; Bank.ShiftTime = DateTime.Now.Second; progressBar1.Value = 0; }
            }

        }

    }
   
} 


