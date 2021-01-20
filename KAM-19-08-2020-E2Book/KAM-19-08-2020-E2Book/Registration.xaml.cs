using E2Book.BL.C_Controller;
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

        bool b22 = true;
        private void Tb2_GotFocus(object sender, RoutedEventArgs e)
        {
            if (b22)
            {
                Tb2.Text = "";
                b22 = false;
            }
        }




        /// <summary>
        /// Authorization
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnGoToAuthorization_Click(object sender, RoutedEventArgs e)
        {
            Authorization auth1 = new Authorization();
            auth1.Show();
            this.Close();
        }

        /// <summary>
        /// Save info about Users
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if ((Tb3.Text == ".db" || Tb3.Text == ".txt") && Tb1.Text.Length > 4 && Tb2.Text.Length > 0)
            {
                UserController.SaveInfo(Tb3, Tb1, Tb2, Tb4, Tb5, Tb6);
            }
            else
            {
                MessageBox.Show("Not correct data entered (first-third fields)!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
