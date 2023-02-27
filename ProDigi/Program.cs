
using ProDigi.App.Concrete;
using ProDigi.App.Managers;
using ProDigi.Domain.Entity;
using ProDigi.Helpers;

MenuActionService actionService = new MenuActionService();
OrderService orderService = new OrderService();
ProductService productService = new ProductService();
OrderManager orderManager = new OrderManager(orderService);
ProductManager productManager = new ProductManager(productService);
int managerId;
    


Console.WriteLine("Welcome to ProDigi app!");
while (true)
{
    while (true)
    {
        managerId = 0;

        Console.WriteLine("Please select the manager you want to use:");
        var mainMenu = actionService.GetMenuActionsByMenuName("Main");
        for (int i = 0; i < mainMenu.Count; i++)
        {
            Console.WriteLine($"{mainMenu[i].Id}. {mainMenu[i].Name}");
        }

        var operation = Console.ReadKey();

        switch (operation.KeyChar)
        {
            case '1':
                managerId = 1;
                break;
            case '2':
                managerId = 2;
                break;
            default:
                Console.WriteLine("Menager you entered does not exist");
                break;
        }
        if (managerId != 0) break;
    }

    while (true)
    {
        var back = false;

        Console.WriteLine("Please let me know what you want to do:");
        if (managerId == 1)
        {
            var managerMenu = actionService.GetMenuActionsByMenuName("ProductManager");
            for (int i = 0; i < managerMenu.Count; i++)
            {
                Console.WriteLine($"{managerMenu[i].Id}. {managerMenu[i].Name}");
            }

            var operation = Console.ReadKey();

            switch (operation.KeyChar)
            {
                case '1':
                    Console.WriteLine("Please insert name for product:");
                    var name = Console.ReadLine();
                    Console.WriteLine("Please insert version for product:");
                    var version = Console.ReadLine();
                    Console.WriteLine("Please insert designer for product:");
                    var designer = Console.ReadLine();

                    var newId = productManager.AddNewProduct(name, version, designer);
                    Console.WriteLine($"Added new product with id number: {newId}");
                    break;
                case '2':
                    Console.WriteLine("Please enter id for product you want to remove");
                    var removeRead = Console.ReadKey();
                    int removeId;
                    Int32.TryParse(removeRead.KeyChar.ToString(), out removeId);
                    productManager.RemoveProductById(removeId);
                    break;
                case '3':
                    Console.WriteLine("Please enter id for product you want to show:");
                    var showRead= Console.ReadKey();
                    int showId;
                    Int32.TryParse(showRead.KeyChar.ToString(), out showId);

                    var productToShow = productManager.GetProductById(showId);

                    Console.WriteLine($"Product id: {productToShow.Id}");
                    Console.WriteLine($"Product name: {productToShow.Name}");
                    Console.WriteLine($"Product version: {productToShow.Version}");
                    Console.WriteLine($"Product designer: {productToShow.Designer}");

                    break;
                case '4':
                    var allProducts = productManager.GetAllProducts();

                    Console.WriteLine(allProducts.ToStringTable
                    (new[] { "Id", "Name", "Version", "Designer" },
                    a => a.Id, a => a.Name, a => a.Version, a => a.Designer));
                    break;
                case '5':
                    back = true;
                    break;
                default:
                    Console.WriteLine("Action you entered does not exist");
                    break;
            }
        }
        else if (managerId == 2)
        {
            var managerMenu = actionService.GetMenuActionsByMenuName("OrderManager");
            for (int i = 0; i < managerMenu.Count; i++)
            {
                Console.WriteLine($"{managerMenu[i].Id}. {managerMenu[i].Name}");
            }

            var operation = Console.ReadKey();

            switch (operation.KeyChar)
            {
                case '1':
                    var orderTypeMenu = actionService.GetMenuActionsByMenuName("OrderTypeMenu");
                    Console.WriteLine("Please select order type:");
                    for (int i = 0; i < orderTypeMenu.Count; i++)
                    {
                        Console.WriteLine($"{orderTypeMenu[i].Id}. {orderTypeMenu[i].Name}");
                    }
                    var typeRead = Console.ReadKey();
                    int typeId;
                    Int32.TryParse(typeRead.KeyChar.ToString(), out typeId);

                    Console.WriteLine("Please select product ID for order:");
                    for (int i = 0; i < productService.GetAll().Count; i++)
                    {
                        Console.WriteLine($"{productService.Items[i].Id}. {productService.Items[i].Name}");
                    }
                    var productRead = Console.ReadKey();
                    int productId;
                    Int32.TryParse(productRead.KeyChar.ToString(), out productId);
                    Product product = productService.GetById(productId);

                    Console.WriteLine("Please select quantity for order:");
                    var returner3 = Console.ReadLine();
                    int quantity;
                    Int32.TryParse(returner3, out quantity);

                    Console.WriteLine("Please select company for order:");
                    var company = Console.ReadLine();

                    var orderId = orderManager.AddNewOrder(typeId, product, quantity, company);
                    Console.WriteLine($"Added new order with id number:  {orderId}");
                    break;
                case '2':
                    Console.WriteLine("Please enter id for order you want to remove");
                    var orderToRemove = Console.ReadKey();
                    int orderToRemoveId;
                    Int32.TryParse(orderToRemove.KeyChar.ToString(), out orderToRemoveId);

                    orderManager.RemoveOrderById(orderToRemoveId);
                    break;
                case '3':
                    Console.WriteLine("Please enter id for order you want to show:");
                    var orderToShow = Console.ReadKey();
                    int orderToShowId;
                    Int32.TryParse(orderToShow.KeyChar.ToString(), out orderToShowId);

                    var order = orderManager.GetOrderById(orderToShowId);

                    Console.WriteLine($"Order id: {order.Id}");
                    Console.WriteLine($"Order type: {order.Id}");
                    Console.WriteLine($"Poduct name: {order.Produkt.Name}");
                    Console.WriteLine($"Quantity: {order.Quantity}");
                    Console.WriteLine($"Company name: {order.Company}");
                    break;
                case '4':
                    Console.WriteLine("Please enter Id for order type you want to show:");
                    var ordersToShowByType = Console.ReadKey();
                    int ordersToShowByTypeId;
                    Int32.TryParse(ordersToShowByType.KeyChar.ToString(), out ordersToShowByTypeId);

                    List<Order> ordersByType = orderManager.GetOrdersByTypeId(ordersToShowByTypeId);
                    Console.WriteLine(ordersByType.ToStringTable
                    (new[] { "Id", "Name", "Quantity", "Company" },
                    a => a.Id, a => a.Produkt.Name, a => a.Quantity, a => a.Company));
                    break;
                case '5':
                    back = true;
                    break;
                default:
                    Console.WriteLine("Action you entered does not exist");
                    break;
            }
        }
        if (back)break;
    }
}


