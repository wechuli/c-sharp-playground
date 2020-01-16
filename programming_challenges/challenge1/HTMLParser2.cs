using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;


namespace challenge1

{
    public static class HTMLToTextParser2
    {

        // read the parsed file line by line and return it as a text
        public static List<string> readHTMLFile(string filePath)
        {

            StreamReader reader = new StreamReader(filePath);
            List<string> html = new List<string>();

            using (reader)
            {
                string line = reader.ReadLine().TrimEnd('\r', '\n');

                while (line != null)
                {

                    html.Add(line);
                    // line = reader.ReadLine().Trim('\r', '\n');
                    line = reader.ReadLine();
                }

            }

            return html;

        }
        public static void writeToTxtFile(string filePath, IEnumerable<string> text)
        {

            StreamWriter writer = new StreamWriter(filePath);
            using (writer)
            {
                foreach (var line in text)
                {
                    if (line.Length > 0)
                    {
                        writer.WriteLine(line);
                    }

                }
            }

        }

        public static List<string> parseRawTextToTokens(List<string> rawTextTokens)
        {

            for (var i = 0; i < rawTextTokens.Count; i++)
            {
                int startIndex;
                int stopIndex;
                while (rawTextTokens[i].IndexOf('<') != -1)
                {

                    startIndex = rawTextTokens[i].IndexOf('<');
                    stopIndex = rawTextTokens[i].IndexOf('>');
                    rawTextTokens[i] = rawTextTokens[i].Remove(startIndex, stopIndex - startIndex + 1);
                    rawTextTokens[i] = Regex.Replace(rawTextTokens[i], @"\s+", " ").Trim();
                }

            }


            return rawTextTokens;

        }



    }

}