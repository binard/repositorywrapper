using System.Data.SqlClient;
using System.IO;

namespace RepositoryWrapper.Test.Dapper
{
    class InitDatas
    {
        public static void Start()
        {
            using (SqlConnection cnx = new ConnectionFactory().GetSqlConnection())
            {
               cnx.Open();
               var cmd = new SqlCommand(File.ReadAllText("init.sql"));
                cmd.Connection = cnx;
                cmd.ExecuteNonQuery();
            }
        }
    }
}