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
 
        private IService<Product> _productService;
        public ProductManager(IService<Product> productService)
        {
            _productService = productService;

            Initialize();
        }

        private void Initialize()
        {
            ((ProductService) _productService).GetProductsFromXml();
        }
        public int AddNewProduct(string name, string version, string designer)
        {
            var lastId = _productService.GetLastId();
            Product product = new Product(lastId + 1, name, version, designer);
            _productService.Add(product);
            ((ProductService)_productService).AddProductsToXml();
            return product.Id;
        }

        public void RemoveProductById(int id)
        {
            var product = _productService.GetById(id);
            _productService.Remove(product);
            ((ProductService)_productService).AddProductsToXml();
        }

        public Product GetProductById(int id)
        {
            var product = _productService.GetById(id);
            return product;
        }

        public List<Product> GetAllProducts()
        {
            var allProducts = _productService.GetAll();
            return allProducts;
        }
        public void GenerateRaport()
        {
            var fileName = "Products Report";
            var filePatch = @"D:\Programowanie\ProDigi";
            using FileStream fs = File.OpenWrite(@$"{filePatch}\{fileName}.csv");
            using StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine("Id, Name, Version, Designer");

            foreach (var item in _productService.Items)
            {
                sw.WriteLine($"{item.Id},{item.Name},{item.Version},{item.Designer}");
            }
        }
    }
}
