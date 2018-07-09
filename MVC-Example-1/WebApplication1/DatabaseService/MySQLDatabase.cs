using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;

namespace WebApplication1.DatabaseService
{
    public class MySQLDatabase
    {
        private string _connectionString = "Server=localhost;Database=sehirler;uid=root;password=1234";
        public DataTable GetDataFromDatabase(object obj)
        {
           try
            {
                using (var con = new MySqlConnection(_connectionString))
                {
                    string Query = "CALL " + obj.GetType().Name + " (";
                    IList<PropertyInfo> props = new List<PropertyInfo>(obj.GetType().GetProperties());
                    foreach (PropertyInfo item in props)
                    {
                        Query += item.GetValue(obj, null) + ",";
                    }
                    Query = Query.TrimEnd(',');
                    Query += ")";
                    using (var adapter = new MySqlDataAdapter(Query, con))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            adapter.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                throw;
            }
           
        }
    }
}