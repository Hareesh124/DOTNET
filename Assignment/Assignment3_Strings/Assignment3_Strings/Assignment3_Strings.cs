using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3_Strings
{
    internal class Assignment3_Strings
    {


        static void length(string word)
        {
            Console.WriteLine("Length of the word is: " + word.Length);
        }

        static void rev(string word)
        {
            char[] arr = word.ToCharArray();
            Array.Reverse(arr);
            string ans = new string(arr);
            Console.WriteLine("Reversed string:" + ans);
        }

        static void check()
        {
            Console.WriteLine("Enter word 1 : ");
            string a = Console.ReadLine();
            a = a.ToLower();
            Console.WriteLine("Enter word 2 : ");
            string b = Console.ReadLine();
            b = b.ToLower();
            if (string.Equals(a, b))
            {
                Console.WriteLine("They are equal");
            }
            else
            {
                Console.WriteLine("They are not equal");
            }
        }
        static void Main(string[] args)
        {
            Console.Write("Enter a word: ");
            string word = Console.ReadLine();
            length(word);
            rev(word);
            check();    
            Console.Read();
        }
    }
}
