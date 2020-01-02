using System;

namespace delegates
{
    class Program
    {
        static void Main(string[] args)
        {
            Del handler = Useless.DelegateMethod;

            // call the delegate
            handler("hi there, Paul");
        }
    }
}
