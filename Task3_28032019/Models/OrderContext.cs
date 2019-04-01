using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Task3_28032019.Models
{
    public class OrderContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder builder)
        {
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<User_Order> UsersOrders { get; set; }
        public DbSet<ProductOrder> ProductOrder { get; set; }
    }
}