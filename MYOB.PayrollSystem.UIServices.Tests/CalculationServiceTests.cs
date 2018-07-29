using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MYOB.PayrollSystem.UIServices.Tests
{
    [TestClass()]
    public class CalculateTests
    {
        [TestMethod()]
        public void GrossIncomeTest()
        {
            Assert.AreEqual(new CalculationService().GrossIncome(60050), 5004);
        }

        [TestMethod()]
        public void IncomeTaxTest()
        {
            Assert.AreEqual(new CalculationService().IncomeTax(60050), 922);
        }

        [TestMethod()]
        public void NetIncomeTest()
        {
            Assert.AreEqual(new CalculationService().NetIncome(5004, 922), 4082);
        }

        [TestMethod()]
        public void SuperTest()
        {
            Assert.AreEqual(new CalculationService().Super(5004, 0.09f), 450);
        }
    }
}