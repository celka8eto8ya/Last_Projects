using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace KAM_KP_PSP__ClassLibrary_
{
    public class OperationServer
    {
        public static void GetMessage(ref string allMessage)
        {
            try
            {
                IPAddress localAddr = IPAddress.Parse("127.0.0.1");
                TcpListener server = new TcpListener(localAddr, 5001);
                // Запускаем сервер
                server.Start();

                // Получаем входящее подключение
                TcpClient client = server.AcceptTcpClient();
                // Получаем сетевой поток для чтения и записи
                NetworkStream stream = client.GetStream();

                // Получаем ответ сервера
                    byte[] data = new byte[256];
                    //List<string> List = new List<string>();
                    StringBuilder response = new StringBuilder();
                    int bytes = 0;
                    do
                    {
                        bytes = stream.Read(data, 0, data.Length);
                        response.Append(Encoding.Unicode.GetString(data, 0, bytes));

                    }
                    while (stream.DataAvailable);

                    allMessage = response.ToString();
                MessageBox.Show(allMessage);
                
                //MessageBox.Show(Bank.allMessage);

                
                stream.Close();
                client.Close();
                // Закрываем слушающий объект
                server.Stop();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
