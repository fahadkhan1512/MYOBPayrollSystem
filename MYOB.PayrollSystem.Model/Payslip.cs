

namespace MYOB.PayrollSystem.Model
{
    /// <summary>
    /// Employee Monthly Payslip
    /// </summary>
    public class PaySlip
    {
        /// <summary>
        /// Employee Details
        /// </summary>
        public Employee Employee { get; set; }
        /// <summary>
        /// Employee Gross Income
        /// </summary>
        public decimal GrossIncome { get; set; }
        /// <summary>
        /// Employee Income Tax
        /// </summary>
        public decimal IncomeTax { get; set; }
        /// <summary>
        /// Employee Net Income
        /// </summary>
        public decimal NetIncome { get; set; }
        /// <summary>
        /// Employee Superannuation Contribution
        /// </summary>
        public decimal Super { get; set; }

        /// <summary>
        /// Returns the Payslip in CVS format
        /// </summary>
        public string ToCsv() => $"{Employee.Name.ToString()},{Employee.PaymentPeriod},{GrossIncome},{IncomeTax},{NetIncome},{Super}";
    }
}