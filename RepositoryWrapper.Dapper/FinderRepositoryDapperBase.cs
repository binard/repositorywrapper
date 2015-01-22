using System;
using System.Linq;
using Dapper;

namespace RepositoryWrapper.Dapper
{
    public abstract class FinderRepositoryDapperBase<T> : RepositoryDapperBase, IFinderRepository<T> where T : class, IIdentifiable
    {
        protected FinderRepositoryDapperBase(IConnectionFactory connectionFactory, string tableName)
            : base(connectionFactory, tableName)
        {
        }

        public T GetById(int id)
        {
            string query = String.Format("SELECT * FROM [{0}] WHERE Id = @id", TableName);
            return DbConnection.Query<T>(query, new { id }, DbTransaction).FirstOrDefault();
        }
    }
}