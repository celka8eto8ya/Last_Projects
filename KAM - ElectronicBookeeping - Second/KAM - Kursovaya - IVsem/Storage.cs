using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace KAM___Kursovaya___IVsem
{
    public class Storage : Vessel
    {
        // количество счетов в хранилище
        private int amountOfAccount;

        // (логин и пароль хранилища)
        Security security;


        // количество счетов на хранилище
        public int AmountOfAccount
        {
            get
            {
                return amountOfAccount;
            }
            set
            {
                if (value >= 0)
                {
                    amountOfAccount = value;
                }
                else
                {
                    MessageBox.Show("Количество счетов в хранилище не может быть меньше 0!", "Ошибка!");
                }
            }
        }

        // Логин хранилища
        public string Login
        {
            get
            {
                return security.Login;
            }
            set
            {
                security.Login = value;
            }
        }

        // Пароль хранилища
        public string Password
        {
            get
            {
                return security.Password;
            }
            set
            {
                security.Password = value;
            }
        }



        // создание хранилища
        public Storage(string name1, string login1, string password1)
            : base(name1)
        {
            AmountOfAccount = 0;
            security = new Security(login1, password1);
        }



        // общая сумма денег текущего хранилища
        public static void CalculateTotalSumAndAmount()
        {
            MySqlConnection conn = new MySqlConnection(Bank.AccessInDB); // создается объект подключения (типо поток файловый)
            conn.Open(); // открываем поток

            string query0 = $"select SUM(Sum) from AccountsOfStorage where (IdOfStorage={Bank.IdOfCurrentStorage}) ;";
            MySqlCommand com0 = new MySqlCommand(query0, conn); // создаем объект, который выполняет наш запрос
            double TotalSum = Convert.ToInt32(com0.ExecuteScalar());

            string query1 = $"UPDATE Storage SET TotalSumOfStorage='{TotalSum}'  where ( Id= '{Bank.IdOfCurrentStorage}');";
            MySqlCommand com1 = new MySqlCommand(query1, conn); // создаем объект, который выполняет наш запрос
            com1.ExecuteScalar();
        }



        // Количество счетов на текущем хранилище   
        public static void CalculateAmountOfAccount()
        {
            MySqlConnection conn = new MySqlConnection(Bank.AccessInDB); // создается объект подключения (типо поток файловый)
            conn.Open(); // открываем поток

            string query = $"select Name from AccountsOfStorage  where ( Name!='' and  IdOfStorage= '{Bank.IdOfCurrentStorage}');";
            MySqlCommand com = new MySqlCommand(query, conn); // создаем объект, который выполняет наш запрос
            MySqlDataReader r1 = com.ExecuteReader(); // хранит все данные запроса (поток чтения)
            DataTable table1 = new DataTable();
            table1.Load(r1);

            query = $"UPDATE Storage SET AmountOfAccount='{table1.Rows.Count}'  where ( Id= '{Bank.IdOfCurrentStorage}');";
            com = new MySqlCommand(query, conn); // создаем объект, который выполняет наш запрос
            com.ExecuteScalar();
            r1.Close();
            conn.Close();
        }



        // вывод информации о хранилищах
        public static void Info(string AccessInDB, DataGridView dgv1)
        {
            try
            {
                dgv1.Rows.Clear();
                MySqlConnection conn = new MySqlConnection(AccessInDB); // создается объект подключения (типо поток файловый)
                conn.Open(); // открываем поток

                string query1 = "select * FROM Storage ;";
                MySqlCommand com = new MySqlCommand(query1, conn); // создаем объект, который выполняет наш запрос
                MySqlDataReader r1 = com.ExecuteReader(); // хранит все данные запроса (поток чтения)

                List<string[]> data = new List<string[]>();

                while (r1.Read())
                {
                    data.Add(new string[5]);

                    data[data.Count - 1][0] = r1[0].ToString();
                    data[data.Count - 1][1] = r1[1].ToString();
                    data[data.Count - 1][2] = r1[2].ToString();
                    data[data.Count - 1][3] = r1[3].ToString();
                    data[data.Count - 1][4] = r1[4].ToString();
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



    }
}
