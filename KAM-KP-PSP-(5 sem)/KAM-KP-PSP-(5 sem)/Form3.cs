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

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> list = new List<string>() { textBox12.Text, textBox2.Text, textBox5.Text };
                Client.SendMessage("EnterStorage", list);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void button4_Click(object sender, EventArgs e)
        {
            //// удалить строку о хранилище из файла и БД, если данные текстбоксов совпадут
            //Database.DeleteStorage(textBox3.Text, textBox1.Text, textBox13.Text, Bank.AccessInDB);

            ////
            //// Внесение события в таблицу
            //Event ev1 = new Event(button4.Text, "Не финансовое", $"Удаление хранилища: \"{textBox13.Text}\"");
            //ev1.AddEventInDB();
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
