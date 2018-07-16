using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.ViewModel
{
    public class ViewModel_Personel
    {
        public List<Personeller> List { get; set; }
        public ViewModel_Personel()
        {
            List = new List<Personeller>();
        }
    }
}
