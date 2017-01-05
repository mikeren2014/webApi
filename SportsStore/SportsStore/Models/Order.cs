using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsStore.Models
{
    public class Order
    {
        public int Id { get; set; }

        public string Customer { get; set; }

        public decimal TotalCost { get; set; }

        public virtual ICollection<OrderLine> Lines { get; set; }
    }
}