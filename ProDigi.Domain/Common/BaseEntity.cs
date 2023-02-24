using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProDigi.Domain.Common
{
    public abstract class BaseEntity : AuditableModel
    {
        [XmlAttribute("Id")]
        public int Id { get; set; }
    }
}
