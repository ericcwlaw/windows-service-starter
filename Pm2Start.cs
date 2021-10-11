using System.ServiceProcess;
using System.Diagnostics;

namespace pm2_starter
{
    public partial class Pm2Start : ServiceBase {

        private EventLog eventLog = new EventLog();

        public Pm2Start() {
            InitializeComponent();
            if (!EventLog.SourceExists("Pm2Starter")) {
                EventLog.CreateEventSource("Pm2Starter", "Pm2Log");
            }
            eventLog.Source = "Pm2Starter";
            eventLog.Log = "Pm2Log";
        }

        protected override void OnStart(string[] args) {
            try {
                Process.Start("pm2", "start d:/sandbox/simple-proxy/simple-proxy.js");
                eventLog.WriteEntry("Service started");
            } catch (System.Exception ex) {
                eventLog.WriteEntry("Unable to start - " + ex.Message);
            }
        }

        protected override void OnStop() {
            try {
                Process.Start("pm2", "stop simple-proxy");
                eventLog.WriteEntry("Service stopped");
            } catch (System.Exception ex) {
                eventLog.WriteEntry("Unable to stop - " + ex.Message);
            }
        }

    }
}
