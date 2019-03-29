using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Task3_28032019.Models
{
    public class UsersInit : DropCreateDatabaseAlways<UsersContext>
    {
        protected override void Seed(UsersContext db)
        {
            db.Users.Add(new User { Name = "Tony", Email = "tony@gmail.com", Id = 1 });
            db.Users.Add(new User { Name = "Steu", Email = "steu@gmail.com", Id = 2 });
            db.Users.Add(new User { Name = "Barbara", Email = "barbara@gmail.com",Id = 3 });

            base.Seed(db);
        }
    }
}