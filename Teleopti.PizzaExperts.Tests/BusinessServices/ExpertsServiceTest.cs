using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Teleopti.PizzaExperts.Experts.Services;
using System.Linq;
using Autofac;

namespace Teleopti.PizzaExperts.Tests.BusinessServices
{
    /// <summary>
    /// ExpertsService Unit Test
    /// </summary>
    [TestClass]
    public class ExpertsServiceTest : AbstractUnitTest
    {
        private readonly IExpertsService _expertsService;

        public ExpertsServiceTest() : base()
        {
            _expertsService = _scope.Resolve<IExpertsService>();
        }

        /// <summary>
        /// Test Exist Experts
        /// </summary>
        [TestMethod]
        public void TestExistExperts()
        {
            var experts = _expertsService.GetAllExperts();

            Assert.IsNotNull(experts);
            Assert.IsTrue(experts.Count() > 0);
        }
    }
}
