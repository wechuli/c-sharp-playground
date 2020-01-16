using System;
using System.IO;
using System.Text.RegularExpressions;

namespace challenge1
{
    class Program
    {
        static void Main(string[] args)
        {
            //We are given HTML file named Problem1.html. Write a program, which removes all HTML tags and retains only the text inside them. Output should be written into the file Problem1.txt.

            // HTMLToTextParser.writeToTxtFile("problem.txt", HTMLToTextParser.parseRawTextToTokens(HTMLToTextParser.readHTMLFile("problem.html")));
            HTMLToTextParser2.writeToTxtFile("problem.txt", HTMLToTextParser2.parseRawTextToTokens(HTMLToTextParser2.readHTMLFile("problem.html")));


        }
    }
}
