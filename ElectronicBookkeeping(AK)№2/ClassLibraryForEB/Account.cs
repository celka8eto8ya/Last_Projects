using System.IO;
using System.Windows.Forms;

namespace ClassLibraryForEB
{
    public class Account
    {
        public string Name { get; private set; }
        public double Sum { get;private set; }

        public Account(string Name)
        {
            this.Name = Name;
        }

        public void TakeMoney(double sum) // взать деньги со счёта
        {
            if (sum <= Sum)
            { Sum -= sum; }
            else
            { MessageBox.Show("Недостаточно средств на счёте!", "Ошибка!"); }
        }

        public void PutMoney(double sum) // положить деньги на счёт
        { Sum += sum; }

        public static void CreateFiles() // если файлы не созданы, создаются с "шапками" (можно оптимизировать)
        {
            string Drive = "";                         
            foreach (var drive in DriveInfo.GetDrives())
            {
                Drive = drive.Name;
            }

            if (!new FileInfo(Drive + "Income.txt").Exists)
            {
                StreamWriter f0 = new StreamWriter(Drive + "Income.txt", true);

                f0.Write("{0, -6}|",      "№ п/п");          // шапка таблицы Income
                f0.Write("{0, -20}|",     "Источник дохода");         
                f0.Write("{0, -20}|",     "Куда (Счёт)");
                f0.Write("{0, -20}|",     "Дата дохода");
                f0.WriteLine("{0, -20}|", "Сумма");
                f0.Write("{0, -6}|",     new string('-', 6));
                f0.Write("{0, -20}|",     new string('-', 20));
                f0.Write("{0, -20}|",     new string('-', 20));
                f0.Write("{0, -20}|",     new string('-', 20));
                f0.WriteLine("{0, -20}|", new string('-', 20));

                f0.Close();
            }

            if (!new FileInfo(Drive + "Expenses.txt").Exists)
            {
                StreamWriter f = new StreamWriter(Drive + "Expenses.txt", true);

                f.Write("{0, -6}|",      "№ п/п");
                f.Write("{0, -20}|",     "Предмет покупки");           
                f.Write("{0, -20}|",     "Откуда (Счёт)");
                f.Write("{0, -20}|",     "Дата покупки");
                f.WriteLine("{0, -20}|", "Стоимость");
                f.Write("{0, -6}|",     new string('-', 6));
                f.Write("{0, -20}|",     new string('-', 20));
                f.Write("{0, -20}|",     new string('-', 20));
                f.Write("{0, -20}|",     new string('-', 20));
                f.WriteLine("{0, -20}|", new string('-', 20));

                f.Close();
            }
        }
        public static void ToWriteMonetaryCondition(Account[] Mass) // запись в файл данных
        {
            string Drive = "";
            foreach (var drive in DriveInfo.GetDrives())
            {
                Drive = drive.Name;
            }

            StreamWriter f00 = new StreamWriter(Drive + "MonetaryCondition.txt");

            f00.Write("{0, -6}|", "№ п/п");        // шапка таблицы MonetaryCondition
            f00.Write("{0, -20}|", "Имя счёта");
            f00.WriteLine("{0, -20}|", "Сумма на счёте");
            f00.Write("{0, -6}|", new string('-', 6));
            f00.Write("{0, -20}|", new string('-', 20));
            f00.WriteLine("{0, -20}|", new string('-', 20));

            double TotalSum = 0;
            for (int i = 0; i < Mass.Length; i++)           // тело таблицы MonetaryCondition
            {
                f00.Write("{0, -6}|",      i+1);
                f00.Write("{0, -20}|",     Mass[i].Name);
                f00.WriteLine("{0, -20}|", Mass[i].Sum);
                TotalSum += Mass[i].Sum;

            }
            f00.Write("{0, -6}|",      new string('-', 6));
            f00.Write("{0, -20}|",     new string('-', 20));
            f00.WriteLine("{0, -20}|", new string('-', 20));

          
            f00.Write("{0, -27}|", "ИТОГОВАЯ СУММА");
            f00.WriteLine("{0, -20}|", TotalSum);

           
            f00.Write("{0, -27}|", new string('-', 27));
            f00.WriteLine("{0, -20}|", new string('-', 20));

            f00.Close();
        }

        public static void ToWriteIncome(string s1, string s2, string s3,string s4) // запись в файл Income данных 
        {
            string Drive = "";
            foreach (var drive in DriveInfo.GetDrives())
            {
                Drive = drive.Name;
            }

            int count = System.IO.File.ReadAllLines(Drive + "Income.txt").Length;//длина файла 
            StreamWriter f00 = new StreamWriter(Drive + "Income.txt",true);

            f00.Write("{0, -6}|",      (count+1)/2);
            f00.Write("{0, -20}|",     s1);                 // тело таблицы Income
            f00.Write("{0, -20}|",     s2);
            f00.Write("{0, -20}|",     s3);
            f00.WriteLine("{0, -20}|", s4);
            f00.Write("{0, -6}|",      new string('-', 6));
            f00.Write("{0, -20}|",     new string('-', 20));
            f00.Write("{0, -20}|",     new string('-', 20));
            f00.Write("{0, -20}|",     new string('-', 20));
            f00.WriteLine("{0, -20}|", new string('-', 20));

            f00.Close();
        }

        public static void ToWriteExpenses(string s1, string s2, string s3,string s4) // запись в файл Expenses данных 
        {
            string Drive = "";
            foreach (var drive in DriveInfo.GetDrives())
            {
                Drive = drive.Name;
            }

            int count = System.IO.File.ReadAllLines(Drive + "Expenses.txt").Length;//длина файла 
            StreamWriter f00 = new StreamWriter(Drive + "Expenses.txt",true);
            f00.Write("{0, -6}|",      (count +1) / 2);
            f00.Write("{0, -20}|",     s1);                 // тело таблицы Expenses
            f00.Write("{0, -20}|",     s2);
            f00.Write("{0, -20}|",     s3);
            f00.WriteLine("{0, -20}|", s4);
            f00.Write("{0, -6}|",      new string('-', 6));
            f00.Write("{0, -20}|",     new string('-', 20));
            f00.Write("{0, -20}|",     new string('-', 20));
            f00.Write("{0, -20}|",     new string('-', 20));
            f00.WriteLine("{0, -20}|", new string('-', 20));

            f00.Close();
        }

        public static void ToReadFile(TextBox tb1, string put1) // вывод содержимого файла в текстбокс 
        {
            tb1.Text = "";

            string Drive = "";
            foreach (var drive in DriveInfo.GetDrives())
            {
                Drive = drive.Name;
            }

            StreamReader f0 = new StreamReader(Drive + put1);
            tb1.Text = f0.ReadToEnd();
            f0.Close();
        }

        public static void ToReadSumMass(Account[] Mass) // счтывание из файла данных в массив
        {
            string Drive = "";
            foreach (var drive in DriveInfo.GetDrives())
            {
                Drive = drive.Name;
            }
            string[] arStr = File.ReadAllLines(Drive + "MonetaryCondition.txt");
            for (int i = 2; i < Mass.Length; i++)
            {
                Mass[i-2].PutMoney(double.Parse(arStr[i].Substring(28, 20)));
            }


        }

    }

}
