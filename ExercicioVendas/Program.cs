using ExercicioVendas.Entities;
using ExercicioVendas.Entities.Enums;
using System;
using System.Collections.Specialized;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using System.Xml;

namespace ExercicioVendas
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Client date:");
            Console.WriteLine("Name:");
            string name = Console.ReadLine();
            Console.WriteLine("Email:");
            string email = Console.ReadLine();
            Console.WriteLine("Birth date (DD/MM/YYYY):");
            DateTime date = DateTime.Parse(Console.ReadLine());

            Client cl = new Client(name, email, date);

            Console.WriteLine("Enter order data:");
            Console.WriteLine("Status");
            OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());

            Console.WriteLine("How many items to this order?");
            int n = int.Parse(Console.ReadLine());
            DateTime d = DateTime.Now;
            Order o = new Order(d, status, cl);
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Enter #{0} item data", i + 1);
                Console.WriteLine("Product name:");
                string nameItem = Console.ReadLine();
                Console.WriteLine("Product Price:");
                double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.WriteLine("Quantity:");
                int quantity = int.Parse(Console.ReadLine());

                Product p = new Product(nameItem, price);

                OrderItem item = new OrderItem(quantity, price, p);

                o.AddItem(item);
            }
            
            Console.WriteLine(o);


        }
    }
}
