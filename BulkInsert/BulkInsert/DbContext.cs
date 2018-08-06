using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace BulkInsert
{
    public class DbContext
    {
        MySqlConnection con = new MySqlConnection("Server=localhost;Database=deneme;Uid=root;Pwd=1234;Ssl Mode=none");
        MySqlCommand cmd;
        MySqlDataAdapter adapter;
        MySqlDataReader reader;

        public bool BulkInsert<T>(List<T> _list)
        {
            var success = false;
            var table_name = typeof(T).Name;
            var query = "INSERT INTO " + table_name + " (";
            var subQuery = "";
            var paramQuery = "";
            IList<PropertyInfo> GenericProperties = new List<PropertyInfo>(typeof(T).GetProperties());
            foreach (PropertyInfo item in GenericProperties)
            {
                subQuery += item.Name + ",";
            }
            subQuery = subQuery.TrimEnd(',') + ") VALUES";
            query = query + subQuery;
            subQuery = "";
            var index = 0;
            try
            {
                using (cmd = new MySqlCommand())
                {
                    cmd.Connection = con;
                    foreach (var item in _list)
                    {
                        IList<PropertyInfo> props = new List<PropertyInfo>(item.GetType().GetProperties());
                        paramQuery = "(";
                        foreach (PropertyInfo sub in props)
                        {
                            paramQuery += "@" + sub.Name + "_" + index.ToString() + ",";
                            cmd.Parameters.AddWithValue("@" + sub.Name + "_" + index.ToString(),sub.GetValue(item,null));
                            index++;
                        }
                        query =query+ paramQuery.TrimEnd(',')+"),";
                    }
                    paramQuery = paramQuery.TrimEnd(',') + "";
                    query = query.TrimEnd(',');
                    cmd.CommandText = query;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    success = true;
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            return success;
        }
    }
}
