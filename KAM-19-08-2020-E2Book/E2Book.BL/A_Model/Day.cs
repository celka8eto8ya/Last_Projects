namespace E2Book.BL.A_Model
{
    public class Day
    {
        // Date of the day
        private string date;
        // Amount Completed Tasks in definite day
        private byte amountCompletedTasks;
        // Amount All Tasks in definite day
        private byte amountAllTasks;
        // Color of the day
        private string colorName;

        public string Date
        {
            get
            {
                return date;
            }
            set
            {
                if (value.Length > 0)
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

        public Day(string date1)
        {
            Date = date1;
            AmountCompletedTasks = 0;
            AmountAllTasks = 0;
            ColorName = "White";
        }
    }
}
