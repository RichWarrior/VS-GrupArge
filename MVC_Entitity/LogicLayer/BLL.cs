using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class BLL
    {
        private DLL.Department _department;
        private DLL.Expense _expense;
        private DLL.Employee _employee;
        
        public DLL.Department Department()
        {
            if (_department == null)
                _department = new DLL.Department();
            return _department;
        }


        public DLL.Expense Expense()
        {
            if (_expense == null)
                _expense = new DLL.Expense();
            return _expense;
        }

        public DLL.Employee Employee()
        {
            if (_employee == null)
                _employee = new DLL.Employee();
            return _employee;
        }

    }
}
