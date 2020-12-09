using KAM_KP_PSP__ClassLibrary_;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KAM_KP_PSP__5_sem_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// frm3.ShowDialog();
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3();
            frm3.ShowDialog();
            timer3.Start();
        }
       

        /// <summary>
        /// Load Form3
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click_2(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3();
            frm3.Show();
        }
       

        /// <summary>
        /// Load Form2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click_2(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }


        /// <summary>
        /// Info about Storages
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Rows.Clear();
                bool success = false;
               
                List<string> list = new List<string>() { Bank.AccessInDB, Bank.IdOfCurrentStorage.ToString() };
                string ANSWER = "";
                Client.SendMessage("StorageInfo", list, ref success, ref ANSWER);

                string[] Mass0 = ANSWER.Split(new char[] { '#' });
                MessageBox.Show(Mass0[0]);

                string S = Mass0[1];

                string[] Mass = S.Split(new char[] { '%' });


                string[][] MASS = new string[Mass.Length][];

                for (int i = 0; i < Mass.Length; i++)
                {
                    MASS[i] = Mass[i].Split(new char[] { '|' });
                }

                foreach (string[] s in MASS)
                {
                    dataGridView1.Rows.Add(s);
                }

                label2.Text = $"Информация о счетах хранилища \"{Bank.NameOfStorage}\" : ";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        /// <summary>
        /// Info About Accounts
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView2.Rows.Clear();
                bool success = false;

                List<string> list = new List<string>() { Bank.AccessInDB, Bank.IdOfCurrentStorage.ToString() };
                string ANSWER = "";
                Client.SendMessage("AccountInfo", list, ref success, ref ANSWER);

                string[] Mass0 = ANSWER.Split(new char[] { '#' });
                MessageBox.Show(Mass0[0]);

                string S = Mass0[1];

                string[] Mass = S.Split(new char[] { '%' });


                string[][] MASS = new string[Mass.Length][];

                for (int i = 0; i < Mass.Length; i++)
                {
                    MASS[i] = Mass[i].Split(new char[] { '|' });
                }

                foreach (string[] s in MASS)
                {
                    dataGridView2.Rows.Add(s);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
         
        }


        /// <summary>
        /// Add Money to Account
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            bool success = false;
            List<string> list = new List<string>() { Bank.AccessInDB, Bank.IdOfCurrentStorage.ToString(), textBox2.Text, textBox4.Text };

            string ANSWER = "";
            Client.SendMessage("AddMoney", list, ref success, ref ANSWER);

            string[] Mass0 = ANSWER.Split(new char[] { '#' });
            MessageBox.Show(Mass0[0]);
        }


        /// <summary>
        /// Get Money to account
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            bool success = false;
            List<string> list = new List<string>() { Bank.AccessInDB, Bank.IdOfCurrentStorage.ToString(), textBox2.Text, textBox4.Text };

            string ANSWER = "";
            Client.SendMessage("GetMoney", list, ref success, ref ANSWER);

            string[] Mass0 = ANSWER.Split(new char[] { '#' });
            MessageBox.Show(Mass0[0]);
        }


        /// <summary>
        /// Convert Money in definite Currency
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button9_Click(object sender, EventArgs e)
        {
            bool success = false;
            List<string> list = new List<string>() { Bank.AccessInDB, Bank.IdOfCurrentStorage.ToString(), textBox2.Text, comboBox1.Text };

            string ANSWER = "";
            Client.SendMessage("ConvertMoney", list, ref success, ref ANSWER);

            string[] Mass0 = ANSWER.Split(new char[] { '#' });
            MessageBox.Show(Mass0[0]);
        }


        /// <summary>
        /// Update info about deposit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button8_Click(object sender, EventArgs e)
        {
            bool success = false;
            List<string> list = new List<string>() { Bank.AccessInDB, Bank.IdOfCurrentStorage.ToString()};

            string ANSWER = "";
            Client.SendMessage("CheckDeposit", list, ref success, ref ANSWER);

            string[] Mass0 = ANSWER.Split(new char[] { '#' });
            MessageBox.Show(Mass0[0]);
        }

        /// <summary>
        /// Show financial events
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button10_Click(object sender, EventArgs e)
        {
            dataGridView3.Rows.Clear();
            bool success = false;
            List<string> list = new List<string>() { Bank.AccessInDB, Bank.IdOfCurrentStorage.ToString() };

            string ANSWER = "";
            Client.SendMessage("ShowFinancialEvents", list, ref success, ref ANSWER);

            string[] Mass0 = ANSWER.Split(new char[] { '#' });
            MessageBox.Show(Mass0[0]);

            string S = Mass0[1];

            string[] Mass = S.Split(new char[] { '%' });


            string[][] MASS = new string[Mass.Length][];

            for (int i = 0; i < Mass.Length; i++)
            {
                MASS[i] = Mass[i].Split(new char[] { '|' });
            }

            foreach (string[] s in MASS)
            {
                dataGridView3.Rows.Add(s);
            }
        }


        /// <summary>
        /// Show not financial events
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button11_Click(object sender, EventArgs e)
        {
            dataGridView3.Rows.Clear();
            bool success = false;
            List<string> list = new List<string>() { Bank.AccessInDB, Bank.IdOfCurrentStorage.ToString() };

            string ANSWER = "";
            Client.SendMessage("ShowNotFinancialEvents", list, ref success, ref ANSWER);

            string[] Mass0 = ANSWER.Split(new char[] { '#' });
            MessageBox.Show(Mass0[0]);

            string S = Mass0[1];

            string[] Mass = S.Split(new char[] { '%' });


            string[][] MASS = new string[Mass.Length][];

            for (int i = 0; i < Mass.Length; i++)
            {
                MASS[i] = Mass[i].Split(new char[] { '|' });
            }

            foreach (string[] s in MASS)
            {
                dataGridView3.Rows.Add(s);
            }
           
        }
        

        /// <summary>
        /// Show all events
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button12_Click(object sender, EventArgs e)
        {
            dataGridView3.Rows.Clear();
            bool success = false;
            List<string> list = new List<string>() { Bank.AccessInDB, Bank.IdOfCurrentStorage.ToString() };

            string ANSWER = "";
            Client.SendMessage("ShowAllEvents", list, ref success, ref ANSWER);

            string[] Mass0 = ANSWER.Split(new char[] { '#' });
            MessageBox.Show(Mass0[0]);

            string S = Mass0[1];

            string[] Mass = S.Split(new char[] { '%' });


            string[][] MASS = new string[Mass.Length][];

            for (int i = 0; i < Mass.Length; i++)
            {
                MASS[i] = Mass[i].Split(new char[] { '|' });
            }

            foreach (string[] s in MASS)
            {
                dataGridView3.Rows.Add(s);
            }
        }

    }
}
