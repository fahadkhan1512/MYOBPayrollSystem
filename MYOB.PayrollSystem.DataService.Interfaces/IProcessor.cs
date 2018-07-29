using MYOB.PayrollSystem.Model;
using System.Collections.Generic;

namespace MYOB.PayrollSystem.DataService.Interfaces
{
    public interface IProcessor
    {
        /// <summary>
        /// Read the list of Employees Details from the given filename
        /// </summary>
        /// <returns></returns>
        List<Employee> ReadCsv(string filename);

        /// <summary>
        /// Write the list of Employee Payslips into the given filename
        /// </summary>
        void WriteCsv(List<PaySlip> payslips, string filename);
    }
}
