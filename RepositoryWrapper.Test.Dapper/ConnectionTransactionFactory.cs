using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using RepositoryWrapper.Dapper;

namespace RepositoryWrapper.Test.Dapper
{
    class ConnectionTransactionFactory : IConnectionFactory
    {
        private readonly IDbConnection _cnx;
        private readonly IDbTransaction _tsn;

        public ConnectionTransactionFactory()
        {
            _cnx = GetSqlConnection();
            _cnx.Open();
            _tsn = _cnx.BeginTransaction();
        }

        public IDbConnection GetConnection()
        {
            return _cnx;
        }

        public IDbTransaction GetTransaction()
        {
            return _tsn;
        }

        public SqlConnection GetSqlConnection()
        {
            string cnxStr = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            var cnx = new SqlConnection(cnxStr);
            return cnx;
        }
    }
}