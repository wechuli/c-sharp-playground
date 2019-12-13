using System;
using System.IO;
using System.Diagnostics;

namespace defensive_prog
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Programm Starting");
            FakeMethodToAssertStuff("fakestring");
        }

        public static void FakeMethodToAssertStuff(string fileName)
        {
            bool templatefileExist = File.Exists(fileName);
            Debug.Assert(templatefileExist, $"Can't load templates file {fileName}");

        }
    }
}
