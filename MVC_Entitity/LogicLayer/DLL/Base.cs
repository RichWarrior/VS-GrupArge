using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.DLL
{
    public class Base
    {
        public Entities.ExpenseEntities dbContext;
        public Base()
        {
            if (dbContext == null)
                dbContext = new Entities.ExpenseEntities();
        }
    }
}
