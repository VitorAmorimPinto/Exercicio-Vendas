using ExercicioVendas.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExercicioVendas.Entities
{
    class Order
    {
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }
        public Client Client { get; set; }
        public List<OrderItem> Itens { get; set; } = new List<OrderItem>();

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
            Itens.Add(item);
        }

        public void RemoveItem(OrderItem item)
        {
            Itens.Remove(item);

        }
        public double SubTotal(int quantity, double price)
        {
            return quantity * price;
        }
        public double total()
        {
            double sum = 0.0;
            foreach (OrderItem it in Itens)
            {
                sum += SubTotal(it.Quantity, it.Price);
            }
            return sum;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Order Moment: ");
            sb.AppendLine(Moment.ToString("dd/MM/yyyy HH:mm:ss"));
            sb.Append("Order Status:");
            sb.AppendLine(Status.ToString());
            sb.Append("Client: ");
            sb.Append(Client.Name + " ");
            sb.Append("(" + Client.BirthDate.ToString("dd/MM/yyyy") + ")" + " ");
            sb.AppendLine("- " + Client.Email);
            sb.AppendLine("Order items");
            foreach (OrderItem it in Itens)
            {

                sb.Append(it.Product.Name + ", ");
                sb.Append("$" + it.Product.Price + ", ");
                sb.Append("Quantity: " + it.Quantity);
                sb.Append(", " + "subtotal: $" + SubTotal(it.Quantity, it.Price));
                sb.AppendLine();
            }
            sb.Append("Total Price: $" + total());
            return sb.ToString();


        }
    }
}
