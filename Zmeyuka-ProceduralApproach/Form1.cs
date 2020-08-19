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

namespace WindowsFormsApp32
{
    public partial class Form1 : Form
    {
        Button[] MassBT = new Button[1000];

        int xx = 49;
        int yy = 49;
        List<int> lstX = new List<int>();
        List<int> lstY = new List<int>();
        string[] Mass = new string[18];

        int sch = 0;

        public Form1()
        {
            InitializeComponent();

            for (int i = 0; i < 1000; i++)
            {
                MassBT[i] = new Button
                {
                    Name = "btn" + Convert.ToString(i),
                    FlatStyle = FlatStyle.Flat,
                    BackColor = SystemColors.ControlDark,
                    Size = new System.Drawing.Size(10, 10)
                };
                if (i < 3)
                {
                    MassBT[i].Location = new Point(xx - (i * 10), yy);
                    panel1.Controls.Add(MassBT[i]);
                }
            }
            Bank.Where = "Right";

        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Bank.Where == "Up")
            {
                yy -= 10;
                if (yy == -11)
                    yy = 319;
            }
            if (Bank.Where == "Down")
            {
                yy += 10;
                if (yy == 319)
                    yy = -11;
            }
            if (Bank.Where == "Left")
            {
                xx -= 10;
                if (xx == -11)
                    xx = 429;
            }
            if (Bank.Where == "Right")
            {
                xx += 10;
                if (xx == 429)
                    xx = -11;
            }
            lstX.Add(xx);
            lstY.Add(yy);

