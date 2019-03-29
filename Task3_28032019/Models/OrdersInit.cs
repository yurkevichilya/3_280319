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
            db.Orders.Add(new Order { Name = "firstord", Quantity = 3, Id = 1, Id_Product =1,Bdate = Convert.ToDateTime("20/03/2019")});
            db.Orders.Add(new Order { Name = "second", Quantity = 4, Id = 2, Id_Product = 1, Bdate = Convert.ToDateTime("20 / 03 / 2019") });
            db.Orders.Add(new Order { Name = "third", Quantity = 2, Id = 3, Id_Product = 2, Bdate = Convert.ToDateTime("20 / 03 / 2019") });

            base.Seed(db);
        }
    }
}