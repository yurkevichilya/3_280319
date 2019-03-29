using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Task3_28032019.Models
{
    public class User_OrderContext : DbContext
{
    public DbSet<User_Order> UsersOrders { get; set; }
}
}