using System;
using System.Runtime.Remoting.Messaging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RepositoryWrapper.Dapper;

namespace RepositoryWrapper.Test.Dapper
{
    [TestClass]
    [DeploymentItem(@"Sql\init.sql")]
    public class UnitOfWorkTest
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserWriter _userWriter;
        private readonly UserFinder _userFinder;
        private readonly IConnectionFactory _cnxFactory;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            InitDatas.Start();
        }

        public UnitOfWorkTest()
        {
            _cnxFactory = new ConnectionTransactionFactory();
            _unitOfWork = new UnitOfWork(_cnxFactory);
            UnitOfWorkFactory.GetDefault = () => _unitOfWork;
            _userWriter = new UserWriter(_cnxFactory);
            _userFinder = new UserFinder(_cnxFactory);
        }

        [TestMethod]
        public void Rollback_Insert()
        {
            UnitOfWorkFactory.GetDefault().Begin();
            _userWriter.Add(new User(){Email = "jose@test.fr", FirstName = "José", Name = "Marcel"});
            UnitOfWorkFactory.GetDefault().Rollback();
            User user = _userFinder.GetByEmail("jose@test.fr");
            Assert.IsNull(user);
        }

        [TestMethod]
        public void Commit_Insert()
        {
            UnitOfWorkFactory.GetDefault().Begin();
            _userWriter.Add(new User() { Email = "claudie@test.fr", FirstName = "Claudie", Name = "Dubois" });
            UnitOfWorkFactory.GetDefault().Commit();
            User user = _userFinder.GetByEmail("claudie@test.fr");
            Assert.IsNotNull(user);
            Assert.AreEqual(user.Email, "claudie@test.fr");
            Assert.AreEqual(user.Name, "Dubois");
            Assert.AreEqual(user.FirstName, "Claudie");
        }

        [TestMethod]
        public void Rollback_Insert_Fail()
        {
            UnitOfWorkFactory.GetDefault().Begin();
            try
            {
                _userWriter.Add(new User() { Email = "test51@test.fr", FirstName = "Marc", Name = "Furo" });
                _userWriter.Add(new User() {Email = "test@test.fr", FirstName = "Marc", Name = "Furo"});
                UnitOfWorkFactory.GetDefault().Commit();
            }
            catch
            {
                UnitOfWorkFactory.GetDefault().Rollback();
            }
            User user = _userFinder.GetByEmail("test51@test.fr");
            Assert.IsNull(user);
        }
    }
}