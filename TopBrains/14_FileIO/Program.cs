using System;
using System.IO;

namespace FileIO
{
    class Program
    {
        static void Main()
        {
            // Input log file name
            string inputFile = "log.txt";

            // Output file to store only ERROR logs
            string outputFile = "error.txt";

            // Check if the input file exists
            if (!File.Exists(inputFile))
            {
                Console.WriteLine("log.txt not found");
                return;
            }

            // StreamReader is used to read the log file
            // StreamWriter is used to write ERROR logs into a new file
            using (StreamReader reader = new StreamReader(inputFile))
            using (StreamWriter writer = new StreamWriter(outputFile))
            {
                string line;

                // Read the file line by line until end of file
                while ((line = reader.ReadLine()) != null)
                {
                    // Check if the current log line contains "ERROR"
                    if (line.Contains("ERROR"))
                    {
                        // Write only ERROR logs to error.txt
                        writer.WriteLine(line);
                    }
                }
            }
        }
    }
}