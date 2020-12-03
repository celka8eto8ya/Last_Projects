using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using MySql.Data.MySqlClient;

namespace KAM_KP_PSP__ClassLibrary_
{
    public class Database
    {
        // имя сервера
        private string serverName;
        // имя пользователя
        private string userName;
        // имя базы данных 
        private string databaseName;
        // пароль БД
        private string passwordOfServer;
        // строка доступа ("ключ") к БД
        private string stringOfAccess;


        // запись имени сервера если оно имеет размер (0,20) (символов)
        public string ServerName
        {
            get
            {
                return serverName;
            }
            set
            {
                if (value.Length > 0 && value.Length < 20)
                {
                    serverName = value;
                }
                else
                {
                    MessageBox.Show("Имя сервера не соответствует длине (0,20) символов!", "Ошибка!");
                }
            }
        }

        // запись имени пользователя если оно имеет размер (0,20) (символов)
        public string UserName
        {
            get
            {
                return userName;
            }
            set
            {
                if (value.Length > 0 && value.Length < 20)
                {
                    userName = value;
                }
                else
                {
                    MessageBox.Show("Имя пользователя не соответствует длине (0,20) символов!", "Ошибка!");
                }
            }
        }

        // запись БД если оно имеет размер (0,20) (символов)
        public string DatabaseName
        {
            get
            {
                return databaseName;
            }
            set
            {
                if (value.Length > 0 && value.Length < 20)
                {
                    databaseName = value;
                }
                else
                {
                    MessageBox.Show("Имя БД не соответствует длине (0,20) символов!", "Ошибка!");
                }
            }
        }

        // запись пароля сервера если он имеет размер (0,20) (символов)
        public string PasswordDatabase
        {
            get
            {
                return passwordOfServer;
            }
            set
            {
                if (value.Length > 0 && value.Length < 20)
                {
                    passwordOfServer = value;
                }
                else
                {
                    MessageBox.Show("Имя сервера не соответствует длине (0,20) символов!", "Ошибка!");
                }
            }
        }

        // запись пароля сервера если он длинее 0 (символов)
        public string StringOfAccess
        {
            get
            {
                return stringOfAccess;
            }
            set
            {
                if (value.Length > 0)
                {
                    stringOfAccess = value;
                }
                else
                {
                    MessageBox.Show(" \"Строка доступа\" к БД не указана!", "Ошибка!");
                }
            }
        }



        // 
        // конструктор (принимает значения текстбоксов формы 3)
        //
        public Database(string str1, string str2, string str3, string str4)
        {
            ServerName = str1;
            UserName = str2;
            DatabaseName = str3;
            PasswordDatabase = str4;

            StringOfAccess = "server=" + ServerName + ";user=" + UserName + ";database=" + DatabaseName + ";password=" + PasswordDatabase + ";";
        }



