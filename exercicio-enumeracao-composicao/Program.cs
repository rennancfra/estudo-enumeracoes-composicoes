using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using exercicio_enumeracao_composicao.Entitites;
using exercicio_enumeracao_composicao.Entitites.Enums;

namespace exercicio_enumeracao_composicao
{
    class Program
    {
        static void Main(string[] args)
        {
            //PARTE CLIENTE
            Console.WriteLine("Enter cliente data");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Birth date (DD/MM/YYYY): ");
            DateTime bdate = DateTime.Parse(Console.ReadLine());
            Client c = new Client(name, email, bdate);
            
            //PARTE ORDER-ORDERSTATUS
            Console.WriteLine("Enter order data: ");
            Console.Write("Status: ");
            OrderStatus status = (OrderStatus)Enum.Parse(typeof(OrderStatus), Console.ReadLine());
            Console.Write("How many items to this order? ");
            int quantProdutos = int.Parse(Console.ReadLine());
            Order order = new Order(DateTime.Now, status, c);
            for (int i = 1; i <= quantProdutos; i++)
            {
                Console.WriteLine($"Enter #{i} item data: ");
                Console.Write("Product name: ");
                string nameP = Console.ReadLine();
                Console.Write("Product price: ");
                double priceP = double.Parse(Console.ReadLine());
                Console.Write("Quantity: ");
                int quantityP = int.Parse(Console.ReadLine());

                Product prod = new Product(nameP, priceP);
                OrderItem orderItem = new OrderItem(quantityP, priceP, prod); 
                order.addItem(orderItem);
            }

            Console.WriteLine("ORDER SUMMARY: ");
            Console.WriteLine(order.ToString());
            Console.WriteLine("Total price: $" + order.total().ToString());
            Console.ReadKey();


        }
    }
}
