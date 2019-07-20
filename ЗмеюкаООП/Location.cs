using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ЗмеюкаООП
{
   public class Location
    {
        public int x;
        public int y;

        public int X
        {
            get { return x; }
            set {
                if (x > 0)
                { x = value; }
                else
                { MessageBox.Show("Ошибка!", "Неподходящее значение поля x!"); }
            }
        }
        public int Y
        {
            get { return y; }
            set {
                if (y > 0)
                { y = value; }
                else
                { MessageBox.Show("Ошибка!", "Неподходящее значение поля y!"); }
            }
        }
    }
}
