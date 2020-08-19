using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Btn1_Click(object sender, RoutedEventArgs e)
        {
            
           
        }

        private void Btn2_Copy_Click(object sender, RoutedEventArgs e)
        {
            ElectronicEveryDayBook_E2DayBook_ w1 = new ElectronicEveryDayBook_E2DayBook_();
            w1.Show();

        }
    }
}

