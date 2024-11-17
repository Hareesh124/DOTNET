using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOn
{
    class NullOperations
    {
        static void Main(string[] Args) 
        {
            Nullable<int> n = null;
            int? x = null;

            if(n.HasValue)
                Console.WriteLine(n.Value);
            else
                Console.WriteLine("Null");
            Console.Read();
        }
    }
}
