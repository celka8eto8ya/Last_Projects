using KAM_KP_PSP__ClassLibrary_;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KAM_KP_PSP_Server
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //timer1.Start();

            //string message = "";
            //OperationServer.GetMessage(ref message);
            //textBox1.Text = message;


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //const int port = 8888; // порт для прослушивания подключений

            //TcpListener server = null;
            //try
            //{
            //    IPAddress localAddr = IPAddress.Parse("127.0.0.1");
            //    server = new TcpListener(localAddr, port);

            //    // запуск слушателя
            //    server.Start();

            //    while (true)
            //    {
            //        MessageBox.Show("Ожидание подключений... ");

            //        // получаем входящее подключение
            //        TcpClient client = server.AcceptTcpClient();
            //        MessageBox.Show("Подключен клиент. Выполнение запроса...");

            //        // получаем сетевой поток для чтения и записи
            //        NetworkStream stream = client.GetStream();

            //        // сообщение для отправки клиенту
            //        string response = "Привет мир";
            //        // преобразуем сообщение в массив байтов
            //        byte[] data = Encoding.UTF8.GetBytes(response);

            //        // получаем сообщение
            //        StringBuilder builder = new StringBuilder();
            //        int bytes = 0;
            //        do
            //        {
            //            bytes = stream.Read(data, 0, data.Length);
            //            builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
            //        }
            //        while (stream.DataAvailable);

            //        MessageBox.Show(builder.ToString());
            //        // отправка сообщения
            //        stream.Write(data, 0, data.Length);
            //        MessageBox.Show("Отправлено сообщение: {0}", response);
            //        // закрываем поток
            //        stream.Close();
            ////        // закрываем подключение
            ////        client.Close();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            //finally
            //{
            //    if (server != null)
            //    {
            //        server.Stop();
            //    }
            //}

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Task task = new Task(Server.GetMessage);
                task.Start();

                textBox2.Text = "Сервер запущен. Ожидание подключений...";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
