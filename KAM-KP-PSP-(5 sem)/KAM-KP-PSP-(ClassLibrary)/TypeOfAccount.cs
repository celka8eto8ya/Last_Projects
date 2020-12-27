using System.Windows.Forms;

namespace KAM_KP_PSP__ClassLibrary_
{
    public class TypeOfAccount
    {
        // название типа счета 
        private string name;

        // процент для депозитного счета
        private double percent;

        // отзывность депозитного счета
        private string feedback;

        // длительность депозита (в днях)
        private int duration;

        // осталось дней депозита (в днях)
        private int daysLeft;



        // создание типа счета если оно удовлеворяет хотябы одному из трех значений
        public string Name
        {
            set
            {
                if (value == "Текущий(только_в_BYN)" || value == "Валютный" || value == "Депозит")
                {
                    name = value;
                }
                else
                {
                    MessageBox.Show("Неврено указан тип счёта!", "Ошибка!");
                }
            }
            get
            {
                return name;
            }
        }

        // процент для депозитного счета
        public double Percent
        {
            set
            {
                if (value >= 0)
                {
                    percent = value;
                }
                else
                {
                    MessageBox.Show("Неврено указан процент депозита!", "Ошибка!");
                }
            }
            get
            {
                return percent;
            }
        }

        // отзывность депозитного счета
        public string FeedBack
        {
            set
            {
                if (value == "Отзывный" || value == "Безотзывный")
                {
                    feedback = value;
                }
                else
                {
                    MessageBox.Show("Некорректно указана отзывность депозита!", "Ошибка!");
                }
            }
            get
            {
                return feedback;
            }
        }

        // длительность депозитного счета (в днях)
        public int Duration
        {
            set
            {
                if (value >= 0)
                {
                    duration = value;
                }
                else
                {
                    MessageBox.Show("Некорректно указана длительность депозита!", "Ошибка!");
                }
            }
            get
            {
                return duration;
            }
        }

        // количество дней до закрытия депозита
        public int DaysLeft
        {
            set
            {
                if (value >= 0)
                {
                    daysLeft = value;
                }
                else
                {
                    MessageBox.Show("Некорректно указано количество дней до \"завершения\" депозита !", "Ошибка!");
                }
            }
            get
            {
                return daysLeft;
            }
        }



        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="name1"></param>
        /// <param name="percent1"></param>
        /// <param name="feedback1"></param>
        /// <param name="duration1"></param>
        public TypeOfAccount(string name1, double percent1, string feedback1, int duration1)
        {
            Name = name1;
            Percent = percent1;
            FeedBack = feedback1;
            Duration = duration1;
            DaysLeft = duration1;
        }

        // нулевой
        public TypeOfAccount()
        {

        }



    }
}
