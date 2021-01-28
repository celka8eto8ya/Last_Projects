using E2Book.BL.A_Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows;
using System.Windows.Controls;



namespace E2Book.BL.C_Controller
{
    public class UserController
    {
        /// <summary>
        /// Save data about User
        /// </summary>
        /// <param name="sourceData"></param>
        /// <param name="password"></param>
        /// <param name="serverName"></param>
        /// <param name="userName"></param>
        /// <param name="serverPassword"></param>
        public static void SaveInfo(TextBox typeOfFile, TextBox password, TextBox login, TextBox serverName, TextBox userName, TextBox serverPassword)
        {
            try
            {

                if (typeOfFile.Text == ".txt")
                {
                    bool b = false;
                    CheckUniquePassword(password.Text, login.Text, ref b);

                    if (b)
                    {
                        User user1 = new User(login.Text, password.Text, typeOfFile.Text);
                        List<User> usersTxt = new List<User>();
                        ReadInfoUser("dataTxt.dat", ref usersTxt);
                        usersTxt.Add(user1);

                        BinaryFormatter formatter = new BinaryFormatter();

                        using (FileStream fs = new FileStream("dataTxt.dat", FileMode.OpenOrCreate))
                        {
                            formatter.Serialize(fs, usersTxt);

                            MessageBox.Show($"Data (about User: {login.Text}) have saved.", "Information.", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Password or login isn't unique!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    bool b = false;
                    CheckUniquePassword(password.Text, login.Text, ref b);

                    if (b)
                    {
                        User user1 = new User(login.Text, password.Text, typeOfFile.Text, serverName.Text, userName.Text, serverPassword.Text);

                        List<User> usersDB = new List<User>();
                        ReadInfoUser("dataDB.dat", ref usersDB);
                        usersDB.Add(user1);

                        BinaryFormatter formatter = new BinaryFormatter();

                        using (FileStream fs = new FileStream("dataDB.dat", FileMode.OpenOrCreate))
                        {
                            formatter.Serialize(fs, usersDB);

                            MessageBox.Show("Data (about User: {login.Text}) have saved.", "Information.", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Password or login isn't unique!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Method <SaveInfo> - {ex.Message} \r\n -- {ex.ToString()}");
            }

        }


        /// <summary>
        /// Check unique password and login
        /// </summary>
        /// <param name="password"></param>
        /// <param name="b"></param>
        static void CheckUniquePassword(string password, string login, ref bool b)
        {
            try
            {
                List<User> usersTxt1 = new List<User>();
                List<User> usersTxt2 = new List<User>();
                b = false;

                bool b1 = true;
                bool b2 = true;

                if (System.IO.File.Exists("dataTxt.dat"))
                {
                    ReadInfoUser("dataTxt.dat", ref usersTxt1);

                    foreach (User user in usersTxt1)
                    {
                        if (user.Password == password && user.Login == login)
                        {
                            b1 = false;
                        }
                    }
                }

                if (System.IO.File.Exists("dataDB.dat"))
                {
                    ReadInfoUser("dataDB.dat", ref usersTxt2);

                    foreach (User user in usersTxt2)
                    {
                        if (user.Password == password && user.Login == login)
                        {
                            b2 = false;
                        }
                    }
                }

                if (b1 && b2)
                {
                    b = true;
                }
                else
                {
                    b = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Method <CheckUniquePassword> - {ex.Message} \r\n -- {ex.ToString()}");
            }
        }


        /// <summary>
        /// Read data about User (Deserialize)
        /// </summary>
        /// <param name="pathFile"></param>
        /// <param name="usersInfo"></param>
        static void ReadInfoUser(string pathFile, ref List<User> usersInfo)
        {
            try
            {
                if (System.IO.File.Exists(pathFile))
                {
                    if (System.IO.File.ReadAllLines(@pathFile).Length > 0)
                    {
                        BinaryFormatter formatter = new BinaryFormatter();

                        using (FileStream fs = new FileStream(pathFile, FileMode.OpenOrCreate))
                        {
                            usersInfo = (List<User>)formatter.Deserialize(fs);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Method <ReadInfoUser> - {ex.ToString()}");
            }
        }


        /// <summary>
        /// Aouthorization of User
        /// </summary>
        /// <param name="password"></param>
        /// <param name="user1"></param>
        /// <param name="bb"></param>
        public static void Enter(string password, string login, ref User user1, ref bool bb)
        {
            try
            {
                bool b = false;
                CheckUniquePassword(password, login, ref b);

                List<User> usersTxt1 = new List<User>();
                List<User> usersTxt2 = new List<User>();

                if (!b)
                {
                    if (System.IO.File.Exists("dataTxt.dat"))
                    {
                        ReadInfoUser("dataTxt.dat", ref usersTxt1);

                        foreach (User user in usersTxt1)
                        {
                            if (user.Password == password && user.Login == login)
                            {
                                bb = true;
                                user1 = user;

                                MessageBox.Show($"Authorization completed successfully.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                            }
                        }
                    }

                    if (System.IO.File.Exists("dataDB.dat"))
                    {
                        ReadInfoUser("dataDB.dat", ref usersTxt1);

                        foreach (User user in usersTxt2)
                        {
                            if (user.Password == password && user.Login == login)
                            {
                                bb = true;
                                user1 = user;
                                MessageBox.Show("Authorization completed successfully.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                            }
                        }
                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Method <Enter> - {ex.Message} \r\n -- {ex.ToString()}");
            }


        }


    }
}


