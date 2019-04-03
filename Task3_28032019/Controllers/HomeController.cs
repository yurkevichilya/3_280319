using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task3_28032019.Models;
using System.Xml.Serialization;
using System.IO;

namespace Task3_28032019.Controllers
{
    public class HomeController : Controller
    {
        //UsersContext DBUsers = new UsersContext();
        //ProductContext DBProducts = new ProductContext();
        OrderContext DBOrders = new OrderContext();
        //User_OrderContext DBUsPrKey = new User_OrderContext(); 

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
            IEnumerable<User> users = DBOrders.Users;
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
            if (ModelState.IsValid)
            {
                DBOrders.Users.Add(user);
                DBOrders.SaveChanges();

                IEnumerable<User> users = DBOrders.Users;
                ViewBag.Users = users;
                return View("Users");
            }
            else {
                return View("AddUser");
            }
        }
        [HttpGet]
        public ActionResult ChangeUser(int id)
        {
            User currentUser = new User();
            currentUser = FindByIdUser(id, DBOrders.Users);
            ViewBag.Id = currentUser.Id;
            ViewBag.Name = currentUser.Name;
            ViewBag.Email = currentUser.Email;
            return View();
        }
        [HttpPost]
        public ActionResult ChangeUser(User user)
        {
            var changeUser = DBOrders.Users.SingleOrDefault(b => b.Id == user.Id);
            changeUser.Name = user.Name;
            changeUser.Email = user.Email;
            DBOrders.SaveChanges();
            IEnumerable<User> users = DBOrders.Users;
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
        [HttpGet]
        public ActionResult ChooseUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ChooseUser(int id)
        {
        
            int userID = id;//input any user id as y want
            int userAllPrice = 0;


            IEnumerable<User_Order> users_orders = DBOrders.UsersOrders;
            IEnumerable<Order> orders = DBOrders.Orders;
            IEnumerable<Product> products = DBOrders.Products;
            IEnumerable<ProductOrder> productOrders = DBOrders.ProductOrder;

            //create an one user list of orders
            List<User_Order> user_orders = new List<User_Order>();
            foreach (User_Order us in users_orders)
            {
                if (us.Id_User == userID)
                {
                    user_orders.Add(us);
                }
            }

            List<Order> orderss = new List<Order>();
            foreach (User_Order us1 in user_orders)
            {
                foreach (Order or in orders)
                {
                    if (us1.Id_Order == or.Id)
                    {
                        orderss.Add(or);
                    }
                }
            }

            List<Product> userproducts = new List<Product>();
            List<ProductOrder> userproductsorder = new List<ProductOrder>();
            foreach (Order or in orderss)
            {
                foreach (ProductOrder pror in productOrders)
                {
                    if (pror.Id_Order == or.Id)
                    {
                        foreach (Product product in products)
                        {
                            if (product.Id == pror.Id_Product)
                            {
                                userAllPrice = userAllPrice + pror.Quantity * product.Price;
                                userproducts.Add(product);
                                userproductsorder.Add(pror);
                            }
                        }
                    }
                }
            }

            //foreach (Order or in orderss)
            //{
            //    foreach (Product pr in products)
            //    {
            //        if (or.Id_Product == or)
            //        {
            //            userAllPrice = userAllPrice + or.Quantity * pr.Price;
            //        }
            //    }
            //}
            ViewData["Price"] = userAllPrice.ToString();
            ViewBag.userproducts = userproducts;
            ViewBag.userproductsorder = userproductsorder;
            return View("UserInfo");
        }

       
        [HttpGet]
        public ActionResult UserInfo(int id)
        {

            int userID = id;//input any user id as y want
            int userAllPrice = 0;

            IEnumerable<User_Order> users_orders = DBOrders.UsersOrders;
            IEnumerable<Order> orders = DBOrders.Orders;
            IEnumerable<Product> products = DBOrders.Products;
            IEnumerable<ProductOrder> productOrders = DBOrders.ProductOrder;

            //create an one user list of orders
            List<User_Order> user_orders = new List<User_Order>();
            foreach (User_Order us in users_orders)
            {
                if (us.Id_User == userID)
                {
                    user_orders.Add(us);
                }
            }

            List<Order> orderss = new List<Order>();
            foreach (User_Order us1 in user_orders)
            {
                foreach (Order or in orders)
                {
                    if (us1.Id_Order == or.Id)
                    {
                        orderss.Add(or);
                    }
                }
            }

            List<Product> userproducts = new List<Product>();
            List<ProductOrder> userproductsorder = new List<ProductOrder>();
            foreach (Order or in orderss)
            {
                foreach (ProductOrder pror in productOrders)
                {
                    if (pror.Id_Order == or.Id)
                    {
                        foreach (Product product in products)
                        {
                            if (product.Id == pror.Id_Product)
                            {
                                userAllPrice = userAllPrice + pror.Quantity * product.Price;
                                userproducts.Add(product);
                                userproductsorder.Add(pror);
                            }
                        }
                    }
                }
            }

            //foreach (Order or in orderss)
            //{
            //    foreach (Product pr in products)
            //    {
            //        if (or.Id_Product == or)
            //        {
            //            userAllPrice = userAllPrice + or.Quantity * pr.Price;
            //        }
            //    }
            //}
            ViewData["Price"] = userAllPrice.ToString();
            ViewBag.userproducts = userproducts;
            ViewBag.userproductsorder = userproductsorder;
            return View("UserInfo");
        }

        public ActionResult Products()
        {
            IEnumerable<Product> products = DBOrders.Products;
            ViewBag.Products = products;
            return View();
        }
        public ActionResult ProductsSerialize()
        {
            IEnumerable<Product> products = DBOrders.Products;
            Product oneofthem = new Product();
            foreach (Product pr in products) {
                oneofthem = pr;
            }
            XmlSerializer formatter = new XmlSerializer(typeof(Product));

            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream("Products.xml", FileMode.OpenOrCreate))
            {
                foreach (Product pr in products) {
                    formatter.Serialize(fs, pr);
                }
                Console.WriteLine("Объект сериализован");
            }
            return View("Index");
        }
        public ActionResult ProductsDeSerialize()
        {
            IEnumerable<Product> products = DBOrders.Products;
            Product oneofthem = new Product();
         
            XmlSerializer formatter = new XmlSerializer(typeof(Product));

            using (FileStream fs = new FileStream("Products.xml", FileMode.OpenOrCreate))
            {
                Product newPerson = (Product)formatter.Deserialize(fs);
            }

            return View("Index");
        }
        [HttpGet]
        public ActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(Product product)
        {

            if (ModelState.IsValid)
            {
                DBOrders.Products.Add(product);
                DBOrders.SaveChanges();

                IEnumerable<Product> products = DBOrders.Products;
                ViewBag.Products = products;
                return View("Products");
            }
            else
            {
                return View("AddProduct");
            }

        
        }

