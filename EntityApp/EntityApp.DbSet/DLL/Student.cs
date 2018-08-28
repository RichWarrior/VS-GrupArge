using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityApp.DbSet.DLL
{
    public class Student : Base
    {
        public List<Entities.Student> Listele()
        {
            return this.dbContext.Students.ToList();
        }
        public bool Ekle(Entities.Student model)
        {
            var result = false;
            try
            {
                this.dbContext.Students.Add(model);
                this.dbContext.SaveChanges();
                result = true;
            }
            catch (Exception)
            {
            }
            return result;
        }
        public bool Sil(int index)
        {
            var result = false;
            try
            {
                dbContext.Students.Remove(dbContext.Students.FirstOrDefault(x => x.id == index));                
                this.dbContext.SaveChanges();
                result = true;
            }
            catch (Exception ex)
            {
            }
            return result;
        }
        public bool Güncelle(int id,Entities.Student model)
        {
            var result = false;
            try
            {
                var data = this.dbContext.Students.Where(x => x.id == id).First();
                data.name_surname = model.name_surname;
                data.number = model.number;
                data.classroom = model.classroom;
                this.dbContext.SaveChanges();
                result = true;

            }
            catch(Exception)
            {
            }
            return result;
        }
    }
}
