using System;
using System.Windows.Forms;

namespace KAM_KP_PSP__ClassLibrary_
{
    public class CurrencyOfAccount
    {
        // коэфф перевода из x-валюты в y-валюты
        private const double BYNtoBYN = 1;
        private const double RUBtoBYN = 0.031694;
        private const double USDtoBYN = 2.3636;//0.4230834320528008
        private const double EURtoBYN = 2.6391;
        private const double UAHtoBYN = 0.089058;  // название валюты
        private string name;


        public string Name
        {
            set
            {
                if (value == "BYN" || value == "RUB" || value == "USD" || value == "EUR" || value == "UAH")
                {
                    name = value;
                }
                else
                {
                    MessageBox.Show("Некорректно указано название валюты!", "Ошибка!");
                }
            }
            get
            {
                return name;
            }
        }

        public CurrencyOfAccount(string name1)
        {
            Name = name1;
        }


        // вычисление суммы (sum1) переведенной из валюты (х) в валюту (у)
        public static void ConvertOfCurrencies(string x, string y, ref double sum1)
        {
            int roundValue = 8;
            if (y == "BYN")
            {
                if (x == "RUB")
                {
                    sum1 = Math.Round((sum1 * RUBtoBYN), roundValue);
                }
                else if (x == "USD")
                {
                    sum1 = Math.Round((sum1 * USDtoBYN), roundValue);
                }
                else if (x == "EUR")
                {
                    sum1 = Math.Round((sum1 * EURtoBYN), roundValue);
                }
                else if (x == "UAH")
                {
                    sum1 = Math.Round((sum1 * UAHtoBYN), roundValue);
                }
            }
            else
            {
                if (x == "RUB")
                {
                    sum1 = Math.Round((sum1 * RUBtoBYN), roundValue);
                }
                else if (x == "USD")
                {
                    sum1 = Math.Round((sum1 * USDtoBYN), roundValue);
                }
                else if (x == "EUR")
                {
                    sum1 = Math.Round((sum1 * EURtoBYN), roundValue);
                }
                else if (x == "UAH")
                {
                    sum1 = Math.Round((sum1 * UAHtoBYN), roundValue);
                }

                if (y == "RUB")
                {
                    sum1 = Math.Round((sum1 / RUBtoBYN), roundValue);
                }
                else if (y == "USD")
                {
                    sum1 = Math.Round((sum1 / USDtoBYN), roundValue);
                }
                else if (y == "EUR")
                {
                    sum1 = Math.Round((sum1 / EURtoBYN), roundValue);
                }
                else if (y == "UAH")
                {
                    sum1 = Math.Round((sum1 / UAHtoBYN), roundValue);
                }
            }
        }

    }
}
