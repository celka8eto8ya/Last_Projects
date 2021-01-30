using System;
using System.Windows;

namespace E2Book.BL.A_Model
{
    [Serializable]
    public class User
    {
        // Login for enter in App
        private string login;
        // Password for enter in App
        private string password;
        // Type of saved Data  
        private string typeOfData;
        // Name of Server for create DB
        private string nameOfServer;
        // User's name of Server for create DB
        private string nameOfUser;
        // password of Server for create DB
        private string passwordOfServer;



        public string Login
        {
            get
            {
                return login;
            }
            set
            {
                if (value.Length > 0)
                {
                    login = value;
                }
            }
        }
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                if (value.Length > 4)
                {
                    password = value;
                }
            }
        }
        public string TypeOfData
        {
            get
            {
                return typeOfData;
            }
            set
            {
                if (value.Length > 0 && value.Length < 5)
                {
                    typeOfData = value;
                }
            }
        }
        public string NameOfServer
        {
            get
            {
                return nameOfServer;
            }
            set
            {
                if (value.Length > 0)
                {
                    nameOfServer = value;
                }
            }
        }
        public string NameOfUser
        {
            get
            {
                return nameOfUser;
            }
            set
            {
                if (value.Length > 0)
                {
                    nameOfUser = value;
                }
            }
        }
        public string PasswordOfServer
        {
            get
            {
                return passwordOfServer;
            }
            set
            {
                if (value.Length > 0)
                {
                    passwordOfServer = value;
                }
            }
        }



        public User(string login1, string password1, string typeOfData1)
        {
            Login = login1;
            Password = password1;
            TypeOfData = typeOfData1;
        }

        public User(string login1, string password1, string typeOfData1, string nameOfServer1, string nameOfUser1, string passwordOfServer1)
        {
            Login = login1;
            Password = password1;
            TypeOfData = typeOfData1;

            NameOfServer = nameOfServer1;
            NameOfUser = nameOfUser1;
            PasswordOfServer = passwordOfServer1;
        }

        public override string ToString()
        {
            return $"{Login} {Password} {TypeOfData} ";
        }

    }
}
