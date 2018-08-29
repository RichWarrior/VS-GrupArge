using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.DLL
{
    public class Employee : Base
    {
        public List<Entities.Employee> Listele()
        {
            return dbContext.Employee.ToList();
        }
        public bool Ekle(Entities.Employee model)
        {
            var result = false;
            dbContext.Employee.Add(model);
            dbContext.SaveChanges();
            result = true;
            return result;
        }

        public bool Sil(int id)
        {
            var result = false;
            dbContext.Employee.Remove(dbContext.Employee.FirstOrDefault(x=>x.id == id));
            dbContext.SaveChanges();
            return result;
        }

        public bool Güncelle(int id,Entities.Employee new_value)
        {
            var result = false;
            var key = dbContext.Employee.First(x => x.id == id);
            key.name_surname = new_value.name_surname;
            key.departman_id = new_value.departman_id;
            key.phone_number = new_value.phone_number;
            dbContext.SaveChanges();
            return result;
        }
    }
}
