using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WPF.DashboardImpl.WCF.Implementation;

namespace WCF.DashboardService
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost serviceHost = new ServiceHost(typeof(WPF.DashboardImpl.WCF.Implementation.DashboardService)))
            {
                serviceHost.Open();
                Console.WriteLine("[" + DateTime.Now.ToString() + "] Host was started: " + nameof(WPF.DashboardImpl.WCF.Implementation.DashboardService));
                Console.ReadLine();
            }
        }
    }
}
