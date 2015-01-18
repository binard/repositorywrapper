namespace RepositoryWrapper
{
    public interface IUnitOfWork
    {
        void Begin();
        void Commit();
        void Rollback();
        void Dispose();
    }
}