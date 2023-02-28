using Newtonsoft.Json;
using ProDigi.App.Common;
using ProDigi.Domain.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProDigi.App.Concrete
{
    public class OrderService : BaseService<Order>
    {
        private const string jsonPatch = @"D:\Programowanie\ProDigi\Orders.txt";
        public void AddProductsToJson()
        {
            using StreamWriter sw = new StreamWriter(jsonPatch);
            using JsonWriter writer = new JsonTextWriter(sw);

            JsonSerializer serializer = new JsonSerializer();
            serializer.Serialize(writer, Items);
        }

        public void GetProductsFromJson()
        {
            string json = File.ReadAllText(jsonPatch);
            Items = JsonConvert.DeserializeObject<List<Order>>(json);
        }
    }
}


