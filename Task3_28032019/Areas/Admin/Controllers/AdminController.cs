using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task3_28032019.Controllers;
using Task3_28032019.Areas.Admin;
using Task3_28032019.Models;
using Task3_28032019.Areas.Admin.Controllers;

namespace Task3_28032019.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        OrderContext DBOrders = new OrderContext();
        // GET: Admin/Admin
        public ActionResult Index()
        {
            OrderContext DBOrders = (OrderContext)(HttpContext.Application["DBOrders"]);
            return View();
        }

        public ActionResult Products()
        {
            IEnumerable<Product> products = DBOrders.Products;
            ViewBag.Products = products;
            return View();
        }
        public ActionResult Users()
        {
            IEnumerable<User> users = DBOrders.Users;
            ViewBag.Users = users;
            return View();
        }

    }
}