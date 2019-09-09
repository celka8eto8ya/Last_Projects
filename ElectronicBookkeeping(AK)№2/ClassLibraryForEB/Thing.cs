using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryForEB
{
    public class Thing
    {
        public string Name { get; set; }
        public DateTime Dt { get; set; }
        public double Cost { get; set; }
        public string SourceOfMoney { get; set; }

        public Thing(string Name, string SourceOfMoney, double Cost)
        {
            this.Name = Name;
                 Dt = DateTime.Now;
            this.Cost = Cost;
            this.SourceOfMoney = SourceOfMoney;
        }

        public void Buy(ref Account [] MASS)
        {
            for (int i = 0; i < 14; i++)
            {
                if (SourceOfMoney == MASS[i].Name)
                {
                    MASS[i].Sum -= Cost;
                }
            }

        }

        //public void PutMoney(double sum)
        //{ }

        //public string InfoAboutAccount()
        //{
        //    return $"Name: {Name} \r\nSum: {Sum}";
        //}
    }
}
