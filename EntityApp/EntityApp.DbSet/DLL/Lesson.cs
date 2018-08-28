using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityApp.DbSet.DLL
{
    public class Lesson : Base
    {
        public List<Entities.Lesson> Listele()
        {
            return this.dbContext.Lessons.ToList();
        }
        public bool Ekle(Entities.Lesson data)
        {
            var result = false;
            try
            {
                this.dbContext.Lessons.Add(data);
                this.dbContext.SaveChanges();
                return result;
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
                dbContext.Lessons.Remove(dbContext.Lessons.FirstOrDefault(x=>x.id==index));
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
