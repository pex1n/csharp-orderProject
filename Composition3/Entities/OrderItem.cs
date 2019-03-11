using System;
namespace Composition3.Entities
{
    public class OrderItem
    {
        public int Quantity { get; set; }
        public double Price { get; set; }
        public Product Product { get; set; }

        public OrderItem()
        {
        }

        public OrderItem(int quantity, double price, Product product)
        {
            Quantity = quantity;
            Product = product;
            Price = price;
        }
        public double subTotal()
        {
            return Quantity * Price;
        }
        public override string ToString()
        {
            return $"{Product.Name}, ${Price}, Quantity: {Quantity}, Subtotal: ${subTotal()}";
        }
    }
}
