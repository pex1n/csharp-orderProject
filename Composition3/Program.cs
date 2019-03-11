using System;
using Composition3.Entities;
using Composition3.Entities.Enum;

namespace Composition3
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter the client data:");
            Console.WriteLine();
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Birth date (DD/MM/YYYY): ");
            string birth = Console.ReadLine();
            DateTime birthDate = DateTime.Parse(birth);
            Client client = new Client(name, email, birthDate);
            Console.WriteLine();
            Console.WriteLine("Enter the order data:");
            Console.Write("Status: ");
            string status = Console.ReadLine();
            OrderStatus Status;
            Enum.TryParse(status, true, out Status);
            Console.Write("How many items to this order? ");
            int n = int.Parse(Console.ReadLine());
            Order order = new Order(DateTime.Now, Status, client);
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Enter #{i} item data:");
                Console.Write("Product name: ");
                string productName = Console.ReadLine();
                Console.Write("Product Price: ");
                double price = double.Parse(Console.ReadLine());
                Console.Write("Quantity: ");
                int quantity = int.Parse(Console.ReadLine());
                Product item = new Product(productName, price);
                OrderItem orderItem = new OrderItem(quantity, item);
                order.AddItem(orderItem);
            }
            Console.WriteLine();
            Console.WriteLine("ORDER SUMMARY:");
            Console.WriteLine(order);
        }
    }
}
