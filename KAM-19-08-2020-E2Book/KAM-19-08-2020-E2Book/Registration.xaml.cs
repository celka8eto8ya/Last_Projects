using System;
using System.Windows;
using E2Book.BL.C_Controller ;
using E2Book.BL.A_Model ;

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
            if (Tb3.Text == ".db" || Tb3.Text == ".txt" && Tb1.Text.Length > 4)
            {
                UserController.SaveInfo(Tb3, Tb1, Tb4, Tb5, Tb6);
            }
            else
            {
                MessageBox.Show("Not correct data entered (1st or/and 2nd field)!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
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

        private void BtnGoToAuthorization_Click(object sender, RoutedEventArgs e)
        {
            Authorization auth1 = new Authorization();
            auth1.Show();
            this.Close();
        }
    }
}
