using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using exercicio_enumeracao_composicao.Entitites.Enums;

namespace exercicio_enumeracao_composicao.Entitites
{
    class Order
    {
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }
        public Client Client { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();

        public Order()
        {

        }

        public Order(DateTime moment, OrderStatus status, Client client)
        {
            Moment = moment;
            Status = status;
            Client = client;
        }

        public void addItem(OrderItem item)
        {
            Items.Add(item);
        }

        public void removeItem(OrderItem item)
        {
            Items.Remove(item);
        }

        public double total()
        {
            double totalItem = 0.0;
            foreach (OrderItem item in Items)
            {
                totalItem += item.subTotal();
            }
            return totalItem;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            
            sb.AppendLine("Order moment: " + Moment.ToString("dd/MM/yyyy HH:mm:ss"));
            sb.AppendLine("Order status: " + Status);
            sb.AppendLine($"Client: {Client.Name} ({Client.birthDate.ToShortDateString()}) - {Client.Email}");
            sb.AppendLine("Order items: ");
            foreach (OrderItem item in Items)
            {
               sb.AppendLine(item.ToString());
            }
            return sb.ToString();
        }
    }
}
