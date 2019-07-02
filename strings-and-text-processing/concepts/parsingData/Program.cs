using System;
using System.Globalization;

namespace parsingData
{
    class Program
    {
        static void Main(string[] args)
        {
            //Parsing Numeric Types
            string text = "53";
            int intValue = int.Parse(text);

            //parse Boolean Variables
            string bText = "True";
            bool boolValue = bool.Parse(bText);

            //parsing dates
            string textDate = "11/11/2019";
            DateTime parsedDate = DateTime.Parse(textDate);
            Console.WriteLine(parsedDate);

            //explicitly parsing dates
            string textDate2 = "11/12/2001";
            string format = "MM/dd/yyyy";

            DateTime parsedDate2 = DateTime.ParseExact(textDate2, format, CultureInfo.InvariantCulture);
            Console.WriteLine("Day: {0}\nMonth: {1}\nYear: {2}", parsedDate2.Day, parsedDate2.Month, parsedDate2.Year);

        }
    }
}
