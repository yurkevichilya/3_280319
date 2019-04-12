using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace Task3_28032019.Models
{
    [Serializable]
    public class Product
    {
        public int Id { get; set; }

        //[Required]
        //[Display(Name = "Name")]
        public string Name { get; set; }

        //[Required]
        //[Display(Name = "Price")]
        public int Price { get; set; }

        [XmlIgnore]
        public virtual List<ProductOrder> ProductOrder { get; set; }

        public Product() {

        }

        public Product(string Name, int Price) {
            this.Name = Name;
            this.Price = Price;

        }
    }
}