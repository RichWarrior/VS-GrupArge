using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MyQuery.Database
{
    public class Database
    {
        private string _connectionString = "Server=localhost;Database=deneme;Uid=root;Password=1234";

       public async Task<List<T>> GetDataFromDatabase<T>(string Query,object Obj)
        {
            List<T> x = new List<T>();
            try
            {
                var con = new MySqlConnection(_connectionString);
                IList<PropertyInfo> myProperties = new List<PropertyInfo>(Obj.GetType().GetProperties());
                using (var cmd = new MySqlCommand())
                {
                    cmd.CommandText = Query;
                    cmd.Connection = con;
                    foreach (PropertyInfo item in myProperties)
                    {
                        if (item.GetValue(Obj,null)!=null)
                        {
                            var a = "@" + item.Name;
                            if (Query.Contains(a))
                            {
                                cmd.Parameters.AddWithValue("@"+item.Name,item.GetValue(Obj,null));
                            }else
                            {
                                Console.WriteLine("Sorgu da Böyle Bir Properties Tanımlı Değil!");
                            }
                        }else
                        {
                            Console.WriteLine("Properties Boş");
                        }
                    }
                    await con.OpenAsync();
                    MySqlDataReader reader = (MySqlDataReader)await cmd.ExecuteReaderAsync();
                    var z = typeof(T);
                    IList<PropertyInfo> generic_properties = new List<PropertyInfo>(z.GetProperties());
                    while (reader.Read())
                    {
                        var a = (T)Activator.CreateInstance(typeof(T));
                        foreach (PropertyInfo item in generic_properties)
                        {
                            item.SetValue(a,reader[item.Name],null);
                        }
                        x.Add(a);
                    }
                    con.Close();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return x;
        }
    }
}
