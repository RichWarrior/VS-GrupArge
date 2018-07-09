using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.ViewModel
{
    public class DropDownListViewModel
    {
        public List<SelectListItem> categoryList;
        public List<SelectListItem> subCategoryList;
        public int id { get; set; }
        public int sub_id { get; set; }
        public DropDownListViewModel()
        {
            categoryList = new List<SelectListItem>();
            subCategoryList = new List<SelectListItem>();
        }
    }
}