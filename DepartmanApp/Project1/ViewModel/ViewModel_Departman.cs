using Project1.Model;
using System.Collections.Generic;

namespace Project1.ViewModel
{
    public class ViewModel_Departman
    {
        public List<Departman> List { get; set; }
        public ViewModel_Departman()
        {
            List = new List<Departman>();
        }
    }
}
