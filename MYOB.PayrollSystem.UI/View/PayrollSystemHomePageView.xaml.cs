using MYOB.PayrollSystem.UI.ViewModel;
using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace MYOB.PayrollSystem.UI
{
    /// <summary>
    /// Interaction logic for PayrollSystemHomePage.xaml
    /// </summary>
    public partial class PayrollSystemHomePageView : Window
    {
        public PayrollSystemHomePageView(IPayrollsystemHomePageViewModel payrollSystemHomePageViewModel)
        {
            InitializeComponent();
            this.DataContext = payrollSystemHomePageViewModel;
        }
       
    }

   
}
