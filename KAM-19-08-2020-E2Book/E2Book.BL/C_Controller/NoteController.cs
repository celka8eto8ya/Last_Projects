using E2Book.BL.A_Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows;
using System.Windows.Controls;

namespace E2Book.BL.C_Controller
{
    public class NoteController
    {
        /// <summary>
        /// Resize DG
        /// </summary>
        /// <param name="dgv2"></param>
        public static void ResizeDataGrid(ref DataGrid dgv2)
        {
            try
            {
                dgv2.Columns[0].Width = Bank.SizeId;
                dgv2.Columns[1].Width = Bank.SizeShortTitle;
                dgv2.Columns[2].Width = Bank.SizeText;
                dgv2.Columns[3].Width = Bank.SizeCondition;
                dgv2.Columns[4].Width = Bank.SizeDate;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Method <ResizeDataGrid> - {ex.Message} \r\n -- {ex.ToString()}");
            }
        }


        /// <summary>
        /// Show Tasks or Notes of Date
        /// </summary>
        /// <param name="datePar"></param>
        /// <param name="dgv2"></param>
        public static void Show(string datePar, ref DataGrid dgv2)
        {
            try
            {
                List<Note> list1 = new List<Note>();
                List<Note> listNotes = new List<Note>();
                Deserialize(ref list1);

                if (datePar.Length > 10)
                {
                    datePar = datePar.Remove(10, 8);
                }
                for (int i = 0; i < list1.Count; i++)
                {
                    if (list1[i].Date == datePar)
                    {
                        listNotes.Add(list1[i]);
                    }
                }

                dgv2.ItemsSource = listNotes;
                ResizeDataGrid(ref dgv2);

                dgv2.Items.SortDescriptions.Add(new SortDescription("Condition", ListSortDirection.Ascending));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Method <Show> - {ex.Message} \r\n -- {ex.ToString()}");
            }
        }


