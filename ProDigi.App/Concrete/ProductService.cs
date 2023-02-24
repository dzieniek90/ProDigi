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
    public class ProductService : BaseService<Product>
    {
        public void ProductDetailView(int detailId)
        {
            Product productToShow = new Product();
            foreach (var produkt in Items)
            {
                if (produkt.Id == detailId)
                {
                    productToShow = produkt;
                    break;
                }
            }

            Console.WriteLine($"Product id: {productToShow.Id}");
            Console.WriteLine($"Product name: {productToShow.Name}");
            Console.WriteLine($"Product version: {productToShow.Version}");
            Console.WriteLine($"Product designer: {productToShow.Designer}");
        }

        public int ProductDetailSelectionView()
        {
            Console.WriteLine("Please enter id for product you want to show:");
            var productId = Console.ReadKey();
            int id;
            Int32.TryParse(productId.KeyChar.ToString(), out id);

            return id;
        }
        public int ProductToRemoveSelectionView()
        {
            Console.WriteLine("Please enter id for product you want to remove");
            var productId = Console.ReadKey();
            int id;
            Int32.TryParse(productId.KeyChar.ToString(), out id);

            return id;
        }
        public void AllProductsView()
        {
            Console.WriteLine(Items.ToStringTable
                (new[] { "Id", "Name","Version", "Designer" },
                a => a.Id, a => a.Name, a => a.Version, a=>a.Designer));
        }
    }
}
