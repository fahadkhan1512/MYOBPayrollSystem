using MYOB.PayrollSystem.DataService.Interfaces;
using MYOB.PayrollSystem.DataServices;
using MYOB.PayrollSystem.UI.ViewModel;
using MYOB.PayrollSystem.UIServices;
using System.Windows;
using Unity;

namespace MYOB.PayrollSystem.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
      
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            IUnityContainer container = new UnityContainer();

            //We register the objects in container and retrieve the objects from the container, 
            //so it is the container with which our client directly interacts.  
            container.RegisterType<IPayrollsystemHomePageViewModel, PayrollSystemHomePageViewModel>();
            container.RegisterType<IProcessor, Processor>();
            container.RegisterType<ICalculationService, CalculationService>();

            //Resolve() method will automatically inject the required dependencies.
            var window = container.Resolve<PayrollSystemHomePageView>();
            window.Show();
        }
    }
}

