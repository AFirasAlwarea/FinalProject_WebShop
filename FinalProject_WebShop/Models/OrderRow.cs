using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalProject_WebShop.Models
{
    public class OrderRow
    {
        [Key]
        public int Id { get; set; }
        public Order OrderId { get; set; }
        public Product ProductId { get; set; }
        
    }
}