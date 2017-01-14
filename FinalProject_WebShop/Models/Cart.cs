using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinalProject_WebShop.Models
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="Customer")]
        public int CustomerId { get; set; }
        public ApplicationUser Customer { get; set; }
        public virtual List<Product> ProductsList { get; set; }
    }
}