using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-TRD3SPE;Database=WareHouse1;integrated security=True;TrustServerCertificate=True");
        }
        public DbSet<User> Users { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<Product>  Products { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<WareHouse> WareHouses { get; set; }
        public DbSet<Costumer>  Costumers { get; set; }
        public DbSet<Order>   Orders { get; set; }
        public DbSet<OrderItem>    OrderItems { get; set; }

    }
}
