using System.IO;
using System.Windows.Forms;

namespace ClassLibraryForEB
{
    public class Account
    {
        public string Name { get; private set; } // Imya shceta (koshel`ka)
        public double Sum { get; private set; } // Summa na schete

        public Account(string Name) 
        {
            this.Name = Name;
        }

        public static string NameDesk() // nahodit imya poslednego systemnogo diska na PC
        {
            string Drive = "";
            foreach (var drive in DriveInfo.GetDrives())
            {
                Drive = drive.Name;
            }
            return Drive;
        }

        public static void TakeMoney(double sum, Account[] accMass, Account el1, Thing th1) // beret denbgi so scheta
        {
            if (sum <= el1.Sum)
            {
                el1.Sum -= sum;

                ToWriteMonetaryCondition(accMass);
                ToWriteExpenses(th1);
            }
            else
            {
                MessageBox.Show("Недостаточно средств на счёте!", "Ошибка!");
            }
        }

        public static void PutMoney(double sum, Account[] accMass, string sourceName) // kladet denbgi na shchet
        {
            for (int i = 0; i < accMass.Length; i++)
            {
                if (sourceName.IndexOf(accMass[i].Name) == 0)
                {
                    accMass[i].Sum += sum;
                    ToWriteMonetaryCondition(accMass);
                }
            }
        }

        public static void CreateFiles(Account[] Mass) // если файлы не созданы, создаются с "шапками" (можно оптимизировать)
        {
            if (!new FileInfo(NameDesk() + "Income.txt").Exists)
            {
                StreamWriter f0 = new StreamWriter(NameDesk() + "Income.txt", true);

                // shapka table "Income" v file
                f0.Write("{0, -6}|", "№ п/п");          
                f0.Write("{0, -20}|", "Источник дохода");
                f0.Write("{0, -20}|", "Куда (Счёт)");
                f0.Write("{0, -20}|", "Дата дохода");
                f0.WriteLine("{0, -20}|", "Сумма, BYN");
                f0.Write("{0, -6}|", new string('-', 6));
                f0.Write("{0, -20}|", new string('-', 20));
                f0.Write("{0, -20}|", new string('-', 20));
                f0.Write("{0, -20}|", new string('-', 20));
                f0.WriteLine("{0, -20}|", new string('-', 20));

                f0.Close();
            }

            if (!new FileInfo(NameDesk() + "Expenses.txt").Exists)
            {
                StreamWriter f = new StreamWriter(NameDesk() + "Expenses.txt", true);

                // shapka table "Expenses" v file
                f.Write("{0, -6}|", "№ п/п");
                f.Write("{0, -20}|", "Предмет покупки");
                f.Write("{0, -20}|", "Откуда (Счёт)");
                f.Write("{0, -20}|", "Дата покупки");
                f.WriteLine("{0, -20}|", "Стоимость, BYN");
                f.Write("{0, -6}|", new string('-', 6));
                f.Write("{0, -20}|", new string('-', 20));
                f.Write("{0, -20}|", new string('-', 20));
                f.Write("{0, -20}|", new string('-', 20));
                f.WriteLine("{0, -20}|", new string('-', 20));

                f.Close();
            }

            if (!new FileInfo(NameDesk() + "MonetaryCondition.txt").Exists)
            {
                // sozdanie pustogo file "MonetaryCondition"
                StreamWriter f = new StreamWriter(NameDesk() + "MonetaryCondition.txt", true);
                f.Close();
                
                // zapis` v file dannih o schetah
                ToWriteMonetaryCondition(Mass);
            }

            if (!new FileInfo(NameDesk() + "ExpensesPlan.txt").Exists)
            {
                // sozdanie pustogo file "ExpensesPlan"
                StreamWriter f = new StreamWriter(NameDesk() + "ExpensesPlan.txt", true);
                f.Close();
            }
        }

