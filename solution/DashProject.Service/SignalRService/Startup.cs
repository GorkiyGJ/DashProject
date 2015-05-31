using System;
using System.Collections.Generic;
using Microsoft.AspNet.SignalR;
using Owin;

namespace DashProject.Service.SignalRService
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
	    {
            HubConfiguration conf = new HubConfiguration();
		    //for debug purpose
            conf.EnableDetailedErrors = true;	
            conf.EnableJavaScriptProxies = true;
            conf.EnableJSONP = true;
            app.MapSignalR("/sr", conf);
	    }
    }
}
