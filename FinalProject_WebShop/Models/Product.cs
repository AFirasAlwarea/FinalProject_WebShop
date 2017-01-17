using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FinalProject_WebShop.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
        [Range(1, 10e6)]
        public decimal Price { get; set; }
        [Range(1,1000)]
        public int Inventory { get; set; }
        public bool Availability { get; set; }
        [DisplayName("Seller")]
        public string SellerId { get; set; }
        [DisplayName("Seller")]
        public virtual ApplicationUser Seller { get; set; }
        [DisplayName("Photo")]
        public string Photo_URL { get; set; }
        public virtual List<OrderRow> OrderRow { get; set; }
        public Cart Cart { get; set; }
    }
}