        // zapis` v file dannih o schetah
        public static void ToWriteMonetaryCondition(Account[] Mass)
        {
            StreamWriter f00 = new StreamWriter(NameDesk() + "MonetaryCondition.txt");

            // shapka table "MonetaryCondition"
            f00.Write("{0, -6}|", "№ п/п");        
            f00.Write("{0, -20}|", "Имя счёта");
            f00.WriteLine("{0, -20}|", "Сумма на счёте, BYN");
            f00.Write("{0, -6}|", new string('-', 6));
            f00.Write("{0, -20}|", new string('-', 20));
            f00.WriteLine("{0, -20}|", new string('-', 20));

            // telo table "MonetaryCondition"
            double TotalSum = 0;
            for (int i = 0; i < Mass.Length; i++)          
            {
                f00.Write("{0, -6}|", i + 1);
                f00.Write("{0, -20}|", Mass[i].Name);
                f00.WriteLine("{0, -20}|", Mass[i].Sum);
                TotalSum += Mass[i].Sum;
            }

            f00.Write("{0, -6}|", new string('-', 6));
            f00.Write("{0, -20}|", new string('-', 20));
            f00.WriteLine("{0, -20}|", new string('-', 20));
            f00.Write("{0, -27}|", "ИТОГОВАЯ СУММА");
            f00.WriteLine("{0, -20}|", TotalSum);
            f00.Write("{0, -27}|", new string('-', 27));
            f00.Write("{0, -20}|", new string('-', 20));

            f00.Close();
        }

        // zapis` dannih v file "Income"
        public static void ToWriteIncome(string s1, string s2, string s3, string s4) 
        {
            int count = File.ReadAllLines(NameDesk() + "Income.txt").Length;
            StreamWriter f00 = new StreamWriter(NameDesk() + "Income.txt", true);

            // telo table "Income"
            f00.Write("{0, -6}|", (count + 1) / 2);   
            f00.Write("{0, -20}|", s1);
            f00.Write("{0, -20}|", s2);
            f00.Write("{0, -20}|", s3);
            f00.WriteLine("{0, -20}|", s4);
            f00.Write("{0, -6}|", new string('-', 6));
            f00.Write("{0, -20}|", new string('-', 20));
            f00.Write("{0, -20}|", new string('-', 20));
            f00.Write("{0, -20}|", new string('-', 20));
            f00.WriteLine("{0, -20}|", new string('-', 20));

            f00.Close();
        }

        // zapis` dannih v file "Expenses"
        public static void ToWriteExpenses(Thing th1) // запись в файл Expenses данных 
        {
            int count = File.ReadAllLines(NameDesk() + "Expenses.txt").Length; 
            StreamWriter f00 = new StreamWriter(NameDesk() + "Expenses.txt", true);

            // telo table "Expenses"
            f00.Write("{0, -6}|", (count + 1) / 2);
            f00.Write("{0, -20}|", th1.Name);                
            f00.Write("{0, -20}|", th1.SourceOfMoney);
            f00.Write("{0, -20}|", th1.DateBuying);
            f00.WriteLine("{0, -20}|", th1.Cost);
            f00.Write("{0, -6}|", new string('-', 6));
            f00.Write("{0, -20}|", new string('-', 20));
            f00.Write("{0, -20}|", new string('-', 20));
            f00.Write("{0, -20}|", new string('-', 20));
            f00.WriteLine("{0, -20}|", new string('-', 20));

            f00.Close();
        }

        // chtenie dannih iz file i zapis` ih v textbox
        public static void ToReadFile(TextBox textbox1, string put1) 
        {
            textbox1.Text = "";

            StreamReader f0 = new StreamReader(NameDesk() + put1);
            textbox1.Text = f0.ReadToEnd();
            f0.Close();
        }

