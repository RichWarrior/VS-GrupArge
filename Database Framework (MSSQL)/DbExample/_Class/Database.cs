using DbExample.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace DbExample._Class
{
    public class Database : IDatabase
    {
        #region Variables
        //string connectionString = "Data Source=LAPTOP;Initial Catalog=Sistem;User Id=sa;Password=123;Max Pool Size=32767;MultipleActiveResultSets=True;";
        public SqlConnection con = new SqlConnection("Data Source=LAPTOP;Initial Catalog=Sistem;User Id=sa;Password=123;Max Pool Size=32767;MultipleActiveResultSets=True;");
        private SqlCommand cmd;
        private SqlParameter parameter;

        
        #endregion

        public List<T> getData<T>()
        {
            T result = default(T);
            var x = typeof(T);
            string query = "SELECT * FROM " + x.Name;
            List<T> list = new List<T>();

            IList<PropertyInfo> properties = new List<PropertyInfo>(x.GetProperties());

            try
            {
                using (cmd = new SqlCommand())
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = query;
                    SqlDataReader reader;
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var y = (T)Activator.CreateInstance(typeof(T));
                        foreach (PropertyInfo item in properties)
                        {
                            Type type = reader[item.Name].GetType();
                            if (type == typeof(DBNull))
                            {
                                item.SetValue(y, null, null);
                            }
                            else
                            {
                                item.SetValue(y, reader[item.Name], null);
                            }
                        }
                        list.Add(y);
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return list;
        }


        public bool writeData(object data)
        {
            using (cmd = new SqlCommand())
            {
                string table_name = data.GetType().Name;
                IList<PropertyInfo> prop = new List<PropertyInfo>(data.GetType().GetProperties());
                string query = "INSERT INTO ";
                query = query + table_name + "(";
                string subQuery = "VALUES (";
                foreach (PropertyInfo item in prop)
                {

                    if (item.Name != "id")
                    {
                        query += item.Name.ToString() + ",";
                        subQuery += "@" + item.Name + ",";
                        parameter = cmd.Parameters.AddWithValue('@' + item.Name, item.GetValue(data, null));
                    }
                }
                query = query.TrimEnd(',');
                subQuery = subQuery.TrimEnd(',');
                query += ")";
                subQuery += ")";

                try
                {
                    con.Open();
                    query = query + subQuery;
                    cmd.CommandText = query;
                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
                finally
                {
                    if (con.State == System.Data.ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
            }
        }


        public void readData<T>()
        {
            T t = default(T);
            var x = typeof(T);
            foreach (var item in this.getData<T>())
            {
                IList<PropertyInfo> props = new List<PropertyInfo>(item.GetType().GetProperties());
                foreach (PropertyInfo subİtem in props)
                {
                    Console.WriteLine(subİtem.GetValue(item, null));
                }
            }
        }

        
    }
}
