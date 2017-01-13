using System.Collections.Generic;

namespace FinalProject_WebShop.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Inventory { get; set; }
        public bool Availability { get; set; }
        public int SellerId { get; set; }
        public string Photo_URL { get; set; }
        public virtual List<Order> OrdersList { get; set; }
        public Cart Cart { get; set; }
    }
}