        // zapis` dannih v file "ExpensePlan" 
        public static void ToWriteExpensesPlan(string[] Mass, TextBox tb1)
        {
            if (Mass[0].Length != 0 && Mass[1].Length != 0 && Mass[2].Length != 0 && Mass[3].Length != 0 && Mass[4].Length != 0 &&
                Mass[5].Length != 0 && Mass[6].Length != 0 && Mass[7].Length != 0 && Mass[8].Length != 0 && Mass[9].Length != 0)
            {
                double TotalExp = 0;
                double TotalInc = 0;

                StreamWriter f00 = new StreamWriter(NameDesk() + "ExpensesPlan.txt");

                // vichislenie ispolzuemih pokazatelei
                for (int i = 0; i < Mass.Length; i++)
                {
                    if (i < 6)
                    {
                        TotalExp += double.Parse(Mass[i]);
                    }
                    else
                    {
                        TotalInc += double.Parse(Mass[i]);
                    }

                    f00.WriteLine(Mass[i]);
                }

                f00.Close();

                // vivod v texbox dannih
                tb1.Text = "";
                tb1.Text += string.Format("{0, -37}", new string('-', 37));
                tb1.Text += $"Ожидаемые затраты (TC, BYN) на:\r\n\r\n1 месяц    = {TotalExp}\r\n1 семестр  = {TotalExp * 5}\r\n2 семестра = {TotalExp * 10}\r\n1 год      = {TotalExp * 12}\r\n\r\n";
                tb1.Text += string.Format("{0, -37}", new string('-', 37));
                tb1.Text += $"Ожидаемый доход (TR, BYN) на:\r\n\r\n1 месяц    = {TotalInc}\r\n1 семестр  = {TotalInc * 5}\r\n2 семестра = {TotalInc * 10}\r\n1 год      = {TotalInc * 12}\r\n\r\n";
                tb1.Text += string.Format("{0, -37}", new string('-', 37));
                tb1.Text += $"Ожидаемая прибыль (Π, BYN) на:\r\n\r\n1 месяц    = {TotalInc - TotalExp}\r\n1 семестр  = {(TotalInc - TotalExp) * 5}\r\n2 семестра = {(TotalInc - TotalExp) * 10}\r\n1 год      = {(TotalInc - TotalExp) * 12}\r\n\r\n";
                tb1.Text += string.Format("{0, -37}", new string('-', 37));
            }
            else
            {
                MessageBox.Show("Не все поля были заполнены!", "Ошибка!");
            }
        }

        // chtenie dannih iz file "ExpensesPlan" i zapis` ih v textboxi
        public static void ToReadExpensesPlan(TextBox[] MassText) // запись в файл Expenses данных 
        {
            string[] arStr = File.ReadAllLines(NameDesk() + "ExpensesPlan.txt");
            int count = File.ReadAllLines(NameDesk() + "ExpensesPlan.txt").Length; //длина файла
            if (count > 1)
            {
                for (int i = 0; i < MassText.Length; i++)
                {
                    MassText[i].Text = arStr[i];
                }
            }
        }

        // udalenie poslednei stroki table iz file i textbox "Income"
        public static void DeleteLastRowIncome(TextBox textbox1, Account[] AccMass, TextBox textbox2)
        {
            int count = File.ReadAllLines(NameDesk() + "Income.txt").Length; //длина файла
            if (count > 3)
            {
                string[] MassRows = File.ReadAllLines(NameDesk() + "Income.txt");

                Thing th1 = new Thing("DeleteRowIncome", (MassRows[MassRows.Length - 2]).Substring(28, 20),
                    "DeleteRowIncome", double.Parse((MassRows[MassRows.Length - 2]).Substring(70, 20)));
                Thing.BuyThing(ref AccMass, th1, textbox2);

                StreamWriter f00 = new StreamWriter(NameDesk() + "Income.txt");

                for (int i = 0; i < MassRows.Length - 2; i++)
                {
                    f00.WriteLine(MassRows[i]);
                }

                f00.Close();

                textbox1.Text = "";
                ToReadFile(textbox1, "Income.txt");
            }
        }

        // udalenie poslednei stroki table iz file i textbox "Expenses"
        public static void DeleteLastRowExpenses(Account[] AccMass, TextBox textbox2)
        {
            int count = File.ReadAllLines(NameDesk() + "Expenses.txt").Length; //длина файла
            if (count > 3)
            {
                string[] MassRows = File.ReadAllLines(NameDesk() + "Expenses.txt");

                PutMoney(double.Parse((MassRows[MassRows.Length - 2]).Substring(70, 20)), AccMass,
                    (MassRows[MassRows.Length - 2]).Substring(28, 20));

                StreamWriter f00 = new StreamWriter(NameDesk() + "Expenses.txt");
                for (int i = 0; i < MassRows.Length - 2; i++)
                {
                    f00.WriteLine(MassRows[i]);
                }
                f00.Close();

                textbox2.Text = "";
                ToReadFile(textbox2, "Expenses.txt");
            }
        }

        // chtenie dannih iz file "MonetaryCondition" i zapis` na sootvetstvuyuschie scheta 
        public static void ToReadMonetaryCondition(Account[] MassAcc)
        {
            string[] arStr = File.ReadAllLines(NameDesk() + "MonetaryCondition.txt");

            for (int i = 2; i < MassAcc.Length; i++)
            {
                MassAcc[i - 2].Sum = double.Parse(arStr[i].Substring(28, 20));
            }
        }
    }
}
