using System;
using System.Windows.Forms;

namespace KAM___Kursovaya___IVsem
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 
            // запись шапки таблицы "InfoAboutDBes"
            //
            Database.WriteShapkaInFile();

            // 
            // создание объекта "db1" для возможности подключения к БД
            //
            Database db1 = new Database(textBox11.Text, textBox10.Text, textBox9.Text, textBox8.Text);

            // строка доступа к БД
            Bank.AccessInDB = db1.StringOfAccess;

            // 
            // проверка с помощью метода на уникальность введенных данных (о хранилище)
            //
            if (Database.CheckOnExclusive(textBox7.Text, textBox6.Text, textBox4.Text))
            {
                // 
                // создание объекта "хранилище1" 
                //
                Storage storage1 = new Storage(textBox4.Text, textBox7.Text, textBox6.Text);

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

                //
                // Внесение события в таблицу
                Event ev1 = new Event(button1.Text, "Не финансовое", $"Создание хранилища: \"{textBox4.Text}\"");
                ev1.AddEventInDB();
            }
            else
            {
                MessageBox.Show("Логин, пароль или имя харнилища уже успользуются!", "Ошибка!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // сверяем введенные данные с даннами текстбоксов и в случае совпадения присваиваем имя хранилища из текстбокса 
                // статической переменной "Bank.StorageOfName"
                if (Database.AccessInStorage(textBox2.Text, textBox5.Text, textBox12.Text))
                {
                    //
                    // по указанному имени хранилища записываю в переменную данные для последующего доступа к БД
                    //
                    Database.ReadDataFromFile(textBox12.Text);

                    Database.CheckIdOfStorage();

                    //
                    // Внесение события в таблицу
                    Event ev1 = new Event(button2.Text, "Не финансовое", $"Вход в хранилище: \"{textBox12.Text}\"");
                    ev1.AddEventInDB();

                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // удалить строку о хранилище из файла и БД, если данные текстбоксов совпадут
            Database.DeleteStorage(textBox3.Text, textBox1.Text, textBox13.Text, Bank.AccessInDB);

            //
            // Внесение события в таблицу
            Event ev1 = new Event(button4.Text, "Не финансовое", $"Удаление хранилища: \"{textBox13.Text}\"");
            ev1.AddEventInDB();
        }

      

    }
}
