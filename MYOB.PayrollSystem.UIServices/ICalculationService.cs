using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYOB.PayrollSystem.UIServices
{
    public interface ICalculationService
    {
        /// <summary>
        /// Calculate the Monthly Gross Income
        /// </summary>
        /// <param name="annualSalary">Annual Salary</param>
       decimal GrossIncome(decimal annualSalary);

        /// <summary>
        /// Calculate the Monthly Income Tax (based on the ATO rates for 2012-13 financial year)
        /// </summary>
        /// <param name="taxableIncome">Taxable Income</param>
        decimal IncomeTax(decimal taxableIncome);

        /// <summary>
        /// Calculate the Monthly Net Income
        /// </summary>
        /// <param name="grossIncome">Monthly Gross Income</param>
        /// <param name="incomeTax">Monthly Income Tax</param>
       decimal NetIncome(decimal grossIncome, decimal incomeTax);

        /// <summary>
        /// Calculate the Monthly Superannuation Contribution
        /// </summary>
        /// <param name="grossIncome">Monthly Gross Income</param>
        /// <param name="superRate">Superannuation Rate</param>
        decimal Super(decimal grossIncome, float superRate);

    }
}
