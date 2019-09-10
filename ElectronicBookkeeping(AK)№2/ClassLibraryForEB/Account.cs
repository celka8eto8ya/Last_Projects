using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.IO;

namespace ClassLibraryForEB
{
    public class Account
    {
        public string   Name { get; set; }
        public double Sum { get; set; }

        public Account(string Name)
        {
            this.Name = Name;
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

        public static void WriteToFile(Account [] Mass)
        {
            string Drive = "";
            foreach (var drive in DriveInfo.GetDrives())
            {
                Drive = drive.Name;
            }
            
            FileInfo file1 = new FileInfo(Drive + "MonetaryCondition.txt");
            FileInfo file2 = new FileInfo(Drive + "Income.txt");
            FileInfo file3 = new FileInfo(Drive + "Expenses.txt");
            
                StreamWriter f0 = new StreamWriter(Drive + "MonetaryCondition.txt");
                f0.Close();
            
          
            StreamWriter f00 = new StreamWriter(Drive + "MonetaryCondition.txt");
          
            f00.Write("{0, -20}", "1-Envelope 09 ");
            f00.WriteLine("{0, -20}", Mass[0].Sum);
            f00.Write("{0, -20}", "2-Envelope 10 ");
            f00.WriteLine("{0, -20}", Mass[1].Sum);
            f00.Write("{0, -20}", "3-Envelope 11 ");
            f00.WriteLine("{0, -20}", Mass[2].Sum);
            f00.Write("{0, -20}", "4-Envelope 12 " );
            f00.WriteLine("{0, -20}", Mass[3].Sum);
            f00.Write("{0, -20}", "5-Envelope 01 ");
            f00.WriteLine("{0, -20}", Mass[4].Sum);
            f00.Write("{0, -20}", "6-Envelope 02 " );
            f00.WriteLine("{0, -20}", Mass[5].Sum);
            f00.Write("{0, -20}", "7-Envelope 03 " );
            f00.WriteLine("{0, -20}", Mass[6].Sum);
            f00.Write("{0, -20}", "8-Envelope 04 " );
            f00.WriteLine("{0, -20}", Mass[7].Sum);
            f00.Write("{0, -20}", "9-Envelope 05 " );
            f00.WriteLine("{0, -20}", Mass[8].Sum);
            f00.Write("{0, -20}", "10-Envelope 06 " );
            f00.WriteLine("{0, -20}", Mass[9].Sum);
            f00.Write("{0, -20}", "Bank Card " );
            f00.WriteLine("{0, -20}", Mass[10].Sum);
            f00.Write("{0, -20}", "11-Envelope " );
            f00.WriteLine("{0, -20}", Mass[11].Sum);
            f00.Write("{0, -20}", "Purse ");
            f00.WriteLine("{0, -20}", Mass[12].Sum);
            f00.Write("{0, -20}", "Cache " );
            f00.WriteLine("{0, -20}", Mass[13].Sum);
            f00.Close();

            //if (file2.Exists)
            //{

            //}
            //else
            //{ file2.Create(); }

            //if (file3.Exists)
            //{

            //}
            //else
            //{ file3.Create(); }

        }
    }
    
}
