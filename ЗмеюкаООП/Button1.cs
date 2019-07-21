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
        
        private int speed;
    
      
        public Button1()
        {
           
            this.FlatStyle = FlatStyle.Flat;
            this.BackColor = SystemColors.ControlDark;
            this.Size = new System.Drawing.Size(10, 10);
        }
       
       
        public int Speed
        {
            set
            {
                if (speed > 0)
                { speed = value; }
                else
                { MessageBox.Show("Ошибка!", "Неподходящее значение поля speed!"); }
            }
        }
       
        public void Chek()
        {
            //if (e.KeyData == Keys.W)
            //{
            //    if (Bank.Where != "Down" && xx > -11 && yy > -11 && xx < 429 && yy < 319)
            //        Bank.Where = "Up";
            //}
            //if (e.KeyData == Keys.S)
            //{
            //    if (Bank.Where != "Up" && xx > -11 && yy > -11 && xx < 429 && yy < 319)
            //        Bank.Where = "Down";
            //}
            //if (e.KeyData == Keys.A)
            //{
            //    if (Bank.Where != "Right" && xx > -11 && yy > -11 && xx < 429 && yy < 319)
            //        Bank.Where = "Left";
            //}
            //if (e.KeyData == Keys.D)
            //{
            //    if (Bank.Where != "Left" && xx > -11 && yy > -11 && xx < 429 && yy < 319)
            //        Bank.Where = "Right";
            //}
            //if (e.KeyData == Keys.F)
            //{
            //    if (xx > -11 && yy > -11 && xx < 429 && yy < 319 && progressBar1.Value == 100)
            //    { Bank.Shift = 1; Bank.ShiftTime = DateTime.Now.Second; progressBar1.Value = 0; }
            //}

        }
        public void Motion()
        {

        }
        public void Random()
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
                    this.Location = new Point(x, y);
                    break;
                }
            }
        }
    }
}