        // Form3 - btn("Создать") - 1
        // провекра "на уникальность" создаваемых данных (логина, пароля, имени хранилища)
        //
        public static bool CheckOnExclusive(string login1, string password1, string name1)
        {
            // чтение данных о учетн записях из файла
            int count = System.IO.File.ReadAllLines("InfoAboutDBes.txt").Length;
            StreamReader f00 = new StreamReader("InfoAboutDBes.txt");

            // переменная для определения совпадают ли данные хранилища
            int k = 0;
            int j = 0;
            string login = "";
            string password = "";
            string name = "";
            string s1 = "";

            while ((s1 = f00.ReadLine()) != null)
            {
                if (j > 1 && j % 2 == 0)
                {
                    login = "";
                    password = "";
                    name = "";

                    // вычленение логина из файла
                    for (int i = 91; i <= 111; i++)
                    {
                        if (s1[i] == ' ')
                        {
                            break;
                        }
                        else
                        {
                            login += s1[i].ToString();
                        }
                    }

                    // вычленение пароля из файла
                    for (int i = 112; i <= 132; i++)
                    {
                        if (s1[i] == ' ')
                        {
                            break;
                        }
                        else
                        {
                            password += s1[i].ToString();
                        }
                    }

                    // вычленение имени хранилища из файла
                    for (int i = 133; i <= 153; i++)
                    {
                        if (s1[i] == ' ')
                        {
                            break;
                        }
                        else
                        {
                            name += s1[i].ToString();
                        }
                    }


                    if (login1 == login || password1 == password || name1 == name)
                    {
                        k++;
                    }
                }
                j += 1;
            }
            f00.Close();

            if (k > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }



        // Form3 - btn("Создать") - 3
        // создание в БД набора необходимых таблиц
        //
        public void CreateDBSetOfTables()
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(StringOfAccess); // создается объект подключения (типо поток файловый)
                conn.Open(); // открываем поток

                string query1 = "" +

                "CREATE TABLE IF NOT EXISTS Storage" +
                "(" +
                    "Id INT primary key auto_increment," +
                    "Name VARChar(20)," +
                    "DateCreate DateTime," +
                    "AmountOfAccount int," +
                    "TotalSumOfStorage double" +
                "); " +

                "CREATE TABLE IF NOT EXISTS AccountsOfStorage" +
                "(" +
                    "Id INT primary key auto_increment, " +
                    "IdOfStorage int, " +
                    "Name VARChar(20), " +
                    "Sum float, " +
                    "Currency varchar(5), " +
                    "DateOfCreate DateTime, " +
                    "DateOfRefresh DateTime, " +
                    "Notation varchar(30), " +
                    "foreign key(IdOfStorage) REFERENCES Storage (Id)" +
                "); " +

                "CREATE TABLE IF NOT EXISTS TypeOfAccount" +
                "(" +
                    "Id INT primary key auto_increment, " +
                    "IdOfAccount int, " +
                    "Name VARChar(25), " +
                    "Percent double, " +
                    "Feedback varchar(13), " +
                    "Duration int, " +
                    "DaysLeft int, " +
                    "foreign key(IdOfAccount) REFERENCES AccountsOfStorage (Id)" +
                "); " +

                "CREATE TABLE IF NOT EXISTS Events" +
                "(" +
                    "Id INT primary key auto_increment, " +
                    "IdOfStorage int, " +
                    "Name VARChar(60)," +
                    "TypeOfEvent VARChar(30)," +
                    "DateOfOperation DateTime," +
                    "DescriptionOfEvent VARChar(60)" +
                "); ";

                // создаем объект, который выполняет наш запрос
                MySqlCommand com = new MySqlCommand(query1, conn);
                // хранит все данные запроса (поток чтения)
                MySqlDataReader r1 = com.ExecuteReader();

                r1.Close();
                conn.Close(); // закрываем поток 
            }
            catch
            {

            }
        }

        // Form3 - btn("Создать") - 0
        // запись шапки таблицы в файл "InfoAboutDBes"
        //
        public static void WriteShapkaInFile()
        {
            if (!new FileInfo("InfoAboutDBes.txt").Exists)
            {
                StreamWriter f0 = new StreamWriter("InfoAboutDBes.txt");

                f0.Write("{0, -6}|", "№ п/п");
                f0.Write("{0, -20}|", "Имя сервера");
                f0.Write("{0, -20}|", "Имя пользователя");
                f0.Write("{0, -20}|", "Пароль сервера");
                f0.Write("{0, -20}|", "Название БД");
                f0.Write("{0, -20}|", "Логин хранилища");
                f0.Write("{0, -20}|", "Пароль хранилища");
                f0.WriteLine("{0, -20}|", "Название хранилища");

                f0.Write("{0, -6}|", new string('-', 6));
                f0.Write("{0, -20}|", new string('-', 20));
                f0.Write("{0, -20}|", new string('-', 20));
                f0.Write("{0, -20}|", new string('-', 20));
                f0.Write("{0, -20}|", new string('-', 20));
                f0.Write("{0, -20}|", new string('-', 20));
                f0.Write("{0, -20}|", new string('-', 20));
                f0.WriteLine("{0, -20}|", new string('-', 20));

                f0.Close();
            }
        }


        // Form3 - btn("Создать") - 2
        // запись данных в файл для последующего подключения в БД
        //
        public void WriteDataInFile(Storage storage1)
        {
            int count = File.ReadAllLines("InfoAboutDBes.txt").Length;
            StreamWriter f1 = new StreamWriter("InfoAboutDBes.txt", true);

            f1.Write("{0, -6}|", (count + 1) / 2);
            f1.Write("{0, -20}|", ServerName);
            f1.Write("{0, -20}|", UserName);
            f1.Write("{0, -20}|", PasswordDatabase);
            f1.Write("{0, -20}|", DatabaseName);
            f1.Write("{0, -20}|", storage1.Login);
            f1.Write("{0, -20}|", storage1.Password);
            f1.WriteLine("{0, -20}|", storage1.Name);

            f1.Write("{0, -6}|", new string('-', 6));
            f1.Write("{0, -20}|", new string('-', 20));
            f1.Write("{0, -20}|", new string('-', 20));
            f1.Write("{0, -20}|", new string('-', 20));
            f1.Write("{0, -20}|", new string('-', 20));
            f1.Write("{0, -20}|", new string('-', 20));
            f1.Write("{0, -20}|", new string('-', 20));
            f1.WriteLine("{0, -20}|", new string('-', 20));

            f1.Close();
        }