        /// <summary>
        /// Paint days wich have a Task
        /// </summary>
        /// <param name="calendarPar"></param>
        public static void UpdateCalendar(ref Calendar calendarPar)
        {
            try
            {
                List<Note> listDG = new List<Note>();
                Deserialize(ref listDG);
                for (int i = 0; i < listDG.Count; i++)
                {
                    if (listDG[i].Condition == "current")
                    {
                        calendarPar.SelectedDates.Add(Convert.ToDateTime(listDG[i].Date));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Method <UpdateCalendar> - {ex.Message} \r\n -- {ex.ToString()}");
            }
        }


        /// <summary>
        /// Add new note
        /// </summary>
        /// <param name="notePar"></param>
        /// <param name="listNotesPar"></param>
        /// <param name="calendarPar"></param>
        public static void Add(string shortTitlePar, string textPar, DatePicker datePickerPar, ref Calendar calendarPar, ref DataGrid dataGridPar)
        { 
            try
            {
                List<Note> listDG = new List<Note>();
                Deserialize(ref listDG);

                Note note1;
                if (listDG.Count > 0)
                {
                    note1 = new Note(listDG[listDG.Count - 1].Id + 1, shortTitlePar, textPar, "current", datePickerPar.Text);
                }
                else
                {
                    note1 = new Note(1, shortTitlePar, textPar, "current", datePickerPar.Text);
                }

                listDG.Add(note1);
                Serialize(listDG);
              
                UpdateCalendar(ref calendarPar);

                Show(datePickerPar.Text, ref dataGridPar);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Method <Add> - {ex.Message} \r\n -- {ex.ToString()}");
            }
        }

        /// <summary>
        /// To do needed task "done"
        /// </summary>
        /// <param name="dataGridPar"></param>
        /// <param name="calendarPar"></param>
        public static void Checked(ref DataGrid dataGridPar, ref Calendar calendarPar)
        {
            try
            {
                List<Note> listDG = new List<Note>();
                Deserialize(ref listDG);
                Note customer = (Note)dataGridPar.SelectedItem;

                for (int i = 0; i < listDG.Count; i++)
                {
                    if (listDG[i].Id == customer.Id)
                    {

                        listDG[i].Condition = "done";
                    }
                }
                Serialize(listDG);

                Show(calendarPar.SelectedDate.ToString(), ref dataGridPar);

                UpdateCalendar(ref calendarPar);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Method <Checked> - {ex.Message} \r\n -- {ex.ToString()}");
            }



            // сначала изменяется объект в лист
            // добавить логику из кнопки соответств
        }


        /// <summary>
        /// Dalete chosen task
        /// </summary>
        /// <param name="notePar"></param>
        /// <param name="listNotesPar"></param>
        /// <param name="dataGridPar"></param>
        /// <param name="calendarPar"></param>
        public static void Delete(ref DataGrid dataGridPar, ref Calendar calendarPar)
        {
            try
            {
                if ((Note)dataGridPar.SelectedItem != null)
                {
                    List<Note> listDG = new List<Note>();
                    Deserialize(ref listDG);

                    Note customer = (Note)dataGridPar.SelectedItem;

                    for (int i = 0; i < listDG.Count; i++)
                    {
                        if (listDG[i].Id == customer.Id)
                        {
                            listDG.RemoveAt(i);
                        }
                    }
                    Serialize(listDG);

                    Show(calendarPar.SelectedDate.ToString(), ref dataGridPar);

                    UpdateCalendar(ref calendarPar);
                }
                else
                {
                    MessageBox.Show($"You don't have chosen the element for Deleting.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Method <Delete> - {ex.Message} \r\n -- {ex.ToString()}");
            }

        }


        /// <summary>
        /// Serialize data into file with path "Bank.UserPath"
        /// </summary>
        /// <param name="listNotesPar"></param>
        public static void Serialize(List<Note> listNotesPar)
        {
            try
            {
                if (Bank.TypeOfDataUser == ".txt")
                {
                    BinaryFormatter formatter = new BinaryFormatter();

                    using (FileStream fs = new FileStream(Bank.UserPath, FileMode.OpenOrCreate))
                    {
                        formatter.Serialize(fs, listNotesPar);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Method <Serialize> - {ex.Message} \r\n -- {ex.ToString()}");
            }
        }


        /// <summary>
        /// Deserialize data from file with path "Bank.UserPath"
        /// </summary>
        /// <param name="listNotesPar"></param>
        public static void Deserialize(ref List<Note> listNotesPar)
        {
            try
            {
                if (System.IO.File.Exists(Bank.UserPath))
                {

                    int count = System.IO.File.ReadAllLines(Bank.UserPath).Length;
                    if (Bank.TypeOfDataUser == ".txt" && count > 1)
                    {
                        BinaryFormatter formatter = new BinaryFormatter();

                        using (FileStream fs = new FileStream(Bank.UserPath, FileMode.OpenOrCreate))
                        {
                            listNotesPar = (List<Note>)formatter.Deserialize(fs);

                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Method <Deserialize> - {ex.Message} \r\n -- {ex.ToString()}");
            }
        }


        /// <summary>
        /// Show task with chosed filter category
        /// </summary>
        /// <param name="filterNamePar"></param>
        /// <param name="dataGridPar"></param>
        public static void Filter(string filterNamePar, ref DataGrid dataGridPar)
        {
            try
            {
                List<Note> list1 = new List<Note>();
                List<Note> listNotes = new List<Note>();

                Deserialize(ref list1);

                if (filterNamePar == "All")
                {
                    dataGridPar.ItemsSource = list1;
                }

                if (filterNamePar == "All current")
                {
                    for (int i = 0; i < list1.Count; i++)
                    {
                        if (list1[i].Condition == "current")
                        {
                            listNotes.Add(list1[i]);
                        }
                    }

                    dataGridPar.ItemsSource = listNotes;
                }

                if (filterNamePar == "All done")
                {
                    for (int i = 0; i < list1.Count; i++)
                    {
                        if (list1[i].Condition == "done")
                        {
                            listNotes.Add(list1[i]);
                        }
                    }

                    dataGridPar.ItemsSource = listNotes;
                }

                ResizeDataGrid(ref dataGridPar);
                //dataGridPar.Items.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Method <Filter> - {ex.Message} \r\n -- {ex.ToString()}");
            }
        }

    }
}



