using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EntityApp2.Controllers
{
    public class ExpenseController : Base
    {
        private List<LogicLayer.Entities.Department> deparments = new List<LogicLayer.Entities.Department>();
        public ExpenseController()
        {
            deparments = bll.Department().Listele();
        }
        // GET: Expense
        public ActionResult Index()
        {
            var result = bll.Expense().Listele();
            var return_date = new List<Models.Expense_Model>();
            foreach (var item in result)
            {
                return_date.Add(new Models.Expense_Model
                {
                    id = item.id,
                    description = item.description,
                    price = item.price,
                    date = item.date,
                    departmant = item.Department_Expense.First(x => x.expense_id == item.id).Department.name

                });
            }
            return View(return_date);
        }
        public ActionResult Delete(int id)
        {
            var result = bll.Expense().Listele().FirstOrDefault(x=>x.id == id);
            var return_value = new Models.Expense_Model();
            return_value.id = id;
            return_value.description = result.description;
            return_value.price = result.price;
            return_value.date = result.date;
            return_value.departmant = result.Department_Expense.First(x => x.expense_id == id).Department.name;
            return View(return_value);
        }
        [HttpPost]
        public ActionResult Delete(int id,Models.Expense_Model old_value)
        {
            bll.Expense().Sil(id);
            return RedirectToAction("Index");
        }
        public ActionResult Create()
        {
            ViewModel.ExpenseCreate model = new ViewModel.ExpenseCreate();
            model.departments = deparments;
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(Models.Expense_Model value)
        {
            var isOk = bll.Expense().Ekle(new LogicLayer.Entities.Expense {
                  price = value.price,
                   description = value.description,
                    date = value.date,
                   
            });

            if (isOk)
            {
                var old_value = bll.Expense().Listele().First(x=>x.price == value.price && x.description == value.description && x.date == value.date);
                bll.Department().dbContext.Department_Expense.Add(new LogicLayer.Entities.Department_Expense {
                     expense_id = old_value.id,
                      department_id = deparments.First(x=>x.name == value.departmant).id
                });
                bll.Department().dbContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            ViewModel.ExpenseCreate v = new ViewModel.ExpenseCreate();
            v.departments = deparments;
            var value = bll.Expense().Listele().FirstOrDefault(x => x.id == id);
            v.expense = new Models.Expense_Model {
                id = id,
                 description = value.description,
                 price =value.price,
                   date = value.date,
                    departmant = value.Department_Expense.First(x=>x.expense_id == id).Department.name
            };
            return View(v);
        }
        [HttpPost]
        public ActionResult Edit(int id,LogicLayer.Entities.Expense new_value)
        {
            bll.Expense().Güncelle(id, new_value);
            return RedirectToAction("Index");
        }
    }
}