using System;

namespace RepositoryWrapper
{
    public interface IUnitOfWork : IDisposable
    {
        void Begin();
        void Commit();
        void Rollback();
    }
}