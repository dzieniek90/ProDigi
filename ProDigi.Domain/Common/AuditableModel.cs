using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProDigi.Domain.Common
{
    public abstract class AuditableModel
    {
        [XmlIgnore]
        public int CreatedById { get; set; }
        [XmlIgnore]
        public DateTime CreatedDateTime { get; set; }
        [XmlIgnore]
        public int? ModifiedById { get; set; }
        [XmlIgnore]
        public DateTime? ModifiedDateTime { get; set; }
    }
}
