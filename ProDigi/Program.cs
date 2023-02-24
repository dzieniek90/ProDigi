
using ProDigi.App.Concrete;
using ProDigi.App.Managers;
using ProDigi.Domain.Entity;

MenuActionService actionService = new MenuActionService();
OrderService orderService = new OrderService();
ProductService productService = new ProductService();
OrderManager orderManager = new OrderManager(actionService, orderService, productService);
ProductManager productManager = new ProductManager(actionService,productService);
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
                    var newId = productManager.AddNewProduct();
                    break;
                case '2':
                    var removeId = productService.ProductToRemoveSelectionView();
                    productManager.RemoveProductById(removeId);
                    break;
                case '3':
                    var detailId = productService.ProductDetailSelectionView();
                    productService.ProductDetailView(detailId);
                    break;
                case '4':
                    productService.AllProductsView();
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
                    var newId = orderManager.AddNewOrder();
                    break;
                case '2':
                    var removeId = orderService.OrderToRemoveSelectionView();
                    orderManager.RemoveOrderById(removeId);
                    break;
                case '3':
                    var detailId = orderService.OrderDetailSelectionView();
                    orderService.OrderDetailView(detailId);
                    break;
                case '4':
                    var orderTypeId = orderService.OrderTypeSelectionView();
                    orderService.OrderByTypeIdView(orderTypeId);
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

