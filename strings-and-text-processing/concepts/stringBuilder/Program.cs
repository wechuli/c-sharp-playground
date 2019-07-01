using System;
using System.Text;

namespace stringBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            string str1 = "Super";
            string str2 = "Star";
            string result = str1 + str2;
            Console.WriteLine(result);

            Console.WriteLine(DateTime.Now);
            StringBuilder sb = new StringBuilder();
            sb.Append("Numbers: ");
            for (int index = 1; index <= 200000; index++)
            {
                sb.Append(index);
            }
            Console.WriteLine(sb.ToString().Substring(0, 1024));
            Console.WriteLine(DateTime.Now);


        }
    }
}
