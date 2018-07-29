using Microsoft.Win32;
using MYOB.PayrollSystem.DataService.Interfaces;
using MYOB.PayrollSystem.Model;
using MYOB.PayrollSystem.UIServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace MYOB.PayrollSystem.UI.ViewModel
{
    public class PayrollSystemHomePageViewModel : IPayrollsystemHomePageViewModel ,INotifyPropertyChanged
    {
        private IProcessor _processor;
        private ICalculationService _calculationService;
        private string _message;
        private List<Employee> _employeeList;
        public List<PaySlip> _paySlipList;
        public PayrollSystemHomePageViewModel(IProcessor processor, ICalculationService calculationService)
        {
            _processor = processor;
            _calculationService = calculationService;
            OpenFileCommand = new RelayCommand(OpenFile);
            EmployeeList = new List<Employee>();
        }

        public ICommand OpenFileCommand { get; set; }

        /// <summary>
        /// Output message that payslip genrated on desired location
        /// </summary>
         public string Message
        {
            private set
            {
                _message = value;
                OnPropertyChanged("Message");
            }
            get
            {
                return _message;
            }
        }

        /// <summary>
        /// Return List of employees after reading from CSV file
        /// </summary>
        public List<Employee> EmployeeList
        {
            set
            {
                _employeeList = value;
                OnPropertyChanged("EmployeeList");
            }
            get
            {
                return _employeeList;
            }
        }

        private void OpenFile(Object obj)
        {
            EmployeeList.Clear();
            OpenFileDialog dlgOpenFile = new OpenFileDialog();
            dlgOpenFile.Filter = "CSV files (input.csv)|input.csv";
            dlgOpenFile.FilterIndex = 1;
            dlgOpenFile.RestoreDirectory = true;
            ImprotData(dlgOpenFile);
        }

        /// <summary>
        /// Import the Data from File dialog
        /// </summary>
        private void ImprotData(OpenFileDialog dlgOpenFile)
        {
            if (dlgOpenFile.ShowDialog().HasValue)
            {
                var input = dlgOpenFile.FileNames.Select(f => f).First();
                EmployeeList = _processor.ReadCsv(input);
                var paySlipList = new List<PaySlip>();
                foreach (var employee in EmployeeList)
                {
                    var payslip = GeneartePayslip(employee);
                    if (payslip != null)
                    {
                        paySlipList.Add(payslip);
                    }
                }
                OnPropertyChanged("PaySlipList");
                var output = input.ToLower().Replace("input", "output");
                _processor.WriteCsv(paySlipList, output);
                Message = string.Format("Payslip has been generated on {0}", output);
            }
        }

        /// <summary>
        /// Process the PaySlip
        /// </summary>
        private PaySlip GeneartePayslip(Employee employee)
        {
            var payslip = new PaySlip { Employee = employee };
            payslip.GrossIncome = _calculationService.GrossIncome(employee.AnnualSalary);
            payslip.IncomeTax = _calculationService.IncomeTax(employee.AnnualSalary);
            payslip.NetIncome = _calculationService.NetIncome(payslip.GrossIncome, payslip.IncomeTax);
            payslip.Super = _calculationService.Super(payslip.GrossIncome, employee.SuperRate);
            return payslip;
        }

        #region INotifiyPropertyChanged Implimentation
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}

