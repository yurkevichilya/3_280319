using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task3_28032019.Models;

namespace Task3_28032019.Controllers
{
    public class HomeController : Controller
    {
        UsersContext DBUsers = new UsersContext();
        ProductContext DBProducts = new ProductContext();
        OrderContext DBOrders = new OrderContext();
        User_OrderContext DBUsPrKey = new User_OrderContext(); 

        public ActionResult Index()
        {
        
            return View();
        }
        [HttpGet]
        public ActionResult Period()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Period(Period period)
        {
            DateTime first = period.firstDate;
            DateTime second = period.secondDate;
            IEnumerable<Order> orders = DBOrders.Orders;
            List<Order> periodorders = new  List<Order>();
            foreach (Order order in orders) {
                if (order.Bdate > first && order.Bdate < second) {
                    periodorders.Add(order);
                }
            }

            ViewBag.Orders = periodorders;
            return View("Orders");
        }
        public ActionResult Users()
        {
            IEnumerable<User> users = DBUsers.Users;
            ViewBag.Users = users;
            return View();
        }
        [HttpGet]
        public ActionResult AddUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddUser(User user)
        {
            DBUsers.Users.Add(user);
            DBUsers.SaveChanges();

            IEnumerable<User> users = DBUsers.Users;
            ViewBag.Users = users;
            return View("Users");
        }
        [HttpGet]
        public ActionResult ChangeUser(int id)
        {
            User currentUser = new User();
            currentUser = FindByIdUser(id, DBUsers.Users);
            ViewBag.Id = currentUser.Id;
            ViewBag.Name = currentUser.Name;
            ViewBag.Email = currentUser.Email;
            return View();
        }
        [HttpPost]
        public ActionResult ChangeUser(User user)
        {
            var changeUser = DBUsers.Users.SingleOrDefault(b => b.Id == user.Id);
            changeUser.Name = user.Name;
            changeUser.Email = user.Email;
            DBUsers.SaveChanges();
            IEnumerable<User> users = DBUsers.Users;
            ViewBag.Users = users;
            return View("Users");
        }
        private User FindByIdUser(int id, IEnumerable<User> users)
        {
            User searchUser = new User();
            foreach (User user in users)
            {
                if (user.Id == id)
                {
                    searchUser = user;
                }
            }
            return searchUser;
        }
        public ActionResult UserInfo()
        {
            int userID = 1;//input any user id as y want
            int userAllPrice = 0;

            IEnumerable<User_Order> users_orders = DBUsPrKey.UsersOrders;
            IEnumerable<Order> orders = DBOrders.Orders;
            IEnumerable<Product> products = DBProducts.Productss;

            //create an one user list of orders
            List<User_Order> user_orders = new List<User_Order>();
            foreach (User_Order us in users_orders) {
                if (us.Id_User == userID) {
                    user_orders.Add(us);
                }
            }

            List<Order> orderss = new List<Order>();
            foreach (User_Order us1 in user_orders) {
                foreach (Order or in orders) {
                    if (us1.Id_Order == or.Id) {
                        orderss.Add(or);
                    }
                }   
            }

            foreach (Order or in orderss) {
                foreach (Product pr in products) {
                    if (or.Id_Product == pr.Id) {
                        userAllPrice = userAllPrice + or.Quantity * pr.Price;
                    }
                }
            }
            return View();
        }
        public ActionResult Products()
        {
            IEnumerable<Product> products = DBProducts.Productss;
            ViewBag.Products = products;
            return View();
        }
        [HttpGet]
        public ActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(Product product)
        {
            DBProducts.Productss.Add(product);
            DBProducts.SaveChanges();

            IEnumerable<Product> products = DBProducts.Productss;
            ViewBag.Products = products;
            return View("Products");
        }

        public ActionResult Orders()
        {
            IEnumerable<Order> orders = DBOrders.Orders;
            ViewBag.Orders = orders;
            return View();
        }

        [HttpGet]
        public ActionResult OrderAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult OrderAdd(Order order)
        {
            DBOrders.Orders.Add(order);
            DBOrders.SaveChanges();

            IEnumerable<Order> orders = DBOrders.Orders;
            ViewBag.Orders = orders;
            return View("Orders");
        }

        public ActionResult UsersOrders()
        {
            IEnumerable<User_Order> user_order = DBUsPrKey.UsersOrders;
            ViewBag.UsersOrders = user_order;
            return View();
        }

        [HttpGet]
        public ActionResult UsersOrdersAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UsersOrdersAdd(User_Order user_order)
        {
            DBUsPrKey.UsersOrders.Add(user_order);
            DBUsPrKey.SaveChanges();

            IEnumerable<User_Order> users_orders = DBUsPrKey.UsersOrders;
            ViewBag.UsersOrders = users_orders;
            return View("UsersOrders");
        }

    }
}