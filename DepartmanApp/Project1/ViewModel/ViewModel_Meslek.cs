using Project1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.ViewModel
{
    public class ViewModel_Meslek
    {
        public List<Meslek> List { get; set; }
        public ViewModel_Meslek()
        {
            List = new List<Meslek>();
        }
    }
}
