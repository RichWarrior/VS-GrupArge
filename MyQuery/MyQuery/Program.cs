using MyQuery.MyDataModel;
using MyQuery.MyQueryModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyQuery
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.Database database = new Database.Database();
            Task<List<Dersler>> task1 = Task.Run(() =>database.GetDataFromDatabase<Dersler>("SELECT ders.ders_adi FROM user_ders _user INNER JOIN dersler ders ON ders.ders_id = _user.ders_id  WHERE _user.user_id = @user_id; ",new  { user_id=1}));
            foreach (var item in task1.Result)
            {
                Console.WriteLine(item.ders_adi);
            }
            Console.ReadKey();
        }
    }
}
