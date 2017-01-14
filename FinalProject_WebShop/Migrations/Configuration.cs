namespace FinalProject_WebShop.Migrations
{
    using Lexicon.CSharp.InfoGenerator;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FinalProject_WebShop.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(FinalProject_WebShop.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            #region Declaring variables
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            InfoGenerator random = new InfoGenerator(DateTime.Now.Ticks.GetHashCode());
            #endregion

            #region Creating THREE roles Admin, Buyer, Seller
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                roleManager.Create(new IdentityRole { Name = "Admin" });
            }

            if (!context.Roles.Any(r => r.Name == "Buyer"))
            {
                roleManager.Create(new IdentityRole { Name = "Buyer" });
            }

            if (!context.Roles.Any(r => r.Name == "Seller"))
            {
                roleManager.Create(new IdentityRole { Name = "Seller" });
            }
            #endregion

            #region Seeding Three testing users: Admin"firas", Buyer"khaled", Seller"kindah"
            if (!context.Users.Any(u => u.UserName == "firas.wira@gmail.com"))
            {
                var user = new ApplicationUser
                {
                    UserName = "firas.wira@gmail.com",
                    Email = "firas.wira@gmail.com",
                    FirstName = "Firas",
                    LastName = "Wira",
                    Gender = "Male",
                    Seller = true,
                    BirthDate = Convert.ToDateTime("25/05/1978"),
                    Telephone = "+46 762 62 287",
                    StreetAddress = "Nergårdsvägen 2B",
                    PostalCode = 56030,
                    City = "Tenhult",
                    Country = "Sweden"
                };

                userManager.Create(user, "654321");
                userManager.AddToRole(user.Id, "Admin");
            }

            if (!context.Users.Any(u => u.UserName == "khaled.wira@gmail.com"))
            {
                var user = new ApplicationUser
                {
                    UserName = "khaled.wira@gmail.com",
                    Email = "khaled.wira@gmail.com",
                    FirstName = "Khaled",
                    LastName = "Wira",
                    Gender = "Male",
                    Seller = false,
                    BirthDate = Convert.ToDateTime("15/04/2007"),
                    Telephone = "+46 733 55 222",
                    StreetAddress = "Nergårdsvägen 2B",
                    PostalCode = 56030,
                    City = "Tenhult",
                    Country = "Sweden"
                };

                userManager.Create(user, "1234567");
                userManager.AddToRole(user.Id, "Buyer");
            }

            if (!context.Users.Any(u => u.UserName == "kindah.alazem@gmail.com"))
            {
                var user = new ApplicationUser
                {
                    UserName = "kindah.alazem@gmail.com",
                    Email = "kindah.alazem@gmail.com",
                    FirstName = "Kindah",
                    LastName = "Alazem",
                    Gender = "Female",
                    Seller = true,
                    BirthDate = Convert.ToDateTime("31/03/1991"),
                    Telephone = "+971 50 263 7404",
                    StreetAddress = "Zayed The First Street",
                    PostalCode = 56030,
                    City = "Abu Dhabi",
                    Country = "United Arab Emirates"
                };

                userManager.Create(user, "1234567");
                userManager.AddToRole(user.Id, "Seller");
            }
            #endregion

            /*#region Adding random 50 Buyers
            for (int i = 0; i < 50; i++)
            {
                string byerFirstName = random.NextFirstName();
                string byerLastName = random.NextLastName();
                string byerEmail = byerFirstName + "." + byerLastName + "@gmail.com";

                string sex = "Male";
                if (i % 2 == 0)
                {
                    sex = "Femail";
                }
                else
                {
                    sex = "Male";
                }

                if (!context.Users.Any(u => u.UserName == byerEmail))
                {
                    var user = new ApplicationUser
                    {
                        UserName = byerEmail,
                        Email = byerEmail,
                        FirstName = byerFirstName,
                        LastName = byerLastName,
                        Gender = sex,
                        Seller = false,
                        BirthDate = random.NextDate(),
                        Telephone = "+46 722 33 " + Convert.ToString(i),
                        StreetAddress = random.NextStreet(),
                        PostalCode = 55400 + i,
                        City = random.NextCity(),
                        Country = random.NextCountry()
                    };

                    userManager.Create(user, "123456");
                    userManager.AddToRole(user.Id, "Buyer");
                }
            }
            #endregion


            #region Adding random 50 Sellers
            for (int i = 0; i < 50; i++)
            {
                var sellerFirstName = random.NextFirstName();
                var sellerLastName = random.NextLastName();
                var sellerEmail = sellerFirstName + "." + sellerLastName + "@gmail.com";

                string sex = "Male";
                if (i % 2 == 0)
                {
                    sex = "Femail";
                }
                else
                {
                    sex = "Male";
                }

                if (!context.Users.Any(u => u.UserName == sellerEmail))
                {
                    var user = new ApplicationUser
                    {
                        UserName = sellerEmail,
                        Email = sellerEmail,
                        FirstName = sellerFirstName,
                        LastName = sellerLastName,
                        Gender = sex,
                        Seller = false,
                        BirthDate = random.NextDate(),
                        Telephone = "+46 722 33 " + Convert.ToString(i),
                        StreetAddress = random.NextStreet(),
                        PostalCode = 39500 + i,
                        City = random.NextCity(),
                        Country = random.NextCountry()
                    };

                    userManager.Create(user, "123456");
                    userManager.AddToRole(user.Id, "Seller");
                }
            }
            #endregion*/

            #region Adding 10 Products
            var seller = context.Users.Where(s => s.Email == "kindah.alazem@gmail.com").FirstOrDefault();
            context.Product.AddOrUpdate(P => P.Name,
               new Product
               {
                   Name = "Diamnond Ring",
                   Description = "24 karat gold ring studded with diamonds Italian design",
                   Inventory = 50,
                   Price = 1500,
                   Availability = true,
                   Seller = seller,
                   SellerId = seller.Id,
                   Photo_URL = "http://img.bluenile.com/is/image/bluenile/-luna-seven-stone-diamond-ring-platinum-/AB30500600_profile?$v2_catprod_lrg$"
               });
            #endregion



        }
    }
}
