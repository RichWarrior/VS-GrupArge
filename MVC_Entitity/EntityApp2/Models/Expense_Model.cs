using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EntityApp2.Models
{
    public class Expense_Model
    {
        public int id { get; set; }
        [Display(Name ="Açıklama")]
        public string description { get; set; }
        [Display(Name ="Tutar")]
        public int? price { get; set; }
        [Display(Name ="Tarih")]
        public DateTime? date { get; set; }
        [Display(Name ="Departman")]
        public string departmant { get; set; }
    }
}