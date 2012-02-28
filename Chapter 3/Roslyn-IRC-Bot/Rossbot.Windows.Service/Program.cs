using System.Globalization;
using System.ServiceProcess;
using System.Threading;

namespace Rossbot.Windows.Service
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
			{ 
				new RoslynService() 
			};
            ServiceBase.Run(ServicesToRun);
        }
    }
}
