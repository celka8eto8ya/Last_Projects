using System;
using System.Windows;

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
            if (Tb3.Text == ".db" || Tb3.Text == ".txt")
            {

            }
            else
            {
                MessageBox.Show("Not correct data entered (1st field).", "Error!",MessageBoxButton.OK,MessageBoxImage.Warning);
            }
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

        bool b3 = true;
        private void Tb4_GotFocus(object sender, RoutedEventArgs e)
        {

            if (b3)
            {
                Tb4.Text = "";
                b3 = false;
            }

        }

        bool b4 = true;
        private void Tb5_GotFocus(object sender, RoutedEventArgs e)
        {
            if (b4)
            {
                Tb5.Text = "";
                b4 = false;
            }
        }
        bool b5 = true;
        private void Tb6_GotFocus(object sender, RoutedEventArgs e)
        {
            if (b5)
            {
                Tb6.Text = "";
                b5 = false;
            }
        }

      
        private void Tb3_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (Tb3.Text == ".db")
            {
                Tb4.IsEnabled = true;
                Tb5.IsEnabled = true;
                Tb6.IsEnabled = true;
            }
            else
            {
                Tb4.IsEnabled = false;
                Tb5.IsEnabled = false;
                Tb6.IsEnabled = false;
            }
        }

        private void Tb3_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (Tb3.Text == ".db")
            {
                Tb4.IsEnabled = true;
                Tb5.IsEnabled = true;
                Tb6.IsEnabled = true;
            }
            else
            {
                Tb4.IsEnabled = false;
                Tb5.IsEnabled = false;
                Tb6.IsEnabled = false;
            }
        }
    }
}
