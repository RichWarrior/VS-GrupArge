using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityApp.DbSet.DLL
{
    public class Base
    {
        public Entities.SchoolEntities dbContext;
        public Base()
        {
            if (dbContext == null)
                dbContext = new Entities.SchoolEntities();
        }
    }
}
