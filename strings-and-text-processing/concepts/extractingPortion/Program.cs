using System;

namespace extractingPortion
{
    class Program
    {
        static void Main(string[] args)
        {

            string path = "C:\\Pics\\CoolPic.jpg";
            string fileName = path.Substring(8, 7);
            Console.WriteLine(fileName);

            // Extracting a File Name and File Extension

            int index = path.LastIndexOf("\\");
            //index = 7
            string fullName = path.Substring(index+1);

            Console.WriteLine(fullName);

        }
    }
}
