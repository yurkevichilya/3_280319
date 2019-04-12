using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Data.Entity;
using Task3_28032019.Models;

namespace Task3_28032019
{
    public class MvcApplication : System.Web.HttpApplication
    {
        internal static OrderContext DBOrders;
        protected void Application_Start()
        {
            DBOrders = new OrderContext();
            Application.Add("DBOrders", DBOrders);
            Database.SetInitializer(new OrdersInit());

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
