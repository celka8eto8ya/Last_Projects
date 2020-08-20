using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp73
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Примечание : программа расчитывает затраты с учетом того, что у вас есть только ");
            Console.Write("посуда и одежда ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("Все данные необходимо вводить : за 1 месяц | (BYN) ");
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("");

            Console.Write("Затраты на количество месяцев =");
            int mes = int.Parse(Console.ReadLine());
            double [] Sum = new double [mes];

            Console.Write("Cтоимость проживания в общежитии/кв. =");
            double kv = double.Parse(Console.ReadLine());
            Console.Write("Cтоимость использования света, холодильника =");
            double svet = double.Parse(Console.ReadLine());
            Console.Write("Cтоимость тарифа интернета =");
            double net = double.Parse(Console.ReadLine());
            Console.Write("Cтоимость абонплаты телефона =");
            double tel = double.Parse(Console.ReadLine());
            Console.Write("Cтипендия =");
            double stip = double.Parse(Console.ReadLine());
            Console.Write("Подработка (доп.доход) =");
            double podr = double.Parse(Console.ReadLine());
            Console.Write("Вас зовут Костючик Андрей (да/нет) ?");
            string imya = Console.ReadLine();
            double obshSum = 0;
            Console.WriteLine();

            if (imya == "нет")
            {
                double Eda = 98;
                double gigiena = 4.5;


                 obshSum = 0;

                double SumConst = kv + svet + net + tel + Eda + gigiena + podr - stip;
                int mesN = 1;
                for (int i = 0; i < mes; i++)
                {
                    if ((mesN == 1) || (mesN % 3 == 0) || (mesN % 5 == 0) || (mesN % 7 == 0))
                    {
                        if (mesN == 1)
                        {
                            Sum[i] = SumConst + 5 + 15 + 3 + 3 + 2 + 2.5 + 3 + 1 + 1 + 1;
                        }
                        if (mesN % 3 == 0)
                        {
                            Sum[i] = SumConst + 5 + 3;
                        }
                        if (mesN % 5 == 0)
                        {
                            Sum[i] = SumConst + 15 + 2.5 + 3;
                        }
                        if (mesN % 7 == 0)
                        {
                            Sum[i] = SumConst + 2;
                        }
                    }
                    else
                    { Sum[i] = SumConst; }
                    mesN = mesN + 1;
                }
                Console.WriteLine("-----------------------------------------------------");
                for (int i = 0; i < mes; i++)
                {
                    Console.WriteLine($"Месяц номер: {i + 1} || сумма: {Sum[i]} (своих денег)");
                }

                Console.WriteLine("-----------------------------------------------------");
                for (int i = 0; i < mes; i++)
                {
                    obshSum = obshSum + Sum[i];
                }
                Console.WriteLine("ОБЩАЯ СУММА ( с учетом стипендии ) за количество месяцев {0} равна {1} ", mes, obshSum);
            }
            else {
                double Eda = 60;
                double gigiena = 4.5;

                obshSum = 0;

                double SumConst = kv + svet + net + tel + Eda + gigiena + podr - stip;
                int mesN = 1;
                for (int i = 0; i < mes; i++)
                {
                    if ((mesN == 1) || (mesN % 3 == 0) || (mesN % 5 == 0) || (mesN % 7 == 0))
                    {
                        if (mesN == 1)
                        {
                            Sum[i] = SumConst + 5 + 15 + 3 + 3 + 2 + 2.5 + 3 + 1 + 1 + 1;
                        }
                        if (mesN % 3 == 0)
                        {
                            Sum[i] = SumConst + 5 + 3;
                        }
                        if (mesN % 5 == 0)
                        {
                            Sum[i] = SumConst + 15 + 2.5 + 3;
                        }
                        if (mesN % 7 == 0)
                        {
                            Sum[i] = SumConst + 2;
                        }
                    }
                    else
                    { Sum[i] = SumConst; }
                    mesN = mesN + 1;
                }
                Console.WriteLine("-----------------------------------------------------");
                for (int i = 0; i < mes; i++)
                {
                    Console.WriteLine($"Месяц номер: {i + 1} || сумма: {Sum[i]} (своих денег)");
                }

                Console.WriteLine("-----------------------------------------------------");
                for (int i = 0; i < mes; i++)
                {
                    obshSum = obshSum + Sum[i];
                }
                Console.WriteLine("ОБЩАЯ СУММА ( с учетом стипендии ) за количество месяцев {0} равна {1} ", mes, obshSum);
            }

            Console.ReadKey();
         
        }
        
    }
}
