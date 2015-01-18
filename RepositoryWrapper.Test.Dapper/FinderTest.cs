using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RepositoryWrapper.Test.Dapper
{
    [TestClass]
    [DeploymentItem(@"Sql\init.sql")]
    public class FinderTest
    {
        private readonly UserFinder _userFinder;

        public FinderTest()
        {
            _userFinder = new UserFinder(new ConnectionFactory());   
        }

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            InitDatas.Start();
        }

        [TestMethod]
        public void GetById_Id1_EmailOK()
        {
            User user = _userFinder.GetById(1);
            Assert.AreEqual(user.Id, 1);
            Assert.AreEqual(user.Email, "test@test.fr");
            Assert.AreEqual(user.Name, "Robert");
            Assert.AreEqual(user.FirstName, "Firmin");
        }

        [TestMethod]
        public void GetById_Id8457_RetourneNull()
        {
            User user = _userFinder.GetById(8457);
            Assert.IsNull(user);
        }

        [TestMethod]
        public void GetByEmail_ValidEmail()
        {
            User user = _userFinder.GetByEmail("test@test.fr");
            Assert.AreEqual(user.Id, 1);
            Assert.AreEqual(user.Email, "test@test.fr");
            Assert.AreEqual(user.Name, "Robert");
            Assert.AreEqual(user.FirstName, "Firmin");
        }
    }
}
