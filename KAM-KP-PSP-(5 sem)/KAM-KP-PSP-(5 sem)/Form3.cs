using KAM_KP_PSP__ClassLibrary_;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace KAM_KP_PSP__5_sem_
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();

        }

        // CreateStorage
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // 
                // создание объекта "db1" для возможности подключения к БД
                //
                Database db1 = new Database(textBox11.Text, textBox10.Text, textBox9.Text, textBox8.Text);

                // строка доступа к БД
                Bank.AccessInDB = db1.StringOfAccess;

                bool success = false;

                List<string> list = new List<string>() { textBox11.Text, textBox10.Text, textBox9.Text, textBox8.Text, textBox7.Text, textBox6.Text, textBox4.Text };
                string ANSWER = "";
                Client.SendMessage("CreateStorage", list, ref success, ref ANSWER);


                string[] Mass0 = ANSWER.Split(new char[] { '#' });
                MessageBox.Show(Mass0[0]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // EnterStorage
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                bool success = false;
                List<string> list = new List<string>() { textBox12.Text, textBox2.Text, textBox5.Text };
                string ANSWER = "";
                Client.SendMessage("EnterStorage", list, ref success, ref ANSWER);
                if (success)
                {
                    string[] Mass0 = ANSWER.Split(new char[] { '#' });
                    MessageBox.Show(Mass0[0]);

                    string[] Mass00 = Mass0[1].Split(new char[] { ' ' });

                   
                    Bank.AccessInDB = Mass00[1];
                    Bank.IdOfCurrentStorage = int.Parse(Mass00[2]);

                    Bank.NameOfStorage = textBox12.Text;

                    MessageBox.Show($"Bank.NameOfStorage={Bank.NameOfStorage}\r\n" +
                        $"Bank.AccessInDB ={Bank.AccessInDB}\r\n"+
                        $"Bank.IdOfCurrentStorage ={Bank.IdOfCurrentStorage}\r\n" +
                        $" Bank.NameOfStorage ={Bank.NameOfStorage}\r\n");

                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // DeleteStorage
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                bool success = false;
                List<string> list = new List<string>() { textBox3.Text, textBox1.Text, textBox13.Text};
                string ANSWER = "";
                Client.SendMessage("DeleteStorage", list, ref success, ref ANSWER);

                string[] Mass0 = ANSWER.Split(new char[] { '#' });
                MessageBox.Show(Mass0[0]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            Form4 frm4 = new Form4();
            frm4.ShowDialog();
        }
    }
}
