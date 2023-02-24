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
            AddItem(new MenuAction(1, "Products manager", "Main"));
            AddItem(new MenuAction(2, "Orders manager", "Main"));

            AddItem(new MenuAction(1, "Add product", "ProductManager"));
            AddItem(new MenuAction(2, "Remove product", "ProductManager"));
            AddItem(new MenuAction(3, "Show product details", "ProductManager"));
            AddItem(new MenuAction(4, "List of all products", "ProductManager"));
            AddItem(new MenuAction(5, "Back", "ProductManager"));

            AddItem(new MenuAction(1, "Add order", "OrderManager"));
            AddItem(new MenuAction(2, "Remove order", "OrderManager"));
            AddItem(new MenuAction(3, "Show order details", "OrderManager"));
            AddItem(new MenuAction(4, "List of orders by order type", "OrderManager"));
            AddItem(new MenuAction(5, "Back", "OrderManager"));

            AddItem(new MenuAction(1, "Production", "OrderTypeMenu"));
            AddItem(new MenuAction(2, "Service", "OrderTypeMenu"));
            AddItem(new MenuAction(3, "Complaint", "OrderTypeMenu"));
        }
    }
}
