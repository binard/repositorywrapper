using System;
using System.Data;

namespace RepositoryWrapper.Dapper
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbConnection _dbConnection;

        public UnitOfWork(IConnectionFactory connectionFactory)
        {
            _dbConnection = connectionFactory.GetConnection();
        }

        public void Begin()
        {
            throw new NotImplementedException();
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public void Rollback()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
