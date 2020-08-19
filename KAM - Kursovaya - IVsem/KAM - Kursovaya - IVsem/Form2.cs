using System;
using System.Windows.Forms;

namespace KAM___Kursovaya___IVsem
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Account acc1 = new Account();
            if (comboBox4.Text == "Депозит")
            {
                try
                {
                    //
                    // создается переменная аккаунт и является источник данных для метода или метод будет не статический
                    acc1 = new Account(textBox6.Text, new TypeOfAccount(comboBox4.Text, double.Parse(textBox5.Text), comboBox3.Text, int.Parse(comboBox2.Text)), new CurrencyOfAccount(comboBox1.Text), textBox2.Text);
                }
                catch 
                {
                   
                }
            }
            else if (comboBox4.Text == "Текущий(только в BYN)")
            {
                acc1 = new Account(textBox6.Text, comboBox4.Text, textBox2.Text);
            }
            else if (comboBox4.Text == "Валютный")
            {
                acc1 = new Account(textBox6.Text, comboBox4.Text, new CurrencyOfAccount(comboBox1.Text), textBox2.Text);
            }

            if (acc1.CheckOnExclusiveAccountName(Bank.IdOfCurrentStorage))
            {
                // 
                // запись данных в таблицу "AccountsOfStorage"
                //
                acc1.AddAccountInDB(Bank.AccessInDB);

                //
                // Внесение события в таблицу
                Event ev1 = new Event(button2.Text, "Не финансовое", $"Создание счёта: \"{textBox6.Text}\"");
                ev1.AddEventInDB();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (comboBox4.Text == "Депозит")
            {
                comboBox1.Enabled = true;
                comboBox2.Enabled = true;
                comboBox3.Enabled = true;
                textBox5.Enabled = true;
            }
            else if (comboBox4.Text == "Текущий(только в BYN)")
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

        private void button3_Click(object sender, EventArgs e)
        {
            // удаление строки о счёте и типе счёта из соответсвующих таблиц БД
            Account.DeleteAccountInDB(textBox6.Text, Bank.IdOfCurrentStorage);

            //
            // Внесение события в таблицу
            Event ev1 = new Event(button3.Text, "Не финансовое", $"Удаление хранилища: \"{textBox6.Text}\"");
            ev1.AddEventInDB();
        }



    }
}
