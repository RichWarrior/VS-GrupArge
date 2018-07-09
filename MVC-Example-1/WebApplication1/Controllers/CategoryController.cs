using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.DatabaseService;
using WebApplication1.DatabaseService.StoredProcedureModel;
using WebApplication1.ViewModel;

namespace WebApplication1.Controllers
{
    public class CategoryController : Controller
    {
        private MySQLDatabase database = new MySQLDatabase();

        // GET: Category
        public ActionResult Index()
        {
            DropDownListViewModel viewModel = new DropDownListViewModel();
            viewModel.categoryList.Add(new SelectListItem {
                 Text="İstanbul",
                 Value="1"
            });
            viewModel.categoryList.Add(new SelectListItem
            {
                Text = "Ankara",
                Value = "2"
            }); viewModel.categoryList.Add(new SelectListItem
            {
                Text = "İzmir",
                Value = "3"
            });
            return View(viewModel);
        }

        public JsonResult getSubCategory(int id)
        {
            sp_ilce ilce = new sp_ilce();
            ilce.sehir_id = id;
            DataTable dt = database.GetDataFromDatabase(ilce);
            List<string> x = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                x.Add(dt.Rows[i].ItemArray[0].ToString());
            }
            return Json(x,JsonRequestBehavior.AllowGet);
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Category/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
