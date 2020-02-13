using System;
using System.Globalization;
using System.Threading;
using SIS.MvcFramework;

namespace Musaca.Web
{
    public static class Program
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            WebHost.Start(new Startup());
        }
    }
}
