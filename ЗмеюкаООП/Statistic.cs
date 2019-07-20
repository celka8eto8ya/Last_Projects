using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ЗмеюкаООП
{
  public class Statistic
    {
        private string put;
        private string slogn;
        private int schet;

        public string Put
        {
            get { return put; }
            set
            {
                if (put.Length > 0)
                { put = value; }
                else
                { MessageBox.Show("Ошибка!","Неподходящее значение поля put!"); }
            }
        }
        public string Slogn
        {
            get { return slogn; }
            set
            {
                if (slogn.Length > 0)
                { slogn = value; }
                else
                { MessageBox.Show("Ошибка!", "Неподходящее значение поля slogn!"); }
            }
        }
        public int Schet
        {
            get { return schet; }
            set
            {
                if (schet >= 0)
                { schet = value; }
                else
                { MessageBox.Show("Ошибка!", "Неподходящее значение поля schet!"); }
            }
        }
    }
}

