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
                MassSQ[i] = new Button1(10);
               
                if (i < 3)
                {
                    MassSQ[i].Location = new Point(xx - (i * 10), yy);
                    panel1.Controls.Add(MassSQ[i]);
                }
            }
            Bank2.Where = "Right";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
       
        }
    }
}
