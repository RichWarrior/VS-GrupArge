using MVC2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC2.ViewModel
{
    public class CategoryViewModel
    {
        public List<Category> categoryList { get; set; }
        public CategoryViewModel()
        {
            categoryList = new List<Category>();
        }
    }
}