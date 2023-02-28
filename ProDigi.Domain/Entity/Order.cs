using ProDigi.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProDigi.Domain.Entity
{
    public class Order : BaseEntity
    {
        public Order()
        {

        }
        public Order(int id, int orderTypeId, Product produkt, int quantity, string company, OrderStatusType status)
        {
            Id = id;
            Produkt = produkt;
            Company = company;
            Quantity = quantity;
            OrderTypeId = orderTypeId;
            Status = status;
        }

        public int OrderTypeId { get; set; }
        public Product Produkt { get; set; }
        public int Quantity { get; set; }
        public string Company { get; set; }
        public OrderStatusType Status { get; set; }

    }
}
