using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace KAM_KP_PSP__ClassLibrary_
{
    public class OperationClient
    {
        //public static void SendMessage(string operationName, List<string> Data)
        //{
        //    try
        //    {
        //        // Создаем клиента, используя конструктор по умолчанию
        //        TcpClient tcpClient = new TcpClient();
        //        // Подключаемся к серверу
        //        tcpClient.Connect("127.0.0.1", 5001);

        //        // Создаем поток, соединенный с сервером
        //        NetworkStream stream = tcpClient.GetStream();

        //        for (int i = 0; i < Data.Count; i++)
        //        {
        //            // Формируем сообщение. Преобразуем его в массив байтов
        //            byte[] data = Encoding.UTF8.GetBytes(Data[i]);
        //            // Отправка сообщения
        //            stream.Write(data, 0, data.Length);
        //        }

        //        // Закрываем потоки
        //        stream.Close();
        //        tcpClient.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //}


        public static void SendMessage(/*string operationName*//*, List<string> Data*/)
        {
            try
            {
                // Создаем клиента, используя конструктор по умолчанию
                TcpClient tcpClient = new TcpClient();
                // Подключаемся к серверу
                tcpClient.Connect("127.0.0.1", 5001);

                // Создаем поток, соединенный с сервером
                NetworkStream stream = tcpClient.GetStream();

                //for (int i = 0; i < Data.Count; i++)
                //{
                //    // Формируем сообщение. Преобразуем его в массив байтов
                //    byte[] data = Encoding.UTF8.GetBytes(Data[i]);
                //    // Отправка сообщения
                //    stream.Write(data, 0, data.Length);
                //}


               // Формируем сообщение. Преобразуем его в массив байтов
                    byte[] data = Encoding.UTF8.GetBytes("Оло ебать");
                // Отправка сообщения
                stream.Write(data, 0, data.Length);

                // Закрываем потоки
                stream.Close();
                tcpClient.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }



        }

    }
}

