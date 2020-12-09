using KAM_KP_PSP__ClassLibrary_;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KAM_KP_PSP_Server
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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
