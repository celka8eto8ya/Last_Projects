using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace KAM_19_08_2020_E2Book
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Authorization aut1 = new Authorization();
            aut1.Show();
            Tb3.Opacity = 1;
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

      

        bool b1 = true;
        private void Tb3_GotFocus(object sender, RoutedEventArgs e)
        {
            if (b1)
            {
                Tb3.Text = "";
                b1 = false;
            }
        }
        bool b2 = true;
        private void Tb1_GotFocus(object sender, RoutedEventArgs e)
        {
            if (b2)
            {
                Tb1.Text = "";
                b2 = false;
            }
        }
        //bool b3 = true;
        //private void Tb2_GotFocus(object sender, RoutedEventArgs e)
        //{
        //    if (b3)
        //    {
        //        Tb2.Text = "";
        //        b3 = false;
        //    }
        //}
    }
}
