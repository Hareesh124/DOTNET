using Furniture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Furniture.ConcreteFactory;

namespace FurnitureShop
{
    public class FurnitureShop
    {
        private IChair chair;
        private ISofa sofa;

        public FurnitureShop(IFurnitureFactory factory)
        {
            chair = factory.CreateChair();
            sofa = factory.CreateSofa();
        }

        public void DisplayFurniture()
        {
            chair.SitOn();
            sofa.LayOn();
        }

        static void Main(string[] args)
        {
            IFurnitureFactory modernFactory = new ModernFurnitureFactory();
            FurnitureShop modernShop = new FurnitureShop(modernFactory);
            Console.WriteLine("Modern Furniture:");
            modernShop.DisplayFurniture();

            IFurnitureFactory vintageFactory = new VintageFurnitureFactory();
            FurnitureShop vintageShop = new FurnitureShop(vintageFactory);
            Console.WriteLine("\nVintage Furniture:");
            vintageShop.DisplayFurniture();
            Console.Read();
        }
    }
}