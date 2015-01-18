namespace RepositoryWrapper
{
    public interface IFinderRepository<out T> where T : class, IIdentifiable
    {
        T GetById(int id);
    }
}