using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Task3_28032019.Models
{
    public class ProductOrder
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        public int Id_Product { get; set; }

        public int Id_Order { get; set; }
    }
}