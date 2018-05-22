#define HandleStopStart // or ServiceOnly ServiceOrConsole
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.WindowsServices;

namespace AspNetCoreService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var pathToExe = Process.GetCurrentProcess().MainModule.FileName;
            var pathToContentRoot = Path.GetDirectoryName(pathToExe);

            var host = WebHost.CreateDefaultBuilder(args)
                .UseContentRoot(pathToContentRoot)
                .UseStartup<Startup>()
                .UseApplicationInsights()
                .UseKestrel( options => 
                {
                    options.Listen(System.Net.IPAddress.Parse("192.168.0.110"), 5000);
                })
                .Build();

            host.RunAsService();
        }
#if ServiceOrConsole
#region ServiceOrConsole
        public static void Main(string[] args)
        {
            bool isService = true;
            if (Debugger.IsAttached || args.Contains("--console"))
            {
                isService = false;
            }

            var pathToContentRoot = Directory.GetCurrentDirectory();
            if (isService)
            {
                var pathToExe = Process.GetCurrentProcess().MainModule.FileName;
                pathToContentRoot = Path.GetDirectoryName(pathToExe);
            }

            var host = WebHost.CreateDefaultBuilder(args)
                .UseContentRoot(pathToContentRoot)
                .UseStartup<Startup>()
                .UseApplicationInsights()
                .Build();

            if (isService)
            {
                host.RunAsService();
            }
            else
            {
                host.Run();
            }
        }
#endregion
#endif
#if HandleStopStart
#region HandleStopStart
        //public static void Main(string[] args)
        //{
        //    bool isService = true;
        //    if (Debugger.IsAttached || args.Contains("--console"))
        //    {
        //        isService = false;
        //    }

        //    var pathToContentRoot = Directory.GetCurrentDirectory();
        //    if (isService)
        //    {
        //        var pathToExe = Process.GetCurrentProcess().MainModule.FileName;
        //        pathToContentRoot = Path.GetDirectoryName(pathToExe);
        //    }

        //    var host = WebHost.CreateDefaultBuilder(args)
        //        .UseContentRoot(pathToContentRoot)
        //        .UseStartup<Startup>()
        //        .UseApplicationInsights()
        //        .Build();

        //    if (isService)
        //    {
        //        host.RunAsCustomService();
        //    }
        //    else
        //    {
        //        host.Run();
        //    }
        //}
#endregion
#endif
    }
}
