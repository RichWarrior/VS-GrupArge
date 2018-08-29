using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace EntityApp2.ViewModel
{
    public class ExpenseCreate
    {
        public Models.Expense_Model expense;
        public List<LogicLayer.Entities.Department> departments;
        public ExpenseCreate()
        {
            expense = new Models.Expense_Model();
            departments =new List<LogicLayer.Entities.Department>();
        }
    }
}