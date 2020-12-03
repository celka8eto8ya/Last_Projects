using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KAM_KP_PSP__ClassLibrary_
{
    public class Server
    {
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

                    string [] getMessage = builder.ToString().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    MessageBox.Show($"{getMessage[0]} {getMessage[1]} {getMessage[2]} {getMessage[3]}");


                    if (getMessage[0]== "EnterStorage")
                    {
                        try
                        {
                            // сверяем введенные данные с даннами текстбоксов и в случае neсовпадения присваиваем имя хранилища из текстбокса 
                            // статической переменной "Bank.StorageOfName"
                            if (Database.AccessInStorage(getMessage[1], getMessage[2], getMessage[3]))
                            {
                                //
                                // по указанному имени хранилища записываю в переменную данные для последующего доступа к БД
                                //
                                Database.ReadDataFromFile(getMessage[1]);

                                Database.CheckIdOfStorage();

                                //
                                // Внесение события в таблицу
                                Event ev1 = new Event(getMessage[0], "Не финансовое", $"Вход в хранилище: \"{getMessage[1]}\"");
                                ev1.AddEventInDB();
                                b1 = true;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }

                       
                    }



                    if (getMessage[0] == "CreateStorage")
                    {
                        //// 
                        //// запись шапки таблицы "InfoAboutDBes"
                        ////
                        //Database.WriteShapkaInFile();

                        //// 
                        //// создание объекта "db1" для возможности подключения к БД
                        ////
                        //Database db1 = new Database(textBox11.Text, textBox10.Text, textBox9.Text, textBox8.Text);

                        //// строка доступа к БД
                        //Bank.AccessInDB = db1.StringOfAccess;

                        //// 
                        //// проверка с помощью метода на уникальность введенных данных (о хранилище)
                        ////
                        //if (Database.CheckOnExclusive(textBox7.Text, textBox6.Text, textBox4.Text))
                        //{
                        //    // 
                        //    // создание объекта "хранилище1" 
                        //    //
                        //    Storage storage1 = new Storage(textBox4.Text, textBox7.Text, textBox6.Text);

                        //    // 
                        //    // запись в файл данных для возможности подклчения к БД
                        //    //
                        //    db1.WriteDataInFile(storage1);

                        //    // 
                        //    // создание всех необходимых таблиц в указанной БД
                        //    //
                        //    db1.CreateDBSetOfTables();

                        //    // 
                        //    // запись в созданные таблицы (БД) информации о хранилище
                        //    //
                        //    db1.AddStorageInDB(storage1);

                        //    //
                        //    // Внесение события в таблицу
                        //    Event ev1 = new Event(button1.Text, "Не финансовое", $"Создание хранилища: \"{textBox4.Text}\"");
                        //    ev1.AddEventInDB();
                        //}
                        //else
                        //{
                        //    MessageBox.Show("Логин, пароль или имя харнилища уже успользуются!", "Ошибка!");
                        //} 
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

                    // закрываем сокет
                    handler.Shutdown(SocketShutdown.Both);
                    handler.Close();
         
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
