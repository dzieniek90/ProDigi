using ProDigi.App.Abstract;
using ProDigi.App.Concrete;
using ProDigi.Domain.Common;
using ProDigi.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProDigi.App.Managers
{
    public class OrderManager
    {
        private IService<Order> _orderService;
        public OrderManager(IService<Order> orderService)
        {
            _orderService = orderService;
            ((OrderService)_orderService).GetProductsFromJson();
        }
        public int AddNewOrder(int typeId, Product product, int quantity, string company)
        {
            var lastId = _orderService.GetLastId();
            Order order = new Order(lastId + 1, typeId, product, quantity, company, OrderStatusType.Ordered);
            _orderService.Add(order);
            ((OrderService)_orderService).AddProductsToJson();
            return order.Id;
        }

        public void RemoveOrderById(int id)
        {
            var order = _orderService.GetById(id);
            _orderService.Remove(order);
            ((OrderService)_orderService).AddProductsToJson();
        }

        public Order GetOrderById(int id)
        {
            var item = _orderService.GetById(id);
            return item;
        }

        public List<Order> GetOrdersByTypeId(int typeId)
        {
            List<Order> toShow = new List<Order>();
            foreach (var order in _orderService.Items)
            {
                if (order.OrderTypeId == typeId)
                {
                    toShow.Add(order);
                }
            }
            return toShow;
        }
        public void GenerateRaport()
        {
            var fileName = "Orders Report";
            var filePatch = "D:\\Programowanie\\ProDigi";
            using FileStream fs = File.OpenWrite($"{filePatch}\\{fileName}.csv");
            using StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine("Id, Order type id, Product name, Quantity, Status id");
            foreach (var item in _orderService.Items)
            {
                sw.WriteLine($"{item.Id},{item.OrderTypeId},{item.Produkt.Name},{item.Quantity},{item.Status}");
            }
        }
    }
}
