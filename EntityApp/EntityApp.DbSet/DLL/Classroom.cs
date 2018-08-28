using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityApp.DbSet.DLL
{
    public class Classroom : Base
    {
        public List<Entities.Class> Listele()
        {
            return this.dbContext.Classes.ToList();
        }
        public bool Ekle(Entities.Class model)
        {
            var result = false;
            try
            {
                this.dbContext.Classes.Add(model);
                this.dbContext.SaveChanges();
                result = true;
            }
            catch (Exception ex)
            {
            }
            return result;
        }
        public bool Sil(int id)
        {
            var result = false;
            try {
                this.dbContext.Classes.Remove(dbContext.Classes.FirstOrDefault(x=>x.id==id));
                this.dbContext.SaveChanges();
                result = true;
            }catch(Exception ex)
            {
            }
            return result;
        }
    }
}
