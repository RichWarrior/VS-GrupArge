using DbExample._Class;
using DbExample.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbExample
{
    class Program
    {
        static void Main(string[] args)
        {

            Database dB = new Database();
            Users user = new Users();
            user.name = "Faruk";
            user.surname = "Şahin";
            dB.veriEkle(user);


            Console.Read();
        }
    }
}
