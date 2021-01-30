using System.Windows;

namespace KAM_19_08_2020_E2Book
{
    /// <summary>
    /// Логика взаимодействия для CreateAccount.xaml
    /// </summary>
    public partial class CreateAccount : Window
    {
        public CreateAccount()
        {
            InitializeComponent();
        }


        bool b1 = true;
        bool b2 = true;
        bool b3 = true;


        private void Tb1_GotFocus_1(object sender, RoutedEventArgs e)
        {
            if (b1)
            {
                Tb1.Text = "";
                b1 = false;
            }
        }

        private void Tb2_GotFocus_1(object sender, RoutedEventArgs e)
        {
            if (b2)
            {
                Tb2.Text = "";
                b2 = false;
            }
        }

        private void Tb3_GotFocus_1(object sender, RoutedEventArgs e)
        {
            if (b3)
            {
                Tb3.Text = "";
                b3 = false;
            }
        }


        /// <summary>
        /// Create new account
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {

        }


        /// <summary>
        /// Close current window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCloseWindow_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


    }
}
