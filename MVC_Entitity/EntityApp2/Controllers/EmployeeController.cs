using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EntityApp2.Controllers
{
    public class EmployeeController : Base
    {
        // GET: Employee
        public ActionResult Index()
        {
            var returned_list = new List<Models.Employee_Model>();
            foreach (var item in bll.Employee().Listele())
            {
                returned_list.Add(new Models.Employee_Model
                {
                    id = item.id,
                    name = item.name_surname,
                    phone_number = item.phone_number,
                    departman = bll.Department().Listele().FirstOrDefault(x => x.id == item.departman_id).name
                });
            }
            return View(returned_list);
        }
        public ActionResult Create()
        {
            ViewModel.EmployeeCreate employee = new ViewModel.EmployeeCreate();
            employee.departments = bll.Department().Listele();
            return View(employee);
        }
        [HttpPost]
        public ActionResult Create(Models.Employee_Model value)
        {
            bll.Employee().Ekle(new LogicLayer.Entities.Employee {
                 name_surname = value.name,
                  phone_number = value.phone_number,
                   departman_id = int.Parse(value.departman)
            });
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var value = bll.Employee().Listele().First(x => x.id == id);
            return View(new Models.Employee_Model {
                 id = id,
                  name = value.name_surname,
                   phone_number = value.phone_number,
                    departman = bll.Department().Listele().First(x=>x.id == value.departman_id).name
            });
        }
        [HttpPost]
        public ActionResult Delete(int id,Models.Employee_Model old_value)
        {
            bll.Employee().Sil(id);
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            ViewModel.EmployeeCreate employee = new ViewModel.EmployeeCreate();
            employee.departments = bll.Department().Listele();
            var value = bll.Employee().Listele().First(x => x.id == id);
            employee.employee = new Models.Employee_Model
            {
                id = id,
                 name = value.name_surname,
                  departman = bll.Department().Listele().First(x=>x.id == value.departman_id).name,
                   phone_number = value.phone_number
            };
            return View(employee);
        }
        [HttpPost]
        public ActionResult Edit(int id,Models.Employee_Model new_value)
        {
            bll.Employee().Güncelle(id,new LogicLayer.Entities.Employee {
                 name_surname = new_value.name,
                  phone_number = new_value.phone_number, 
                   departman_id = bll.Department().Listele().First(x=>x.name == new_value.departman).id
            });
            return RedirectToAction("Index");
        }
        
    }
}