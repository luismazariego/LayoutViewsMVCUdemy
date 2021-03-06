using EFDbFirstApproachExample.Models;

namespace EFDbFirstApproachExample.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EFDbFirstApproachExample.Models.CompanyDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "EFDbFirstApproachExample.Models.CompanyDbContext";
        }

        protected override void Seed(EFDbFirstApproachExample.Models.CompanyDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Brands.AddOrUpdate(new Brand(){BrandID = 1, BrandName = "Sony"}, new Brand(){BrandID = 2, BrandName = "Samsung"});
            context.Categories.AddOrUpdate(new Category(){CategoryID = 1, CategoryName = "Electronics"}, new Category(){CategoryID = 2, CategoryName = "Home Appliances"});
            context.Products.AddOrUpdate(new Product(){ProductID = 1, ProductName = "Mouse", CategoryID = 1, BrandID = 1, Price = 800, Active = true, AvailabilityStatus = "InStock", DOP = DateTime.Now});
        }
    }
}
