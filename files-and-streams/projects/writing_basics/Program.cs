using System;
using System.IO;

namespace writing_basics
{
    class Program
    {
        static void Main(string[] args)
        {

            // Create a StreamWriter instance
            StreamWriter writer = new StreamWriter("numbers.txt");

            //Ensure the writer will be closed when no longer used

            using (writer)
            {
                //Loop through the numbers from 1 to 20 and write them

                for (int i = 0; i < 21; i++)
                {
                    writer.WriteLine(i);
                }
            }

            WritePoem();

        }

        public static void WritePoem()
        {
            StreamWriter deathPoem = new StreamWriter("deathPoem.txt");
            using (deathPoem)
            {
                deathPoem.WriteLine("And you as well must die beloved dust");
                deathPoem.WriteLine("And all your beauty stand you in no stead");
                deathPoem.WriteLine("This flawless hand, this perfect head");
                deathPoem.WriteLine("This body of flame and steel before the gust of death");
                deathPoem.WriteLine("Or under his autmumnal frost, shall be as any leaf");
                deathPoem.WriteLine("Be no less dead, than the first leaf that fell, this wonder fled");

            }
        }
    }
}
