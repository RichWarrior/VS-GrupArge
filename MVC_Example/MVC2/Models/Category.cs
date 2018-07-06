using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC2.Models
{
    public class Category
    {
        public int id { get; set; }
        public string category_name { get; set; }
        public int? f_key { get; set; }
    }
}