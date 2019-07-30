using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;


namespace ЗмеюкаООП
{
    public class SquareSnake : Button
    {
        public SquareSnake()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.BackColor = SystemColors.ControlDark;
            this.Size = new System.Drawing.Size(10, 10);
        }

        public static void ChekKey(KeyEventArgs e,ProgressBar pb1) // was refactored
        {
            if (Convert.ToString(e.KeyData) == "W")
            {
                if (Bank.Where != "Down" && Bank.X > -11 && Bank.Y > -11 && Bank.X < 429 && Bank.Y < 319)
                    Bank.Where = "Up";
            }
            if (Convert.ToString(e.KeyData) == "S")
            {
                if (Bank.Where != "Up" && Bank.X > -11 && Bank.Y > -11 && Bank.X < 429 && Bank.Y < 319)
                    Bank.Where = "Down";
            }
            if (Convert.ToString(e.KeyData) == "A")
            {
                if (Bank.Where != "Right" && Bank.X > -11 && Bank.Y > -11 && Bank.X < 429 && Bank.Y < 319)
                    Bank.Where = "Left";
            }
            if (Convert.ToString(e.KeyData) == "D")
            {
                if (Bank.Where != "Left" && Bank.X > -11 && Bank.Y > -11 && Bank.X < 429 && Bank.Y < 319)
                    Bank.Where = "Right";
            }
            if (Convert.ToString(e.KeyData) == "F")
            {
                if (Bank.X > -11 && Bank.Y > -11 && Bank.X < 429 && Bank.Y < 319 && pb1.Value == 100)
                { Bank.Shift = 1; Bank.ShiftTime = DateTime.Now.Second; pb1.Value = 0; }
            }
        }

        public static void Motion() // was refactored
        {
            if (Bank.Where == "Up")
            {
                Bank.Y -= 10;
                if (Bank.Y == -11)
                    Bank.Y = 319;
            }
            if (Bank.Where == "Down")
            {
                Bank.Y += 10;
                if (Bank.Y == 319)
                    Bank.Y = -11;
            }
            if (Bank.Where == "Left")
            {
                Bank.X -= 10;
                if (Bank.X == -11)
                    Bank.X = 429;
            }
            if (Bank.Where == "Right")
            {
                Bank.X += 10;
                if (Bank.X == 429)
                    Bank.X = -11;
            }
        }
        public static void Motion1(Button [] btn) // was refactored
        {
            Bank.lstX.Add(Bank.X);
            Bank.lstY.Add(Bank.Y);
            for (int i = 0; i < Bank.Dlina; i++)
            {
                if (i > 0 && Bank.lstX.Count > 2)
                {
                    btn[i].Location = new Point(Bank.lstX[Bank.lstX.Count - i - 1], Bank.lstY[Bank.lstY.Count - i - 1]);
                }
                else
                {
                    btn[i].Location = new Point(Bank.X - (10 * i), Bank.Y);
                }
            }
          
        }

        public static void RandomPosition1(Button eat) // was refactored
        {
            Random rand = new Random();
            Random rand1 = new Random();
            int x = 0; int y = 0; int zz = 0;
            eat.Visible = false;
            for (; ; )
            {
                zz = 0;
                x = rand.Next(10, 410);
                y = rand.Next(10, 300);
                for (int i = 0; i < Bank.lstX.Count; i++)
                {
                    if (Bank.lstX[i] == x && Bank.lstY[i] == y)
                    { zz = 1; break; }
                }
                if (zz != 1)
                {
                    if ((x + 1) % 10 == 0 && (y + 1) % 10 == 0)
                    {
                        eat.Location = new Point(x, y);
                        eat.Visible = true;
                        break;
                    }
                }

            }
        }

        public static void Eat(out int z, Button btn1,Button btn,Button [] Btn)  // was refactored
        {
            z = 0;
            if (Bank.Where == "Right" && btn1.Location.Y == btn.Location.Y && btn1.Location.X + 10 == btn.Location.X)
            { z = 1; }
            if (Bank.Where == "Left" && btn1.Location.Y == btn.Location.Y && btn1.Location.X - 10 == btn.Location.X)
            { z = 1; }
            if (Bank.Where == "Up" && btn1.Location.Y - 10 == btn.Location.Y && btn1.Location.X == btn.Location.X)
            { z = 1; }
            if (Bank.Where == "Down" && btn1.Location.Y + 10 == btn.Location.Y && btn1.Location.X == btn.Location.X)
            { z = 1; }

            if (z == 1)
            {
                if (Bank.Slog == "Змея" && Bank.Shift == 1) { Bank.Sch += 50; }
                if (Bank.Slog == "Змея" && Bank.Shift != 1) { Bank.Sch += 5; }
                if (Bank.Slog == "Гадюка" && Bank.Shift == 1) { Bank.Sch += 100; }
                if (Bank.Slog == "Гадюка" && Bank.Shift != 1) { Bank.Sch += 10; }
                if (Bank.Slog == "Змеюка" && Bank.Shift == 1) { Bank.Sch += 120; }
                if (Bank.Slog == "Змеюка" && Bank.Shift != 1) { Bank.Sch += 12; }

                SquareSnake.RandomPosition1(btn);
                Btn[Bank.Dlina].Location = new Point(Bank.lstX[Bank.lstX.Count - Bank.Dlina - 1], Bank.lstY[Bank.lstY.Count - Bank.Dlina - 1]);
            }
        }
        public static void Speed(Timer tm)  // was refactored
        {
            if (DateTime.Now.Second - 10 == Bank.ShiftTime && Bank.ShiftTime < 50) Bank.Shift = 0;
            if (Bank.ShiftTime >= 50) { if (DateTime.Now.Second == Bank.ShiftTime - 50) Bank.Shift = 0; }

            if (Bank.Slog == "Змея" && Bank.Shift == 1) { tm.Interval = 50; }
            if (Bank.Slog == "Змея" && Bank.Shift != 1) { tm.Interval = 100; }
            if (Bank.Slog == "Гадюка" && Bank.Shift == 1) { tm.Interval = 25; }
            if (Bank.Slog == "Гадюка" && Bank.Shift != 1) { tm.Interval = 50; }
            if (Bank.Slog == "Змеюка" && Bank.Shift == 1) { tm.Interval = 20; }
            if (Bank.Slog == "Змеюка" && Bank.Shift != 1) { tm.Interval = 40; }
        }

    }
}

