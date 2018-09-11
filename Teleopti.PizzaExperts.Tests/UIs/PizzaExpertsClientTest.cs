using System;
using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Teleopti.PizzaExperts.Framework.Environment;

namespace Teleopti.PizzaExperts.Tests.UIs
{
    /// <summary>
    /// PizzaExpertsClient Unit Test
    /// </summary>
    [TestClass]
    public class PizzaExpertsClientTest: AbstractUnitTest
    {
        private readonly IPizzaExpertsHost _pizzaExpertsHost;

        public PizzaExpertsClientTest()
        {
            _pizzaExpertsHost = _scope.Resolve<IPizzaExpertsHost>();
        }

        /// <summary>
        /// Test ShowTips
        /// </summary>
        [TestMethod]
        public void TestShowTips()
        {
            bool isTrue = true;

            try
            {
                _pizzaExpertsHost.ShowTips("test");
            }
            catch
            {
                isTrue = false;
            }

            Assert.IsTrue(isTrue);
        }
    }
}
