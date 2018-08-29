using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EntityApp2.Controllers
{
    public class Base : Controller
    {
        public LogicLayer.BLL bll;
        public Base()
        {
            if (bll == null)
                bll = new LogicLayer.BLL();
        }
    }
}