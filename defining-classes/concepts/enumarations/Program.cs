using System;

namespace enumarations
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine(Days.Mon.GetType());
        }
    }

    public enum Days
    {
        Sun, Mon, Tue, Wed, Thu, Fri, Sar
    }
}
