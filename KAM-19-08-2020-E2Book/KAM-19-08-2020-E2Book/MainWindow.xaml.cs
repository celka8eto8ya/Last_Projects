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
           
            ///
            /// Deserialization of NotesList
            /// 
            /// 
            /// 
            /// 

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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(Bank.TypeOfDataUser);
        }

        private void Tb10_KeyDown(object sender, KeyEventArgs e)
        {

        }
        bool b11 = true;
        private void Tb11_GotFocus(object sender, RoutedEventArgs e)
        {
            bool b11 = true;

            if (b11)
            {
                Tb11.Text = "";
               
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        bool b10 = true;
        private void Tb10_GotFocus(object sender, RoutedEventArgs e)
        {
            bool b10 = true;
           
                if (b10)
                {
                    Tb10.Text = "";
                   
                }
        }
        List<Note> NoteList = new List<Note>();
        private void Btn12_Click(object sender, RoutedEventArgs e)
        {
            dataGrid1.Items.Clear();
            // тут добавить метод для вычисления ИД заметки
            Note note1 = new Note(NoteList.Count+1, Tb10.Text, Tb11.Text, "current", DatePicker1.Text);
            textBox1.Text = note1.ToString();
            //            List<Phone> phonesList = new List<Phone>
            //{
            //    new Phone { Title="iPhone 6S", Company="Apple", Price=54990 },
            //    new Phone {Title="Lumia 950", Company="Microsoft", Price=39990 },
            //    new Phone {Title="Nexus 5X", Company="Google", Price=29990 }
            //};
            //            phonesGrid.ItemsSource = phonesList;
            NoteList.Add(note1);
            dataGrid1.ItemsSource = NoteList;
        
            //NoteController.
        }
    }
}
