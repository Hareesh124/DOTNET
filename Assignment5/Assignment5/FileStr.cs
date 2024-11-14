using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assignment5
{
    class FileStr
    {
        static void Main(string[] args)
        {
            string[] lines = new string[]
            {
            "Hello from IO",
            "Writing into file",
            "Written",
            "Completed"
            };

            string filePath = "output.txt";

            try
            {
                File.WriteAllLines(filePath, lines);
                Console.WriteLine("Data has been written to the file successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            Console.Read();
        }
    }
}
