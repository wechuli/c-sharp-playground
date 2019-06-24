using System;
using System.IO;

namespace nested_exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string fileName = "WrongFileName.txt";
                ReadFile(fileName);
            }
            catch (IOException e)
            {

                throw new ApplicationException("Somethind bad happened", e);
            }
        }

        static void ReadFile(string fileName)
        {
            try
            {
                TextReader reader = new StreamReader(fileName);
                string line = reader.ReadLine();
                Console.WriteLine(line);
                reader.Close();
            }
            catch (FileNotFoundException fnfe)
            {

                Console.WriteLine($"The file {fileName} does not exist!");
            }
            // In this example, the ReadFile() method catches and handles only FileNotFoundException while passing all other exceptions up to the Main() method. In the Main() method, we handle only exceptions of type IOException and will let the CLR handle all other exceptions.

            //If the Main() method passes a wrong filename, FileNotFoundException will be thrown while intializing the TextReader in ReadFile(). This exception will be handled by the ReadFile() method itself. If on the other hand the file exists but there is some problem reading it (insufficient permissions, damaged file contents etc), the respective exception that will be thrown will be handled by the Main() method.

            //Handling exceptions at different levels allows the error conditions to be handled at the most suitable place for the particular error. This allows the program code to be clear and structured and the flexibility achieved is enormous.


        }
    }
}
