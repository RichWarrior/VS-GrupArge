using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntityApp2.ViewModel
{
    public class EmployeeCreate
    {
        public List<LogicLayer.Entities.Department> departments;
        public Models.Employee_Model employee;
        public EmployeeCreate()
        {
            departments = new List<LogicLayer.Entities.Department>();
            employee = new Models.Employee_Model();
        }
    }
}