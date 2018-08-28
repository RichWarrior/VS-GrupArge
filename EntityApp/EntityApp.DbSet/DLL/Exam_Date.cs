using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityApp.DbSet.DLL
{
    public class Exam_Date : Base
    {
        public List<Entities.Exam_Date> Listele()
        {
            return this.dbContext.Exam_Date.ToList();
        }
        public bool Ekle(Entities.Exam_Date model)
        {
            var result = false;
            try
            {
                this.dbContext.Exam_Date.Add(model);
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
                dbContext.Exam_Date.Remove(dbContext.Exam_Date.FirstOrDefault(x=>x.id==index));
                this.dbContext.SaveChanges();
                result = true;
            }
            catch (Exception)
            {
            }
            return result;
        }
        public bool SilRange(List<int> value)
        {
            var result = false;
            try
            {
                foreach (var item in value)
                {
                    dbContext.Exam_Date.Remove(dbContext.Exam_Date.FirstOrDefault(x => x.id == item));
                }
                dbContext.SaveChanges();
                result = true;
            }
            catch (Exception ex)
            {
            }
            return result;
        }
        public bool Güncelle(int index,Entities.Exam_Date model)
        {
            var result = false;
            try
            {
                var data = this.dbContext.Exam_Date.FirstOrDefault(x=>x.id==index);
                data.exam_date1 = model.exam_date1;
                dbContext.SaveChanges();
                result = true;
            }
            catch (Exception)
            {
            }
            return result;
        }
    }
}
