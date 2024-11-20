using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furniture
{
    public class ModernChair : IChair
    {
        public void SitOn()
        {
            Console.WriteLine("Sitting on modern chair.");
        }
    }

    public class ModernSofa : ISofa
    {
        public void LayOn()
        {
            Console.WriteLine("SLeeping on modern sofa.");
        }
    }

    public class VintageChair : IChair
    {
        public void SitOn()
        {
            Console.WriteLine("Sitting on vintage chair");
        }
    }

    public class VintageSofa : ISofa
    {
        public void LayOn()
        {
            Console.WriteLine("SLeeping on vintage sofa");
        }
    }

}
