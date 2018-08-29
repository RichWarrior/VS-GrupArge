using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EntityApp2.Models
{
    public class Employee_Model
    {
        public int id { get; set; }
        [Display(Name ="Ad")]
        public string name { get; set; }
        [Display(Name = "Telefon Numarası")]
        public string phone_number { get; set; }
        [Display(Name = "Departman")]
        public string departman { get; set; }
    }
}