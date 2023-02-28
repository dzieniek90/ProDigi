using ProDigi.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

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
        [XmlElement("Name")]
        public string Name { get; set; }
        [XmlElement("Version")]
        public string Version { get; set; }
        [XmlElement("Designer")]
        public string Designer { get; set; }
    }
}
