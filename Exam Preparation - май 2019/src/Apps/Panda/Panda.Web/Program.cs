using System;
using SIS.MvcFramework;

namespace Panda.Web
{
    public class Program
    {
        public static void Main()
        {
            WebHost.Start(new StartUp());
        }
    }
}
