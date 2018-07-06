using MVC2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC2.ViewModel
{
    public class DetailViewModel
    {
        public List<SelectListItem> categoryList;
        public List<Detail> detailList;
        public int id;

        public DetailViewModel() {
            categoryList = new List<SelectListItem>();
            detailList = new List<Detail>();
        }
    }
}