using System.Collections;
using System;


namespace delegates
{
    public delegate void Del(string message);


    public static class Useless
    {
        public static void DelegateMethod(string message)
        {
            Console.WriteLine(message);
        }
    }

}