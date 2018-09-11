using System;
using System.Linq;
using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Teleopti.PizzaExperts.Repositories.Repositories;

namespace Teleopti.PizzaExperts.Tests.Repositories
{
    /// <summary>
    /// ExpertRepository Unit Test
    /// </summary>
    [TestClass]
    public class ExpertRepositoryTest : AbstractUnitTest
    {
        private readonly IExpertRepository _repository;

        public ExpertRepositoryTest() : base()
        {
            _repository = _scope.Resolve<IExpertRepository>();
        }

        /// <summary>
        /// Test Exist Experts
        /// </summary>
        [TestMethod]
        public void TestExistExperts()
        {
            var experts = _repository.Table;

            Assert.IsNotNull(experts);
            Assert.IsTrue(experts.Count() > 0);
        }
    }
}
