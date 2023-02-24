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
        private readonly MenuActionService _actionService;
        private IService<Order> _orderService;
        private IService<Product> _productService;
        public OrderManager(MenuActionService actionService, IService<Order> orderService, IService<Product> productService)
        {
            _orderService = orderService;
            _actionService = actionService;
            _productService = productService;

        }
        public int AddNewOrder()
        {
            var orderTypeMenu = _actionService.GetMenuActionsByMenuName("OrderTypeMenu");
            Console.WriteLine("Please select order type:");
            for (int i = 0; i < orderTypeMenu.Count; i++)
            {
                Console.WriteLine($"{orderTypeMenu[i].Id}. {orderTypeMenu[i].Name}");
            }
            var returner = Console.ReadKey();
            int typeId;
            Int32.TryParse(returner.KeyChar.ToString(), out typeId);

            Console.WriteLine("Please select product for order:");
            for (int i = 0; i < _productService.GetAllItems().Count; i++)
            {
                Console.WriteLine($"{_productService.Items[i].Id}. {_productService.Items[i].Name}");
            }
            var returner2 = Console.ReadKey();
            int productId;
            Int32.TryParse(returner2.KeyChar.ToString(), out productId);
            Product product= _productService.GetItemById(productId);

            Console.WriteLine("Please select quantity for order:");
            var returner3 = Console.ReadLine();
            int quantity; 
            Int32.TryParse(returner3, out quantity);

            Console.WriteLine("Please select company for order:");
            var company = Console.ReadLine();

            var lastId = _orderService.GetLastId();
            Order order = new Order(lastId + 1, typeId, product, quantity, company);
            _orderService.AddItem(order);
            return order.Id;
        }

        public void RemoveOrderById(int id)
        {
            var order = _orderService.GetItemById(id);
            _orderService.RemoveItem(order);
        }

        public Order GetOrderById(int id)
        {
            var item = _orderService.GetItemById(id);
            return item;
        }
    }
}
