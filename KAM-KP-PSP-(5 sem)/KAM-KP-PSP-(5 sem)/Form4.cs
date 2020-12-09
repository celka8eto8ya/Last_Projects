using KAM_KP_PSP__ClassLibrary_;
using System;
using System.Windows.Forms;

namespace KAM_KP_PSP__5_sem_
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Writing information for connecting to Server
            Bank.ServerAdress = textBox1.Text;
            Bank.ServerPort = int.Parse(textBox2.Text);
            this.Close();
        }
    }
}
