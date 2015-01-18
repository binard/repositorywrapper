using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RepositoryWrapper.Test.Dapper
{
    [TestClass]
    [DeploymentItem(@"Sql\init.sql")]
    public class WriterTest
    {
        private UserWriter _userWriter;
        private UserFinder _userFinder;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            InitDatas.Start();
        }

        public WriterTest()
        {
            _userWriter = new UserWriter(new ConnectionFactory());
            _userFinder = new UserFinder(new ConnectionFactory());
        }

        [TestMethod]
        public void Delete_ByItem()
        {
            User user = _userFinder.GetById(2);
            _userWriter.Delete(user);
            User deletedUser = _userFinder.GetById(2);
            Assert.IsNull(deletedUser);
        }

        [TestMethod]
        public void Add_NewValue()
        {
            var newUser = new User()
            {
                Email = "jean-pierre.claudie@gmail.com",
                Name = "Claudie",
                FirstName = "Jean-Pierre"
            };
            _userWriter.Add(newUser);

            User user = _userFinder.GetByEmail(newUser.Email);
            Assert.IsNotNull(user);
            Assert.IsTrue(user.Id > 0);
            Assert.AreEqual(user.Email, newUser.Email);
            Assert.AreEqual(user.Name, newUser.Name);
            Assert.AreEqual(user.FirstName, newUser.FirstName);
        }

        [TestMethod]
        public void Update_ExistedValue()
        {

            User user = _userFinder.GetById(1);
            user.FirstName = "Patrick";
            _userWriter.Update(user);

            User updatedUser = _userFinder.GetById(1);
            Assert.AreEqual(updatedUser.FirstName, "Patrick");            
        }
    }
}