using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using RepositoryWrapper.Dapper;

namespace RepositoryWrapper.Test.Dapper
{
    class ConnectionFactory : IConnectionFactory
    {
        public IDbConnection GetConnection()
        {
            return GetSqlConnection();

        }

        public SqlConnection GetSqlConnection()
        {
            string cnxStr = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            var cnx = new SqlConnection(cnxStr);
            return cnx;
        }
    }
}