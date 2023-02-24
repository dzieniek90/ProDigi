using ProDigi.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProDigi.Domain.Entity
{
    public class Product : BaseEntity
    {
        public Product()
        {

        }
        public Product(int id, string name, string version, string designer)
        {
            Id = id;
            Name = name;
            Version = version;
            Designer = designer;
        }

        public string Name { get; set; }
        public string Version { get; set; }
        public string Designer { get; set; }
    }
}
