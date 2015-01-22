using System;
using System.Data;
using Dapper;

namespace RepositoryWrapper.Dapper
{
    public abstract class WriterRepositoryDapperBase<T> : RepositoryDapperBase, IWriteRepository<T> where T : class, IIdentifiable
    {
        protected WriterRepositoryDapperBase(IConnectionFactory connectionFactory, string tableName)
            : base(connectionFactory, tableName)
        {
        }

        public void Add(T item)
        {
             DbConnection.Insert<T>(TableName, item, DbTransaction);
        }

        public void Update(T item)
        {
            DbConnection.Update<T>(TableName, item, DbTransaction);
        }

        public void Delete(T item)
        {
            if (item != null)
            {
                string query = String.Format("DELETE FROM [{0}] Where Id = @id", TableName);
                DbConnection.Query(query, item, DbTransaction);
            }
        }

        public void Delete(int id)
        {
            string query = String.Format("DELETE FROM [{0}] Where Id = @id", TableName);
            DbConnection.Query(query, new { id }, DbTransaction);
        }
    }
}