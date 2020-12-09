using KAM_KP_PSP__ClassLibrary_;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace KAM_KP_PSP__5_sem_
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Start timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form2_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        /// <summary>
        /// Create new Account
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            bool success = false;
            textBox2.Text += ".";
            List<string> list = new List<string>() { Bank.AccessInDB, Bank.IdOfCurrentStorage.ToString(), textBox6.Text, comboBox4.Text, textBox5.Text, comboBox3.Text, comboBox2.Text, comboBox1.Text, textBox2.Text };

            string ANSWER = "";
            Client.SendMessage("CreateAccount", list, ref success, ref ANSWER);

            string[] Mass0 = ANSWER.Split(new char[] { '#' });
            MessageBox.Show(Mass0[0]);
        }

        /// <summary>
        /// Tuning visibility by turn variant (Type of account) 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (comboBox4.Text == "Депозит")
            {
                comboBox1.Enabled = true;
                comboBox2.Enabled = true;
                comboBox3.Enabled = true;
                textBox5.Enabled = true;
            }
            else if (comboBox4.Text == "Текущий(только_в_BYN)")
            {
                comboBox1.Enabled = false;
                comboBox2.Enabled = false;
                comboBox3.Enabled = false;
                textBox5.Enabled = false;
            }
            else if (comboBox4.Text == "Валютный")
            {
                comboBox1.Enabled = true;
                comboBox2.Enabled = false;
                comboBox3.Enabled = false;
                textBox5.Enabled = false;
            }
        }

        /// <summary>
        /// Delete Account by name
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            bool success = false;
            List<string> list = new List<string>() { Bank.AccessInDB, Bank.IdOfCurrentStorage.ToString(), textBox6.Text };

            string ANSWER = "";
            Client.SendMessage("DeleteAccount", list, ref success, ref ANSWER);

            string[] Mass0 = ANSWER.Split(new char[] { '#' });
            MessageBox.Show(Mass0[0]);
        }

    }
}
