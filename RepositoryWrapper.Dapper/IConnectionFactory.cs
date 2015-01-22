using System.Data;

namespace RepositoryWrapper.Dapper
{
    public interface IConnectionFactory
    {
        IDbConnection GetConnection();
        IDbTransaction GetTransaction();
    }
}