using System;
using System.Collections.Generic;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using DashProject.Api;
using DashProject.Service;
using DashProject.Service.SignalRService;
using DashProject.Utils;
using Microsoft.Owin.Hosting;

namespace DashProject.Service
{
    public class Service : ServiceBase
    {
        private IDisposable signalRService;

        public Service()
        {
            this.ServiceName = CoreApi.ApplicationConfiguration.ServiceFullName;
        }

        protected override void OnStart(string[] args)
        {
            Thread.Sleep(7000);
            InitializeFactory();
            InitializeSignalRService();
        }

        private void InitializeFactory()
        {
            Factory.Production.GetProduction().Start();
        }

        private void InitializeSignalRService()
        {
            this.signalRService = WebApp.Start<Startup>(CoreApi.ApplicationConfiguration.ServiceDomainUrl);
        }

        protected override void OnStop()
        {
            Factory.Production.GetProduction().Stop();

            if (signalRService != null)
            {
                signalRService.Dispose();
                signalRService = null;
            }
            this.Dispose(true);
        }

        public new string ToString()
        {
            return this.ServiceName + " " + base.ToString();
        }

        protected new void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
