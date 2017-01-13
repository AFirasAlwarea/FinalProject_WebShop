using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FinalProject_WebShop.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Date of Order")]
        public DateTime OrderDate { get; set; }
        public int CustomerId { get; set; }
        public List<Product> ProductsList { get; set; }
    }
}