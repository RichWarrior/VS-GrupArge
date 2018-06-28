using DbExample.Interfaces;
using DbExample.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DbExample._Class
{
    public class Database : IDatabase
    {
        #region Variables
        private SqlConnection con = new SqlConnection("Data Source=LAPTOP;Initial Catalog=Sistem;User Id=sa;Password=123");
        private SqlCommand cmd;
        private SqlParameter parameter;
        private SqlDataReader reader=null;
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
                con.Open();
                cmd = new SqlCommand(query, con);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var y = (T)Activator.CreateInstance(typeof(T));
                    foreach (PropertyInfo item in properties)
                    {
                        item.SetValue(y, reader[item.Name] , null);
                    }
                    list.Add(y);
                }
                reader.Close();
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

        public async Task<List<T>> getDataAsync<T>()
        {
            T result = default(T);
            var x = typeof(T);
            string query = "SELECT * FROM " + x.Name;
            List<T> myList = new List<T>();
            IList<PropertyInfo> props = new List<PropertyInfo>(x.GetProperties());
            try
            {
                await con.OpenAsync();
                cmd = new SqlCommand(query,con);
                reader = await cmd.ExecuteReaderAsync();
                while (reader.Read())
                {
                    var y = (T)Activator.CreateInstance(typeof(T));
                    foreach (PropertyInfo item in props)
                    {
                        item.SetValue(y, reader[item.Name], null);
                    }
                    myList.Add(y);
                }
                return myList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return myList;
            }
            finally
            {
                if(con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }


        }

        public bool writeData(object data)
        {
            string table_name = data.GetType().Name;
            IList<PropertyInfo> prop = new List<PropertyInfo>(data.GetType().GetProperties());
            string query = "INSERT INTO ";
            query = query + table_name + "(";
            string subQuery = "VALUES (";
            cmd = new SqlCommand();
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

        public async Task<Boolean> writeDataAsync(object data)
        {
            string tableName = data.GetType().Name;
            string query = "INSERT INTO ";
            string subQuery = " VALUES (";
            query += tableName + " (";
            IList<PropertyInfo> props = new List<PropertyInfo>(data.GetType().GetProperties());
            cmd = new SqlCommand();
            foreach (PropertyInfo item in props)
            {
                if(item.Name!="id")
                {
                    query += item.Name + ",";
                    subQuery += "@"+item.Name+" ,";
                    parameter = cmd.Parameters.AddWithValue("@" + item.Name, item.GetValue(data, null));
                }
            }
            query = query.TrimEnd(',');
            query += ")";
            subQuery = subQuery.TrimEnd(',');
            subQuery += ")";
            query += subQuery;
            try
            {
                await con.OpenAsync();
                cmd.CommandText = query;
                cmd.Connection = con;
                await cmd.ExecuteNonQueryAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }finally
            {
                if(con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }

        }
    }
}
