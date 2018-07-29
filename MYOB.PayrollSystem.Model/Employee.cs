namespace MYOB.PayrollSystem.Model
{
    /// <summary>
    /// Employee Details
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// Employee Name
        /// </summary>
        public Name Name { get; set; }
        /// <summary>
        /// Employee Annual Salary
        /// </summary>
        public decimal AnnualSalary { get; set; }
        /// <summary>
        /// Employee Super Rate
        /// </summary>
        public float SuperRate { get; set; }
        /// <summary>
        /// Payment Period
        /// </summary>
        public string PaymentPeriod { get; set; }
    }
}