using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Task3_28032019.Models
{
    public class Product
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public int Price { get; set; }

        public virtual List<ProductOrder> ProductOrder { get; set; }

    }
}