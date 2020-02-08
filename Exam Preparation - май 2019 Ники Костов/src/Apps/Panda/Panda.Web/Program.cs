using SIS.MvcFramework;

namespace Panda.Web
{
    public static class Program
    {
        public static void Main()
        {
            WebHost.Start(new Startup());
        }
    }
}
