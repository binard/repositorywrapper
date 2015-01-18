using RepositoryWrapper.Dapper;

namespace RepositoryWrapper.Test.Dapper
{
    public class UserWriter : WriterRepositoryDapperBase<User>
    {
        public UserWriter(IConnectionFactory connectionFactory)
            : base(connectionFactory, "User")
        {
        }
    }
}