using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.DLL
{
    public class Department : Base
    {
        public List<Entities.Department> Listele()
        {
            return dbContext.Department.ToList();
        }
        public bool Ekle(Entities.Department model)
        {
            var result = false;
            dbContext.Department.Add(model);
            dbContext.SaveChanges();
            result = true;
            return result;
        }
        public bool Sil(int index)
        {
            var result = false;
            var value = dbContext.Department_Expense.Where(x => x.department_id == index).ToList();
            //dbContext.Department_Expense.Remove(dbContext.Department_Expense.First(x => x.department_id == index));
            foreach (var item in value)
            {
                var expense_id = item.expense_id;
                var departman_id = item.department_id;
                dbContext.Expense.Remove(dbContext.Expense.FirstOrDefault(x => x.id == expense_id));
                dbContext.Department_Expense.Remove(dbContext.Department_Expense.FirstOrDefault(x => x.department_id == departman_id));
            }
            dbContext.Department.Remove(dbContext.Department.FirstOrDefault(x=>x.id == index));
            dbContext.SaveChanges();
            result = true;
            return result;
        }
        public bool Güncelle(int index,Entities.Department new_value)
        {
            var result = false;
            var value = dbContext.Department.FirstOrDefault(x=>x.id == index);
            value.name = new_value.name;
            dbContext.SaveChanges();
            result = true;
            return result;
        }
    }
}
