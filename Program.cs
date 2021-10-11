
using System.ServiceProcess;

namespace pm2_starter
{
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main() {
            ServiceBase[] ServicesToRun = new ServiceBase[] {
                new Pm2Start()
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
