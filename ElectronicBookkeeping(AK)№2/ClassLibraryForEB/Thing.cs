using System;

namespace ClassLibraryForEB
{
    public class Thing
    {
        public string Name { get; set; }
        public DateTime DtBuying { get; set; }
        public double Cost { get; set; }
        public string SourceOfMoney { get; set; }

        public Thing(string Name, string SourceOfMoney, double Cost)
        {
            this.Name = Name;
            DtBuying = DateTime.Now;
            this.Cost = Cost;
            this.SourceOfMoney = SourceOfMoney;
        }

        public void Buy(ref Account[] MASS)
        {
            for (int i = 0; i < 14; i++)
            {
                if (SourceOfMoney == MASS[i].Name)
                {
                    MASS[i].TakeMoney(Cost);
                }
            }

        }

        //public void PutMoney(double sum)
        //{ }

        //public string InfoAboutThing()
        //{
        //    return $"Name: {Name} \r\nSum: {Sum}";
        //}
    }
}
