namespace RepositoryWrapper.Test.Dapper
{
    public class User : IIdentifiable
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public string FirstName { get; set; }
    }
}