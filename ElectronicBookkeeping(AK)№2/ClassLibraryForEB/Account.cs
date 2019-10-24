using System.IO;
using System.Windows.Forms;

namespace ClassLibraryForEB
{
    public class Account
    {
        public string Name { get; private set; }
        public double Sum { get; set; }

        public Account(string Name)
        {
            this.Name = Name;
            Sum = 0;
        }

        public void TakeMoney(double sum)
        {
            if (sum <= Sum)
            { Sum -= sum; }
            else
            { MessageBox.Show("Insufficient funds in account!", "Error!"); }
        }

        public void PutMoney(double sum) // 
        { Sum += sum; }

        public string InfoAboutAccount()
        {
            return $"Name: {Name} \r\nSum: {Sum} BYN";
        }

        public static void CreateFiles(Account[] Mass)
        {

        }
        public static void CreateAndWriteFiles(Account[] Mass)
        {
            string Drive = "";
            foreach (var drive in DriveInfo.GetDrives())
            {
                Drive = drive.Name;
            }

            FileInfo file1 = new FileInfo(Drive + "MonetaryCondition.txt");
            FileInfo file2 = new FileInfo(Drive + "Income.txt");
            FileInfo file3 = new FileInfo(Drive + "Expenses.txt");

            if (file1.Exists)
            {
                StreamWriter f00 = new StreamWriter(Drive + "MonetaryCondition.txt");

                f00.Write("{0, -20}|", "Name of Account");
                f00.WriteLine("{0, -20}|", "Amount on Account");
                f00.Write("{0, -20}|", new string('-', 20));
                f00.WriteLine("{0, -20}|", new string('-', 20));
                for (int i = 0; i < Mass.Length; i++)
                {
                    f00.Write("{0, -20}|", Mass[i].Name);
                    f00.WriteLine("{0, -20}|", Mass[i].Sum);
                }
                f00.Write("{0, -20}|", new string('-', 20));
                f00.WriteLine("{0, -20}|", new string('-', 20));
                f00.Close();
            }
            else
            { file1.Create(); }

            //if (file2.Exists)
            //{
            //    StreamWriter f00 = new StreamWriter(Drive + "MonetaryCondition.txt");
            //    for (int i = 0; i < Mass.Length; i++)
            //    {
            //        f00.Write("{0, -20}", Mass[i].Name);
            //        f00.WriteLine("{0, -20}", Mass[i].Sum);
            //    }
            //    f00.Close();
            //}
            //else
            //{ file2.Create(); }

            //if (file3.Exists)
            //{
            //    StreamWriter f00 = new StreamWriter(Drive + "MonetaryCondition.txt");
            //    for (int i = 0; i < Mass.Length; i++)
            //    {
            //        f00.Write("{0, -20}", Mass[i].Name);
            //        f00.WriteLine("{0, -20}", Mass[i].Sum);
            //    }
            //    f00.Close();
            //}
            //else
            //{ file3.Create(); }

        }


    }

}
