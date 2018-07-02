using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Threading.Tasks;

namespace DbExample._Class
{
    public class Database 
    {
        #region Variables
        private static string connectionString = "Data Source=LAPTOP;Initial Catalog=Sistem;User Id=sa;Password=123";
        #endregion
        public List<T> getData<T>()
        {
            T result = default(T);
            var x = typeof(T);
            string query = "SELECT * FROM " + x.Name;
            List<T> list = new List<T>();

            IList<PropertyInfo> properties = new List<PropertyInfo>(x.GetProperties());
            var con = new SqlConnection(connectionString);
            try
            {
                SqlCommand cmd;
                using (cmd = new SqlCommand())
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = query;
                    SqlDataReader reader;
                    reader = (SqlDataReader)cmd.ExecuteReader();
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
                    con.Dispose();
                }
                GC.SuppressFinalize(this);
            }
            return list;
        }
        public bool writeData(object data)
        {
            var con = new SqlConnection(connectionString);
            var parameter = new SqlParameter();
            SqlCommand cmd;
            using (cmd = new SqlCommand())
            {
                string table_name = data.GetType().Name;
                IList<PropertyInfo> prop = new List<PropertyInfo>(data.GetType().GetProperties());
                string query = "INSERT INTO ";
                query = query + table_name + " (";
                string subQuery = "VALUES (";
                string identityon = "SET IDENTITY_INSERT " + con.Database + ". dbo." + table_name + " ON";
                //string identityoff = "SET IDENTITY INSERT " + con.Database + ". dbo." + table_name + " OFF";
                foreach (PropertyInfo item in prop)
                {
                    //Console.WriteLine(item.GetValue(data,null));
                    query += item.Name + ",";
                    subQuery += "@" + item.Name + ",";
                    parameter = cmd.Parameters.AddWithValue("@" + item.Name, item.GetValue(data, null));
                }
                query = query.TrimEnd(',');
                subQuery = subQuery.TrimEnd(',');
                query += ")";
                subQuery += ")";
                try
                {
                    con.Open();
                    query = query + subQuery;
                    cmd.Connection = con;
                    cmd.CommandText = identityon + " " + query;
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627)
                    {
                        Console.WriteLine("Primary Key Eşsiz Olmalıdır!");
                    }
                    else
                    {
                        Console.WriteLine(ex.Message);
                    }
                    return false;
                }
                finally
                {
                    if (con.State == System.Data.ConnectionState.Open)
                    {
                        con.Close();
                        con.Dispose();
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
        public async Task<bool> writeDataAsync(object data)
        {
            var con = new SqlConnection(connectionString);
            var parameter = new SqlParameter();
            SqlCommand cmd;
            using (cmd = new SqlCommand())
            {
                string table_name = data.GetType().Name;
                IList<PropertyInfo> prop = new List<PropertyInfo>(data.GetType().GetProperties());
                string query = "INSERT INTO ";
                query = query + table_name + " (";
                string subQuery = "VALUES (";
                string identityon = "SET IDENTITY_INSERT " + con.Database + ". dbo." + table_name + " ON";
                //string identityoff = "SET IDENTITY INSERT " + con.Database + ". dbo." + table_name + " OFF";
                foreach (PropertyInfo item in prop)
                {
                    //Console.WriteLine(item.GetValue(data,null));
                    query += item.Name + ",";
                    subQuery += "@" + item.Name + ",";
                    parameter = cmd.Parameters.AddWithValue("@" + item.Name, item.GetValue(data, null));
                }
                query = query.TrimEnd(',');
                subQuery = subQuery.TrimEnd(',');
                query += ")";
                subQuery += ")";
                try
                {
                    await con.OpenAsync();
                    query = query + subQuery;
                    cmd.Connection = con;
                    cmd.CommandText = identityon + " " + query;
                    await cmd.ExecuteNonQueryAsync();
                    return true;
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627)
                    {
                        Console.WriteLine("Primary Key Eşsiz Olmalıdır!");
                    }
                    else
                    {
                        Console.WriteLine(ex.Message);
                    }
                    return false;
                }
                finally
                {
                    if (con.State == System.Data.ConnectionState.Open)
                    {
                        con.Close();
                        con.Dispose();
                    }
                    GC.SuppressFinalize(this);
                }
            }
        }
        public async Task<List<T>> getDataAsync<T>()
        {
            T result = default(T);
            var x = typeof(T);
            string query = "SELECT * FROM " + x.Name;
            List<T> list = new List<T>();

            IList<PropertyInfo> properties = new List<PropertyInfo>(x.GetProperties());
            var con = new SqlConnection(connectionString);
            try
            {
                SqlCommand cmd;
                using (cmd = new SqlCommand())
                {
                    await con.OpenAsync();
                    cmd.Connection = con;
                    cmd.CommandText = query;
                    SqlDataReader reader;
                    reader = (SqlDataReader)await cmd.ExecuteReaderAsync();
                    while (await reader.ReadAsync())
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
                    con.Dispose();
                }
                GC.SuppressFinalize(this);
            }
            return list;
        }
        public void readDataAsync<T>()
        {
            T t = default(T);
            var x = typeof(T);
            Task<List<T>> task1 = Task.Run(() => this.getDataAsync<T>());
            Task.WaitAll(task1);
            foreach (var item in task1.Result)
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
