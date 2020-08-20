using System;
using System.Windows.Forms;

namespace KAM___Kursovaya___IVsem
{
    public abstract class Vessel
    {

        // имя сосуда
        private string name;

        // дата создания сосуда
        private DateTime dateCreate;

        // количество вещества в сосуде
        private double sum;



        // создание имени если оно соответствует длине (0,20) символов
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value.Length > 0 && value.Length < 20)
                {
                    name = value;
                }
                else
                {
                    MessageBox.Show("Имя счёта не соответствует длине (0,20) символов!", "Ошибка!");
                }
            }
        }

        // дата создания хранилища
        public DateTime DateCreate
        {
            get
            {
                return dateCreate;
            }
            set
            {
                if (value <= DateTime.Now)
                {
                    dateCreate = value;
                }
                else
                {
                    MessageBox.Show("Хранилище не может быть создано в будущем!", "Ошибка!");
                }
            }
        }

        // общая сумма денег в хранилище (BYN) 
        public double Sum
        {
            get
            {
                return sum;
            }
            set
            {
                if (value >= 0)
                {
                    sum = value;
                }
            }
        }



        // создание сосудаы
        public Vessel()
        {

        }

        // создание сосудаы
        public Vessel(string name1)
        {
            Name = name1;
            DateCreate = DateTime.Now;
            Sum = 0;
        }



    }
}
