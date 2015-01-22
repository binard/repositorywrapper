using System.Data;

namespace RepositoryWrapper.Dapper
{
    public abstract class RepositoryDapperBase
    {
        protected readonly IDbConnection DbConnection;
        protected readonly IDbTransaction DbTransaction;

        protected string TableName { get; private set; }

        protected RepositoryDapperBase(IConnectionFactory connectionFactory, string tableName)
        {
            DbConnection = connectionFactory.GetConnection();
            DbTransaction = connectionFactory.GetTransaction();
            TableName = tableName;
        }
    }
}