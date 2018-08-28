using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityApp.DbSet.DLL
{
    public class Teacher : Base
    {
        public List<Entities.Teacher> Listele()
        {
            return this.dbContext.Teachers.ToList();
        }
        public bool Ekle(Entities.Teacher model)
        {
            var result = false;
            try
            {
                this.dbContext.Teachers.Add(model);
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
                dbContext.Teachers.Remove(dbContext.Teachers.FirstOrDefault(x=>x.id == index));
                this.dbContext.SaveChanges();
                result = true;
            }catch(Exception)
            {
            }
            return result;
        }
        public bool Güncelle(int index,Entities.Teacher model)
        {
            var result = false;
            try
            {
                var data = this.dbContext.Teachers.Where(x => x.id == index).First();
                data.lesson_id = model.lesson_id;
                this.dbContext.SaveChanges();
                result = true;
            }
            catch (Exception)
            {
            }
            return result;
        }
    }
}
