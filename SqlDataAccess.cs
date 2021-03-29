using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Dapper;

namespace LoginDB
{
    public static class SqlDataAccess
    {

        public static string ConnectionString(string name="MyDB")
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }

        public static int CreateData<T>(string sql, T data)
        {
            using (IDbConnection con = new SqlConnection(ConnectionString()))
            {
                return con.Execute(sql, data);
            }
        }

        public static int SearchData<T>(string sql, T data)
        {
            using (IDbConnection con = new SqlConnection(ConnectionString()))
            {
                var rows = con.Query<T>(sql, data).ToList();
                int exist = rows.Count;
                return exist;
            }
        }
    }
}