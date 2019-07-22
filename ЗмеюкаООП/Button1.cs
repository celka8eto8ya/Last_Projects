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
    public class Button1 : Button
    {
        private string slog;
    
        public Button1()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.BackColor = SystemColors.ControlDark;
            this.Size = new System.Drawing.Size(10, 10);
        }
        public string Slog
        {
            set
            {
                if (slog.Length > 0)
                { slog = value; }
                else
                { MessageBox.Show("Ошибка!", "Неподходящее значение поля slog!"); }
            }
        }
       
        public static void Chek(KeyEventArgs e)
        {
            if (e.KeyData == Keys.W)
            {
                if (Bank.Where != "Down" && Bank.X > -11 && Bank.Y > -11 && Bank.X < 429 && Bank.Y < 319)
                    Bank.Where = "Up";
            }
            if (e.KeyData == Keys.S)
            {
                if (Bank.Where != "Up" && Bank.X > -11 && Bank.Y > -11 && Bank.X < 429 && Bank.Y < 319)
                    Bank.Where = "Down";
            }
            if (e.KeyData == Keys.A)
            {
                if (Bank.Where != "Right" && Bank.X > -11 && Bank.Y > -11 && Bank.X < 429 && Bank.Y < 319)
                    Bank.Where = "Left";
            }
            if (e.KeyData == Keys.D)
            {
                if (Bank.Where != "Left" && Bank.X > -11 && Bank.Y > -11 && Bank.X < 429 && Bank.Y < 319)
                    Bank.Where = "Right";
            }
        }

        public static void Motion()
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

        public static void Random(Button eat)
        {
            Random rand = new Random();
            Random rand1 = new Random();
            int x = 0; int y = 0;
            for (; ; )
            {
                x = rand.Next(50, 410);
                y = rand.Next(50, 300);
                if ((x + 1) % 10 == 0 && (y + 1) % 10 == 0)
                {
                    eat.Location = new Point(x, y);
                    break;
                }
            }
        }

        public static void Eat(out int z, Button btn1,Button btn)
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
              


            }
        }



    }
}

