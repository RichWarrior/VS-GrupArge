using Project1.Model;
using Project1.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Controller
{
    public class DepartmanController
    {
        private ViewModel_Departman departman = new ViewModel_Departman();

        public List<Departman> Listele()
        {
            return departman.List;
        }

        public bool Ekle(Departman _departman)
        {
            departman.List.Add(_departman);
            return true;
        }
        public bool Sil(int id)
        {
            departman.List.RemoveAt(id);
            return true;
        }
    }
}
