using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace FinalProject_WebShop.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        public string Gender { get; set; }
        [Required]
        [DisplayName("Telephone No.")]
        public string Telephone { get; set; }
        [Required]
        [StringLength(100)]
        [DisplayName("Street Address")]
        public string StreetAddress { get; set; }
        [Required]
        [StringLength(50)]
        public string City { get; set; }
        [DisplayName("Postal Code")]
        [Range(11111,99999)]
        public int? PostalCode { get; set; }
        [Required]
        public string Country { get; set; }
        [Display(Name ="Birth Date")]
        public DateTime? BirthDate { get; set; }
        public virtual List<Order> OrdersList { get; set; }
        public bool Seller { get; set; }
        public virtual List<Product> ProductsList { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Order> Order { get; set; }
        public DbSet<OrderRow> OrderRow { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Cart> Cart { get; set; }

        //public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    }
}