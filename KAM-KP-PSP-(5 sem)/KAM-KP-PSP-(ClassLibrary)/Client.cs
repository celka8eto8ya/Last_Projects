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
    public class Client
    {
        public static void SendMessage(string command, List<string> list, ref bool b0, ref string ANSWER)
        {
            // адрес и порт сервера, к которому будем подключаться
            string address = Bank.ServerAdress;
            int port = Bank.ServerPort;

            try
            {
                IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(address), port);
                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                // подключаемся к удаленному хосту
                socket.Connect(ipPoint);

                string Parametres = "";
                for (int i = 0; i < list.Count; i++)
                {
                    Parametres +=" "+list[i];
                }
               
                // Send Message
                socket.Send(Encoding.Unicode.GetBytes($"{command} {Parametres}"));

                // Get Answer
                byte[] data = new byte[256]; // буфер для ответа
                int bytes = 0; // количество полученных байт
                StringBuilder builder = new StringBuilder();

                do
                {
                    bytes = socket.Receive(data, data.Length, 0);
                    builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                }
                while (socket.Available > 0);

                if (builder.ToString().IndexOf("failed") > 0)
                {
                    b0 = false;
                }
                else
                {
                    b0 = true;
                }

                

                // закрываем сокет
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();

                ANSWER = builder.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
