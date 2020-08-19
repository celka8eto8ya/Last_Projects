using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using MySql.Data.MySqlClient;

namespace Pr2_СУБД_MySQL_
{
    public partial class Form2 : Form
    {
        public void ShowDB(string table, int x,string pred) // метод показывает базу данных с пом (dataGridView)
        {
            try
            {
                DataTable table1;

                string connStr = Bank1.CONNSTR; // для подключения к серверу
                MySqlConnection conn = new MySqlConnection(Bank1.CONNSTR); // создается объект подключения (типо поток файловый)
                conn.Open(); // открываем поток
                string sql1 = "";
                if (x == 3 && table[0] == 'P')
                {
                    if (pred == "Все")
                    { sql1 = "select * from table" + table + " where( (DatePost>='" + dateTimePicker3.Text + "') and (DatePost<='" + dateTimePicker4.Text + "' ))"; }
                    else
                    { sql1 = "select * from table" + table + " where( (DatePost>='" + dateTimePicker3.Text + "') and (DatePost<='" + dateTimePicker4.Text + "' ) and (IstPost='" + pred + "' ))"; }

                }
                if (x == 3 && table[0] == 'Z')
                {
                    if (pred == "Все")
                    { sql1 = "select * from table" + table + " where( (DatePok>='" + dateTimePicker3.Text + "') and (DatePok<='" + dateTimePicker4.Text + "' ))"; }
                    else
                    { sql1 = "select * from table" + table + " where( (DatePok>='" + dateTimePicker3.Text + "') and (DatePok<='" + dateTimePicker4.Text + "' ) and (PredPok='" + pred + "' ))"; }

                }
                if (x != 3)
                {
                    sql1 = "select * from table" + table;
                }
                MySqlCommand com = new MySqlCommand(sql1, conn); // создаем объект, который выполняет наш запрос
                MySqlDataReader r1 = com.ExecuteReader(); // хранит все данные запроса (поток чтения)


                table1 = new DataTable();
                table1.Load(r1);       // Загружаем таблицу из базы данных

                // Задаем таблицу tablePersons в качестве источника данных для объекта-сетки
                if (x == 1)
                { dataGridView1.DataSource = table1; }
                if (x == 2)
                { dataGridView2.DataSource = table1; }
                if (x == 3)
                { dataGridView3.DataSource = table1; }
                r1.Close();
                conn.Close(); // закрываем поток 
            }
            catch  {  }
        }
        // "статистика" для файла (текстового) в отлич от пред метода (он для БД)
        public void StatS(int DateX,int DateY,int SumX,int SumY, int IstX, int IstY, string put,string predmet,int obrez,int Leng) 
        { 
                    int count = System.IO.File.ReadAllLines(put).Length;
                    string[] Mass = new string[count];
                    string s1 = ""; int i = 0;

                    StreamReader f0 = new StreamReader(put);
                    while ((s1 = f0.ReadLine()) != null)
                    {
                        Mass[i] = s1;
                        i++;
                    }
                    f0.Close();

                    string S = Mass[0] + "\r\n" + Mass[1] + "\r\n";
                    double SUM = 0;
                    string sum = "";
                    string istoch = "";
                    string date = "";
                    for (int j = 0; j<count - 2; j++)
                    {
                        if (j > 1 && j % 2 == 0 && j<(count - 2))
                        {
                            if (comboBox4.Text == "Все")
                            {
                                date = "";
                                for (int g = DateX; g< DateY; g++)
                                { date += Convert.ToString((Mass[j])[g]); }

                                if (Convert.ToDateTime(date) >= dateTimePicker3.Value && Convert.ToDateTime(date) <= dateTimePicker4.Value)
                                {
                                    sum = "";
                                    S = S + Mass[j] + "\r\n" + Mass[1] + "\r\n";
                                    for (int g = SumX; g< SumY; g++)
                                    {

                                        if ((Mass[j])[g] == ' ') { break; }
                                        else { sum += Convert.ToString((Mass[j])[g]); }

                                    }
                                    SUM += Convert.ToDouble(sum);
                                }
                            }
                            else
                            {
                                istoch = "";
                                date = "";
                                for (int g = DateX; g< DateY; g++)
                                { date += Convert.ToString((Mass[j])[g]); }
                                for (int g = IstX; g< IstY; g++)
                                {
                                    if ((Mass[j])[g] == ' ') { break; }
                                    else { istoch += Convert.ToString((Mass[j])[g]); }
                                }
                               
                                if (Convert.ToDateTime(date) >= dateTimePicker3.Value && Convert.ToDateTime(date) <= dateTimePicker4.Value && istoch==comboBox4.Text )
                                {
                                    sum = "";
                                    S = S + Mass[j] + "\r\n" + Mass[1] + "\r\n";
                                    for (int g = SumX; g< SumY; g++)
                                    {
                                        if ((Mass[j])[g] == ' ') { break; }
                                        else { sum += Convert.ToString((Mass[j])[g]); }
                                    }
                                    SUM += Convert.ToDouble(sum);
                                }
                            }
                        }
                    }
                    string s = Mass[count - 2];
                    s = s.Substring(0, obrez);
                    s += SUM;
                    while (s.Length< Leng)
                    { s += " "; }
                    s += "|";

                    S = S + s + "\r\n" + Mass[count - 1] + "\r\n";
                    textBox7.Text = S;
        }
        public void Itogo(string table,string pred, int x) // метод для подсчета (ИТОГО) в зависимости от выбранного варианта статистики
        {
            try
            {
                MySqlConnection conn1 = new MySqlConnection(Bank1.CONNSTR); // создается объект подключения (типо поток файловый)
                conn1.Open(); // открываем поток

                string sql1 = "";
                if (x == 1) { sql1 = "select sum(SumPost) from table" + table; }

                if (x == 2) { sql1 = "select sum(Stoit)   from table" + table; }

                if (x == 3)
                {
                    if (table[0] == 'P')
                    {
                        if (pred == "Все")
                        {
                            sql1 = "select sum(SumPost) from table" + table + " where( (DatePost>='" + dateTimePicker3.Text + "') and (DatePost<='" + dateTimePicker4.Text + "' ))";
                        }
                        else
                        {
                            sql1 = "select sum(SumPost) from table" + table + " where( (DatePost>='" + dateTimePicker3.Text + "') and (DatePost<='" + dateTimePicker4.Text + "' ) and (IstPost='" + pred + "' ))";
                        }

                    }
                    if (table[0] == 'Z')
                    {
                        if (pred == "Все")
                        {
                            sql1 = "select sum(Stoit) from table" + table + " where( (DatePok>='" + dateTimePicker3.Text + "') and (DatePok<='" + dateTimePicker4.Text + "' ))";
                        }
                        else
                        {
                            sql1 = "select sum(Stoit) from table" + table + " where( (DatePok>='" + dateTimePicker3.Text + "') and (DatePok<='" + dateTimePicker4.Text + "' ) and (PredPok='" + pred + "' ))";
                        }
                    }
                }
                MySqlCommand com1 = new MySqlCommand(sql1, conn1); // создаем объект, который выполняет наш запрос
                double r1 = 0;
                try
                { r1 = Convert.ToDouble(com1.ExecuteScalar()); }
                catch (Exception ex) { }
                if (x == 1)
                {
                    dataGridView1[3, dataGridView1.RowCount - 1].Value = r1;
                    dataGridView1[0, dataGridView1.RowCount - 1].Value = "ИТОГО";
                }

                if (x == 2)
                {
                    dataGridView2[3, dataGridView2.RowCount - 1].Value = r1;
                    dataGridView2[0, dataGridView2.RowCount - 1].Value = "ИТОГО";
                }

                if (x == 3)
                {
                    dataGridView3[3, dataGridView3.RowCount - 1].Value = r1;
                    dataGridView3[0, dataGridView3.RowCount - 1].Value = "ИТОГО";
                }
                conn1.Close(); // закрываем поток 
            }
            catch { }
        }
        public Form2()
        {
            InitializeComponent();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) // запись в файл БД данных (в завис от TIP)
                                                               // усложнено тем что в конце таблицы подсчитывается сумма (ИТОГО)
        {
            try
            {
                if ((comboBox1.Text).Length == 0 || (textBox4.Text).Length == 0)
                { MessageBox.Show("Ошибка: не все поля были заполнены!"); }
                else
                {
                    if (Bank1.TIP == 2 || Bank1.TIP == 3)
                    {
                        try
                        {
                            MySqlConnection conn = new MySqlConnection(Bank1.CONNSTR); // создается объект подключения (типо поток файловый)
                            conn.Open(); // открываем поток

                            string sql1 = "insert table" + "P" + Bank1.UchName + "(IstPost, DatePost, SumPost) values('" + comboBox1.Text + "', '" + dateTimePicker1.Text + "', '" + textBox4.Text + "'); "; // добавление строки в таблицу БД(на языке SQL)

                            MySqlCommand com = new MySqlCommand(sql1, conn); // создаем объект, который выполняет наш запрос
                            com.ExecuteNonQuery(); // исполняет комнду ввода

                            conn.Close(); // закрываем поток 
                            ShowDB("P" + Bank1.UchName, 1, "");
                            Itogo("P" + Bank1.UchName, "", 1);
                        }
                        catch { }
                    }
                    if (Bank1.TIP == 1 || Bank1.TIP == 3)
                    {
                        int count = System.IO.File.ReadAllLines(Bank1.Disk + "P " + Bank1.UchName + ".txt").Length;

                        string[] Mass = new string[count];
                        string s1 = "";
                        double SUM = 0;

                        StreamReader f0 = new StreamReader(Bank1.Disk + "P " + Bank1.UchName + ".txt");
                        int i = 0;
                        while ((s1 = f0.ReadLine()) != null)
                        {
                            Mass[i] = s1;
                            i++;
                        }
                        f0.Close();

                        string ss = "";
                        string ss1 = "";
                        StreamWriter f1 = new StreamWriter(Bank1.Disk + "P " + Bank1.UchName + ".txt");
                        f1.Close();

                        StreamWriter f00 = new StreamWriter(Bank1.Disk + "P " + Bank1.UchName + ".txt");
                        int zz = 0;
                        int zz1 = 0;
                        if (count >= 6) { zz1 = 1; }
                        if (count > 7) { zz = 2; }
                        for (i = 0; i < count - zz; i++)
                        {
                            ss1 = "";
                            f00.WriteLine(Mass[i]);
                            if (i % 2 == 0 && i > 1)
                            {
                                ss = Mass[i];
                                for (int j = 47; j < 67; j++)
                                {
                                    if (ss[j] == ' ') { break; }
                                    else { ss1 += Convert.ToString(ss[j]); }
                                }

                                SUM += Convert.ToDouble(ss1);
                            }
                        }
                        f00.Write("{0, -4}|", (count / 2) - zz1);
                        f00.Write("{0, -20}|", comboBox1.Text);
                        f00.Write("{0, -20}|", dateTimePicker1.Text);
                        f00.Write("{0, -20}|", textBox4.Text);
                        f00.WriteLine(" ");

                        f00.Write("{0, -4}|", "----");
                        f00.Write("{0, -20}|", "--------------------");
                        f00.Write("{0, -20}|", "--------------------");
                        f00.Write("{0, -20}|", "--------------------");
                        f00.WriteLine(" ");
                        if (count >= 4)
                        {
                            f00.Write("{0, -46}|", "ИТОГО");
                            f00.Write("{0, -20}|", SUM + Convert.ToDouble(textBox4.Text));
                            f00.WriteLine(" ");
                            f00.Write("{0, -44}|", "----------------------------------------------");
                            f00.Write("{0, -20}|", "--------------------");
                            f00.WriteLine(" ");
                        }
                        f00.Close();

                        s1 = "";
                        string S = "";

                        StreamReader f000 = new StreamReader(Bank1.Disk + "P " + Bank1.UchName + ".txt");
                        while ((s1 = f000.ReadLine()) != null)
                        {
                            S = S + s1 + "\r\n";
                        }
                        f000.Close();

                        textBox5.Text = S;
                    }
                }
            }
            catch { }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // создаются таблицы в бд и текстовых файлах для "Поступления" и "Затраты"
            //
                try
            {
                MySqlConnection conn = new MySqlConnection(Bank1.CONNSTR); // создается объект подключения (типо поток файловый)
                conn.Open(); // открываем поток

                string sql1 = "create table table" + "P" + Bank1.UchName + "  (Id int primary key auto_increment, IstPost varchar(20) not null,DatePost date not null,SumPost double not null)";

                MySqlCommand com = new MySqlCommand(sql1, conn); // создаем объект, который выполняет наш запрос
                com.ExecuteNonQuery(); // хранит все данные запроса (поток чтения)
                conn.Close();
            }
            catch 
            {  }
            try
            {
                MySqlConnection conn = new MySqlConnection(Bank1.CONNSTR); // создается объект подключения (типо поток файловый)
                conn.Open(); // открываем поток

                string sql1 = "create table table" + "Z" + Bank1.UchName + "  (Id int primary key auto_increment, PredPok varchar(20) not null,DatePok date not null,Stoit double not null,DopInf varchar(50) null)";

                MySqlCommand com = new MySqlCommand(sql1, conn); // создаем объект, который выполняет наш запрос
                com.ExecuteNonQuery(); // хранит все данные запроса (поток чтения)
                conn.Close();
            }
            catch { }

            dataGridView1.Visible = false;
            textBox5.Visible = false;
            textBox2.Visible = false;
            textBox7.Visible = false;
            dataGridView2.Visible = false;
            dataGridView3.Visible = false;

            if (Bank1.TIP == 1)
            {
                textBox5.Visible = true;
                textBox2.Visible = true;
                textBox7.Visible = true;
            }
            if (Bank1.TIP == 2 || Bank1.TIP == 3)
            { dataGridView1.Visible = true;
                dataGridView2.Visible = true;
                dataGridView3.Visible = true;
            }

            this.Text = "Учётная запись: " +Bank1.UchName ;

            if (Bank1.TIP == 1 || Bank1.TIP == 3)
            {
                if (System.IO.File.Exists(Bank1.Disk + "P " + Bank1.UchName + ".txt"))
                {
                    //Ваши действия.....
                }
                else
                {
                    StreamWriter f00 = new StreamWriter(Bank1.Disk +"P "+ Bank1.UchName + ".txt", true);
                    f00.Write("{0, -4}|", "№");
                    f00.Write("{0, -20}|", "Источник поступления");
                    f00.Write("{0, -20}|", "Дата поступления");
                    f00.Write("{0, -20}|", "Сумма поступления");
                    f00.WriteLine(" ");

                    f00.Write("{0, -4}|", "----");
                    f00.Write("{0, -20}|", "--------------------");
                    f00.Write("{0, -20}|", "--------------------");
                    f00.Write("{0, -20}|", "--------------------");
                    f00.WriteLine(" ");

                    f00.Close();
                }
                if (System.IO.File.Exists(Bank1.Disk + "Z "+ Bank1.UchName + ".txt"))
                {
                    //Ваши действия.....
                }
                else
                {
                    StreamWriter f0 = new StreamWriter(Bank1.Disk + "Z " + Bank1.UchName + ".txt", true);
                    f0.Write("{0, -4}|", "№");
                    f0.Write("{0, -15}|", "Предмет покупки");
                    f0.Write("{0, -15}|", "Дата покупки");
                    f0.Write("{0, -15}|", "Стоимость, BYN");
                    f0.Write("{0, -20}|", "Доп.инф. (Наименов.)");

                    f0.WriteLine(" ");

                    f0.Write("{0, -4}|", "----");
                    f0.Write("{0, -15}|", "---------------");
                    f0.Write("{0, -15}|", "---------------");
                    f0.Write("{0, -15}|", "---------------");
                    f0.Write("{0, -20}|", "--------------------");
                    f0.WriteLine(" ");
                    
                    f0.Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e) // отображение данных в (textBox или dataGridView)
        {
            if (Bank1.TIP == 2 || Bank1.TIP == 3)
            {
                try
                {
                    ShowDB("P" + Bank1.UchName,1,"");
                    Itogo("P" + Bank1.UchName, "", 1);
                }
                catch   { }
            }
        
            if (Bank1.TIP == 1 || Bank1.TIP == 3)
            {
                string s1 = "";
                string S = "";

                StreamReader f000 = new StreamReader(Bank1.Disk + "P " + Bank1.UchName + ".txt");
                while ((s1 = f000.ReadLine()) != null)
                {
                    S = S + s1 + "\r\n";
                }
                f000.Close();

                textBox5.Text = S;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
           // удаление последней строки в (БД и\или текст файл)
           // усложнено: подсчет ИТОГО
            if (Bank1.TIP == 2 || Bank1.TIP == 3)
            {
                try
                {
                    MySqlConnection conn1 = new MySqlConnection(Bank1.CONNSTR); // создается объект подключения (типо поток файловый)
                    conn1.Open(); // открываем поток

                    string sql1 = "delete from table" + "P" + Bank1.UchName + " where (Id=" + (dataGridView1[0, dataGridView1.RowCount - 2].Value) + ")"; // добавление строки в таблицу БД(на языке SQL)

                    MySqlCommand com1 = new MySqlCommand(sql1, conn1); // создаем объект, который выполняет наш запрос
                    com1.ExecuteNonQuery(); // исполняет комнду ввода   

                    conn1.Close(); // закрываем поток 
                    ShowDB("P" + Bank1.UchName, 1, "");
                    Itogo("P" + Bank1.UchName, "", 1);
                }
                catch { }
            }
                if (Bank1.TIP == 1 || Bank1.TIP == 3)
            {
                int count = System.IO.File.ReadAllLines(Bank1.Disk + "P " + Bank1.UchName + ".txt").Length;
                if (count > 5)
                {
                    string[] Mass = new string[count];
                    string s1 = "";

                    StreamReader f00 = new StreamReader(Bank1.Disk + "P " + Bank1.UchName + ".txt");
                    int i = 0;
                    while ((s1 = f00.ReadLine()) != null)
                    {
                        Mass[i] = s1;
                        i++;
                    }
                    f00.Close();

                    StreamWriter f1 = new StreamWriter(Bank1.Disk + "P " + Bank1.UchName + ".txt");
                    f1.Close();

                    double SUM = 0; string ss = "";
                    string ss1 = ""; int zz = 4;
                    StreamWriter f0 = new StreamWriter(Bank1.Disk + "P " + Bank1.UchName + ".txt", true);
                    if (count <= 4) zz = 2;
                    for (i = 0; i < count - zz; i++)
                    {
                        ss1 = "";
                        f0.WriteLine(Mass[i]);
                        if (i % 2 == 0 && i > 1)
                        {
                            ss = Mass[i];
                            for (int j = 47; j < 67; j++)
                            {
                                if (ss[j] == ' ') { break; }
                                else { ss1 += Convert.ToString(ss[j]); }
                            }

                            SUM += Convert.ToDouble(ss1);
                        }
                    }
                    if (count > 8)
                    {
                        f0.Write("{0, -46}|", "ИТОГО");
                        f0.Write("{0, -20}|", SUM);
                        f0.WriteLine(" ");
                        f0.Write("{0, -46}|", "----------------------------------------------");
                        f0.Write("{0, -20}|", "--------------------");
                        f0.WriteLine(" ");
                    }

                    f0.Close();

                    s1 = "";
                    string S = "";

                    StreamReader f000 = new StreamReader(Bank1.Disk + "P " + Bank1.UchName + ".txt");
                    while ((s1 = f000.ReadLine()) != null)
                    {
                        S = S + s1 + "\r\n";
                    }
                    f000.Close();

                    textBox5.Text = S;
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
           // всё то же самое что и в баттон 1 (только тут для таблицы "Затраты")
           // усложнено тем же
            if ((comboBox2.Text).Length == 0 || (textBox3.Text).Length == 0)
            { MessageBox.Show("Ошибка: не все необходимые поля были заполнены!"); }
            else
            {
                if (Bank1.TIP == 2 || Bank1.TIP == 3)
                {
                    try
                    {
                        MySqlConnection conn = new MySqlConnection(Bank1.CONNSTR); // создается объект подключения (типо поток файловый)
                        conn.Open(); // открываем поток

                        string sql1 = "insert table" + "Z" + Bank1.UchName + "(PredPok, DatePok, Stoit,DopInf) values('" + comboBox2.Text + "', '" + dateTimePicker2.Text + "', '" + textBox3.Text + "', '" + textBox6.Text + "'); "; // добавление строки в таблицу БД(на языке SQL)

                        MySqlCommand com = new MySqlCommand(sql1, conn); // создаем объект, который выполняет наш запрос
                        com.ExecuteNonQuery(); // исполняет комнду ввода
                        conn.Close(); // закрываем поток 

                        ShowDB("Z" + Bank1.UchName, 2, "");
                        Itogo("Z" + Bank1.UchName, "", 2);
                    }
                    catch { }
                }
                if (Bank1.TIP == 1 || Bank1.TIP == 3)
                {
                    int count = System.IO.File.ReadAllLines(Bank1.Disk + "Z " + Bank1.UchName + ".txt").Length;

                    string[] Mass = new string[count];
                    string s1 = "";
                    double SUM = 0;

                    StreamReader f0 = new StreamReader(Bank1.Disk + "Z " + Bank1.UchName + ".txt");
                    int i = 0;
                    while ((s1 = f0.ReadLine()) != null)
                    {
                        Mass[i] = s1;
                        i++;
                    }
                    f0.Close();

                    string ss = "";
                    string ss1 = "";

                    StreamWriter f1 = new StreamWriter(Bank1.Disk + "Z " + Bank1.UchName + ".txt");
                    f1.Close();

                    StreamWriter f00 = new StreamWriter(Bank1.Disk + "Z " + Bank1.UchName + ".txt");
                    int zz = 0;
                    int zz1 = 0;
                    if (count >= 6) { zz1 = 1; }
                    if (count > 7) { zz = 2; }
                    for (i = 0; i < count - zz; i++)
                    {
                        ss1 = "";
                        f00.WriteLine(Mass[i]);
                        if (i % 2 == 0 && i > 1)
                        {
                            ss = Mass[i];
                            for (int j = 37; j < 52; j++)
                            {
                                if (ss[j] == ' ') { break; }
                                else { ss1 += Convert.ToString(ss[j]); }
                            }

                            SUM += Convert.ToDouble(ss1);
                        }

                    }
                    f00.Write("{0, -4}|", (count / 2) - zz1);
                    f00.Write("{0, -15}|", comboBox2.Text);
                    f00.Write("{0, -15}|", dateTimePicker2.Text);
                    f00.Write("{0, -15}|", textBox3.Text);
                    f00.Write("{0, -20}|", textBox6.Text);
                    f00.WriteLine(" ");

                    f00.Write("{0, -4}|", "----");
                    f00.Write("{0, -15}|", "---------------");
                    f00.Write("{0, -15}|", "---------------");
                    f00.Write("{0, -15}|", "---------------");
                    f00.Write("{0, -20}|", "--------------------");
                    f00.WriteLine(" ");
                    if (count >= 4)
                    {
                        f00.Write("{0, -36}|", "ИТОГО");
                        f00.Write("{0, -15}|", SUM + Convert.ToDouble(textBox3.Text));
                        f00.WriteLine(" ");
                        f00.Write("{0, -36}|", "------------------------------------");
                        f00.Write("{0, -15}|", "---------------");
                        f00.WriteLine(" ");
                    }
                    f00.Close();

                    s1 = "";
                    string S = "";

                    StreamReader f000 = new StreamReader(Bank1.Disk + "Z " + Bank1.UchName + ".txt");
                    while ((s1 = f000.ReadLine()) != null)
                    {
                        S = S + s1 + "\r\n";
                    }
                    f000.Close();

                    textBox2.Text = S;
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // всё то же самое что и в баттон 2 (только тут для таблицы "Затраты")
            // усложнено тем же
            if (Bank1.TIP == 2 || Bank1.TIP == 3)
            {
                try
                {
                    ShowDB("Z" + Bank1.UchName, 2, "");
                    Itogo("Z" + Bank1.UchName, "", 2);
                }
                catch { }
            }

            if (Bank1.TIP == 1 || Bank1.TIP == 3)
            {
                string s1 = "";
                string S = "";

                StreamReader f000 = new StreamReader(Bank1.Disk + "Z " + Bank1.UchName + ".txt");
                while ((s1 = f000.ReadLine()) != null)
                {
                    S = S + s1 + "\r\n";
                }
                f000.Close();

                textBox2.Text = S;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // всё то же самое что и в баттон 3 (только тут для таблицы "Затраты")
            // усложнено тем же

            if (Bank1.TIP == 2 || Bank1.TIP == 3)
            {
                try
                {
                    MySqlConnection conn1 = new MySqlConnection(Bank1.CONNSTR); // создается объект подключения (типо поток файловый)
                    conn1.Open(); // открываем поток

                    string sql1 = "delete from table" + "Z" + Bank1.UchName + " where (Id=" + (dataGridView2[0, dataGridView2.RowCount - 2].Value) + ")"; // добавление строки в таблицу БД(на языке SQL)

                    MySqlCommand com1 = new MySqlCommand(sql1, conn1); // создаем объект, который выполняет наш запрос
                    com1.ExecuteNonQuery(); // исполняет комнду ввода   
                    conn1.Close(); // закрываем поток 

                    ShowDB("Z" + Bank1.UchName, 2, "");
                    Itogo("Z" + Bank1.UchName, "", 2);
                }
                catch { }
            }
            if (Bank1.TIP == 1 || Bank1.TIP == 3)
            {
                int count = System.IO.File.ReadAllLines(Bank1.Disk + "Z " + Bank1.UchName + ".txt").Length;
                if (count > 5)
                {
                    string[] Mass = new string[count];
                    string s1 = "";

                    StreamReader f00 = new StreamReader(Bank1.Disk + "Z " + Bank1.UchName + ".txt");
                    int i = 0;
                    while ((s1 = f00.ReadLine()) != null)
                    {
                        Mass[i] = s1;
                        i++;
                    }
                    f00.Close();

                    StreamWriter f1 = new StreamWriter(Bank1.Disk + "Z " + Bank1.UchName + ".txt");
                    f1.Close();

                    double SUM = 0; string ss = "";
                    string ss1 = ""; int zz = 4;
                    StreamWriter f0 = new StreamWriter(Bank1.Disk + "Z " + Bank1.UchName + ".txt", true);
                    if (count <= 4) zz = 2;
                    for (i = 0; i < count - zz; i++)
                    {
                        ss1 = "";
                        f0.WriteLine(Mass[i]);
                        if (i % 2 == 0 && i > 1)
                        {
                            ss = Mass[i];
                            for (int j = 37; j < 52; j++)
                            {
                                if (ss[j] == ' ') { break; }
                                else { ss1 += Convert.ToString(ss[j]); }
                            }

                            SUM += Convert.ToDouble(ss1);
                        }
                    }

                    if (count > 8)
                    {
                        f0.Write("{0, -36}|", "ИТОГО");
                        f0.Write("{0, -15}|", SUM);
                        f0.WriteLine(" ");
                        f0.Write("{0, -36}|", "------------------------------------");
                        f0.Write("{0, -15}|", "---------------");
                        f0.WriteLine(" ");
                    }

                    f0.Close();

                    s1 = "";
                    string S = "";

                    StreamReader f000 = new StreamReader(Bank1.Disk + "Z " + Bank1.UchName + ".txt");
                    while ((s1 = f000.ReadLine()) != null)
                    {
                        S = S + s1 + "\r\n";
                    }
                    f000.Close();

                    textBox2.Text = S;
                }
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            // в зависимости от выбранного в комбобоксе3 заполняется вариантами комбобокс4

            comboBox4.Items.Clear();
            if (comboBox3.Text == "Поступлений")
            {
                comboBox4.Items.Add("Все");
                comboBox4.Items.Add("Стипендия");
                comboBox4.Items.Add("Зарплата");
                comboBox4.Items.Add("Продажа");
                comboBox4.Items.Add("Доп. деятельность");
                comboBox4.Items.Add("Другой источник");
            }
            if (comboBox3.Text == "Затрат")
            {
                comboBox4.Items.Add("Все");
                comboBox4.Items.Add("Еда");
                comboBox4.Items.Add("Телефон");
                comboBox4.Items.Add("Интернет");
                comboBox4.Items.Add("Общага\\ к.в.");
                comboBox4.Items.Add("Гигиена");
                comboBox4.Items.Add("Образование");
                comboBox4.Items.Add("Одежда");
                comboBox4.Items.Add("Другое");
               
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            // отображение данных в зависимости от варианта статистики
            // усложнено тем же


            if ((comboBox3.Text).Length > 1 || (comboBox4.Text).Length > 1)
            {
                if (Bank1.TIP == 1)
                {
                    if (comboBox3.Text == "Поступлений" && comboBox3.Text != "Затрат" && (comboBox4.Text).Length > 0)
                    {
                        StatS(26, 46, 47, 67, 5, 25, Bank1.Disk + "P " + Bank1.UchName + ".txt", comboBox4.Text, 47, 67);
                    }
                    else if (comboBox3.Text != "Поступлений" && comboBox3.Text == "Затрат" && (comboBox4.Text).Length > 0)
                    {
                        StatS(21, 31, 37, 52, 5, 20, Bank1.Disk + "Z " + Bank1.UchName + ".txt", comboBox4.Text, 37, 52);
                    }
                    else { MessageBox.Show("Ошибка: не корректно произведено заполнение полей: \"Учёт\" и\\или \"Источник \\ Предмет\" !"); }

                }
                if (Bank1.TIP == 2 || Bank1.TIP == 3)
                {
                    try
                    {
                        if (comboBox3.Text == "Поступлений")
                        {
                            ShowDB("P" + Bank1.UchName, 3, comboBox4.Text);
                            Itogo("P" + Bank1.UchName, comboBox4.Text, 3);
                        }
                        if (comboBox3.Text == "Затрат")
                        {
                            ShowDB("Z" + Bank1.UchName, 3, comboBox4.Text);
                            Itogo("Z" + Bank1.UchName, comboBox4.Text, 3);
                        }
                    }
                    catch { }
                }
            }
            else { MessageBox.Show("Ошибка: Не все поля были заполнены!"); }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void tabPage5_Click(object sender, EventArgs e)
        {
        }

        private void button8_Click(object sender, EventArgs e)
        {
          
      
    }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }
    }
}
