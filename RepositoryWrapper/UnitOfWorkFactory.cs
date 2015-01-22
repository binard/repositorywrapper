using System;

namespace RepositoryWrapper
{
    public class UnitOfWorkFactory
    {
        public static Func<IUnitOfWork> GetDefault = NotIntializedFactory;

        private static IUnitOfWork NotIntializedFactory()
        {
            throw new ApplicationException("Factory for IUnitOfWork is not intialized");
        }
    }
}