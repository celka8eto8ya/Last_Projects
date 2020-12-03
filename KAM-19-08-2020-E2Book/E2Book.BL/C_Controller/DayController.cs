using E2Book.BL.A_Model;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;

namespace E2Book.BL.C_Controller
{
    public class DayController
    {
        public static void DefineCalendar(DateTime Dt1, ref Button[] DaysButton/*, ref Day[] DaysInfo*/)
        {


            //DT1.Month
            DateTime dt1 = new DateTime(Dt1.Year, Dt1.Month, 1);

            MessageBox.Show(dt1.DayOfWeek.ToString());

            byte startPos = 0;

            if (dt1.DayOfWeek.ToString() == "Tuesday")
            {
                startPos = 1;
            }
            if (dt1.DayOfWeek.ToString() == "Wednesday")
            {
                startPos = 2;
            }
            if (dt1.DayOfWeek.ToString() == "Thursday")
            {
                startPos = 3;
            }
            if (dt1.DayOfWeek.ToString() == "Friday")
            {
                startPos = 4;
            }
            if (dt1.DayOfWeek.ToString() == "Saturday")
            {
                startPos = 5;
            }
            if (dt1.DayOfWeek.ToString() == "Sunday")
            {
                startPos = 6;
            }

            int daysInMonth = System.DateTime.DaysInMonth(Dt1.Year, Dt1.Month);
            for (int i = 0; i < 42; i++)
            {
                if (i < startPos || i >= daysInMonth + startPos)
                {
                    DaysButton[i].Content = "";
                    DaysButton[i].Background = Brushes.AntiqueWhite;

                }
                else
                {
                    DaysButton[i].Background = Brushes.LightGray;
                    DaysButton[i].Content = $"{dt1.Day + i - startPos}.{dt1.Month}";
                }
               



            }
          
          
        }

        public static void CreateCalender(ref Grid grid1, ref Button [] DaysButton)
        {
            DaysButton = new Button[42];
           
            ParserContext context = new ParserContext();
            context.XmlnsDictionary.Add("", "http://schemas.microsoft.com/winfx/2006/xaml/presentation");
            context.XmlnsDictionary.Add("x", "http://schemas.microsoft.com/winfx/2006/xaml");

            int ii = 0;
            for (int j = 1; j < 7; j++)
            {
                for (int i = 0; i < 7; i++)
                {
                    string xaml = String.Format($"<Button  Grid.Row='{j}' Grid.Column='{i}'/>" );
                    UIElement element = (UIElement)XamlReader.Parse(xaml, context);

                    DaysButton[ii] = new Button() ;
                    DaysButton[ii] = (Button)element ;

                    grid1.Children.Add(DaysButton[ii]);
                    ii++;
                }
            }
        }



    }
}
