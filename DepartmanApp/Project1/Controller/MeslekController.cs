using Project1.Model;
using Project1.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Controller
{
    public class MeslekController
    {
        private ViewModel_Meslek meslek = new ViewModel_Meslek();

        public List<Meslek> Listele()
        {
            return meslek.List;
        }

        public bool Ekle(Meslek _meslek)
        {
            meslek.List.Add(_meslek);
            return true;
        }

        public bool Sil(Meslek id)
        {
            meslek.List.Remove(id);
            return true;
        }
    }
}
