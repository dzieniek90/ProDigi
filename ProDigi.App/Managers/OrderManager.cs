using ProDigi.App.Abstract;
using ProDigi.App.Concrete;
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
        }
        public int AddNewOrder(int typeId, Product product, int quantity, string company)
        {
            var lastId = _orderService.GetLastId();
            Order order = new Order(lastId + 1, typeId, product, quantity, company);
            _orderService.Add(order);
            return order.Id;
        }

        public void RemoveOrderById(int id)
        {
            var order = _orderService.GetById(id);
            _orderService.Remove(order);
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
    }
}
