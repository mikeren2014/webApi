using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SportsStore.Models
{
    public class Order
    {
        [HttpBindNever]
        public int Id { get; set; }

        [Required]
        public string Customer { get; set; }

        [Required]
        [HttpBindNever]
        public decimal TotalCost { get; set; }

        public virtual ICollection<OrderLine> Lines { get; set; }
    }
}