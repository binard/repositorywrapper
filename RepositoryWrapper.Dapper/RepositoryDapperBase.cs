using System.Data;

namespace RepositoryWrapper.Dapper
{
    public abstract class RepositoryDapperBase
    {
        protected readonly IDbConnection DbConnection;

        protected string TableName { get; private set; }

        protected RepositoryDapperBase(IConnectionFactory connectionFactory, string tableName)
        {
            DbConnection = connectionFactory.GetConnection();
            TableName = tableName;
        }
    }
}