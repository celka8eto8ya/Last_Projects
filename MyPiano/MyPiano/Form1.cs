using System;
using System.Windows.Forms;


namespace MyPiano
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            timer2.Start();
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (Convert.ToString(e.KeyData) != "Shift")
            { PianoKey.RenameKeyInNotes(Convert.ToString(e.KeyData), ref Bank1.Name,button1); }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (Bank1.PressKey)
            { PianoKey.FrequencySound(Bank1.Name);  }

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (Bank1.PressKey)
            { PianoKey.FrequencySound(Bank1.Name); }
        }

       
    }
}
