using System;
using Composition3.Entities.Enum;
using System.Collections.Generic;
using System.Text;
namespace Composition3.Entities
{
    public class Order
    {
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
        public Client Client { get; set; }
            

        public Order()
        {

        }

        public Order(DateTime moment, OrderStatus status, Client client)
        {
            Moment = moment;
            Status = status;
            Client = client;
        }
        public void AddItem(OrderItem item)
        {
            Items.Add(item);
        }
        public void RemoveItem(OrderItem item)
        {
            Items.Remove(item);
        }
        public double Total()
        {
            double sum=0;
            foreach(OrderItem item in Items)
            {
                sum += item.subTotal();
            }
            return sum;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Order Moment: ");
            sb.AppendLine(Moment.ToString("dd/MM/yyyy HH:mm:ss"));
            sb.Append("Order status: ");
            sb.AppendLine(Status.ToString());
            sb.Append("Client: ");
            sb.Append(Client.Name);
            sb.Append($" ({Client.BirthDate.ToShortDateString()}) - ");
            sb.AppendLine(Client.Email);
            sb.AppendLine("Order items:");
            double total = 0;
            foreach(OrderItem order in Items)
            {
                total += order.subTotal();
                sb.AppendLine($"{order.Product.Name}, ${order.Product.Price}, Quantity: {order.Quantity}, Subtotal: ${order.subTotal()}");
            }
            sb.AppendLine($"Total price: ${total}");
            return sb.ToString();




        }
    }
}
