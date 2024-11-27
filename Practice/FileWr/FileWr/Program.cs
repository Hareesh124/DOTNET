using System;
using System.IO;

class Program
{
    static void Main()
    {
        string fileName = "output.txt";

        Console.Write("EnTer the text you want to append: ");
        string inputText = Console.ReadLine();
        using (StreamWriter writer = new StreamWriter(fileName, false))
        {
            writer.WriteLine(inputText);
        }
        

        Console.WriteLine($"The Text - {inputText} - has been appended to the file '{fileName}'.");
        Console.Read();
    }
}