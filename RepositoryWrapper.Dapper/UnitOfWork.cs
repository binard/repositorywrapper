using System;
using System.Data;

namespace RepositoryWrapper.Dapper
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbConnection _dbConnection;
        private readonly IDbTransaction _transaction;

        public UnitOfWork(IConnectionFactory connectionFactory)
        {
            _dbConnection = connectionFactory.GetConnection();
            _transaction = connectionFactory.GetTransaction();
        }

        public void Begin()
        {
            if(_transaction == null)
                throw new InvalidOperationException("Begin method cannot call if transaction is null");
        }

        public void Commit()
        {
            _transaction.Commit();
        }

        public void Rollback()
        {
            _transaction.Rollback();
        }

        public void Dispose()
        {
            Rollback();
            _dbConnection.Close();
        }
    }
}