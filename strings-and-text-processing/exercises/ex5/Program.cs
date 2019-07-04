using System;

namespace ex5
{
    class Program
    {
        static void Main(string[] args)
        {
            // Write a program that detects how many times a substring is contained in the text. For example, let’s look for the substring "in" in the text
            string text = "We are living in a yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";

            int startIndex = 0;
            int count = 0;

            while (true)
            {
                int currentIndex = text.IndexOf("in", startIndex, StringComparison.CurrentCultureIgnoreCase);
                if (currentIndex == -1)
                {
                    break;
                }
                count++;
                startIndex = currentIndex + 1;
            }


            Console.WriteLine($"{count} occurences");

        }
    }
}
