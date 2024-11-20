using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assesment3
{
    class FileWrite
    {
        static void Main(string[] args)
        {
            string fileName = "output1.txt";

            Console.Write("EnTer the text you want to append: ");
            string inputText = Console.ReadLine();

            using (StreamWriter writer = new StreamWriter(fileName, true))
            {
                writer.WriteLine(inputText);
            }

            Console.WriteLine($"The Text - {inputText} - has been appended to the file '{fileName}'.");
            Console.Read();
        }
    }
}
