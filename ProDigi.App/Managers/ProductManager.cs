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
    public class ProductManager
    {
        private readonly MenuActionService _actionService;
        private IService<Product> _productService;
        public ProductManager(MenuActionService actionService, IService<Product> productService)
        {
            _productService = productService;
            _actionService = actionService;
            Initialize();
        }

        private void Initialize()
        {
            _productService.Add(new Product(1,"Testowy","1.0","Pan Jan"));
        }
        public int AddNewProduct()
        {
            Console.WriteLine("Please insert name for product:");
            var name = Console.ReadLine();
            Console.WriteLine("Please insert version for product:");
            var version = Console.ReadLine();
            Console.WriteLine("Please insert designer for product:");
            var designer = Console.ReadLine();

            var lastId = _productService.GetLastId();
            Product product = new Product(lastId + 1, name, version, designer);
            _productService.Add(product);
            return product.Id;
        }

        public void RemoveProductById(int id)
        {
            var product = _productService.GetById(id);
            _productService.Remove(product);
        }

        public Product GetProductById(int id)
        {
            var product = _productService.GetById(id);
            return product;
        }
    }
}
