using DbExample._Class;
using DbExample.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DbExample
{
    class Program
    {
        static  void Main(string[] args)
        {
            Database dB = new Database();
            Users users = new Users();
            users.name = "Faruk";
            users.surname = "Şahin";




            //var result = dB.getDataAsync<Users>().GetAwaiter().GetResult();

            //foreach (var item in result)
            //{
            //    Console.WriteLine(item.name+" "+item.surname);
            //}

            //bool result = dB.writeDataAsync(users).GetAwaiter().GetResult();
            //if (result)
            //{
            //    Console.WriteLine("Başarılı");
            //}

            Console.Read();
        }
        
    }
}
