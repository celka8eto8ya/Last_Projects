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
    public class AccountController
    {
        /// <summary>
        /// Serialize data into file with path "Bank.UserPathAccount"
        /// </summary>
        /// <param name="accountsPar"></param>
        public static void Serialize(List<Account> accountsPar)
        {
            try
            {
                if (Bank.TypeOfDataUser == ".txt")
                {
                    BinaryFormatter formatter = new BinaryFormatter();

                    using (FileStream fs = new FileStream(Bank.UserPathAccount, FileMode.OpenOrCreate))
                    {
                        formatter.Serialize(fs, accountsPar);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Method <AccountController.Serialize> - {ex.Message} \r\n -- {ex.ToString()}");
            }
        }

        /// <summary>
        /// Deserialize data from file with path "Bank.UserPathAccount"
        /// </summary>
        /// <param name="accountsPar"></param>
        public static void Deserialize(ref List<Account> accountsPar)
        {
            try
            {
                if (System.IO.File.Exists(Bank.UserPathAccount))
                {
                    int count = System.IO.File.ReadAllLines(Bank.UserPath).Length;
                    if (Bank.TypeOfDataUser == ".txt" && count > 1)
                    {
                        BinaryFormatter formatter = new BinaryFormatter();

                        using (FileStream fs = new FileStream(Bank.UserPathAccount, FileMode.OpenOrCreate))
                        {
                            accountsPar = (List<Account>)formatter.Deserialize(fs);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Method <AccountController.Deserialize> - {ex.Message} \r\n -- {ex.ToString()}");
            }
        }

        /// <summary>
        /// Add new account at the file
        /// </summary>
        /// <param name="namePar"></param>
        /// <param name="currencyPar"></param>
        /// <param name="locationPar"></param>
        /// <param name="dataGridPar"></param>
        public static void Add(string namePar, string currencyPar, string locationPar)
        {
            try
            {
                List<Account> listDG = new List<Account>();
                Deserialize(ref listDG);

                Account acc1;
                if (listDG.Count > 0)
                {
                    acc1 = new Account((byte)(listDG[listDG.Count - 1].Id + 1), namePar, currencyPar, locationPar);
                }
                else
                {
                    acc1 = new Account(1, namePar, currencyPar, locationPar);
                }

                listDG.Add(acc1);
                Serialize(listDG);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Method <AccountController.Add> - {ex.Message} \r\n -- {ex.ToString()}");
            }
        }

        /// <summary>
        /// Show all Accounts (Update info about)
        /// </summary>
        /// <param name="dataGridPar"></param>
        public static void Show(ref DataGrid dataGridPar)
        {
            try
            {
                List<Account> list1 = new List<Account>();
                Deserialize(ref list1);

                dataGridPar.ItemsSource = list1;
                ResizeDataGrid(ref dataGridPar);
                dataGridPar.Items.SortDescriptions.Add(new SortDescription("Id", ListSortDirection.Ascending));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Method <AccountController.Show> - {ex.Message} \r\n -- {ex.ToString()}");
            }
        }

        /// <summary>
        /// To do resize DataGrid (Width)
        /// </summary>
        /// <param name="dataGridPar"></param>
        public static void ResizeDataGrid(ref DataGrid dataGridPar)
        {
            try
            {
                dataGridPar.Columns[0].Width = 40;
                dataGridPar.Columns[1].Width = 100;
                dataGridPar.Columns[2].Width = 70;
                dataGridPar.Columns[3].Width = 70;
                dataGridPar.Columns[4].Width = 85;
                dataGridPar.Columns[5].Width = 90;
                dataGridPar.Columns[6].Width = 100;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Method <AccountController.ResizeDataGrid> - {ex.Message} \r\n -- {ex.ToString()}");
            }
        }

        /// <summary>
        /// Check unique name of account
        /// </summary>
        /// <param name="namePar"></param>
        /// <param name="answerPar"></param>
        public static void CheckUniqueName(string namePar, ref bool answerPar)
        {
            try
            {
                answerPar = true;
                List<Account> list1 = new List<Account>();
                Deserialize(ref list1);

                for (int i = 0; i < list1.Count; i++)
                {
                    if (list1[i].Name == namePar)
                    {
                        answerPar = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Method <AccountController.CheckUniqueName> - {ex.Message} \r\n -- {ex.ToString()}");
            }
        }

        public static void Convert(string currency1Par, double sumCurrency1Par, string currency2Par, ref double answerPar)
        {
            // КОНЕРТИРОВНАИЕ ВАЛЮТЫ
            // УМНОЖЕНИЕ ИЗНАЧАЛЬНОЙ СУММЫ НА НОВЫЙ КОЭФФИЦИЕНТ
            // ТУТ ВОЗМОЖНО ИСПОЛЬЗЩОВАТЬ ПРОТОКОЛ ДЛЯ ДОСТУПА К САЙТУ (ВЗЯТЬ МЕТОД ИЗ ЛАБЫ КОТОРУЮ ПИСАЛ)
            // ПРОПИСАТЬ ИСКЛЮЧЕНИЕ НА СЛУЧАЙ ОШИБКИ С ВЫВОДОМ СООБЩЕНИЯ "НЕТ ПОДКЛЮЧЕНИЯ К ИНТЕРНЕТУ"

        }

        /// <summary>
        /// Get name of accounts for input at the comboBox
        /// </summary>
        /// <param name="comboBoxPar"></param>
        public static void GetNameAccounts(ref ComboBox comboBoxPar)
        {
            try
            {
                comboBoxPar.Items.Clear();
                List<Account> list1 = new List<Account>();
                Deserialize(ref list1);

                for (int i = 0; i < list1.Count; i++)
                {
                    comboBoxPar.Items.Add(list1[i].Name);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Method <AccountController.GetNameAccounts> - {ex.Message} \r\n -- {ex.ToString()}");
            }
        }


        public static void Delete( ref DataGrid dataGridPar)
        {
            try
            {
                if ((Account)dataGridPar.SelectedItem != null)
                {
                    List<Account> listDG = new List<Account>();
                    Deserialize(ref listDG);

                    Account customer = (Account)dataGridPar.SelectedItem;

                    for (int i = 0; i < listDG.Count; i++)
                    {
                        if (listDG[i].Id == customer.Id)
                        {
                            listDG.RemoveAt(i);
                        }
                    }
                    Serialize(listDG);

                    Show(ref dataGridPar);
                }
                else
                {
                    MessageBox.Show($"You don't have chosen the element for Deleting.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Method <AccountController.Delete> - {ex.Message} \r\n -- {ex.ToString()}");
            }
        }
    }
}
