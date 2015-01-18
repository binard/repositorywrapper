using System.Linq;
using Dapper;
using RepositoryWrapper.Dapper;

namespace RepositoryWrapper.Test.Dapper
{
    public class UserFinder : FinderRepositoryDapperBase<User>
    {
        public UserFinder(IConnectionFactory connectionFactory)
            : base(connectionFactory, "User")
        {

        }

        public User GetByEmail(string email)
        {
            string query = "Select * FROM [User] Where Email = @email";
            return DbConnection.Query<User>(query, new { email }).SingleOrDefault();
        }
    }
}