        //  Form3 - btn("Создать") - 4
        // запись данных о хранилище в БД
        //
        public void AddStorageInDB(Storage storage1)
        {
            try
            {
                if (storage1.Name != null && (storage1.AmountOfAccount).ToString().Length > 0 && (storage1.Sum).ToString().Length > 0)
                {
                    MySqlConnection conn = new MySqlConnection(StringOfAccess); // создается объект подключения (типо поток файловый)
                    conn.Open(); // открываем поток

                    string query1 = "INSERT Storage (Name, DateCreate, AmountOfAccount, TotalSumOfStorage)" +
                    $"VALUES('{storage1.Name}','{storage1.DateCreate.ToString("yyyy-MM-dd")}',{storage1.AmountOfAccount}, {storage1.Sum} );";

                    MySqlCommand com = new MySqlCommand(query1, conn); // создаем объект, который выполняет наш запрос
                    MySqlDataReader r1 = com.ExecuteReader(); // хранит все данные запроса (поток чтения)
                    r1.Close();
                    conn.Close(); // закрываем поток 

                    MessageBox.Show($"Хранилище \"{storage1.Name}\" создано успешно!");
                }
                else
                {
                    MessageBox.Show($"Данные о хранилище были заполнены некорректно или отсутствуют!");
                }
            }
            catch
            {

            }
        }



        // Form3 - btn("Войти") - 0
        // сверка введенных данных с существующими, что имитирует вход и присвоение в случае совпадения
        // статической переменной для использования в любом месте программы
        //
        public static bool AccessInStorage(string name1, string login1, string password1)
        {
            // чтение данных о учетн записях из файла
            int count = System.IO.File.ReadAllLines("InfoAboutDBes.txt").Length;
            StreamReader f00 = new StreamReader("InfoAboutDBes.txt");

            // переменная для определения совпадают ли данные хранилища
            int k = 0;
            int j = 0;
            string login = "";
            string password = "";
            string name = "";
            string s1 = "";

            while ((s1 = f00.ReadLine()) != null)
            {
                if (j > 1 && j % 2 == 0)
                {
                    login = "";
                    password = "";
                    name = "";

                    // вычленение логина из файла
                    for (int i = 91; i <= 111; i++)
                    {
                        if (s1[i] == ' ')
                        {
                            break;
                        }
                        else
                        {
                            login += s1[i].ToString();
                        }
                    }

                    // вычленение пароля из файла
                    for (int i = 112; i <= 132; i++)
                    {
                        if (s1[i] == ' ')
                        {
                            break;
                        }
                        else
                        {
                            password += s1[i].ToString();
                        }
                    }

                    // вычленение имени хранилища из файла
                    for (int i = 133; i <= 153; i++)
                    {
                        if (s1[i] == ' ')
                        {
                            break;
                        }
                        else
                        {
                            name += s1[i].ToString();
                        }
                    }

                    if (login1 == login && password1 == password && name1 == name)
                    {
                        k++;
                    }
                }
                j += 1;
            }
            f00.Close();

            if (k > 0)
            {
                Bank.NameOfStorage = name1;
                MessageBox.Show($"Вы успешно выполнили вход в хранилище \"{name1}\" !", "Успех!");
                return true;
            }
            else
            {
                MessageBox.Show("Введен не существующий логин, пароль или имя хранилища!", "Ошибка!");
                return false;
            }
        }



