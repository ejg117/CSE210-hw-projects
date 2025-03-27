using System;
using System.Collections.Generic;

namespace OnlineOrdering
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create addresses
            Address address1 = new Address("123 Maple St", "Springfield", "IL", "USA");
            Address address2 = new Address("456 Pine Rd", "Toronto", "ON", "Canada");

            // Create customers
            Customer customer1 = new Customer("Alice Smith", address1);
            Customer customer2 = new Customer("Bob Jones", address2);

            // Create products
            Product product1 = new Product("Laptop", "LPT001", 1000, 1);
            Product product2 = new Product("Mouse", "MSE002", 20, 2);
            Product product3 = new Product("Keyboard", "KBD003", 50, 1);
            Product product4 = new Product("Monitor", "MON004", 300, 1);

            // Create orders
            List<Product> order1Products = new List<Product> { product1, product2 }; // Alice: Laptop, Mouse
            Order order1 = new Order(customer1, order1Products);

            List<Product> order2Products = new List<Product> { product3, product4 }; // Bob: Keyboard, Monitor
            Order order2 = new Order(customer2, order2Products);

            // Display order details
            List<Order> orders = new List<Order> { order1, order2 };
            foreach (Order order in orders)
            {
                Console.WriteLine(order.GetPackingLabel());
                Console.WriteLine();
                Console.WriteLine(order.GetShippingLabel());
                Console.WriteLine();
                Console.WriteLine($"Total Cost: ${order.GetTotalCost()}");
                Console.WriteLine(new string('-', 40));
            }
        }
    }
}