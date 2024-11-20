using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPdf
{
    class ClientDocConv
    {
        static void Main()
        {
            Console.Write("Enter your data:");
            string data = Console.ReadLine();

            Console.WriteLine("\nTo which format you need to convert (doc/pdf/txt):");
            string extension = Console.ReadLine();

            DocConvertFactory factory = new DocConvertFactory();
            try
            {
                IDocConversion obj = factory.GetConverter(extension);
                Console.WriteLine(obj.Convert(data));
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }

            Console.Read();

        }
    }
}
