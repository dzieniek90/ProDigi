using ProDigi.App.Common;
using ProDigi.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProDigi.App.Concrete
{
    public class MenuActionService : BaseService<MenuAction>
    {
        public MenuActionService() 
        {
            Initialize();
        }
        public List<MenuAction> GetMenuActionsByMenuName(string menuName)
        {
            List<MenuAction> result = new List<MenuAction>();
            foreach (var menuAction in Items)
            {
                if (menuAction.MenuName == menuName)
                {
                    result.Add(menuAction);
                }
            }
            return result;
        }

        private void Initialize()
        {
            Add(new MenuAction(1, "Products manager", "Main"));
            Add(new MenuAction(2, "Orders manager", "Main"));

            Add(new MenuAction(1, "Add product", "ProductManager"));
            Add(new MenuAction(2, "Remove product", "ProductManager"));
            Add(new MenuAction(3, "Show product details", "ProductManager"));
            Add(new MenuAction(4, "List of all products", "ProductManager"));
            Add(new MenuAction(5, "Back", "ProductManager"));

            Add(new MenuAction(1, "Add order", "OrderManager"));
            Add(new MenuAction(2, "Remove order", "OrderManager"));
            Add(new MenuAction(3, "Show order details", "OrderManager"));
            Add(new MenuAction(4, "List of orders by order type", "OrderManager"));
            Add(new MenuAction(5, "Back", "OrderManager"));

            Add(new MenuAction(1, "Production", "OrderTypeMenu"));
            Add(new MenuAction(2, "Service", "OrderTypeMenu"));
            Add(new MenuAction(3, "Complaint", "OrderTypeMenu"));
        }
    }
}
