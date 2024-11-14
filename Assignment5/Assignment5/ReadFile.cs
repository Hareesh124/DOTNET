using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assignment5
{
    class ReadFIle
    {
        static void Main(string[] args)
        {
            string filePath = "output.txt"; 

            try
            {
                string[] lines = File.ReadAllLines(filePath);
                Console.WriteLine($"The file contains {lines.Length} lines.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            Console.Read();
        }
    }
}
