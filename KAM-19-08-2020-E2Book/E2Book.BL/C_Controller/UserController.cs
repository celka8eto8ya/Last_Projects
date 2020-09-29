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
        public static void SaveInfoUser(TextBox sourceData, TextBox password, TextBox serverName, TextBox userName, TextBox serverPassword)
        {
            if (sourceData.Text == ".txt")
            {
                bool b = false;
                CheckUniquePassword("dataTxt.dat", password.Text, ref b);

                if (b)
                {
                    User user1 = new User(password.Text);

                    List<User> usersTxt = new List<User>();
                    TakeInfoUser("dataTxt.dat", ref usersTxt);
                    usersTxt.Add(user1);

                    BinaryFormatter formatter = new BinaryFormatter();

                    using (FileStream fs = new FileStream("dataTxt.dat", FileMode.OpenOrCreate))
                    {
                        formatter.Serialize(fs, usersTxt);

                        MessageBox.Show("Data (about User) have saved.", "Information.", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            else
            {
                bool b = false;
                CheckUniquePassword("dataDB.dat", password.Text, ref b);

                if (b)
                {
                    User user1 = new User(password.Text, serverName.Text, userName.Text, serverPassword.Text);

                    List<User> usersDB = new List<User>();
                    TakeInfoUser("dataDB.dat", ref usersDB);
                    usersDB.Add(user1);

                    BinaryFormatter formatter = new BinaryFormatter();

                    using (FileStream fs = new FileStream("dataDB.dat", FileMode.OpenOrCreate))
                    {
                        formatter.Serialize(fs, usersDB);

                        MessageBox.Show("Data (about User) have saved.", "Information.", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
        }



        static void CheckUniquePassword(string pathFile, string password, ref bool b)
        {
            List<User> usersTxt = new List<User>();
            TakeInfoUser(pathFile, ref usersTxt);

            b = true;
            foreach (User user in usersTxt)
            {
                if (user.Password == password)
                {
                    b = false;
                }
            }

            if (!b)
            {
                MessageBox.Show($"Password \"{password}\" isn't unique.", "Warning!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }




        static void TakeInfoUser(string pathFile, ref List<User> usersInfo)
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();

                using (FileStream fs = new FileStream(pathFile, FileMode.OpenOrCreate))
                {
                    usersInfo = (List<User>)formatter.Deserialize(fs);
                }
            }
            catch (Exception)
            {
                MessageBox.Show($"File \"{pathFile}\" not exist.", "Warning!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }



    }
}


