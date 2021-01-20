using E2Book.BL.A_Model;
using E2Book.BL.C_Controller;
using System.Windows;

namespace KAM_19_08_2020_E2Book
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        public Authorization()
        {
            InitializeComponent();
        }




        bool b = true;
        private void Tb1_GotFocus(object sender, RoutedEventArgs e)
        {
            if (b)
            {
                Tb1.Text = "";
                b = false;
            }
        }

        bool b2 = true;
        private void Tb2_GotFocus(object sender, RoutedEventArgs e)
        {

            if (b2)
            {
                Tb2.Text = "";
                b2 = false;

            }
        }




        /// <summary>
        /// Authorization
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnGoToAuthorization_Click(object sender, RoutedEventArgs e)
        {
            Registration regWindow = new Registration();
            regWindow.Show();
            this.Close();
        }

        /// <summary>
        /// Enter at the account
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnEnter_Click(object sender, RoutedEventArgs e)
        {
            if (Tb1.Text.Length > 4 && Tb2.Text.Length > 0)
            {
                bool bb = false;
                User user1 = new User("", "", ".txt");
                UserController.Enter(Tb1.Text, Tb2.Text, ref user1, ref bb);

              
                if (!bb)
                {
                    MessageBox.Show("Not exist password or login!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    Bank.TypeOfDataUser = user1.TypeOfData;
                    Bank.UserPath = $"dataAboutUser{user1.Login}.dat";
                    MainWindow window1 = new MainWindow();
                    window1.Show();

                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Not correct length of password or login !", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }

      
    }
}
