namespace RepositoryWrapper
{
    public interface IWriteRepository<in T> where T : class, IIdentifiable
    {
        void Add(T item);
        void Update(T item);
        void Delete(T item);
        void Delete(int id);
    }
}