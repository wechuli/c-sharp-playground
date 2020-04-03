using System;
using System.Threading;

namespace threading_in_c_
{
    class Program
    {


        static void Main(string[] args)
        {

            var threadManager = new ThreadDemoManager();
            threadManager.ShowThreadInfo();

            threadManager.RunCodeOnSeparateThread();
            threadManager.Execute();

        }
    }
}
