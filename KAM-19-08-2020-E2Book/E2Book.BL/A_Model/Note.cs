using System;
using System.Windows;

namespace E2Book.BL.A_Model
{
    [Serializable]
    public class Note
    {
        // Unique number of task
        private int id;
        // Short info about text
        private string shortTitle;
        // Deal or case
        private string text;
        // Current or done
        private string condition;
        // Date to wich it belongs note
        private string date;


        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                if (value >= 0)
                {
                    id = value;
                }
                else
                {
                    MessageBox.Show($"Not correct filed \"Id\" (Unique number of task)!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        public string ShortTitle
        {
            get
            {
                return shortTitle;
            }
            set
            {
                if (value.Length > 0)
                {
                    shortTitle = value;
                }
                else
                {
                    MessageBox.Show($"Not correct filed \"ShortTitle\" (Short info about text)!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        public string Text
        {
            get
            {
                return text;
            }
            set
            {
                if (value.Length > 0)
                {
                    text = value;
                }
                else
                {
                    MessageBox.Show($"Not correct filed \"Text\" (Name of deal or case)!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        public string Condition
        {
            get
            {
                return condition;
            }
            set
            {
                if (value.Length > 0)
                {
                    condition = value;
                }
                else
                {
                    MessageBox.Show($"Not correct filed \"Condition\" (Current or done)!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
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
                else
                {
                    MessageBox.Show($"Not correct filed \"Date\" (Date to wich it belongs note)!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        public Note(int IdOfLastTask, string shortTitles1, string text1, string condition1, string date1)
        {
            if (date1.Length == 10 && (date1[5] == '.') && (date1[5] == '.'))
            {
                Id = IdOfLastTask;
                ShortTitle = shortTitles1;
                Text = text1;
                Condition = condition1;
                Date = date1;
            }
            else
            {
                MessageBox.Show($"Not correct filed \"Date\" (Date to wich it belongs note)!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        public override string ToString()
        {
            return $"{Id} {ShortTitle} {Text} {Condition} {Date}";
        }
    }
}
