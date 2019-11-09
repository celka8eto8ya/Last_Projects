using ClassLibraryForEB;
using System;
using System.Windows.Forms;



namespace ElectronicBookkeeping_AK___2
{
    public partial class ElectronicBookkeeping : Form
    {
        Account[] accMass = new Account[16];

        public ElectronicBookkeeping()
        {
            InitializeComponent();

            accMass[0] = new Account("1-й конверт"); // Создание счетов
            accMass[1] = new Account("2-й конверт");
            accMass[2] = new Account("3-й конверт");
            accMass[3] = new Account("4-й конверт");
            accMass[4] = new Account("5-й конверт");
            accMass[5] = new Account("6-й конверт");
            accMass[6] = new Account("7-й конверт");
            accMass[7] = new Account("8-й конверт");
            accMass[8] = new Account("9-й конверт");
            accMass[9] = new Account("10-й конверт");
            accMass[10] = new Account("11-й конверт");
            accMass[11] = new Account("12-й конверт");
            accMass[12] = new Account("Банковская карта");
            accMass[13] = new Account("Кошелёк");
            accMass[14] = new Account("Тайник");
            accMass[15] = new Account("На чёрный день");
        }

        private void button15_Click(object sender, EventArgs e)
        {

        }

        private void ElectronicBookkeeping_Load(object sender, EventArgs e)
        {
            Account.CreateFiles();

            Account.ToReadSumMass(accMass);
            Account.ToReadFile(textBox12, "MonetaryCondition.txt");
            Account.ToReadFile(textBox2, "Income.txt");
            Account.ToReadFile(textBox4, "Expenses.txt");

            button8.Text = $"Последнее обновление:\r\n{DateTime.Now}";
        }
      

        private void button5_Click(object sender, EventArgs e) // Запись в файл доходов
        {
            if (comboBox1.Text.Length != 0 && comboBox2.Text.Length != 0 && textBox1.Text.Length != 0)
            {
                Account.ToWriteIncome(comboBox1.Text, comboBox2.Text, dateTimePicker2.Text, textBox1.Text);
                Account.ToReadFile(textBox2, "Income.txt");
                for (int i = 0; i < accMass.Length; i++)
                {
                    if (accMass[i].Name == comboBox2.Text)
                    {
                        accMass[i].PutMoney(double.Parse(textBox1.Text));
                        Account.ToWriteMonetaryCondition(accMass);
                    }
                }
            }
            else
            { MessageBox.Show("Не все поля были заполнены!", "Ошибка!"); }
        }

        private void button18_Click(object sender, EventArgs e) // Запись в файл затрат
        {
                if (textBox5.Text.Length != 0 && comboBox7.Text.Length != 0 && textBox3.Text.Length != 0)
                {
                    Account.ToWriteExpenses(textBox5.Text, comboBox7.Text, dateTimePicker1.Text, textBox3.Text);
                    Account.ToReadFile(textBox4, "Expenses.txt");
                for (int i = 0; i < accMass.Length; i++)
                {
                    if (accMass[i].Name == comboBox7.Text)
                    {
                        accMass[i].TakeMoney(double.Parse(textBox3.Text));
                        Account.ToWriteMonetaryCondition(accMass);
                    }
                }
            }
                else
                { MessageBox.Show("Не все поля были заполнены!", "Ошибка!"); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Account.ToReadFile(textBox12, "MonetaryCondition.txt");
            button8.Text = $"Последнее обновление:\r\n{DateTime.Now}";
        }

       
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsLetter(e.KeyChar)  && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
    }
}
