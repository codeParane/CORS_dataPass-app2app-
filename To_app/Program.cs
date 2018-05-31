using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace dbCore
{
    
    public class Program
    {
        public static void Main(string[] args)
        {
            //timer 
            BuildWebHost(args).Run();
        
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                // to run in diff port
                .UseUrls("http://localhost:4200")
                .Build();
    }
}
