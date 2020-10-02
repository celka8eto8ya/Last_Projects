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
        /// 
        /// </summary>
        /// <param name="sourceData"></param>
        /// <param name="password"></param>
        /// <param name="serverName"></param>
        /// <param name="userName"></param>
        /// <param name="serverPassword"></param>
        public static void SaveInfo(TextBox typeOfFile, TextBox password, TextBox serverName, TextBox userName, TextBox serverPassword)
        {
            if (typeOfFile.Text == ".txt")
            {
                bool b = false;
                CheckUniquePassword(password.Text, ref b);

                if (b)
                {
                    User user1 = new User(password.Text);

                    List<User> usersTxt = new List<User>();
                    ReadInfoUser("dataTxt.dat", ref usersTxt);
                    usersTxt.Add(user1);

                    BinaryFormatter formatter = new BinaryFormatter();

                    using (FileStream fs = new FileStream("dataTxt.dat", FileMode.OpenOrCreate))
                    {
                        formatter.Serialize(fs, usersTxt);

                        MessageBox.Show("Data (about User) have saved.", "Information.", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                else
                {
                    MessageBox.Show($"Password \"{password.Text}\" isn't unique!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                bool b = false;
                CheckUniquePassword(password.Text, ref b);

                if (b)
                {
                    User user1 = new User(password.Text, serverName.Text, userName.Text, serverPassword.Text);

                    List<User> usersDB = new List<User>();
                    ReadInfoUser("dataDB.dat", ref usersDB);
                    usersDB.Add(user1);

                    BinaryFormatter formatter = new BinaryFormatter();

                    using (FileStream fs = new FileStream("dataDB.dat", FileMode.OpenOrCreate))
                    {
                        formatter.Serialize(fs, usersDB);

                        MessageBox.Show("Data (about User) have saved.", "Information.", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                else
                {
                    MessageBox.Show($"Password \"{password.Text}\" isn't unique!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }



        static void CheckUniquePassword(string password, ref bool b)
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
                    if (user.Password == password)
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
                    if (user.Password == password)
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



        static void ReadInfoUser(string pathFile, ref List<User> usersInfo)
        {
            if (System.IO.File.Exists(pathFile))
            {
                BinaryFormatter formatter = new BinaryFormatter();

                using (FileStream fs = new FileStream(pathFile, FileMode.OpenOrCreate))
                {
                    usersInfo = (List<User>)formatter.Deserialize(fs);
                }
            }
        }



        public static void Enter(string password, ref User user1, ref bool bb)
        {
            bool b = false;
            CheckUniquePassword(password, ref b);

            List<User> usersTxt1 = new List<User>();
            List<User> usersTxt2 = new List<User>();

            if (!b)
            {
                if (System.IO.File.Exists("dataTxt.dat"))
                {
                    ReadInfoUser("dataTxt.dat", ref usersTxt1);

                    foreach (User user in usersTxt1)
                    {
                        if (user.Password == password)
                        {
                            bb = true;
                            user1 = user;
                            MessageBox.Show("Authorization completed successfully.", "Information", MessageBoxButton.OK,MessageBoxImage.Information);
                        }
                    }
                }

                if (System.IO.File.Exists("dataDB.dat"))
                {
                    ReadInfoUser("dataDB.dat", ref usersTxt1);

                    foreach (User user in usersTxt2)
                    {
                        if (user.Password == password)
                        {
                            bb = true;
                            user1 = user;
                            MessageBox.Show("Authorization completed successfully.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                }
            }
        }

    }
}


