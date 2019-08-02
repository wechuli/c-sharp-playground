using System;
using System.IO;
using System.Text;

namespace encoding
{
    class Program
    {
        static void Main(string[] args)
        {

            //lets try using two different encodings on the same file

            Encoding utf8 = Encoding.GetEncoding("UTF-8");
            Encoding win1251 = Encoding.GetEncoding("utf-32BE");

            StreamReader reader1 = new StreamReader("poem.txt", utf8);
            StreamReader reader2 = new StreamReader("poem.txt", win1251);


            using (reader1)
            {
                Console.WriteLine(reader1.ReadLine());
            }


            // the below code will produce totally different results due to a different encoding scheme used to open it
            using (reader2)
            {
                Console.WriteLine(reader2.ReadLine());
            }





        }
    }
}
