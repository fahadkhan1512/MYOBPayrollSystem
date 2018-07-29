using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MYOB.PayrollSystem.UI.ViewModel
{
    public interface IPayrollsystemHomePageViewModel
    {
        ICommand OpenFileCommand { get; set; }
    }
}
