using ProDigi.App.Common;
using ProDigi.Domain.Entity;
using ProDigi.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProDigi.App.Concrete
{
    public class OrderService : BaseService<Order>
    {
        public void OrderByTypeIdView(int typeId)
        {
            List<Order> toShow = new List<Order>();
            foreach (var order in Items)
            {
                if (order.OrderTypeId == typeId)
                {
                    toShow.Add(order);
                }
            }

            Console.WriteLine(toShow.ToStringTable
                (new[] { "Id", "Name","Quantity","Company" }, 
                a => a.Id, a => a.Produkt.Name, a=> a.Quantity, a=>a.Company));
        }

        public int OrderTypeSelectionView()
        {
            Console.WriteLine("Please enter Id for order type you want to show:");
            var orderId = Console.ReadKey();
            int id;
            Int32.TryParse(orderId.KeyChar.ToString(), out id);

            return id;
        }

        public void OrderDetailView(int detailId)
        {
            Order orderToShow = new Order();
            foreach (var order in Items)
            {
                if (order.Id == detailId)
                {
                    orderToShow = order;
                    break;
                }
            }

            Console.WriteLine($"Order id: {orderToShow.Id}");
            Console.WriteLine($"Order type: {orderToShow.Id}");
            Console.WriteLine($"Poduct name: {orderToShow.Produkt.Name}");
            Console.WriteLine($"Quantity: {orderToShow.Quantity}");
            Console.WriteLine($"Company name: {orderToShow.Company}");
        }

        public int OrderDetailSelectionView()
        {
            Console.WriteLine("Please enter id for order you want to show:");
            var orderId = Console.ReadKey();
            int id;
            Int32.TryParse(orderId.KeyChar.ToString(), out id);

            return id;
        }
        public int OrderToRemoveSelectionView()
        {
            Console.WriteLine("Please enter id for order you want to remove");
            var orderId = Console.ReadKey();
            int id;
            Int32.TryParse(orderId.KeyChar.ToString(), out id);

            return id;
        }
    }
}

