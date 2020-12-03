using System;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace E2Book.BL.A_Model
{
    public class Day : Button
    {
        // Date of the day
        private DateTime date;
        // Amount Completed Tasks in definite day
        private byte amountCompletedTasks;
        // Amount All Tasks in definite day
        private byte amountAllTasks;
        // Color of the day
        private string colorName;

        public DateTime Date
        {
            get
            {
                return date;
            }
            set
            {
                if (value.ToString().Length > 0)
                {
                    date = value;
                }
            }
        }
        public byte AmountCompletedTasks
        {
            get
            {
                return amountCompletedTasks;
            }
            set
            {
                if (value >= 0)
                {
                    amountCompletedTasks = value;
                }
            }
        }
        public byte AmountAllTasks
        {
            get
            {
                return amountAllTasks;
            }
            set
            {
                if (value >= 0)

                {
                    amountAllTasks = value;
                }
            }
        }
        public string ColorName
        {
            get
            {
                return colorName;
            }
            set
            {
                if (value.Length > 0)
                {
                    colorName = value;
                }
            }
        }

        public Day(DateTime date1)
        {
            Date = date1;
            AmountCompletedTasks = 0;
            AmountAllTasks = 0;
            ColorName = "White";
        }
    }
}
