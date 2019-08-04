using System;
using System.IO;
class FixingSubtitles
{
    const double COEFFICIENT = 1.05;
    const int ADDITION = 5000;
    const string INPUT_FILE = "StarWars.sub";
    const string OUTPUT_FILE = "StarWarsFixed.sub";
    static void Main()
    {
        try
        {
            // Create reader
            StreamReader streamReader = new StreamReader(INPUT_FILE);
            // Create writer
            StreamWriter streamWriter =
            new StreamWriter(OUTPUT_FILE, false);
            using (streamReader)
            {
                using (streamWriter)
                {
                    string line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        streamWriter.WriteLine(FixLine(line));
                    }
                }
            }
        }
        catch (IOException exc)
        {
            Console.WriteLine("Error: {0}.", exc.Message);
        }
    }
    static string FixLine(string line)
    {
        // Find closing brace
        int bracketFromIndex = line.IndexOf('}');
        // Extract 'from' time
        string fromTime = line.Substring(1, bracketFromIndex - 1);
        // Calculate new 'from' time
        int newFromTime = (int)(Convert.ToInt32(fromTime) *
        COEFFICIENT + ADDITION);
        // Find the following closing brace
        int bracketToIndex = line.IndexOf('}',
        bracketFromIndex + 1);
        // Extract 'to' time
        string toTime = line.Substring(bracketFromIndex + 2,
        bracketToIndex - bracketFromIndex - 2);
        // Calculate new 'to' time
        int newToTime = (int)(Convert.ToInt32(toTime) *
        COEFFICIENT + ADDITION);
        // Create a new line using the new 'from' and 'to' times
        string fixedLine = "{" + newFromTime + "}" + "{" +
        newToTime + "}" + line.Substring(bracketToIndex + 1);
        return fixedLine;
    }
}