using ClassLibraryForEB;
using System;
using System.Windows.Forms;



namespace ElectronicBookkeeping_AK___2
{
    public partial class ElectronicBookkeeping : Form
    {
        // massiv koshel`kov
        Account[] accMass = new Account[16];

        public ElectronicBookkeeping()
        {
            InitializeComponent();

            // inicializaciya koshel`kov
            for (int i = 1; i < 13; i++)
            {
                accMass[i - 1] = new Account(i + "-й конверт");
            }
            accMass[12] = new Account("Банковская карта");
            accMass[13] = new Account("Кошелёк");
            accMass[14] = new Account("Тайник");
            accMass[15] = new Account("На чёрный день");

        }

        private void ElectronicBookkeeping_Load(object sender, EventArgs e)
        {
            // sozdanie ispol`zuemih failov
            Account.CreateFiles(accMass);

            // update dannih o koshel`kah
            button2.Text = $"Псоледнее обновление:\r\n{DateTime.Now}";
            Account.ToReadMonetaryCondition(accMass);

            // zapis` dannih v sootvetstv. textboxi iz sootv. file
            Account.ToReadFile(textBox12, "MonetaryCondition.txt");
            Account.ToReadFile(textBox2, "Income.txt");
            Account.ToReadFile(textBox4, "Expenses.txt");

            TextBox[] Mass = new TextBox[] { textBox6, textBox7, textBox8, textBox9, textBox10,textBox13, textBox16,textBox17,
                textBox18, textBox19 };
            Account.ToReadExpensesPlan(Mass);
        }

        // zapis` v texbox i file "Income"
        private void button5_Click(object sender, EventArgs e) // Запись в файл доходов
        {
            if (comboBox1.Text.Length != 0 && comboBox2.Text.Length != 0 && textBox1.Text.Length != 0 && textBox1.Text.Length <= 20)
            {
                // vneseniye summi na schet
                Account.PutMoney(double.Parse(textBox1.Text), accMass, comboBox2.Text);

                // zapis` v file "Income" dannih
                Account.ToWriteIncome(comboBox1.Text, comboBox2.Text, dateTimePicker2.Text, textBox1.Text);

                // chtenie iz file "Income" dannih v textbox2
                Account.ToReadFile(textBox2, "Income.txt");
            }
            else
            {
                MessageBox.Show("Не все поля были заполнены или заполнены не корректно!", "Ошибка!");
            }
        }

        // zapis` v texbox i file "Expenses"
        private void button18_Click(object sender, EventArgs e) // Запись в файл затрат
        {
            if (textBox5.Text.Length != 0 && textBox5.Text.Length <= 20 && comboBox7.Text.Length != 0 && textBox3.Text.Length != 0 && textBox3.Text.Length <= 20)
            {
                Thing th1 = new Thing(textBox5.Text, comboBox7.Text, dateTimePicker1.Text, double.Parse(textBox3.Text));

                // // zapis` v file "Expenses" dannih i chtenie iz file "Expenses" dannih v textbox4
                Thing.BuyThing(ref accMass, th1, textBox4);
            }
            else
            {
                MessageBox.Show("Не все поля были заполнены или заполнены не корректно!", "Ошибка!");
            }
        }

        // pozvolyaet zapisat` v textBox3 tol`ko cifri  
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        // pozvolyaet zapisat` v textBox1 tol`ko cifri  
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void button6_Click(object sender, EventArgs e) // zapisb v file "ExpensesPlan" i podschet znacheniy v textbox11
        {
            string[] Mass = new string[] { textBox6.Text, textBox7.Text, textBox8.Text, textBox9.Text, textBox10.Text,
                textBox13.Text, textBox16.Text, textBox17.Text, textBox18.Text, textBox19.Text };

            Account.ToWriteExpensesPlan(Mass, textBox11);
        }

        // delete last stroku v texbox2 i file "Income"
        private void button17_Click(object sender, EventArgs e)
        {
            Account.DeleteLastRowIncome(textBox2, accMass, textBox4); // udalyaet poslednuyu zapisanuyu summu so scheta
        }

        // delete last stroku v texbox4 i file "Income"
        private void button16_Click(object sender, EventArgs e)
        {
            Account.DeleteLastRowExpenses(accMass, textBox4);
            Account.ToWriteIncome(comboBox1.Text, comboBox2.Text, dateTimePicker2.Text, textBox1.Text);
        }

        // open form="Spravka"
        private void button4_Click(object sender, EventArgs e)
        {
            Spravka spr1 = new Spravka();
            spr1.Show();
        }

        // obnovlenie dannih o koshel`kah (vkladka "MonetaryCondition")
        private void button1_Click(object sender, EventArgs e)
        {
            Account.ToReadFile(textBox12, "MonetaryCondition.txt");
            button2.Text = $"Псоледнее обновление:\r\n{DateTime.Now}";
        }

    }
}
