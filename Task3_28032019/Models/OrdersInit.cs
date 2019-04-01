using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Task3_28032019.Models
{
    public class OrdersInit : DropCreateDatabaseAlways<OrderContext>
    {
        protected override void Seed(OrderContext db)
        {
            db.Orders.Add(new Order { Name = "firstord", Id = 1, Bdate = Convert.ToDateTime("20/03/2019")});
            db.Orders.Add(new Order { Name = "second", Id = 2, Bdate = Convert.ToDateTime("20 / 03 / 2019") });
            db.Orders.Add(new Order { Name = "third",  Id = 3,  Bdate = Convert.ToDateTime("20 / 03 / 2019") });

            db.Products.Add(new Product { Name = "Shoes", Price = 67, Id = 3 });
            db.Products.Add(new Product { Name = "Trousers", Price = 13, Id = 1 });
            db.Products.Add(new Product { Name = "Eggs", Price = 32, Id = 2 });

            db.Users.Add(new User { Name = "Tony", Email = "tony@gmail.com", Id = 1 });
            db.Users.Add(new User { Name = "Steu", Email = "steu@gmail.com", Id = 2 });
            db.Users.Add(new User { Name = "Barbara", Email = "barbara@gmail.com", Id = 3 });

            db.UsersOrders.Add(new User_Order { Id_User = 1, Id_Order = 1 });
            db.UsersOrders.Add(new User_Order { Id_User = 1, Id_Order = 2 });
            db.UsersOrders.Add(new User_Order { Id_User = 3, Id_Order = 2 });

            db.ProductOrder.Add(new ProductOrder { Id_Product = 1, Id_Order = 1 , Quantity =1});
            db.ProductOrder.Add(new ProductOrder { Id_Product = 1, Id_Order = 2, Quantity = 12});
            db.ProductOrder.Add(new ProductOrder { Id_Product = 3, Id_Order = 2, Quantity = 11 });

            base.Seed(db);
        }
    }
}