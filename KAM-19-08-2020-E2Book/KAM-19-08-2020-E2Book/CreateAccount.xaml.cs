using E2Book.BL.C_Controller;
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
        bool b3 = true;

        private void Tb1_GotFocus_1(object sender, RoutedEventArgs e)
        {
            if (b1)
            {
                Tb1.Text = "";
                b1 = false;
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
            try
            {
                bool b = true;
                AccountController.CheckUniqueName(Tb3.Text, ref b);
                if (Tb3.Text.Length > 4 && comboBox1.Text.Length == 3 && Tb1.Text.Length > 0 && b)
                {
                    AccountController.Add(Tb3.Text, comboBox1.Text, Tb1.Text);
                    MessageBox.Show("Account created success.", "Success!", MessageBoxButton.OK, MessageBoxImage.Information);

                }
                else
                {
                    MessageBox.Show("Not all fields have corect data or not unique name of account.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch { }
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
