using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.DLL
{
    public class Expense : Base
    {
        public List<Entities.Expense> Listele()
        {
            return dbContext.Expense.ToList();
        }
        public bool Ekle(Entities.Expense model)
        {
            var result = false;
            dbContext.SaveChanges();
            dbContext.Expense.Add(model);
            dbContext.SaveChanges();
            result = true;
            return result;
        }
        public bool Sil(int index)
        {
            var result = false;
            dbContext.Department_Expense.Remove(dbContext.Department_Expense.First(x=>x.expense_id == index));
            dbContext.Expense.Remove(dbContext.Expense.FirstOrDefault(x=>x.id == index));
            dbContext.SaveChanges();
            return result;
        }
        public bool Güncelle(int index,Entities.Expense new_value)
        {
            var result = false;
            var value = dbContext.Expense.FirstOrDefault(x=>x.id == index);
            value.description = new_value.description;
            value.date = new_value.date;
            value.price = new_value.price;            
            dbContext.SaveChanges();
            return result;
        }

    }
}
