using System.Windows.Forms;

namespace KAM___ElectronicBookeeping
{
    public class Thing
    {
        public string Name { get; set; } // Imya veschi
        public string SourceOfMoney { get; set; } // Istochnik oplati
        public string DateBuying { get; set; } // Data pokupki
        public double Cost { get; set; } // Stoimost` veschi

        public Thing(string Name, string SourceOfMoney, string DtBuying, double Cost)
        {
            this.Name = Name;
            this.SourceOfMoney = SourceOfMoney;
            DateBuying = DtBuying;
            this.Cost = Cost;
        }

        // pokupka veschi
        public static void BuyThing(ref Account[] MassAcc, Thing thing1, TextBox textbox1)
        {
            for (int i = 0; i < MassAcc.Length; i++)
            {
                if ((thing1.SourceOfMoney).IndexOf(MassAcc[i].Name) == 0)
                {
                    // snimat summu "th1.Cost" so scheta "MassAcc[i]" i zapisivaet dannie "thing1" v file
                    Account.TakeMoney(thing1.Cost, MassAcc, MassAcc[i], thing1);
                    // chitaet dannie iz file v textbox
                    Account.ToReadFile(textbox1, "Expenses.txt");
                }
            }
        }

    }
}
