using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furniture
{
    class ConcreteFactory
    {
        public class ModernFurnitureFactory : IFurnitureFactory
        {
            public IChair CreateChair()
            {
                return new ModernChair();
            }

            public ISofa CreateSofa()
            {
                return new ModernSofa();
            }

        }

        public class VintageFurnitureFactory : IFurnitureFactory
        {
            public IChair CreateChair()
            {
                return new VintageChair();
            }

            public ISofa CreateSofa()
            {
                return new VintageSofa();
            }
        }

    }
}