        // Form3 - btn("Удалить") - 0
        // удалить строку о хранилище из файла и БД, если данные текстбоксов совпадут
        //
        public static void DeleteStorage(string login1, string password1, string name1, string AccessInDB)
        {
            // нужна чтобы знать номер элемента "ListOfStorageInfo" для удаления определенной строки файла
            int indDelete = 0;
            // чтение данных о учетн записях из файла
            int count = System.IO.File.ReadAllLines("InfoAboutDBes.txt").Length;
            StreamReader f00 = new StreamReader("InfoAboutDBes.txt");
            string[] MassOfStorageInfo = new string[count];

            // переменная для определения совпадают ли данные хранилища
            int k = 0;
            int j = 0;
            string login = "";
            string password = "";
            string name = "";
            string s1 = "";

            while ((s1 = f00.ReadLine()) != null)
            {
                MassOfStorageInfo[j] = s1;

                if (j > 1 && j % 2 == 0)
                {
                    login = "";
                    password = "";
                    name = "";

                    // вычленение логина из файла
                    for (int i = 91; i <= 111; i++)
                    {
                        if (s1[i] == ' ')
                        {
                            break;
                        }
                        else
                        {
                            login += s1[i].ToString();
                        }
                    }

                    // вычленение пароля из файла
                    for (int i = 112; i <= 132; i++)
                    {
                        if (s1[i] == ' ')
                        {
                            break;
                        }
                        else
                        {
                            password += s1[i].ToString();
                        }
                    }

                    // вычленение имени хранилища из файла
                    for (int i = 133; i <= 153; i++)
                    {
                        if (s1[i] == ' ')
                        {
                            break;
                        }
                        else
                        {
                            name += s1[i].ToString();
                        }
                    }

                    if (login1 == login && password1 == password && name1 == name)
                    {
                        k++;
                        indDelete = j;
                    }
                }
                j += 1;
            }
            f00.Close();

            if (k > 0)
            {
                try
                {
                    StreamWriter f0 = new StreamWriter("InfoAboutDBes.txt");
                    for (int ii = 0; ii < MassOfStorageInfo.Length; ii++)
                    {
                        if (ii != indDelete && ii != (indDelete + 1))
                        {
                            f0.WriteLine(MassOfStorageInfo[ii]);
                        }
                    }
                    f0.Close();


                    MySqlConnection conn = new MySqlConnection(AccessInDB); // создается объект подключения (типо поток файловый)
                    conn.Open(); // открываем поток

                    string query1 = " DELETE FROM Storage WHERE Name='" + name1 + "';";

                    MySqlCommand com = new MySqlCommand(query1, conn); // создаем объект, который выполняет наш запрос
                    MySqlDataReader r1 = com.ExecuteReader(); // хранит все данные запроса (поток чтения)
                    r1.Close();
                    conn.Close(); // закрываем поток 

                    MessageBox.Show($"Вы успешно удалили хранилище \"{name1}\" !", "Успех!");
                }
                catch
                {

                }
            }
            else
            {
                MessageBox.Show("Введен не существующий логин, пароль или имя хранилища!", "Ошибка!");
            }
        }



        // Form3 - btn("Войти") - 
        // "вытягивание данных для доступа к БД из файла и присвоение в случае совпадения
        // статической переменной для использования в любом месте программы
        //
        public static void ReadDataFromFile(string name1)
        {
            // чтение данных о учетн записях из файла
            int count = System.IO.File.ReadAllLines("InfoAboutDBes.txt").Length;
            StreamReader f00 = new StreamReader("InfoAboutDBes.txt");

            int j = 0;

            string serverName = "";
            string userName = "";
            string databaseName = "";
            string passwordDatabase = "";

            string name = "";
            string s1 = "";
            while ((s1 = f00.ReadLine()) != null)
            {
                if (j > 1 && j % 2 == 0)
                {
                    name = "";

                    // вычленение имени хранилища из файла
                    for (int i = 133; i <= 153; i++)
                    {
                        if (s1[i] == ' ')
                        {
                            break;
                        }
                        else
                        {
                            name += s1[i].ToString();
                        }
                    }


                    if (name1 == name)
                    {
                        // вычленение имени сервера из файла
                        for (int i = 7; i <= 27; i++)
                        {
                            if (s1[i] == ' ')
                            {
                                break;
                            }
                            else
                            {
                                serverName += s1[i].ToString();
                            }
                        }

                        // вычленение имени пользователя из файла
                        for (int i = 28; i <= 48; i++)
                        {
                            if (s1[i] == ' ')
                            {
                                break;
                            }
                            else
                            {
                                userName += s1[i].ToString();
                            }
                        }

                        // вычленение пароля БД из файла
                        for (int i = 49; i <= 69; i++)
                        {
                            if (s1[i] == ' ')
                            {
                                break;
                            }
                            else
                            {
                                passwordDatabase += s1[i].ToString();
                            }
                        }

                        // вычленение имени БД из файла
                        for (int i = 70; i <= 90; i++)
                        {
                            if (s1[i] == ' ')
                            {
                                break;
                            }
                            else
                            {
                                databaseName += s1[i].ToString();
                            }
                        }

                        Bank.NameOfStorage = name1;
                        Bank.AccessInDB = "server=" + serverName + ";user=" + userName + ";database=" + databaseName + ";password=" + passwordDatabase + ";";
                        break;
                    }
                }
                j += 1;
            }
            f00.Close();
        }



        // Form3 - ("Войти")
        // индекс необходим для того чтоб знать к какому хранилищу счёт отноится 
        //
        public static void CheckIdOfStorage()
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(Bank.AccessInDB); // создается объект подключения (типо поток файловый)
                conn.Open(); // открываем поток

                string query1 = $"Select Id FROM Storage where (Name='{Bank.NameOfStorage}');";


                MySqlCommand com = new MySqlCommand(query1, conn); // создаем объект, который выполняет наш запрос

                Bank.IdOfCurrentStorage = Convert.ToInt32(com.ExecuteScalar());

                conn.Close(); // закрываем поток 
            }
            catch
            {

            }
        }

    }
}
