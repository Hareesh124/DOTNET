using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3_inheritance
{
    class SaleDetails
    {
        public int SalesNo { get;  set; }
        public int ProductNo { get;  set; }
        public decimal Price { get;  set; }
        public DateTime DateOfSale { get;  set; }
        public int Quantity { get;  set; }
        public decimal TotalAmount { get;  set; }

        public SaleDetails(int salesNo, int productNo, decimal price, int quantity, DateTime dateOfSale)
        {
            SalesNo = salesNo;
            ProductNo = productNo;
            Price = price;
            Quantity = quantity;
            DateOfSale = dateOfSale;
            CalculateTotalAmount();
        }

        private void CalculateTotalAmount()
        {
            TotalAmount = Quantity * Price;
        }

        public static void ShowData(SaleDetails sale)
        {
            Console.WriteLine($"Sales No: {sale.SalesNo}");
            Console.WriteLine($"Product No: {sale.ProductNo}");
            Console.WriteLine($"Price: {sale.Price}");
            Console.WriteLine($"Quantity: {sale.Quantity}");
            Console.WriteLine($"Date of Sale: {sale.DateOfSale.ToShortDateString()}");
            Console.WriteLine($"Total Amount: {sale.TotalAmount}");
        }

        static void Main()
        {
            Console.Write("Enter Sales Number: ");
            int salesNo = int.Parse(Console.ReadLine());

            Console.Write("Enter Product Number: ");
            int productNo = int.Parse(Console.ReadLine());

            Console.Write("Enter Price per item: ");
            decimal price = decimal.Parse(Console.ReadLine());

            Console.Write("Enter Quantity: ");
            int quantity = int.Parse(Console.ReadLine());

            Console.Write("Enter Date of Sale (yyyy-mm-dd): ");
            DateTime dateOfSale = DateTime.Parse(Console.ReadLine());

            SaleDetails sale = new SaleDetails(salesNo, productNo, price, quantity, dateOfSale);

            SaleDetails.ShowData(sale);
            Console.Read();
        }
    }

}
