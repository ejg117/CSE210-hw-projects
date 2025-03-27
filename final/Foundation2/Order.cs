using System.Collections.Generic;

namespace OnlineOrdering
{
    public class Order
    {
        private Customer customer;
        private List<Product> products;

        public Order(Customer customer, List<Product> products)
        {
            this.customer = customer;
            this.products = products;
        }

        public double GetTotalCost()
        {
            double totalProductCost = 0;
            foreach (Product product in products)
            {
                totalProductCost += product.GetTotalCost();
            }
            double shippingCost = customer.LivesInUSA() ? 5 : 35;
            return totalProductCost + shippingCost;
        }

        public string GetPackingLabel()
        {
            string label = "Packing Label:\n";
            foreach (Product product in products)
            {
                label += $"{product.Name} (ID: {product.ProductId})\n";
            }
            return label.Trim();
        }

        public string GetShippingLabel()
        {
            return $"Shipping Label:\n{customer.Name}\n{customer.Address.GetFullAddress()}";
        }
    }
}