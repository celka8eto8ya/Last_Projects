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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Button[] Days = new Button[42];
        DateTime CurrentDate = new DateTime();
        public MainWindow()
        {
            InitializeComponent();

            CurrentDate = DateTime.Now;
            DayController.CreateCalender(ref gridCalender, ref Days);
            DayController.DefineCalendar(CurrentDate, ref Days);
            
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DayController.DefineCalendar(DateTime.Now, ref Days);
        }

        private void BtnNext_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CurrentDate.Month + 1 > 12)
                {
                    CurrentDate = new DateTime(CurrentDate.Year+1, 1, 1);
                }
                else
                {
                    CurrentDate = new DateTime(CurrentDate.Year, CurrentDate.Month + 1, 1);
                }
             

                DayController.DefineCalendar(CurrentDate, ref Days);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
