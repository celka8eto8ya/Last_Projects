using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
    }
    
}
