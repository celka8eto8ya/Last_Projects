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
        private int size;
        private int speed;
        private Location location;
      
        public Button1(int size)
        {
            Button btn = new Button();
            btn.FlatStyle = FlatStyle.Flat;
            btn.BackColor = SystemColors.ControlDark;
            btn.Size = new System.Drawing.Size(size, size);
              
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
        public Location Location1
        {
            get { return location; }
            set
            {
                if (location.X >= 0 && location.Y >= 0)
                { location = value; }
                else
                { MessageBox.Show("Ошибка!", "Неподходящее значение поля location!"); }
            }
        }
    }
}

