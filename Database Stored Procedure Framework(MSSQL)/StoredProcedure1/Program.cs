using StoredProcedure1._Class;
using StoredProcedure1.StoredProcedure;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoredProcedure1
{
    class Program
    {
        static void Main(string[] args)
        {
            Database db = new Database();
            sp_ÖgrenciDers_SELECT ogr_select = new sp_ÖgrenciDers_SELECT();
            sp_ÖgrenciDers_INSERT ogr_insert = new sp_ÖgrenciDers_INSERT();
            ogr_insert.ogr_id = 1;
            ogr_insert.ders_kodu = "4";
            ogr_select.OGR_ID = 1;
            db.getData(ogr_select);
            Console.ReadKey();
        }
    }
}
