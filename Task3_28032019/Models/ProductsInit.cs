using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Task3_28032019.Models
{
    public class ProductsInit : DropCreateDatabaseAlways<OrderContext>
    {
        protected override void Seed(OrderContext db)
        {
            db.Products.Add(new Product { Name = "Trousers", Price = 13, Id = 1 });
            db.Products.Add(new Product { Name = "Eggs", Price = 32, Id = 2 });
            db.Products.Add(new Product { Name = "Shoes", Price = 67, Id = 3 });

            base.Seed(db);
        }
    }
}