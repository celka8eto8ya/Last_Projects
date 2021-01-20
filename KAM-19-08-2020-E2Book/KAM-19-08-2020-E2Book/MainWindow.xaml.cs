using E2Book.BL.A_Model;
using E2Book.BL.C_Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace KAM_19_08_2020_E2Book
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //// Current list of Tasks\Notes
        //List<Note> NoteList; = new List<Note>();

        //calendar1.BlackoutDates.AddDatesInPast();
        ////calendar1.BlackoutDates.Add(new CalendarDateRange(DateTime.Today, DateTime.Today.AddDays(1)));
        //calendar1.SelectedDates.Add(DateTime.Today.AddDays(2));
        //calendar1.SelectedDates.Add(DateTime.Today.AddDays(3));
        //calendar1.SelectedDates.Add(new DateTime(2021, 01, 26));
        //calendar1.SelectedDates.Add(new DateTime(2021, 01, 26));

        public MainWindow()
        {
            InitializeComponent();

            try
            {
                calendar1.BlackoutDates.AddDatesInPast();
                DatePicker1.Text = DateTime.Now.ToShortDateString();
                //NoteController.Show(ref dataGrid2);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message +" "+ex);
            }
            ///
            /// Deserialization of NotesList with filtr 
            /// 
            /// 
            
        }

    
        bool b11 = true;
        private void Tb11_GotFocus(object sender, RoutedEventArgs e)
        {
            b11 = true;

            if (b11)
            {
                Tb11.Text = "";

            }
        }

        bool b10 = true;
        private void Tb10_GotFocus(object sender, RoutedEventArgs e)
        {
            b10 = true;

            if (b10)
            {
                Tb10.Text = "";

            }
        }
        

        /// <summary>
        /// Create new Note
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn12_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<Note> listDG = new List<Note>();
                NoteController.Deserialize(ref listDG);

                Note note1;
                if (listDG.Count > 0)
                {
                    note1 = new Note(listDG[listDG.Count - 1].Id + 1, Tb10.Text, Tb11.Text, "current", DatePicker1.Text);
                }
                else
                {
                    note1 = new Note(1, Tb10.Text, Tb11.Text, "current", DatePicker1.Text);
                }
                NoteController.Add(note1, ref listDG, ref dataGrid2);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "|" + ex);
            }
        }


        /// <summary>
        /// Delete choosen Note
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn13_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<Note> listDG = new List<Note>();
                Note customer = (Note)dataGrid2.SelectedItem;

                for (int i = 0; i < listDG.Count; i++)
                {
                    if (listDG[i].Id == customer.Id)
                    {
                        listDG.RemoveAt(i);
                    }
                }

                dataGrid2.ItemsSource = listDG;
                NoteController.ResizeDataGrid(ref dataGrid2);

                dataGrid2.Items.SortDescriptions.Add(new SortDescription("Condition", ListSortDirection.Ascending));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex);
            }
        }


        /// <summary>
        /// Checked choosen Note
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn14_Click(object sender, RoutedEventArgs e)
        {
            try { 
            List<Note> listDG = new List<Note>();
            Note customer = (Note)dataGrid2.SelectedItem;
            int a = 0;
            for (int i = 0; i < listDG.Count; i++)
            {
                if (listDG[i] == customer)
                {
                    a = i;
                    listDG[i].Condition = "done";
                }
            }

            dataGrid2.Items.Refresh();
            dataGrid2.Items.SortDescriptions.Add(new SortDescription("Condition", ListSortDirection.Ascending));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex);
            }

        }



        private void Calendar1_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                List<Note> list1 = new List<Note>();
                NoteController.Show(calendar1.SelectedDate.ToString(), ref dataGrid2);



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "--->" + ex);
            }
        }
    }
}
