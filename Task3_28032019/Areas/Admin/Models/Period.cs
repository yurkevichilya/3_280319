using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Task3_28032019.Models
{
    public class Period
    {
        [DataType(DataType.Date)]
        public DateTime firstDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime secondDate { get; set; }
    }
}