using DbExample._Class;
using DbExample.AsyncHelper;
using DbExample.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DbExample
{
    class Program
    {
       static void Main(string[] args)
        {
            //ASYNC Metodları Tetiklemek İçin Sonlarına .GetAwaiter().GetResult(); Eklenmelidir Bu Nito.AsyncEx Kütüphanesi İle Olmuştur

            Database dB = new Database();


            //var task1 = _AsyncHelper.RunSync<List<Users>>(() => dB.getDataAsync<Users>());
            //var task2 = _AsyncHelper.RunSync<List<Dersler>>(() => dB.getDataAsync<Dersler>());

            //var task1 = dB.getDataAsync<Users>().GetAwaiter().GetResult();
            //var task2 = dB.getDataAsync<Dersler>().GetAwaiter().GetResult();
            //var task3 = dB.getDataAsync<Birth>().GetAwaiter().GetResult();
            //var task4 = dB.getDataAsync<Users>().GetAwaiter().GetResult();



            //foreach (var item in task1)
            //{
            //    IList<PropertyInfo> props = new List<PropertyInfo>(item.GetType().GetProperties());
            //    foreach (PropertyInfo sub in props)
            //    {
            //        Console.Write(sub.Name + "=" + sub.GetValue(item, null) + "\n");
            //    }
            //}
            //foreach (var item in task2)
            //{
            //    IList<PropertyInfo> props = new List<PropertyInfo>(item.GetType().GetProperties());
            //    foreach (PropertyInfo sub in props)
            //    {
            //        Console.Write(sub.Name + "=" + sub.GetValue(item, null) + "\n");
            //    }
            //}
            //foreach (var item in task3)
            //{
            //    IList<PropertyInfo> props = new List<PropertyInfo>(item.GetType().GetProperties());
            //    foreach (PropertyInfo sub in props)
            //    {
            //        Console.Write(sub.Name + "=" + sub.GetValue(item, null) + "\n");
            //    }
            //}
            //foreach (var item in task4)
            //{
            //    IList<PropertyInfo> props = new List<PropertyInfo>(item.GetType().GetProperties());
            //    foreach (PropertyInfo sub in props)
            //    {
            //        Console.Write(sub.Name + "=" + sub.GetValue(item, null) + "\n");
            //    }
            //}

            Console.Read();
        }
       
    }
}
