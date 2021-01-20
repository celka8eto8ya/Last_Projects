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
                MessageBox.Show(ex.Message);
            }
        }

        public static void Show(ref DataGrid dgv2)
        {
            try
            {
                List<Note> list1 = new List<Note>();

                Deserialize(ref list1);


                dgv2.ItemsSource = list1;
                ResizeDataGrid(ref dgv2);

                dgv2.Items.SortDescriptions.Add(new SortDescription("Condition", ListSortDirection.Ascending));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            // получает дату и по ней заполняет лист из 
            // вытянутого чрез сериализацию листа
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

                datePar = datePar.Remove(10, 8);
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
                MessageBox.Show(ex.Message);
            }
        }

        public static void Add(Note notePar, ref List<Note> listNotesPar, ref DataGrid dgv2)
        {
            try
            {
                listNotesPar.Add(notePar);
                Serialize(listNotesPar);

                dgv2.ItemsSource = listNotesPar;
                ResizeDataGrid(ref dgv2);
                dgv2.Items.Refresh();
                dgv2.Items.SortDescriptions.Add(new SortDescription("Condition", ListSortDirection.Ascending));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            // сначала добавляется объект в лист
            // добавить логику из кнопки соответств
            // закрашивается день в календаре
        }

        public static void Checked(Note notePar, ref List<Note> listNotesPar)
        {

            // сначала изменяется объект в лист
            // добавить логику из кнопки соответств
        }

        public static void Delete(Note notePar, ref List<Note> listNotesPar)
        {
            // сначала удаляется объект из лист
            // добавить логику из кнопки соответств
            // день в календаре делается прозрачным
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
                MessageBox.Show(ex.Message);
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
                MessageBox.Show(ex.Message);
            }
        }


    }
}



