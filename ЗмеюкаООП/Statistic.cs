using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ЗмеюкаООП
{
  public class Statistic
    {
        private string put;
        private string slogn;
        private int schet;

        public string Put
        {
            get { return put; }
            set
            {
                if (put.Length > 0)
                { put = value; }
                else
                { MessageBox.Show("Ошибка!","Неподходящее значение поля put!"); }
            }
        }
        public string Slogn
        {
            get { return slogn; }
            set
            {
                if (slogn.Length > 0)
                { slogn = value; }
                else
                { MessageBox.Show("Ошибка!", "Неподходящее значение поля slogn!"); }
            }
        }
        public int Schet
        {
            get { return schet; }
            set
            {
                if (schet >= 0)
                { schet = value; }
                else
                { MessageBox.Show("Ошибка!", "Неподходящее значение поля schet!"); }
            }
        }
        public static void CreateFile()
        {
            string s = "";
            foreach (var drive in DriveInfo.GetDrives())
            {
                s = drive.Name;
            }
            Bank.Put = s + "Рекордсмены змейки (по уровням)" + ".txt";
            StreamWriter f5 = new StreamWriter(Bank.Put, true);
            f5.Close();
            string S = "1.    0\r\n2.    0\r\n3.    0\r\n4.    0\r\n5.    0";
            
            if (System.IO.File.ReadAllLines(Bank.Put).Length <= 1)
            {
                StreamWriter f1 = new StreamWriter(Bank.Put);
                f1.WriteLine("ТОП-5: (Змея)");
                f1.WriteLine(S);
                f1.WriteLine("ТОП-5: (Гадюка)");
                f1.WriteLine(S);
                f1.WriteLine("ТОП-5: (Змеюка)");
                f1.WriteLine(S);
                
                f1.Close();
            }
        }

        public static void UpdateSch(out string S)
        {
            string[] Mass = new string[18];
            int a = 0; int b = 0;
            if (Bank.Slog == "Змея")   { a = 0; b = 5; }
            if (Bank.Slog == "Гадюка") { a = 6; b = 11;}
            if (Bank.Slog == "Змеюка") { a = 12;b = 17;}

            StreamReader f2 = new StreamReader(Bank.Put);
            int i = 0;
            string s1 = "";
            while ((s1 = f2.ReadLine()) != null)
            {
                Mass[i] = s1;
                i++;
            }
            f2.Close();

            string s2 = ""; string s22 = "";
            for (i = a + 1; i <= b; i++)
            {
                s2 = Mass[i];
                for (int h = 3; h < 7; h++)
                { s22 += Convert.ToString(s2[h]); }

                if (Convert.ToInt32(s22) < Bank.Sch)
                {
                    if (i != 0 && i != 6 && i != 12)
                    {
                            string SchString = Bank.Sch.ToString();
                            if (SchString.Length == 1) Mass[i] = Convert.ToString(i - a+1) + ".    " + SchString;
                            if (SchString.Length == 2) Mass[i] = Convert.ToString(i - a + 1) + ".   " + SchString;
                            if (SchString.Length == 3) Mass[i] = Convert.ToString(i - a + 1) + ".  " + SchString;
                            if (SchString.Length == 4) Mass[i] = Convert.ToString(i - a + 1) + ". " + SchString;
                    }
                    break;
                }
                s2 = "";
                s22 = "";
            }

            StreamWriter f4 = new StreamWriter(Bank.Put);
            for (i = 0; i < 18; i++)
            {
                f4.WriteLine(Mass[i]);
            }
            f4.Close();

            S = "";
            for (int j = a; j <= b; j++)
            { S += Mass[j] + "\r\n"; }
        }
    }

  }


