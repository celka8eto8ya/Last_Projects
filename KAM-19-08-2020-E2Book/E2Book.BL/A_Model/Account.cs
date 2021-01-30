using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E2Book.BL.A_Model
{
    [Serializable]
    public class Account
    {

        // Number of Account (definite user)
        private byte id;
        // Name of account
        private string name;
        // Amount of money at the account  
        private double sum;
        // Currency of account
        private string currency;
        // Date when account was created
        private DateTime dateOfCreate;
        // Date when account was change
        private DateTime dateOfChange;
        // Place where is the money
        private string location;


      
        public byte Id
        {
            get
            {
                return id;
            }
            set
            {
                if (value > 0 && value < 250)
                {
                    id = value;
                }
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value.Length > 4)
                {
                    name = value;
                }
            }
        }
        public double Sum
        {
            get
            {
                return sum;
            }
            set
            {
                if (value >= 0 )
                {
                    sum = value;
                }
            }
        }
        public string Currency
        {
            get
            {
                return currency;
            }
            set
            {
                if (value.Length >= 2)
                {
                    currency = value;
                }
            }
        }
        public DateTime DateOfCreate
        {
            get
            {
                return dateOfCreate;
            }
            set
            {
                if (value >= DateTime.Now)
                {
                    dateOfCreate = value;
                }
            }
        }
        public DateTime DateOfChange
        {
            get
            {
                return dateOfChange;
            }
            set
            {
                if (value <= DateTime.Now)
                {
                    dateOfChange = value;
                }
            }
        }
        public string Location
        {
            get
            {
                return location;
            }
            set
            {
                if (value.Length > 0)
                {
                    location = value;
                }
            }
        }
      


        public Account(string name1, string currency1, string location1)
        {
            Name = name1;
            Currency = currency1;
            Location = location1;
        }

        public override string ToString()
        {

            return $"{Id} {Name} {Sum} {Currency} {DateOfCreate} {DateOfChange} {Location} ";
        }

    }
}
