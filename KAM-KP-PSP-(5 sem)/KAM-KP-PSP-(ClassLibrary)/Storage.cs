using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace KAM_KP_PSP__ClassLibrary_
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




        /// <summary>
        /// Calculate total sum of Storage
        /// </summary>
        /// <param name="AccessString"></param>
        /// <param name="IdOfCurrentStorage"></param>
        public static void CalculateTotalSumAndAmount(string AccessString, int IdOfCurrentStorage)
        {
            MySqlConnection conn = new MySqlConnection(AccessString); // создается объект подключения (типо поток файловый)
            conn.Open(); // открываем поток

            string query0 = $"select SUM(Sum) from AccountsOfStorage where (IdOfStorage={IdOfCurrentStorage}) ;";
            MySqlCommand com0 = new MySqlCommand(query0, conn); // создаем объект, который выполняет наш запрос
            double TotalSum = Convert.ToInt32(com0.ExecuteScalar());

            string query1 = $"UPDATE Storage SET TotalSumOfStorage='{TotalSum}'  where ( Id= '{IdOfCurrentStorage}');";
            MySqlCommand com1 = new MySqlCommand(query1, conn); // создаем объект, который выполняет наш запрос
            com1.ExecuteScalar();
        }


        /// <summary>
        /// Amount of Account on this Storage
        /// </summary>
        /// <param name="AccessString"></param>
        /// <param name="IdOfCurrentStorage"></param>
        public static void CalculateAmountOfAccount(string AccessString, int IdOfCurrentStorage)
        {
            MySqlConnection conn = new MySqlConnection(AccessString); // создается объект подключения (типо поток файловый)
            conn.Open(); // открываем поток

            string query = $"select Name from AccountsOfStorage  where ( Name!='' and  IdOfStorage= '{IdOfCurrentStorage}');";
            MySqlCommand com = new MySqlCommand(query, conn); // создаем объект, который выполняет наш запрос
            MySqlDataReader r1 = com.ExecuteReader(); // хранит все данные запроса (поток чтения)
            DataTable table1 = new DataTable();
            table1.Load(r1);

            query = $"UPDATE Storage SET AmountOfAccount='{table1.Rows.Count}'  where ( Id= '{IdOfCurrentStorage}');";
            com = new MySqlCommand(query, conn); // создаем объект, который выполняет наш запрос
            com.ExecuteScalar();
            r1.Close();
            conn.Close();
        }


        /// <summary>
        /// Output info about Storage
        /// </summary>
        /// <param name="AccessInDB"></param>
        /// <param name="AnswerString"></param>
        public static void Info(string AccessInDB, ref string AnswerString)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(AccessInDB); // создается объект подключения (типо поток файловый)
                conn.Open(); // открываем поток

                string query1 = "select * FROM Storage ;";
                MySqlCommand com = new MySqlCommand(query1, conn); // создаем объект, который выполняет наш запрос
                MySqlDataReader r1 = com.ExecuteReader(); // хранит все данные запроса (поток чтения)

                string MESSAGE = "";
                while (r1.Read())
                {
                    MESSAGE += $"{r1[0].ToString()}|" +
                        $"{r1[1].ToString()}|" +
                        $"{r1[2].ToString()}|" +
                        $"{r1[3].ToString()}|" +
                        $"{r1[4].ToString()}%";
                }
                AnswerString = MESSAGE;

                r1.Close();
            }
            catch
            {

            }
        }



    }
}
