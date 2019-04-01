using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Task3_28032019.Models
{
    public class Order
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Id_Product { get; set; }

        public int Quantity { get; set; }

        [DataType(DataType.Date)]
        public DateTime Bdate { get; set; }

    }
}