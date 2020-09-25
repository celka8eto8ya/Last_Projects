using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E2Book.BL.A_Model
{
    public class Security
    {
        private string password;
        private DateTime dateOfRegistration;

        // TODO: Добавить валидацию properties
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }

        public DateTime DateOfRegistration
        {
            get
            {
                return dateOfRegistration;
            }
            set
            {
                dateOfRegistration = value;
            }
        }

        public Security(string password)
        {
            Password = password;
            DateOfRegistration = DateTime.Now;
        }
    }
}
