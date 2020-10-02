using System;
using System.Windows;

namespace E2Book.BL.A_Model
{
    [Serializable]
    public class User
    {
        // Password for enter in App
        private string password;
        // Total amount money on Account
        private double totalSum;
        // Total amount of Accounts
        private readonly byte amountOfAccount;
        // Name of Server for create DB
        private string nameOfServer;
        // User's name of Server for create DB
        private string nameOfUser;
        // password of Server for create DB
        private string passwordOfServer;

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
        public double TotalSum
        {
            get
            {
                return totalSum;
            }
            set
            {
                if (value >= 0)
                {
                    totalSum = value;
                }
            }
        }
        public byte AmountOfAccount
        {
            get
            {
                return amountOfAccount;
            }
            set
            {
                if (value >= 0 && value < 250)
                {
                    totalSum = value;
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


        public User(string password1)
        {
            Password = password1;
            TotalSum = 0;
            AmountOfAccount = 0;
        }

        public User(string password1, string nameOfServer1, string nameOfUser1, string passwordOfServer1)
        {
            Password = password1;
            TotalSum = 0;
            AmountOfAccount = 0;

            NameOfServer = nameOfServer1;
            NameOfUser = nameOfUser1;
            PasswordOfServer = passwordOfServer1;
        }



    }
}
