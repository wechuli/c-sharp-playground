using System;

namespace throwing_expeptions
{
    class Program
    {
        static void Main(string[] args)
        {
            Exception e = new Exception("There was a problem");
            
            throw e;
            ApplicationException appEx = new ApplicationException();
        }
    }
}
