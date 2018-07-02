using DbExample._Class;
using DbExample.Model;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace DbExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Database db = new Database();
            users users = new users();
            Task<List<users>> task1 = Task.Run(() => db.getDataAsync<users>());
            Task<List<users>> task2 = Task.Run(() => db.getDataAsync<users>());
            Task<List<users>> task3 = Task.Run(() => db.getDataAsync<users>());
            Task.WaitAll(task1,task2,task3);


            Console.ReadKey();

        }

    }
}
