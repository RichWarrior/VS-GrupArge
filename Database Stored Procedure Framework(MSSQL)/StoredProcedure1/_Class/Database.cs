using StoredProcedure1.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace StoredProcedure1._Class
{
    public class Database : IDatabase
    {
        #region Database
        private SqlConnection con = new SqlConnection("Data Source=LAPTOP;Initial Catalog=StoredProcedure1;User Id=sa;Password=123");
        private SqlCommand cmd;
        private SqlDataAdapter adapter;
        private SqlParameter param;
        private DataTable dt;
        #endregion
        public void getData(object obj)
        {
            var data = obj.GetType();
            string query = "EXEC " + data.Name + " ";
            string subQuery = "";
            using (cmd = new SqlCommand())
            {
                cmd.Connection = con;
                IList<PropertyInfo> props = new List<PropertyInfo>(obj.GetType().GetProperties());
                foreach (PropertyInfo item in props)
                {
                    subQuery += item.GetValue(obj, null)+",";
                }
                try
                {
                    query = query.TrimEnd(',');
                    query = query.TrimEnd(' ');
                    string[] str = query.Split('_');
                    subQuery = subQuery.TrimEnd(',');
                    query += " "+subQuery;
                    if (str[2].ToString()=="SELECT")
                    {
                        adapter = new SqlDataAdapter(query,con);
                        dt = new DataTable();
                        adapter.Fill(dt);
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            for (int k = 0; k < dt.Columns.Count; k++)
                            {
                                Console.Write(" "+dt.Rows[i].ItemArray[k]+"\n");
                            }
                        }
                    }
                    else
                    {
                        con.Open();
                        cmd.CommandText = query;
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("Başarılı");
                    }
                   
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
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
    }
}
