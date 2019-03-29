using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace Task3_28032019.Models
{
    public class UsersContext : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}