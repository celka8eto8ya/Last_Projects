using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace KAM_KP_PSP__ClassLibrary_
{
    public class Server
    {
        /// <summary>
        /// Method for sending messages from Client to Server
        /// </summary>
        public static void GetMessage()
        {
            // порт для приема входящих запросов
            int serverPort = 8005;
            string serverAdress = "127.0.0.1";

            // получаем адреса для запуска сокета
            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(serverAdress), serverPort);

            // создаем сокет
            Socket listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                // связываем сокет с локальной точкой, по которой будем принимать данные
                listenSocket.Bind(ipPoint);
                // начинаем прослушивание
                listenSocket.Listen(30);

                while (true)
                {
                    bool b1 = false;

                    Socket handler = listenSocket.Accept();
                    // получаем сообщение
                    StringBuilder builder = new StringBuilder();
                    int bytes = 0; // количество полученных байтов
                    byte[] data = new byte[10000]; // буфер для получаемых данных

                    // Get Message
                    do
                    {
                        bytes = handler.Receive(data);
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (handler.Available > 0);

                    string[] getMessage = builder.ToString().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    //MessageBox.Show($"{getMessage[0]} {getMessage[1]} {getMessage[2]} {getMessage[3]}");







                    if (getMessage[0] == "EnterStorage")
                    {
                        try
                        {
                            // сверяем введенные данные с даннами текстбоксов и в случае neсовпадения присваиваем имя хранилища из текстбокса 
                            // статической переменной "Bank.StorageOfName"
                            int IdOfCurrentStorage = 0;
                            string StringAccess = "";
                            if (Database.AccessInStorage(getMessage[1], getMessage[2], getMessage[3]))
                            {
                                //
                                // по указанному имени хранилища записываю в переменную данные для последующего доступа к БД
                                //
                                Database.ReadDataFromFile(getMessage[1], ref StringAccess);

                                string[] Mass00 = StringAccess.Split(new char[] { ' ' });
                                Database.CheckIdOfStorage(Mass00[1], Mass00[0], ref IdOfCurrentStorage);

                                //
                                // Внесение события в таблицу
                                Event ev1 = new Event(getMessage[0], "Не финансовое", $"Вход в хранилище: \"{getMessage[1]}\"");
                                ev1.AddEventInDB(Mass00[1], IdOfCurrentStorage);
                                b1 = true;
                            }

                            // Send Answer
                            if (b1)
                            {
                                string StringAccessAndIdStorage = $"{StringAccess} {IdOfCurrentStorage}";
                                string ANSWER = $"Operation \"{getMessage[0]}\" completed successfully !#{StringAccessAndIdStorage}";
                                handler.Send(Encoding.Unicode.GetBytes(ANSWER));

                            }
                            else
                            {
                                handler.Send(Encoding.Unicode.GetBytes($"Operation \"{getMessage[0]}\" failed !"));
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }

                    if (getMessage[0] == "CreateStorage")
                    {
                        // 
                        // запись шапки таблицы "InfoAboutDBes"
                        //
                        Database.WriteShapkaInFile();

                        // 
                        // создание объекта "db1" для возможности подключения к БД
                        //
                        Database db1 = new Database(getMessage[1], getMessage[2], getMessage[3], getMessage[4]);

                        //// строка доступа к БД
                        //Bank.AccessInDB = db1.StringOfAccess;

                        // 
                        // проверка с помощью метода на уникальность введенных данных (о хранилище)
                        //
                        if (Database.CheckOnExclusive(getMessage[5], getMessage[6], getMessage[7])) // textBox7.Text, textBox6.Text, textBox4.Text
                        {
                            // 
                            // создание объекта "хранилище1" 
                            //
                            Storage storage1 = new Storage(getMessage[7], getMessage[5], getMessage[6]);

                            // 
                            // запись в файл данных для возможности подклчения к БД
                            //
                            db1.WriteDataInFile(storage1);

                            // 
                            // создание всех необходимых таблиц в указанной БД
                            //
                            db1.CreateDBSetOfTables();

                            // 
                            // запись в созданные таблицы (БД) информации о хранилище
                            //
                            db1.AddStorageInDB(storage1);

                            b1 = true;
                        }
                        else
                        {
                            MessageBox.Show("Логин, пароль или имя харнилища уже успользуются!", "Ошибка!");
                        }


                        // Send Answer
                        if (b1)
                        {
                            string ANSWER = $"Operation \"{getMessage[0]}\" completed successfully !#{Bank.AccessInDB}";
                            handler.Send(Encoding.Unicode.GetBytes(ANSWER));

                        }
                        else
                        {
                            handler.Send(Encoding.Unicode.GetBytes($"Operation \"{getMessage[0]}\" failed !"));
                        }
                    }

                    if (getMessage[0] == "DeleteStorage")
                    {
                        string StringAccess = "";
                        //
                        // по указанному имени хранилища записываю в переменную данные для последующего доступа к БД
                        //
                        Database.ReadDataFromFile(getMessage[3], ref StringAccess);
                        string[] Mass00 = StringAccess.Split(new char[] { ' ' });
                        MessageBox.Show($"{Mass00[0]} || {Mass00[1]}");
                        if (Mass00[0].Length > 0 && Mass00[1].Length > 0)
                        {
                            // удалить строку о хранилище из файла и БД, если данные текстбоксов совпадут
                            Database.DeleteStorage(getMessage[1], getMessage[2], getMessage[3], Mass00[1]);

                            b1 = true;
                        }

                        // Send Answer
                        if (b1)
                        {
                            handler.Send(Encoding.Unicode.GetBytes($"Operation \"{getMessage[0]}\" completed successfully !"));
                        }
                        else
                        {
                            handler.Send(Encoding.Unicode.GetBytes($"Operation \"{getMessage[0]}\" failed !"));
                        }
                    }

                    if (getMessage[0] == "StorageInfo")
                    {
                        // 
                        // показать таблицу "Storage" БД
                        //
                        string PartOfAnser = "";
                        Storage.Info(getMessage[1], ref PartOfAnser);

                        Storage.CalculateAmountOfAccount(getMessage[1], int.Parse(getMessage[2]));
                        Storage.CalculateTotalSumAndAmount(getMessage[1], int.Parse(getMessage[2]));


                        string ANSWER = $"Operation \"{getMessage[0]}\" completed successfully !#{PartOfAnser}";
                        handler.Send(Encoding.Unicode.GetBytes(ANSWER));
                    }

                    if (getMessage[0] == "AccountInfo")
                    {
                        string PartOfAnser = "";
                        // обновление данных таблиц
                        Account.Info(getMessage[1], int.Parse(getMessage[2]), ref PartOfAnser);


                        string ANSWER = $"Operation \"{getMessage[0]}\" completed successfully !#{PartOfAnser}";
                        handler.Send(Encoding.Unicode.GetBytes(ANSWER));
                    }

                    if (getMessage[0] == "CreateAccount")
                    {
                        string s = "";
                        foreach (string ii in getMessage)
                        {
                            s += $"{ii}\r\n";
                        }
                        MessageBox.Show(s);
                        Account acc1 = new Account();
                        int i = 0;

                        if (getMessage[4] == "Депозит")
                        {
                            try
                            {
                                i++;
                                //
                                // создается переменная аккаунт и является источник данных для метода или метод будет не статический
                                acc1 = new Account(getMessage[3], new TypeOfAccount(getMessage[4], double.Parse(getMessage[5]), getMessage[6], int.Parse(getMessage[7])), new CurrencyOfAccount(getMessage[8]), getMessage[9]);
                            }
                            catch
                            {

                            }
                        }
                        else if (getMessage[4] == "Текущий(только_в_BYN)")
                        {
                            try
                            {
                                i++;
                                acc1 = new Account(getMessage[3], getMessage[4], getMessage[5]);
                            }
                            catch
                            {

                            }
                        }
                        else if (getMessage[4] == "Валютный")
                        {
                            try
                            {
                                i++;
                                acc1 = new Account(getMessage[3], getMessage[4], new CurrencyOfAccount(getMessage[5]), getMessage[6]);
                            }
                            catch
                            {

                            }
                        }
                        MessageBox.Show($"acc1.Name={acc1.Name} i={i}");

                        if (acc1.CheckOnExclusiveAccountName(int.Parse(getMessage[2]), getMessage[1]))
                        {
                            // 
                            // запись данных в таблицу "AccountsOfStorage"
                            //
                            acc1.AddAccountInDB(getMessage[1], int.Parse(getMessage[2]));

                            //
                            // Внесение события в таблицу
                            Event ev1 = new Event(getMessage[0], "Не финансовое", $"Создание счёта: \"{getMessage[3]}\"");
                            ev1.AddEventInDB(getMessage[1], int.Parse(getMessage[2]));

                            string ANSWER = $"Operation \"{getMessage[0]}\" completed successfully !#{""}";
                            handler.Send(Encoding.Unicode.GetBytes(ANSWER));
                        }
                    }

                    if (getMessage[0] == "DeleteAccount")
                    {
                        // удаление строки о счёте и типе счёта из соответсвующих таблиц БД
                        Account.DeleteAccountInDB(getMessage[3], int.Parse(getMessage[2]), getMessage[1]);

                        //
                        // Внесение события в таблицу
                        Event ev1 = new Event("DeleteAccount", "Не финансовое", $"Удаление хранилища: \"{getMessage[3]}\"");
                        ev1.AddEventInDB(getMessage[1], int.Parse(getMessage[2]));

                        string ANSWER = $"Operation \"{getMessage[0]}\" completed successfully !#{""}";
                        handler.Send(Encoding.Unicode.GetBytes(ANSWER));
                    }

                    if (getMessage[0] == "AddMoney")
                    {
                        // добавление суммы на счёт
                        Account.AddGetMoney(getMessage[3], getMessage[4], "+", int.Parse(getMessage[2]), getMessage[1]);

                        //
                        // Внесение события в таблицу
                        Event ev1 = new Event("AddMoney", "Финансовое", $"Пополнение счёта \"{getMessage[3]}\" на {getMessage[4]} единиц");
                        ev1.AddEventInDB(getMessage[1], int.Parse(getMessage[2]));

                        string ANSWER = $"Operation \"{getMessage[0]}\" completed successfully !#{""}";
                        handler.Send(Encoding.Unicode.GetBytes(ANSWER));
                    }

                    if (getMessage[0] == "GetMoney")
                    {
                        // изъятие суммы со счёта
                        Account.AddGetMoney(getMessage[3], getMessage[4], "-", int.Parse(getMessage[2]), getMessage[1]);

                        //
                        // Внесение события в таблицу
                        Event ev1 = new Event("GetMoney", "Финансовое", $"Изъятие со счёта \"{getMessage[3]}\" на {getMessage[4]} единиц");
                        ev1.AddEventInDB(getMessage[1], int.Parse(getMessage[2]));

                        string ANSWER = $"Operation \"{getMessage[0]}\" completed successfully !#{""}";
                        handler.Send(Encoding.Unicode.GetBytes(ANSWER));
                    }

                    if (getMessage[0] == "ConvertMoney")
                    {
                        // конвертирование денег счёта, если счет валютный
                        Account.ChangeCurrency(getMessage[3], getMessage[4], getMessage[1], int.Parse(getMessage[2]));

                        //
                        // Внесение события в таблицу
                        Event ev1 = new Event("ConvertMoney", "Не финансовое", $"Конвертация счёта \"{getMessage[3]}\" в валюту {getMessage[4]}");
                        ev1.AddEventInDB(getMessage[1], int.Parse(getMessage[2]));

                        string ANSWER = $"Operation \"{getMessage[0]}\" completed successfully !#{""}";
                        handler.Send(Encoding.Unicode.GetBytes(ANSWER));
                    }

                    if (getMessage[0] == "ReplaceMoney")
                    {
                        string SS = "";
                        foreach (string s in getMessage)
                        {
                            SS += s;
                        }
                        MessageBox.Show(SS);
                        // Переместить сумму1 со счёта1 на счёт2
                        Account.ReplaceMoney(getMessage[3], getMessage[4], getMessage[5], getMessage[1], int.Parse(getMessage[2]));

                        //
                        // Внесение события в таблицу
                        Event ev1 = new Event("ReplaceMoney", "Финансовое", $"Перемещение со счёта \"{getMessage[3]}\" на счёт \"{getMessage[4]}\" {getMessage[5]} единиц");
                        ev1.AddEventInDB(getMessage[1], int.Parse(getMessage[2]));

                        string ANSWER = $"Operation \"{getMessage[0]}\" completed successfully !#{""}";
                        handler.Send(Encoding.Unicode.GetBytes(ANSWER));
                    }

                    if (getMessage[0] == "ShowNotFinancialEvents")
                    {
                        string PartOfAnser = "";
                        // Показываются события, которые не являются финансовыми
                        Event.FinancialInfo("!=", "Финансовое", getMessage[1], int.Parse(getMessage[2]), ref PartOfAnser);


                        string ANSWER = $"Operation \"{getMessage[0]}\" completed successfully !#{PartOfAnser}";
                        handler.Send(Encoding.Unicode.GetBytes(ANSWER));
                    }

                    if (getMessage[0] == "ShowFinancialEvents")
                    {
                        string PartOfAnser = "";
                        // Показываются события, которые не являются финансовыми
                        Event.FinancialInfo("=", "Финансовое", getMessage[1], int.Parse(getMessage[2]), ref PartOfAnser);


                        string ANSWER = $"Operation \"{getMessage[0]}\" completed successfully !#{PartOfAnser}";
                        handler.Send(Encoding.Unicode.GetBytes(ANSWER));
                    }

                    if (getMessage[0] == "ShowAllEvents")
                    {
                        string PartOfAnser = "";
                        // Показываются события всех типов 
                        Event.Info(getMessage[1], int.Parse(getMessage[2]), ref PartOfAnser);

                        string ANSWER = $"Operation \"{getMessage[0]}\" completed successfully !#{PartOfAnser}";
                        handler.Send(Encoding.Unicode.GetBytes(ANSWER));
                    }

                   


                    // закрываем сокет
                    handler.Shutdown(SocketShutdown.Both);
                    handler.Close();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
