using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KAM_KP_PSP__ClassLibrary_
{
    public class Security
    {
        // логин (в потенциале хранилища)
        private string login;
        // пароль хранилища
        private string password;

        // создание логина (если длина находится в пределе (0,20) символов)
        public string Login
        {
            get
            {
                return login;
            }
            set
            {
                if (value.Length > 0 && value.Length < 20)
                {
                    login = value;
                }
                else
                {
                    MessageBox.Show("Логин не соответствует длине (0,20) символов!", "Ошибка!");
                }
            }
        }

        // создание пароля (если длина находится в пределе (0,20) символов)
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                if (value.Length > 0 && value.Length < 20)
                {
                    password = value;
                }
                else
                {
                    MessageBox.Show("Логин не соответствует длине (0,20) символов!", "Ошибка!");
                }
            }
        }

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="login1"></param>
        /// <param name="pass1"></param>

        public Security(string login1, string pass1)
        {
            Login = login1;
            Password = pass1;
        }



    }
}