            for (int i = 0; i < Bank.Dlina; i++)
            {

                if (i > 0 && lstX.Count > 2)
                {
                    MassBT[i].Location = new Point(lstX[lstX.Count - i - 1], lstY[lstY.Count - i - 1]);
                }
                else
                {
                    MassBT[i].Location = new Point(xx - (10 * i), yy);
                }

            }
            for (int i = 1; i < Bank.Dlina; i++)
            {
                if (MassBT[0].Location.X == MassBT[i].Location.X && MassBT[0].Location.Y == MassBT[i].Location.Y)
                {

                    timer1.Stop();
                    timer2.Stop();
                    label2.Visible = true;
                    button1.Visible = true;
                    button2.Visible = true;
                    break;
                }
            }
            if (lstX.Count == MassBT.Length)
            {
                lstX.RemoveAt(0);
                lstY.RemoveAt(0);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer2.Start();
            label7.Visible = false;
            string s = "";
            foreach (var drive in DriveInfo.GetDrives())
            {
                s = drive.Name;
            }
            Bank.Put = s + "Рекордсмены змейки (по уровням)" + ".txt";
            StreamWriter f5 = new StreamWriter(Bank.Put, true);
            f5.Close();
            if (System.IO.File.ReadAllLines(Bank.Put).Length <= 1)
            {
                StreamWriter f1 = new StreamWriter(Bank.Put);
                f1.WriteLine("ТОП-5: (Змея)");
                f1.WriteLine("1.    0");
                f1.WriteLine("2.    0");
                f1.WriteLine("3.    0");
                f1.WriteLine("4.    0");
                f1.WriteLine("5.    0");
                f1.WriteLine("ТОП-5: (Гадюка)");
                f1.WriteLine("1.    0");
                f1.WriteLine("2.    0");
                f1.WriteLine("3.    0");
                f1.WriteLine("4.    0");
                f1.WriteLine("5.    0");
                f1.WriteLine("ТОП-5: (Змеюка)");
                f1.WriteLine("1.    0");
                f1.WriteLine("2.    0");
                f1.WriteLine("3.    0");
                f1.WriteLine("4.    0");
                f1.WriteLine("5.    0");
                f1.Close();
            }

            new Form2().Show();
            timer1.Stop();
            button1.Visible = false;
            button2.Visible = false;
            label4.BackColor = System.Drawing.Color.Transparent;

            Random rand = new Random();
            Random rand1 = new Random();
            int x = 0; int y = 0;
            for (; ; )
            {
                x = rand.Next(50, 410);
                y = rand.Next(50, 300);
                if ((x + 1) % 10 == 0 && (y + 1) % 10 == 0)
                {
                    button4.Location = new Point(x, y);
                    break;
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.W)
            {
                if (Bank.Where != "Down" && xx > -11 && yy > -11 && xx < 429 && yy < 319)
                    Bank.Where = "Up";
            }
            if (e.KeyData == Keys.S)
            {
                if (Bank.Where != "Up" && xx > -11 && yy > -11 && xx < 429 && yy < 319)
                    Bank.Where = "Down";
            }
            if (e.KeyData == Keys.A)
            {
                if (Bank.Where != "Right" && xx > -11 && yy > -11 && xx < 429 && yy < 319)
                    Bank.Where = "Left";
            }
            if (e.KeyData == Keys.D)
            {
                if (Bank.Where != "Left" && xx > -11 && yy > -11 && xx < 429 && yy < 319)
                    Bank.Where = "Right";
            }
            if (e.KeyData == Keys.F)
            {
                if (xx > -11 && yy > -11 && xx < 429 && yy < 319 && progressBar1.Value == 100)
                { Bank.Shift = 1; Bank.ShiftTime = DateTime.Now.Second; progressBar1.Value = 0; }
            }

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (DateTime.Now.Second - 10 == Bank.ShiftTime && Bank.ShiftTime < 50) Bank.Shift = 0;
            if (Bank.ShiftTime >= 50) { if (DateTime.Now.Second == Bank.ShiftTime - 50) Bank.Shift = 0; }

            if (Bank.Slog == "Змея" && Bank.Shift == 1) { timer1.Interval = 50; }
            if (Bank.Slog == "Змея" && Bank.Shift != 1) { timer1.Interval = 100; }
            if (Bank.Slog == "Гадюка" && Bank.Shift == 1) { timer1.Interval = 25; }
            if (Bank.Slog == "Гадюка" && Bank.Shift != 1) { timer1.Interval = 50; }
            if (Bank.Slog == "Змеюка" && Bank.Shift == 1) { timer1.Interval = 20; }
            if (Bank.Slog == "Змеюка" && Bank.Shift != 1) { timer1.Interval = 40; }
            if (Bank.HH == 1)
            {
                label6.Text = "Сложность: \"" + Bank.Slog + "\"";
                timer1.Start();
                Bank.HH = 0;
            }
            int z = 0;

            if (Bank.Where == "Right" && MassBT[0].Location.Y == button4.Location.Y && MassBT[0].Location.X + 10 == button4.Location.X)
            { z = 1; }
            if (Bank.Where == "Left" && MassBT[0].Location.Y == button4.Location.Y && MassBT[0].Location.X - 10 == button4.Location.X)
            { z = 1; }
            if (Bank.Where == "Up" && MassBT[0].Location.Y - 10 == button4.Location.Y && MassBT[0].Location.X == button4.Location.X)
            { z = 1; }
            if (Bank.Where == "Down" && MassBT[0].Location.Y + 10 == button4.Location.Y && MassBT[0].Location.X == button4.Location.X)
            { z = 1; }

            if (z == 1)
            {
                if (Bank.Slog == "Змея" && Bank.Shift == 1) { sch += 50; }
                if (Bank.Slog == "Змея" && Bank.Shift != 1) { sch += 5; }
                if (Bank.Slog == "Гадюка" && Bank.Shift == 1) { sch += 100; }
                if (Bank.Slog == "Гадюка" && Bank.Shift != 1) { sch += 10; }
                if (Bank.Slog == "Змеюка" && Bank.Shift == 1) { sch += 120; }
                if (Bank.Slog == "Змеюка" && Bank.Shift != 1) { sch += 12; }
                if (progressBar1.Value < 100) progressBar1.Value += 10;

                Bank.Sch = sch;
                int a = 0; int b = 0;

                if (Bank.Slog == "Змея")
                {
                    a = 0; b = 5;
                }

                if (Bank.Slog == "Гадюка")
                {
                    a = 6; b = 11;
                }
                if (Bank.Slog == "Змеюка")
                {
                    a = 12; b = 17;
                }

                StreamReader f2 = new StreamReader(Bank.Put);
                int i = 0;
                string s1 = "";
                while ((s1 = f2.ReadLine()) != null)
                {
                    Mass[i] = s1;
                    i++;
                }
                f2.Close();

                string s2 = ""; string s22 = "";
                for (i = a + 1; i <= b; i++)
                {
                    s2 = Mass[i];
                    for (int h = 3; h < 7; h++)
                    { s22 += Convert.ToString(s2[h]); }

                    if (Convert.ToInt32(s22) < Bank.Sch)
                    {
                        if (i != 0 && i != 6 && i != 12)
                        {
                            if (i > 5 && i <= 11)
                            {
                                if (Convert.ToString(Bank.Sch).Length == 1) Mass[i] = Convert.ToString(i - 6) + ".    " + Convert.ToString(Bank.Sch);
                                if (Convert.ToString(Bank.Sch).Length == 2) Mass[i] = Convert.ToString(i - 6) + ".   " + Convert.ToString(Bank.Sch);
                                if (Convert.ToString(Bank.Sch).Length == 3) Mass[i] = Convert.ToString(i - 6) + ".  " + Convert.ToString(Bank.Sch);
                                if (Convert.ToString(Bank.Sch).Length == 4) Mass[i] = Convert.ToString(i - 6) + ". " + Convert.ToString(Bank.Sch);
                            }
                            if (i > 11 && i <= 17)
                            {
                                if (Convert.ToString(Bank.Sch).Length == 1) Mass[i] = Convert.ToString(i - 12) + ".    " + Convert.ToString(Bank.Sch);
                                if (Convert.ToString(Bank.Sch).Length == 2) Mass[i] = Convert.ToString(i - 12) + ".   " + Convert.ToString(Bank.Sch);
                                if (Convert.ToString(Bank.Sch).Length == 3) Mass[i] = Convert.ToString(i - 12) + ".  " + Convert.ToString(Bank.Sch);
                                if (Convert.ToString(Bank.Sch).Length == 4) Mass[i] = Convert.ToString(i - 12) + ". " + Convert.ToString(Bank.Sch);
                            }
                            if (i > 0 && i <= 5)
                            {
                                if (Convert.ToString(Bank.Sch).Length == 1) Mass[i] = Convert.ToString(i) + ".    " + Convert.ToString(Bank.Sch);
                                if (Convert.ToString(Bank.Sch).Length == 2) Mass[i] = Convert.ToString(i) + ".   " + Convert.ToString(Bank.Sch);
                                if (Convert.ToString(Bank.Sch).Length == 3) Mass[i] = Convert.ToString(i) + ".  " + Convert.ToString(Bank.Sch);
                                if (Convert.ToString(Bank.Sch).Length == 4) Mass[i] = Convert.ToString(i) + ". " + Convert.ToString(Bank.Sch);
                            }
                        }
                        break;
                    }
                    s2 = "";
                    s22 = "";
                }

                StreamWriter f4 = new StreamWriter(Bank.Put);
                for (i = 0; i < 18; i++)
                {
                    f4.WriteLine(Mass[i]);
                }
                f4.Close();

                string S = "";
                for (int j = a; j <= b; j++)
                { S += Mass[j] + "\r\n"; }
                label4.Text = S;

                if (Bank.Sound == "Да") Console.Beep(275, 75);
                button4.Visible = false;
                MassBT[Bank.Dlina].Location = new Point(lstX[lstX.Count - Bank.Dlina - 1], lstY[lstY.Count - Bank.Dlina - 1]);
                panel1.Controls.Add(MassBT[Bank.Dlina]);

                label3.Text = "Счёт: " + Convert.ToString(sch);

                Random rand = new Random();
                Random rand1 = new Random();
                int x = 0; int y = 0; int zz = 0;
                for (; ; )
                {
                    x = rand.Next(10, 410);
                    y = rand.Next(10, 300);
                    for (i = 0; i < lstX.Count; i++)
                    {
                        if (lstX[i] == x && lstY[i] == y)
                        { z = 1; break; }
                    }
                    if (zz != 1)
                    {
                        if ((x + 1) % 10 == 0 && (y + 1) % 10 == 0)
                        {
                            button4.Location = new Point(x, y);
                            button4.Visible = true;
                            break;
                        }
                    }
                }
                Bank.Dlina += 1;
                if (Bank.Slog == "Змея" && sch == 5000) { label7.Visible = true; timer1.Stop(); timer2.Stop(); }
                if (Bank.Slog == "Гадюка" && sch == 10000) { label7.Visible = true; timer1.Stop(); timer2.Stop(); }
                if (Bank.Slog == "Змеюка" && sch == 12000) { label7.Visible = true; timer1.Stop(); timer2.Stop(); }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }
        private void panel1_Load(object sender, PaintEventArgs e)
        { }

        private void button1_Click(object sender, EventArgs e)
        {
            sch = 0;
            label3.Text = "Счёт: " + Convert.ToString(sch);
            Bank.Slog = "Змея";
            timer1.Stop();
            timer2.Stop();
            for (int i = 0; i < 1000; i++)
            {
                panel1.Controls.Remove(MassBT[i]);
            }
            Bank.Dlina = 3;
            lstX = new List<int>();
            lstY = new List<int>();
            xx = 49;
            yy = 49;
            for (int i = 0; i < 100; i++)
            {
                MassBT[i] = new Button
                {
                    Name = "btn" + Convert.ToString(i),
                    FlatStyle = FlatStyle.Flat,
                    BackColor = SystemColors.ControlDark,
                    Size = new System.Drawing.Size(10, 10)
                };

                if (i < 3)
                {
                    MassBT[i].Location = new Point(xx - (i * 10), yy);
                    panel1.Controls.Add(MassBT[i]);
                }
            }
            Random rand = new Random();
            Random rand1 = new Random();
            int x = 0; int y = 0;
            for (; ; )
            {
                x = rand.Next(50, 410);
                y = rand.Next(50, 300);
                if ((x + 1) % 10 == 0 && (y + 1) % 10 == 0)
                {
                    button4.Location = new Point(x, y);
                    break;
                }
            }
            Bank.Where = "Right";

            button1.Visible = false;
            button2.Visible = false;
            label2.Visible = false;
            timer1.Start();
            timer2.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Form2().Show();
            timer1.Stop();
        }

        private void помощьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("При нажатии \"F\" на 10 сек. появляется возможность получать Х10 очков. \r\nПри достижении отметки в X1000 очков игра считается пройденой. \r\nУдачной игры!");
        }
    }
}
