using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SportsStore.Models
{
    public class OrderLine
    {
        [HttpBindNever]
        public int Id { get; set; }

        [Required]
        [Range(1,100)]
        public int Count { get; set; }

        [Required]
        public int ProductId { get; set; }

        [HttpBindNever]
        public int OrderId { get; set; }

        [HttpBindNever]
        public virtual Product Product { get; set; }

        [HttpBindNever]
        public virtual Order Order { get; set; }
    }
}