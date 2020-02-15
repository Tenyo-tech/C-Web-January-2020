using SIS.MvcFramework;
using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;

namespace IRunes
{
    class Program
    {
        static async Task Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            await WebHost.StartAsync(new Startup());
        }
    }
}