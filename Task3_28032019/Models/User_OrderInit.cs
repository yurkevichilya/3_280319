using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace Task3_28032019.Models
{
    public class User_OrderInit : DropCreateDatabaseAlways<User_OrderContext>
    {
        protected override void Seed(User_OrderContext db)
        {
            db.UsersOrders.Add(new User_Order { Id_User = 1, Id_Order = 1});
            db.UsersOrders.Add(new User_Order { Id_User = 1, Id_Order = 2 });
            db.UsersOrders.Add(new User_Order { Id_User = 3, Id_Order = 2 });

            base.Seed(db);
        }
    }
}