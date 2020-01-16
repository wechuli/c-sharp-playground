using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;


namespace challenge1

{
    public static class HTMLToTextParser
    {

        // read the parsed file line by line and return it as a text
        public static string readHTMLFile(string filePath)
        {

            StreamReader reader = new StreamReader(filePath);
            StringBuilder readString = new StringBuilder();

            using (reader)
            {
                string line = reader.ReadLine().TrimEnd('\r', '\n');

                while (line != null)
                {
                    readString.Append(line);
                    line = reader.ReadLine();

                }

            }

            return readString.ToString();

        }
        public static void writeToTxtFile(string filePath, string[] text)
        {

            StreamWriter writer = new StreamWriter(filePath);
            using (writer)
            {
                foreach (var line in text)
                {
                    writer.WriteLine(line);
                }
            }

        }

        public static string[] parseRawTextToTokens(string rawText)
        {
            string parsedString = rawText;
            int startIndex;
            int stopIndex;
            string[] tokens;

            while (parsedString.IndexOf('<') != -1)
            {

                startIndex = parsedString.IndexOf('<');
                stopIndex = parsedString.IndexOf('>');
                parsedString = parsedString.Remove(startIndex, stopIndex - startIndex + 1);
            }

            return Regex.Replace(parsedString, @"\s+", " ").Trim().Split(' ');

        }



    }

}