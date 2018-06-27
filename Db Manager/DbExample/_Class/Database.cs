using DbExample.Interfaces;
using DbExample.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DbExample._Class
{
    public class Database : IDatabase
    {
        private SqlConnection con = new SqlConnection("Data Source=LAPTOP;Initial Catalog=Sistem;User Id=sa;Password=123");
        private SqlCommand cmd;
        private SqlParameter parameter;
        public void veriEkle(object data)
        {
            string table_name = data.GetType().Name;
            IList<PropertyInfo> prop = new List<PropertyInfo>(data.GetType().GetProperties());
            string query = "INSERT INTO ";
            query = query + table_name + "(";
            string subQuery = "VALUES (";
            cmd = new SqlCommand();
            foreach (PropertyInfo item in prop)
            {
                query += item.Name.ToString() + ",";
                subQuery += "@" + item.Name+ ",";
                parameter = cmd.Parameters.AddWithValue('@'+item.Name,item.GetValue(data,null));
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
                Console.Write("Başarılı");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }finally
            {
                if(con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }
    }
}
