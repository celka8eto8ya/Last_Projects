using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using E2Book.BL.A_Model;



namespace E2Book.BL.C_Controller
{
    public class UserController
    {
        public static void SaveInfoUser(TextBox sourceData, TextBox password, TextBox serverName, TextBox userName, TextBox serverPassword)
        {
            if (sourceData.Text == ".txt")
            {
                User user1 = new User(password.Text);

                List<User> usersTxt = new List<User>() { user1 };

                BinaryFormatter formatter = new BinaryFormatter();

                using (FileStream fs = new FileStream("dataTxt.dat", FileMode.OpenOrCreate))
                {

                }
            }
            else
            {
                User user1 = new User(password.Text, serverName.Text, userName.Text, serverPassword.Text);

                List<User> usersDB = new List<User>() { user1 };

                BinaryFormatter formatter = new BinaryFormatter();

                using (FileStream fs = new FileStream("dataTxt.dat", FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs,usersDB);
                }
            }

        }
    }
}
