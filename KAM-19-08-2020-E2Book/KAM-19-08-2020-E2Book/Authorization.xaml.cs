using E2Book.BL.A_Model;
using E2Book.BL.C_Controller;
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

        private void BtnGoToAuthorization_Click(object sender, RoutedEventArgs e)
        {
            Registration regWindow = new Registration();
            regWindow.Show();
            this.Close();
        }

        private void BtnEnter_Click(object sender, RoutedEventArgs e)
        {
            if (Tb1.Text.Length > 4)
            {
                bool bb = false;
                User user1 = new User("");
                UserController.Enter(Tb1.Text, ref user1, ref bb);

                if (!bb)
                {
                    MessageBox.Show("Not exist password !", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    MainWindow window1 = new MainWindow();
                    window1.Show();

                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Not correct length of password !", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
           

        }
    }
}
