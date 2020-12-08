using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KAM_KP_PSP__ClassLibrary_
{
    public class Event
    {
        // название события
        private string name;

        // тип события
        private string typeOfEvent;

        // дата происхождения события
        private DateTime dateOfOperation;

        // описание события
        private string descriptionOfEvent;

        /// <summary>
        /// 
        /// </summary>

        // название события (если оно в пределах (0,60) символов)
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value.Length > 0 && value.Length < 60)
                {
                    name = value;
                }
                else
                {
                    MessageBox.Show("Имя события не соответствует длине (0,60) символов!", "Ошибка!");
                }
            }
        }

        // тип события (если оно в пределах (0,60) символов)
        public string TypeOfEvent
        {
            get
            {
                return typeOfEvent;
            }
            set
            {
                if (value == "Финансовое" || value == "Не финансовое")
                {
                    typeOfEvent = value;
                }
                else
                {
                    MessageBox.Show("Некорректно указан тип события!", "Ошибка!");
                }
            }
        }

        // дата события 
        public DateTime DateOfOperation
        {
            get
            {
                return dateOfOperation;
            }
            set
            {
                if (value <= DateTime.Now)
                {
                    dateOfOperation = value;
                }
                else
                {
                    MessageBox.Show("Некорректно указана дата события!", "Ошибка!");
                }
            }
        }

        // описание (уточнение ) события 
        public string DescriptionOfEvent
        {
            get
            {
                return descriptionOfEvent;
            }
            set
            {
                if (value.Length > 0 && value.Length < 60)
                {
                    descriptionOfEvent = value;
                }
                else
                {
                    MessageBox.Show("Описание события не соответствует длине (0,60) символов!", "Ошибка!");
                }
            }
        }

        /// <summary>
        /// Дальше идут методы
        /// </summary>


        // конструктор класса
        public Event(string name1, string typeOfEvent1, string descriptionOfEvent1)
        {
            Name = name1;
            TypeOfEvent = typeOfEvent1;
            DateOfOperation = DateTime.Now;
            DescriptionOfEvent = descriptionOfEvent1;
        }

        /// <summary>
        /// Информация о всех событиях
        /// </summary>
        /// <param name="dgv1"></param>
        public static void Info(DataGridView dgv1)
        {
            try
            {
                dgv1.Rows.Clear();
                MySqlConnection conn = new MySqlConnection(Bank.AccessInDB); // создается объект подключения (типо поток файловый)
                conn.Open(); // открываем поток

                string query1 = $"select * from Events where (IdOfStorage='{Bank.IdOfCurrentStorage}');";

                MySqlCommand com = new MySqlCommand(query1, conn); // создаем объект, который выполняет наш запрос
                MySqlDataReader r1 = com.ExecuteReader(); // хранит все данные запроса (поток чтения)

                List<string[]> data = new List<string[]>();

                while (r1.Read())
                {
                    data.Add(new string[5]);

                    data[data.Count - 1][0] = r1[0].ToString();
                    data[data.Count - 1][1] = r1[2].ToString();
                    data[data.Count - 1][2] = r1[3].ToString();
                    data[data.Count - 1][3] = r1[4].ToString();
                    data[data.Count - 1][4] = r1[5].ToString();
                }

                r1.Close();

                foreach (string[] s in data)
                {
                    dgv1.Rows.Add(s);
                }
            }
            catch
            {

            }
        }



        /// <summary>
        /// Информация о событиях "==" или "!=" финансовым
        /// </summary>
        /// <param name="dgv1"></param>
        public static void FinancialInfo(DataGridView dgv1, string znak, string typeOfEvent1)
        {
            try
            {
                dgv1.Rows.Clear();
                MySqlConnection conn = new MySqlConnection(Bank.AccessInDB); // создается объект подключения (типо поток файловый)
                conn.Open(); // открываем поток

                string query1 = $"select * from Events where (TypeOfEvent{znak}'{typeOfEvent1}' and IdOfStorage='{Bank.IdOfCurrentStorage}');";

                MySqlCommand com = new MySqlCommand(query1, conn); // создаем объект, который выполняет наш запрос
                MySqlDataReader r1 = com.ExecuteReader(); // хранит все данные запроса (поток чтения)

                List<string[]> data = new List<string[]>();

                while (r1.Read())
                {
                    data.Add(new string[5]);

                    data[data.Count - 1][0] = r1[0].ToString();
                    data[data.Count - 1][1] = r1[2].ToString();
                    data[data.Count - 1][2] = r1[3].ToString();
                    data[data.Count - 1][3] = r1[4].ToString();
                    data[data.Count - 1][4] = r1[5].ToString();
                }

                r1.Close();

                foreach (string[] s in data)
                {
                    dgv1.Rows.Add(s);
                }
            }
            catch
            {

            }
        }


        /// <summary>
        /// Добавление в базу данных события
        /// </summary>
        public void AddEventInDB(string AccessString)
        {
            try
            {
                // создается объект подключения (типо поток файловый)
                MySqlConnection conn = new MySqlConnection(AccessString);
                conn.Open(); // открываем поток

                string query1 = $"INSERT Events (Name,IdOfStorage,TypeOfEvent, DateOfOperation, DescriptionOfEvent)" +
                $"VALUES('{Name}','{Bank.IdOfCurrentStorage}','{TypeOfEvent}','{DateOfOperation.ToString($"yyyy-MM-dd HH:mm:ss")}','{DescriptionOfEvent}')";

                MySqlCommand com1 = new MySqlCommand(query1, conn); // создаем объект, который выполняет наш запрос
                com1.ExecuteScalar();
                conn.Close(); // закрываем поток 
            }
            catch
            {

            }
        }

    }
}