        public ActionResult Orders()
        {
            //SELECT dbo.Orders.id, dbo.Orders.nane, dbo.Products.name
            //FROM dbo.Orders LEFT OUTER JOIN
            //dbo.Products ON dbo.Orders.product_id = dbo.Products.id
            IEnumerable<Order> orders = DBOrders.Orders;
            //IEnumerable<Product> products = DBOrders.Products.Include(p => p.Orders);

            //var order = from o in orders
            //            join p in products on o.Id_Product equals p.Id into orderProds
            //            from op in orderProds
            //            select new { op.Name };
            //foreach(Product p in products){
            //}
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
        private Order FindByIdOrder(int id, IEnumerable<Order> orders)
        {
            Order searchOrder = new Order();
            foreach (Order order in orders)
            {
                if (order.Id == id)
                {
                    searchOrder = order;
                }
            }
            return searchOrder;
        }
        [HttpGet]
        public ActionResult ChangeOrder(int id)
        {
            Order currentOrder = new Order();
            currentOrder = FindByIdOrder(id, DBOrders.Orders);
            ViewBag.Id = currentOrder.Id;
            ViewBag.Name = currentOrder.Name;
            ViewBag.Bdate = currentOrder.Bdate;
            return View();
        }
        [HttpPost]
        public ActionResult ChangeOrder(Order order)
        {
            var changeOrder = DBOrders.Orders.SingleOrDefault(b => b.Id == order.Id);
            changeOrder.Name = order.Name;
            changeOrder.Bdate = order.Bdate;
            DBOrders.SaveChanges();
            IEnumerable<Order> orders = DBOrders.Orders;
            ViewBag.Orders = orders;
            return View("Orders");
        }
        public ActionResult UsersOrders()
        {
            IEnumerable<User_Order> user_order = DBOrders.UsersOrders;
            IEnumerable<User> users = DBOrders.Users;
            IEnumerable<Order> orders = DBOrders.Orders;
            ViewBag.Users = users;
            ViewBag.Orders = orders;
            ViewBag.UsersOrders = user_order;
            return View();
        }

        [HttpGet]
        public ActionResult UsersOrdersAdd()
        {
            IEnumerable<User> users = DBOrders.Users;
            IEnumerable<Order> orders = DBOrders.Orders;
            ViewBag.Users = users;
            ViewBag.Orders = orders;
            return View();
        }

        [HttpPost]
        public ActionResult UsersOrdersAdd(User_Order user_order)
        {
            DBOrders.UsersOrders.Add(user_order);
            DBOrders.SaveChanges();

            IEnumerable<User_Order> users_orders = DBOrders.UsersOrders;
            ViewBag.UsersOrders = users_orders;
            IEnumerable<User> users = DBOrders.Users;
            IEnumerable<Order> orders = DBOrders.Orders;
            ViewBag.Users = users;
            ViewBag.Orders = orders;
            return View("UsersOrders");
        }

        [HttpGet]
        public ActionResult ProductOrder()
        {
            IEnumerable<ProductOrder> product_order = DBOrders.ProductOrder;
            IEnumerable<Product> products = DBOrders.Products;
            IEnumerable<Order> orders = DBOrders.Orders;
            ViewBag.ProductOrder = product_order;
            ViewBag.Products = products;
            ViewBag.Orders = orders;
            return View();
        }
        [HttpGet]
        public ActionResult AddProductOrder()
        {
            //SelectList products = new SelectList(DBOrders.Products, "Name");
            IEnumerable<Product> products = DBOrders.Products;
            IEnumerable<Order> orders = DBOrders.Orders;
            ViewBag.Products = products;
            ViewBag.Orders = orders;
            return View();
        }
        [HttpPost]
        public ActionResult AddProductOrder(ProductOrder productOrder)
        {
            DBOrders.ProductOrder.Add(productOrder);
            DBOrders.SaveChanges();
            IEnumerable<ProductOrder> product_order = DBOrders.ProductOrder;
            IEnumerable<Product> products = DBOrders.Products;
            IEnumerable<Order> orders = DBOrders.Orders;
            ViewBag.ProductOrder = product_order;
            ViewBag.Products = products;
            ViewBag.Orders = orders;
            return View("ProductOrder");
        }
    }
}