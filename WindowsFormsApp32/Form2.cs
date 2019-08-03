using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp32
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            TopMost = true;
            InitializeComponent();
          
        }

        private void Form2_Load(object sender, EventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            
        }
        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
           
            Bank.Slog = comboBox1.Text;
             Bank.HH = 1;
            
            Bank.Sound = comboBox2.Text;
            Bank.Wals = comboBox3.Text;
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
