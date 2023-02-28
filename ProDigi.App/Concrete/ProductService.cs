using ProDigi.App.Common;
using ProDigi.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace ProDigi.App.Concrete
{
    public class ProductService : BaseService<Product>
    {
        private const string xmlPatch = @"D:\Programowanie\ProDigi\Products.xml";
        public void AddProductsToXml()
        {
            XmlRootAttribute root = new XmlRootAttribute();
            root.ElementName = "Products";
            root.IsNullable = true;
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Product>), root);

            using StreamWriter sw = new StreamWriter(xmlPatch);
            xmlSerializer.Serialize(sw, Items);
        }

        public void GetProductsFromXml()
        {
            XmlRootAttribute root = new XmlRootAttribute();
            root.ElementName = "Products";
            root.IsNullable = true;
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Product>), root);

            string xml = File.ReadAllText(xmlPatch);
            StringReader stringReader = new StringReader(xml);
            Items = (List<Product>)xmlSerializer.Deserialize(stringReader);
        }
    }
}
