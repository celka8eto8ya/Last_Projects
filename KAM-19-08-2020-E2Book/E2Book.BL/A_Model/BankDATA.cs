using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E2Book.BL.A_Model
{
    public static class Bank
    {
        // Type of entered User
        public static string TypeOfDataUser;
        // Id of Last task 
        public static int IdOfLastTask;


        //// Date of creating Account for Naming file (Serialization)
        //public static string UserLogin;

        // Path of user data about Tasks\Notes
        public static string UserPath;
        // Path of user data about Account
        public static string UserPathAccount;
        //// Path of user data about Operations
        //public static string UserPathOperations;
        //// Path of user data about Note
        //public static string UserPathNotes;


        // Size of DataGrid (Tasks\Notes)
        public static int SizeId = 40;
        public static int SizeShortTitle = 90;
        public static int SizeText = 260;
        public static int SizeCondition = 70;
        public static int SizeDate = 90;

    }
}
