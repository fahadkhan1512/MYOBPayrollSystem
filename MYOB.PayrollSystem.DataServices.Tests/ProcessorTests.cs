using Microsoft.VisualStudio.TestTools.UnitTesting;
using MYOB.PayrollSystem.Model;

namespace Myob.PayrollSystem.DataServices.Tests
{
    [TestClass()]
    public class ProcessorTests
    {
        private PaySlip payslip;

        [TestMethod()]
        public void ToCsv()
        {
            Assert.AreEqual(payslip.ToCsv(), "David Rudd,01 March - 31 March,5004,922,4082,450");
        }
    }
}