using Project1.Model;
using Project1.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Controller
{
    public class PersonelController
    {
        private ViewModel_Personel personel = new ViewModel_Personel();

        public List<Personeller> Listele()
        {
            return personel.List;
        }

        public bool Ekle(Personeller _personel)
        {
            personel.List.Add(_personel);
            return true;
        }

        public bool Sil(int id)
        {
            personel.List.RemoveAt(id);
            return true;
        }
    }
}
