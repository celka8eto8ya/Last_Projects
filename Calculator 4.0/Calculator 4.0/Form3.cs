using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator_4._0
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            this.Text = "История";

            
        List<string> Ist1 = new List<string>();
            Ist1 = Bank.IST;
            foreach (string s in Ist1)
            {
                textBox1.Text = textBox1.Text + s;
              
            }

        }

        private void Form3_Load(object sender, EventArgs e)
        {
        
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
}
